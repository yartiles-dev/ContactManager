using System.ComponentModel.DataAnnotations;

namespace ContactManager.Helpers
{
    public static class HelperMethods
    {
        public static bool ValidateEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}