using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RegisterSteps
{
    public partial class UserInfoModel
    {
        public static ValidationResult ValidateEmail(string email, ValidationContext vc)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return (
            regex.IsMatch(email) ?
            ValidationResult.Success :
            new ValidationResult($"The {vc.DisplayName} field is invalid.", new[] { vc.DisplayName })
            );
        }

        public static ValidationResult ValidatePassword(string password, ValidationContext vc)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            Regex regex = new Regex(pattern);
            return
            regex.IsMatch(password) ?
            ValidationResult.Success :
            new ValidationResult(
            $"The {vc.DisplayName} needs at least 8 characters between numbers and letters.",
            new[] { vc.DisplayName }
            )
            ;
        }
    }

    public partial class PaymentInfoModel
    {
        public static ValidationResult ValidateCardNumber(string cardNumber, ValidationContext vc)
        {
            string pattern = @"^(?:[0-9]{4}[-\s]?){3}[0-9]{4}$";
            Regex regex = new Regex(pattern);
            return (
            regex.IsMatch(cardNumber) ?
            ValidationResult.Success :
            new ValidationResult($"The {vc.DisplayName} field is invalid.", new[] { vc.DisplayName })
            );
        }

        public static ValidationResult ValidateExpiryDate(string expiryDate, ValidationContext vc)
        {
            string pattern = @"^(0[1-9]|1[0-2])\/[0-9]{2}$";
            Regex regex = new Regex(pattern);
            return (
            regex.IsMatch(expiryDate) ?
            ValidationResult.Success :
            new ValidationResult($"The {vc.DisplayName} field is invalid.", new[] { vc.DisplayName })
            );
        }

        public static ValidationResult ValidateCVV(string cvv, ValidationContext vc)
        {
            string pattern = @"^\d{3}$";
            Regex regex = new Regex(pattern);
            return (
            regex.IsMatch(cvv) ?
            ValidationResult.Success :
            new ValidationResult($"The {vc.DisplayName} field is invalid.", new[] { vc.DisplayName })
            );
        }

    }
}