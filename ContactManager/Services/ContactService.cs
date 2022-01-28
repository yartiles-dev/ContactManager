using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using ContactManager.Authorization;
using ContactManager.Entities;
using ContactManager.Helpers;
using ContactManager.Models.Contacts;

namespace ContactManager.Services
{
    public interface IContactService
    {
        IEnumerable<GetRequest> GetAll();
        GetRequest GetById(int id);
        GetRequest Create(CreateRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }

    public class ContactService : IContactService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public ContactService(
            DataContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public IEnumerable<GetRequest> GetAll()
        {
            List<GetRequest> contactNews = new List<GetRequest>();
            var contacts = _context.Contact.ToList();
            foreach (var contact in contacts)
            {
                var contactNew = _mapper.Map<GetRequest>(contact);
                contactNew.Age = CalculateAge(contactNew.DateOfBirth);
                contactNews.Add(contactNew);
            }
            return contactNews.AsEnumerable();
        }

        public GetRequest GetById(int id)
        {
            var contact = _mapper.Map<GetRequest>(getContact(id));
            contact.Age = CalculateAge(contact.DateOfBirth);
            return contact;
        }

        public GetRequest Create(CreateRequest model)
        {
            // validate
            if (_context.Contact.Any(x => x.Email == model.Email))
                throw new AppException("Email '" + model.Email + "' is already taken");
            
            // validate User exists
            if (!_context.User.Any(x => x.Id == model.OwnerId))
                throw new AppException("OwnerId does not match any User");
            
            // Validate contact age
            if (CalculateAge(model.DateOfBirth) < 18)
            {
                throw new AppException("The Contact must be 18 years or older");
            }
            
            // Validate Email Address
            if (!HelperMethods.ValidateEmail(model.Email))
            {
                throw new AppException("The Email field is not a valid e-mail address");
            }

            // map model to new user object
            var contact = _mapper.Map<Contact>(model);

            // save user
            _context.Contact.Add(contact);
            _context.SaveChanges();

            var contactResponse = _mapper.Map<GetRequest>(contact);
            contactResponse.Age = CalculateAge(contactResponse.DateOfBirth);
            
            return contactResponse;
        }

        public void Update(int id, UpdateRequest model)
        {
            var contact = getContact(id);

            // validate
            if (model.Email != contact.Email && _context.Contact.Any(x => x.Email == model.Email))
                throw new AppException("Email '" + model.Email + "' is already taken");
            
            // validate User exists
            if (!_context.User.Any(x => x.Id == model.OwnerId))
                throw new AppException("OwnerId does not match any User");
            
            // Validate Email Address
            if (!HelperMethods.ValidateEmail(model.Email))
            {
                throw new AppException("The Email field is not a valid e-mail address");
            }

            // copy model to contact and save
            _mapper.Map(model, contact);
            _context.Contact.Update(contact);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = getContact(id);
            _context.Contact.Remove(contact);
            _context.SaveChanges();
        }

        // helper methods

        private Contact getContact(int id)
        {
            var contact = _context.Contact.Find(id);
            if (contact == null) throw new KeyNotFoundException("Contact not found");
            return contact;
        }
        
        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime now = DateTime.Today;
            int edad = now.Year - dateOfBirth.Year;
            if (now < dateOfBirth.AddYears(edad)) 
                edad--;
            return edad;
        }
    }
}