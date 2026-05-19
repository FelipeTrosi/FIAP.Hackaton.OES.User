using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FIAP.Hackathon.OES.User.Service.Util
{
    public static class ValidatorService
    {
        public static bool IsValidEmail(string email) 
            => new EmailAddressAttribute().IsValid(email);

        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            bool hasLetter = false, hasDigit = false, hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsLetter(c)) hasLetter = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (!char.IsLetterOrDigit(c)) hasSpecial = true;

                if (hasLetter && hasDigit && hasSpecial)
                    return true;
            }

            return false;
        }

        public static bool IsValidCpf(string? cpf)
        {
            cpf = Regex.Replace(cpf, @"\D", "");

            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            if (!ValidateDigit(cpf, 9))
                return false;

            if (!ValidateDigit(cpf, 10))
                return false;

            return true;
        }

        private static bool ValidateDigit(string cpf, int length)
        {
            int sum = 0;
            for (int i = 0; i < length; i++)
                sum += (cpf[i] - '0') * (length + 1 - i);

            int remainder = sum % 11;
            int digit = remainder < 2 ? 0 : 11 - remainder;

            return (cpf[length] - '0') == digit;
        }

    }
}
