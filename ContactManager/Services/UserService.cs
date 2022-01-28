using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using ContactManager.Authorization;
using ContactManager.Entities;
using ContactManager.Helpers;
using ContactManager.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        List<string> GetUserWithRolesByUserId(int id);
        void Register(RegisterRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(
            DataContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.User.SingleOrDefault(x => x.Username == model.Username);

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.Password))
                throw new AppException("Username or password is incorrect");
            
            var userRoles = _context.UserRole.Include(userRole => userRole.Role).Where(userRole => userRole.UserId == user.Id).ToList();
            
            List<string> roles = new List<string>();
            foreach (var userRole in userRoles)
            {
                roles.Add(userRole.Role.Name);
            }
            
            // authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user, roles);
            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public void Register(RegisterRequest model)
        {
            // validate
            if (_context.User.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");
            
            // Validate Email Address
            if (!HelperMethods.ValidateEmail(model.Email))
            {
                throw new AppException("The Email field is not a valid e-mail address");
            }
            
            // validate
            if (_context.User.Any(x => x.Email == model.Email))
                throw new AppException("Email '" + model.Email + "' is already taken");
            
            // validate UserRole exists
            var role = _context.Role.SingleOrDefault(x => x.Name == "Client");
            if (role == null)
                throw new Exception("Unexpected error");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // save user
            _context.User.Add(user);
            _context.SaveChanges();
            
            // save userRole
            _context.UserRole.Add(new UserRole(){RoleId = role.Id, UserId = user.Id});
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var user = getUser(id);

            // validate
            if (model.Username != user.Username && _context.User.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");
            
            // Validate Email Address
            if (!HelperMethods.ValidateEmail(model.Email))
            {
                throw new AppException("The Email field is not a valid e-mail address");
            }
            
            // validate
            if (model.Email != user.Email && _context.User.Any(x => x.Email == model.Email))
                throw new AppException("Email '" + model.Email + "' is already taken");

            // copy model to user and save
            _mapper.Map(model, user);
            _context.User.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.User.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private User getUser(int id)
        {
            var user = _context.User.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
        
        public List<string> GetUserWithRolesByUserId(int id)
        {
            var userRoles = _context.UserRole.Include(userRole => userRole.Role).Where(userRole => userRole.UserId == id).ToList();
            List<string> roles = new List<string>();
            foreach (var userRole in userRoles)
            {
                roles.Add(userRole.Role.Name);
            }
            return roles;
        }
    }
}