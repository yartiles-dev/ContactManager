using AutoMapper;
using ContactManager.Entities;
using ContactManager.Models.Contacts;
using ContactManager.Models.Users;
using UpdateRequest = ContactManager.Models.Users.UpdateRequest;
using UpdateRequestContact = ContactManager.Models.Contacts.UpdateRequest;

namespace ContactManager.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Contact -> GetRequest
            CreateMap<Contact, GetRequest>();
            
            // Contact -> CreateRequest
            CreateMap<CreateRequest, Contact>();
            
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<RegisterRequest, User>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
            
            // UpdateRequest -> Contact
            CreateMap<UpdateRequestContact, Contact>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
        }
    }
}