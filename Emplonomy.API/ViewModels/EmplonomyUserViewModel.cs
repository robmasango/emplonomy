using Emplonomy.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emplonomy.API.ViewModels
{
    public class EmplonomyUserViewModel
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddressAlt { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? AgreeTC { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int FailedPasswordAttempts { get; set; }
        public bool isLoggedin { get; set; }
        public bool ConfirmedReg { get; set; }
        public bool? isDeleted { get; set; }

        public string Name { get; set; }
        public int? DepartmentID { get; set; }

        public EmplonomyUser MapEmployeeUser(EmplonomyUser user)
        {
            return new EmplonomyUser()
            {
                ID = user.ID,
                EmployeeNumber = user.EmployeeNumber,
                EmailAddress = user.EmailAddress,
                EmailAddressAlt = user.EmailAddressAlt,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                CreateDate = user.CreateDate,
                AgreeTC = user.AgreeTC,
                LastLoginDate = user.LastLoginDate,
                FailedPasswordAttempts = user.FailedPasswordAttempts,
                IsLoggedin = user.IsLoggedin,
                isDeleted = user.isDeleted,
                //UserAddresses = UserAddressViewModel.ReverseMapMultipleAddresses(UserAddressViewModel.MapMultipleAddresses((List<UserAddress>)user.UserAddresses)),
                //Employee = (new EmployeeViewModel()).ReverseMap(user.Employee)

            };
        }

        public EmplonomyUser MapSenderUser(EmplonomyUser user)
        {
            return new EmplonomyUser()
            {
                ID = user.ID,
                EmployeeNumber = user.EmployeeNumber,
                EmailAddress = user.EmailAddress,
                EmailAddressAlt = user.EmailAddressAlt,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                CreateDate = user.CreateDate,
                AgreeTC = user.AgreeTC,
                LastLoginDate = user.LastLoginDate,
                FailedPasswordAttempts = user.FailedPasswordAttempts,
                IsLoggedin = user.IsLoggedin,
                isDeleted = user.isDeleted,
                //UserAddresses = UserAddressViewModel.ReverseMapMultipleAddresses(UserAddressViewModel.MapMultipleAddresses((List<UserAddress>)user.UserAddresses)),
            };
        }

        public EmplonomyUserViewModel ReverseMapUser(EmplonomyUser user)
        {
            ID = user.ID;
            EmployeeNumber = user.EmployeeNumber;
            EmailAddress = user.EmailAddress;
            EmailAddressAlt = user.EmailAddressAlt;
            PasswordHash = user.PasswordHash;
            PasswordSalt = user.PasswordSalt;
            CreateDate = user.CreateDate;
            AgreeTC = user.AgreeTC;
            LastLoginDate = user.LastLoginDate;
            FailedPasswordAttempts = user.FailedPasswordAttempts;
            isLoggedin = user.IsLoggedin;
            isDeleted = user.isDeleted;
            FailedPasswordAttempts = user.FailedPasswordAttempts;

            return this;
        }

        public List<EmplonomyUser> MapMultipleSenderUsers(List<EmplonomyUser> EmplonomyUsers)
        {
            return (from user in EmplonomyUsers select MapSenderUser(user)).ToList();
        }

    }
}
