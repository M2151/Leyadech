namespace leyadech.server.Service
{
    public class UserService
    {
        public bool IsvalidEmail(string email)
        {
            if (email == null)
                return false;
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
        public bool IsValidPhone(string phone)
        {
            if (phone == null) return true;
            string trimmedPhone = phone.Trim();
            foreach (char digit in trimmedPhone)
                if (!char.IsDigit(digit)) return false;
            if (trimmedPhone[0] != '0') return false;
            switch (trimmedPhone[1])
            {
                case '5': return trimmedPhone.Length == 10;
                case '7': return trimmedPhone.Length == 10;
                case '8': return trimmedPhone.Length == 9;
                default: return false;
            }

        }
    }
}
