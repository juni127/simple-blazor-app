using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RegisterSteps
{
    public struct PlanStruct
    {
        public string Name, Description, Value;
        public int Perks;

        public PlanStruct(string name, string description, string value, int perks)
        {
            Name = name;
            Description = description;
            Value = value;
            Perks = perks;
        }
    }

    public class Models
    {
        public UserInfoModel UserInfo;
        public PaymentInfoModel PaymentInfo;
        public PlanModel Plan;

        public Models()
        {
            UserInfo = new UserInfoModel();
            PaymentInfo = new PaymentInfoModel();
            Plan = new PlanModel();
        }
    }

    public partial class UserInfoModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [CustomValidation(typeof(UserInfoModel), nameof(ValidateEmail))]
        public string Email { get; set; }

        [Required]
        [CustomValidation(typeof(UserInfoModel), nameof(ValidatePassword))]
        public string Password { get; set; }
    }

    public partial class PaymentInfoModel
    {
        [Required]
        [Display(Name = "Name on card")]
        public string NameOnCard { get; set; }

        [Required]
        [Display(Name = "Card number")]
        [CustomValidation(typeof(PaymentInfoModel), nameof(ValidateCardNumber))]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Expiry date")]
        [CustomValidation(typeof(PaymentInfoModel), nameof(ValidateExpiryDate))]
        public string ExpiryDate { get; set; }

        [Required]
        [CustomValidation(typeof(PaymentInfoModel), nameof(ValidateCVV))]
        public string CVV { get; set; }

        [Required]
        [Display(Name = "Address line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address line 2")]
        public string AddressLine2 { get; set; }


        [Required]
        public string City { get; set; }

        [Display(Name = "State/Province/Region")]
        public string State { get; set; }


        [Required]
        [Display(Name = "Zip / Postal code")]
        public string PostalCode { get; set; }


        [Required]
        public string Country { get; set; }
    }

    public class PlanModel
    {
        private int _Index;

        public static PlanStruct[] Plans = {
            new PlanStruct("Starter", "Lorem Ipsum is simply dummy text of the printing and industry.", "0", 3),
            new PlanStruct("Exclusive", "Lorem Ipsum is simply dummy text of the printing and industry.", "99", 7),
            new PlanStruct("Premium", "Lorem Ipsum is simply dummy text of the printing and industry.", "150", 15)
        };

        [Required(ErrorMessage = "You must select a Plan to continue.")]
        public string? Name
        {
            get
            {
                return Plans[_Index].Name;
            }
            set
            {
                int x = 0;
                for (; x < Plans.Length; x++)
                    if (value == Plans[x].Name)
                    {
                        _Index = x;
                        break;
                    }
                if (x == Plans.Length)
                    throw new ArgumentException(nameof(value), "Plan name is out of range.");
            }
        }


        public string Description
        {
            get
            {
                return Plans[_Index].Name;
            }
        }
        public string Value
        {
            get
            {
                return Plans[_Index].Value;
            }
        }
        public int Perks
        {
            get
            {
                return Plans[_Index].Perks;
            }
        }
    }

}