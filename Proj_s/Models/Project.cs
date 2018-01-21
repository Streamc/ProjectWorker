using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proj_s.Models
{
    public class Project
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Customer_Company { get; set; }
        public string Executive_Company { get; set; }
        public int ManagerID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Begin_date { get; set; }
        [AgeCheck]
        [DataType(DataType.Date)]
        public DateTime End_date { get; set; }
        [Range(1, 5)]
        public int Priority { get; set; }
    
        public string Test_comment { get; set; }
        public ICollection<ProjectAssignment> ProjectAssignment { get; set; }

    }


    public class AgeCheck : ValidationAttribute
    {
        protected override ValidationResult IsValid(
object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as Project;

            if (model == null)
                throw new ArgumentException("Attribute not applied on Employee");

            if (model.End_date > DateTime.Now.Date)
                return new ValidationResult(GetErrorMessage(validationContext));
            if (model.End_date < model.Begin_date)
                return new ValidationResult(GetErrorMessage_dd(validationContext));

            return ValidationResult.Success;
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            // Message that was supplied
            if (!string.IsNullOrEmpty(this.ErrorMessage))
                return this.ErrorMessage;

            // Use generic message: i.e. The field {0} is invalid
            //return this.FormatErrorMessage(validationContext.DisplayName);

            // Custom message
            return $"{validationContext.DisplayName} can't be in future";          
        }
        private string GetErrorMessage_dd(ValidationContext validationContext)
        {
            // Message that was supplied
            if (!string.IsNullOrEmpty(this.ErrorMessage))
                return this.ErrorMessage;

            // Use generic message: i.e. The field {0} is invalid
            //return this.FormatErrorMessage(validationContext.DisplayName);

            // Custom message
            return $"{validationContext.DisplayName} date is wrong";
        }


    }

}
