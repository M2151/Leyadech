using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leyadech.Service
{
    public class UserService
    {
        public bool IsvalidEmail(string? email)
        {
            if (email == null) return true;
            string trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        public bool IsValidPhone(string? phone)
        {
            if (phone == null) return true;
            string trimmedPhone = phone.Trim();
            string pattern = @"^0(5\d{8}|7\d{8}|8\d{7})$";
            return Regex.IsMatch(trimmedPhone, pattern);

        }
    }
}
