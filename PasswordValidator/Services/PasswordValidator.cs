using PasswordValidator.Services.Interfaces;
using System.Text.RegularExpressions;

namespace PasswordValidator.Services.Services
{
    public class PasswordValidator : IPasswordValidator
    {
        private const int MinimalPasswordLength = 8;
        private const string UpperCaseRegex = @"[A-Z]";
        private const string LowerCaseRegex = @"[a-z]";
        private const string DigitRegex = @"\d";
        private const string SpecialCharacterRegex = @"[!@#$%^&*()-_=+[\]{};:'"",.<>/?\\|]";

        public Task<bool> Validate(string password)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(password) || password.Length < MinimalPasswordLength)
            {
                errors.Add($"Password must be at least {MinimalPasswordLength} characters long.");
            }
            if (!Regex.IsMatch(password, UpperCaseRegex))
            {
                errors.Add("Password must have at least ONE Upper Case character.");
            }
            if (!Regex.IsMatch(password, LowerCaseRegex))
            {
                errors.Add("Password must have at least ONE Lower Case character.");
            }
            if (!Regex.IsMatch(password, DigitRegex))
            {
                errors.Add("Password must have at least ONE Number character.");
            }
            if (!Regex.IsMatch(password, SpecialCharacterRegex))
            {
                errors.Add("Password must have at least ONE Special character.");
            }

            if (errors.Count > 0) throw new Exception(string.Join(' ', errors));

            return Task.FromResult(true);
        }
    }
}
