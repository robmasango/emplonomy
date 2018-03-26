using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emplonomy.Model
{
    public class EmplonomyUser : IEntityBase
    {
        public EmplonomyUser()
        {
            UserAddresses = new List<UserAddress>();
            SurveyResponses = new List<SurveyResponse>();
            DepartmentManagers = new List<DepartmentManager>();
            OrganisationManagers = new List<OrganisationManager>();
            UserRoles = new List<UserRole>();
        }

        public int ID { get; set; }
        [Column("RoleID", Order = 2, TypeName = "int")]
        public int UserRoleID { get; set; }
        [Column("DepartmentID", Order = 3, TypeName = "int")]
        public int DepartmentID { get; set; }
        [Column("EmployeeNumber", Order = 4, TypeName = "nvarchar(20)")]
        public string EmployeeNumber { get; set; }
        [Column("EmailAddress", Order = 5, TypeName = "nvarchar(100)")]
        public string EmailAddress { get; set; }
        [Column("EmailAddressAlt", Order = 6, TypeName = "nvarchar(100)")]
        public string EmailAddressAlt { get; set; }
        [Column("PasswordHash", Order = 7, TypeName = "nvarchar(100)")]
        public string PasswordHash { get; set; }
        [Column("PasswordSalt", Order = 8, TypeName = "nvarchar(100)")]
        public string PasswordSalt { get; set; }
        [Column("PasswordQuestionID", Order = 9, TypeName = "int")]
        public int PasswordQuestionID { get; set; }
        [Column("PasswordAnswer", Order = 10, TypeName = "nvarchar(100)")]
        public string PasswordAnswer { get; set; }
        [Column("isManager", Order = 11)]
        public bool isManager { get; set; }
        [Column("isOrgManager", Order = 12)]
        public bool isOrgManager { get; set; }
        [Column("IDNumber", Order = 13, TypeName = "nvarchar(13)")]
        public string IDNumber { get; set; }
        [Column("Salary", Order = 14, TypeName = "Money")]
        public decimal Salary { get; set; }
        [Column("FirstName", Order = 15, TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Column("MiddleName", Order = 16, TypeName = "nvarchar(100)")]
        public string MiddleName { get; set; }
        [Column("LastName", Order = 17, TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [Column("Birthdate", Order = 18)]
        public DateTime? Birthdate { get; set; }
        [Column("HireDate", Order = 19)]
        public DateTime? HireDate { get; set; }
        [Column("ResignationDate", Order = 20)]
        public DateTime? ResignationDate { get; set; }
        [Column("PhoneCell", Order = 21, TypeName = "nvarchar(100)")]
        public string PhoneCell { get; set; }
        [Column("PhoneHome", Order = 22, TypeName = "nvarchar(100)")]
        public string PhoneHome { get; set; }
        [Column("PhoneWork", Order = 23, TypeName = "nvarchar(100)")]
        public string PhoneWork { get; set; }
        [Column("AvatarURL", Order = 24, TypeName = "nvarchar(100)")]
        public string AvatarURL { get; set; }
        [Column("CreateDate", Order = 25)]
        public DateTime? CreateDate { get; set; }
        [Column("AgreeTC", Order = 26)]
        public bool? AgreeTC { get; set; }
        [Column("LastLoginDate", Order = 26)]
        public DateTime? LastLoginDate { get; set; }
        [Column("FailedPasswordAttempts", Order = 27, TypeName = "int")]
        public int FailedPasswordAttempts { get; set; }
        [Column("IsLoggedin", Order = 28)]
        public bool IsLoggedin { get; set; }
        [Column("ConfirmedReg", Order = 29)]
        public bool ConfirmedReg { get; set; }
        [Column("IsLocked", Order = 30)]
        public bool IsLocked { get; set; }
        [Column("isDeleted", Order = 31)]
        public bool? isDeleted { get; set; }

        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        public virtual ICollection<DepartmentManager> DepartmentManagers { get; set; }
        public virtual ICollection<OrganisationManager> OrganisationManagers { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual Department Department { get; set; }
        public virtual PasswordQsBank PasswordQsBank { get; set; }
    }
}
