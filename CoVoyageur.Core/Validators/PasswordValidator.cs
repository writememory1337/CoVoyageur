using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CoVoyageur.Core.Validators
{
    public class PasswordValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var input = value?.ToString();
            ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                ErrorMessage = "password must not be empty";
            }
            else
            {
                var hasNumber = new Regex(@"[0-9]{2,}");
                var hasUpperLetters = new Regex(@"[A-Z]{2,}");
                var hasLowerCase = new Regex(@"[a-z]{2,}");
                var hasEnoughChars = new Regex(@".{8,15}");
                var hasSymbol = new Regex(@"[.+*?!:;,^@/$(){}|]{2,}");

                if (!hasNumber.IsMatch(input))
                {
                    ErrorMessage += "Le mot de passe doit contenir au moins (2) chiffres. ";
                }
                if (!hasUpperLetters.IsMatch(input))
                {
                    ErrorMessage += "Le mot de passe doit contenir au moins (2) lettres majuscules. ";
                }
                if (!hasLowerCase.IsMatch(input))
                {
                    ErrorMessage += "Le mot de passe doit contenir au moins (2) minuscules. ";
                }
                if (!hasEnoughChars.IsMatch(input))
                {
                    ErrorMessage += "Le mot de passe doit contenir entre 8 et 15 caractères. ";
                }
                if (!hasSymbol.IsMatch(input))
                {
                    ErrorMessage += "Le mot de passe doit contenir au moins (2) symboles. ";
                }

                if (ErrorMessage == string.Empty)
                    return true;
            }

            return false;
        }
    }
}

