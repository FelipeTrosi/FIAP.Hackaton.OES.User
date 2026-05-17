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
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = Regex.Replace(cpf, @"[^\d]", "");
            
            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;
            
            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += (cpf[i] - '0') * (10 - i);
            }

            int resto = soma % 11;
            int primeiroDigito = resto < 2 ? 0 : 11 - resto;

            if ((cpf[9] - '0') != primeiroDigito)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += (cpf[i] - '0') * (11 - i);
            }

            resto = soma % 11;
            int segundoDigito = resto < 2 ? 0 : 11 - resto;

            return (cpf[10] - '0') == segundoDigito;
        }

    }
}
