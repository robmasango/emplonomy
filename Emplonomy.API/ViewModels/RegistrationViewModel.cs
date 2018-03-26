using System.ComponentModel.DataAnnotations;

namespace Emplonomy.API.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneCell { get; set; }
        public string IDNumber { get; set; }
        [Required]
        public bool AgreeTC { get; set; }
        public int RoleID { get; set; }
        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public bool isDeleted { get; set; }
        public string PasswordHash { get; set; }
        public bool isOrgManager { get; set; }
        public string EmployeeName { get; set; }
        public string AvatarURL { get; set; }

    }
}
