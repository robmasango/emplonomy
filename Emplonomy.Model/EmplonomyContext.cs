using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Emplonomy.Model
{
    public class EmplonomyContext : DbContext
    {
        //Admin
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<PasswordQsBank> PasswordQsBanks { get; set; }
        public DbSet<Provisioned> Provisioned { get; set; }
        public DbSet<SendShortMessage> SendShortMessages { get; set; }
        public DbSet<ShortMessage> ShortMessages { get; set; }
        public DbSet<SendSmsStatus> SendSmsStatus { get; set; }
        public DbSet<Role> Roles { get; set; }
        //Surveys
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyFrequency> SurveyFrequencies { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyResponse> SurveyResponses { get; set; }
        //User
        public DbSet<DepartmentManager> DepartmentManagers { get; set; }
        public DbSet<EmplonomyUser> EmplonomyUsers { get; set; }
        public DbSet<OrganisationManager> OrganisationManagers { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public EmplonomyContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //ADMIN
            #region AddressType
            modelBuilder.Entity<AddressType>()
                .ToTable("AddressType", "dbo");

            modelBuilder.Entity<AddressType>()
                .Property(s => s.AddressTypeDesc)
                .HasMaxLength(100);

            modelBuilder.Entity<AddressType>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<AddressType>()
                .HasMany(s => s.UserAddresses)
                .WithOne(c => c.AddressType);
            #endregion

            #region Department
            modelBuilder.Entity<Department>()
                .ToTable("Department", "dbo");

            modelBuilder.Entity<Department>()
                .Property(s => s.DepartmentName)
                .HasMaxLength(100);

            modelBuilder.Entity<Department>()
                .Property(s => s.OrganisationID);

            modelBuilder.Entity<Department>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<Department>()
                .HasOne(s => s.Organisation)
                .WithMany(c => c.Departments)
                .HasForeignKey(a => a.OrganisationID);

            modelBuilder.Entity<Department>()
                .HasMany(s => s.DepartmentManagers)
                .WithOne(c => c.Department);
            #endregion

            #region Location
            modelBuilder.Entity<Location>()
                .ToTable("Location", "dbo");

            modelBuilder.Entity<Location>()
                .Property(s => s.StreetNumber)
                .HasMaxLength(100);

            modelBuilder.Entity<Location>()
                .Property(s => s.StreetName);

            modelBuilder.Entity<Location>()
                .Property(s => s.Town);

            modelBuilder.Entity<Location>()
                .Property(s => s.City);

            modelBuilder.Entity<Location>()
                .Property(s => s.Country);

            modelBuilder.Entity<Location>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<Location>()
                .HasMany(s => s.Organisations)
                .WithOne(c => c.Location);
            #endregion

            #region Organisation
            modelBuilder.Entity<Organisation>()
                .ToTable("Organisation", "dbo");

            modelBuilder.Entity<Organisation>()
                .Property(s => s.LocationID);

            modelBuilder.Entity<Organisation>()
                .Property(s => s.OrganisationName)
                .HasMaxLength(100);

            modelBuilder.Entity<Organisation>()
                .Property(s => s.Industry);

            modelBuilder.Entity<Organisation>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<Organisation>()
                .HasOne(s => s.Location)
                .WithMany(c => c.Organisations)
                .HasForeignKey(a => a.LocationID);

            modelBuilder.Entity<Organisation>()
                .HasMany(s => s.Departments)
                .WithOne(c => c.Organisation);

            modelBuilder.Entity<Organisation>()
                .HasMany(s => s.OrganisationManagers)
                .WithOne(c => c.Organisation);
            #endregion

            #region Department
            modelBuilder.Entity<PasswordQsBank>()
                .ToTable("PasswordQsBank", "dbo");

            modelBuilder.Entity<PasswordQsBank>()
                .Property(s => s.PasswordQuestion)
                .HasMaxLength(100);

            modelBuilder.Entity<PasswordQsBank>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<PasswordQsBank>()
                .HasMany(s => s.Users)
                .WithOne(c => c.PasswordQsBank);
            #endregion

            #region Provisioned
            modelBuilder.Entity<Provisioned>()
                .ToTable("Provisioned", "dbo");

            modelBuilder.Entity<Provisioned>()
                .Property(s => s.EmailAddress)
                .HasMaxLength(100);

            modelBuilder.Entity<Provisioned>()
                .Property(s => s.RoleID);

            modelBuilder.Entity<Provisioned>()
                .Property(s => s.isDeleted);
            #endregion

            #region Role
            modelBuilder.Entity<Role>()
                .ToTable("Role", "dbo");

            modelBuilder.Entity<Role>()
                .Property(s => s.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Role>()
                .Property(s => s.Description)
                .HasMaxLength(100)
                .IsRequired(false);

            modelBuilder.Entity<Role>()
                .Property(s => s.isDeleted);
            #endregion

            #region SendshortMessage
            modelBuilder.Entity<SendShortMessage>()
                .ToTable("SendShortMessage", "dbo");

            modelBuilder.Entity<SendShortMessage>()
                .Property(s => s.smsID);

            modelBuilder.Entity<SendShortMessage>()
                .Property(s => s.smsStatusID);

            modelBuilder.Entity<SendShortMessage>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<SendShortMessage>()
                .HasOne(s => s.SendSmsStatus)
                .WithMany(c => c.SendShortMessages)
                .HasForeignKey(a => a.smsStatusID);

            modelBuilder.Entity<SendShortMessage>()
                .HasOne(s => s.ShortMessage)
                .WithMany(c => c.SendShortMessages)
                .HasForeignKey(a => a.smsID);
            #endregion

            #region SendSmsStatus
            //SendSmsStatus
            modelBuilder.Entity<SendSmsStatus>()
                .ToTable("SendSmsStatus", "dbo");

            modelBuilder.Entity<SendSmsStatus>()
                .Property(s => s.StatusDesc)
                .HasMaxLength(100);

            modelBuilder.Entity<SendSmsStatus>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<SendSmsStatus>()
                .HasMany(s => s.SendShortMessages)
                .WithOne(c => c.SendSmsStatus);
            #endregion

            #region ShortMessage
            //ShortMessage
            modelBuilder.Entity<ShortMessage>()
                .ToTable("ShortMessage", "dbo");

            modelBuilder.Entity<ShortMessage>()
                .Property(s => s.smsText)
                .HasMaxLength(100);

            modelBuilder.Entity<ShortMessage>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<ShortMessage>()
                .HasMany(s => s.SendShortMessages)
                .WithOne(c => c.ShortMessage);
            #endregion

            #region Error
            modelBuilder.Entity<Error>()
                .ToTable("Error", "dbo");

            modelBuilder.Entity<Error>()
                .Property(s => s.Message);

            modelBuilder.Entity<Error>()
                .Property(s => s.StackTrace);

            modelBuilder.Entity<Error>()
                .Property(s => s.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Error>()
                .Property(s => s.isDeleted)
                .HasDefaultValue(false);

            #endregion

            // USER

            #region DepartmentManager
            modelBuilder.Entity<DepartmentManager>()
                .ToTable("DepartmentManager", "dbo");

            modelBuilder.Entity<DepartmentManager>()
                .Property(s => s.DepartmentID);

            modelBuilder.Entity<DepartmentManager>()
                .Property(s => s.ManagerID);

            modelBuilder.Entity<DepartmentManager>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<DepartmentManager>()
                .HasOne(s => s.Department)
                .WithMany(c => c.DepartmentManagers)
                .HasForeignKey(a => a.DepartmentID);

            modelBuilder.Entity<DepartmentManager>()
                .HasOne(s => s.EmplonomyUser)
                .WithMany(c => c.DepartmentManagers)
                .HasForeignKey(a => a.ManagerID);

            #endregion

            #region EmplonomyUser

            modelBuilder.Entity<EmplonomyUser>()
                .ToTable("EmplonomyUser", "dbo");

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.DepartmentID);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.EmployeeNumber);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.EmailAddress);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.EmailAddressAlt);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.PasswordHash);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.PasswordSalt);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.PasswordQuestionID);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.PasswordAnswer);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.isManager);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.isOrgManager);

            modelBuilder.Entity<EmplonomyUser>()
                 .Property(s => s.IDNumber);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.Salary)
                .HasDefaultValue(0.00);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.FirstName);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.MiddleName);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.LastName);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.Birthdate);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.HireDate);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.ResignationDate);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.PhoneCell);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.PhoneHome);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.PhoneWork);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.AvatarURL);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.CreateDate)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.AgreeTC);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.LastLoginDate)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.FailedPasswordAttempts);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.IsLoggedin);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.ConfirmedReg);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.IsLocked);

            modelBuilder.Entity<EmplonomyUser>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<EmplonomyUser>()
                .HasMany(s => s.DepartmentManagers)
                .WithOne(c => c.EmplonomyUser);

            modelBuilder.Entity<EmplonomyUser>()
                .HasMany(s => s.OrganisationManagers)
                .WithOne(c => c.EmplonomyUser);

            modelBuilder.Entity<EmplonomyUser>()
                .HasMany(s => s.UserAddresses)
                .WithOne(c => c.EmplonomyUser);

            #endregion

            #region OrganisationManager
            modelBuilder.Entity<OrganisationManager>()
                .ToTable("OrganisationManager", "dbo");

            modelBuilder.Entity<OrganisationManager>()
                .Property(s => s.OrganisationID);

            modelBuilder.Entity<OrganisationManager>()
                .Property(s => s.ManagerID);

            modelBuilder.Entity<OrganisationManager>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<OrganisationManager>()
                .HasOne(s => s.Organisation)
                .WithMany(c => c.OrganisationManagers)
                .HasForeignKey(a => a.OrganisationID);

            modelBuilder.Entity<OrganisationManager>()
                .HasOne(s => s.EmplonomyUser)
                .WithMany(c => c.OrganisationManagers)
                .HasForeignKey(a => a.ManagerID);

            #endregion

            #region UserAddress
            modelBuilder.Entity<UserAddress>()
                .ToTable("UserAddress", "dbo");

            modelBuilder.Entity<UserAddress>()
                .Property(s => s.UserID);

            modelBuilder.Entity<UserAddress>()
                .Property(s => s.AddressTypeID);

            modelBuilder.Entity<UserAddress>()
                .Property(s => s.PrefferedAddress);

            modelBuilder.Entity<UserAddress>()
                .Property(s => s.StreetAddress);

            modelBuilder.Entity<UserAddress>()
                .Property(s => s.Town);

            modelBuilder.Entity<UserAddress>()
                .Property(s => s.City);

            modelBuilder.Entity<UserAddress>()
                .Property(s => s.Province);

            modelBuilder.Entity<UserAddress>()
                .Property(s => s.Country);

            modelBuilder.Entity<UserAddress>()
                .Property(s => s.PostalCode);

            modelBuilder.Entity<UserAddress>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<UserAddress>()
                .HasOne(s => s.EmplonomyUser)
                .WithMany(c => c.UserAddresses)
                .HasForeignKey(a => a.UserID);

            modelBuilder.Entity<UserAddress>()
                .HasOne(s => s.AddressType)
                .WithMany(c => c.UserAddresses)
                .HasForeignKey(a => a.AddressTypeID);

            #endregion

            #region UserRole
            modelBuilder.Entity<UserRole>()
                .ToTable("UserRole", "dbo");

            modelBuilder.Entity<UserRole>()
                .Property(ur => ur.UserID)
                .IsRequired();

            modelBuilder.Entity<UserRole>()
                .Property(ur => ur.RoleID)
                .IsRequired();

            modelBuilder.Entity<UserRole>()
                .Property(ur => ur.isDeleted);

            #endregion
            // SURVEY

            #region Survey

            modelBuilder.Entity<Survey>()
                .ToTable("Survey", "dbo");

            modelBuilder.Entity<Survey>()
                .Property(s => s.OrganisationID);

            modelBuilder.Entity<Survey>()
                .Property(s => s.FrequencyID);

            modelBuilder.Entity<Survey>()
                .Property(s => s.Title);

            modelBuilder.Entity<Survey>()
                .Property(s => s.Version);

            modelBuilder.Entity<Survey>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<Survey>()
                .HasOne(s => s.Organisation)
                .WithMany(c => c.Surveys);

            modelBuilder.Entity<Survey>()
                .HasOne(s => s.SurveyFrequency)
                .WithMany(c => c.Surveys);

            modelBuilder.Entity<Survey>()
                .HasOne(s => s.SurveyFrequency)
                .WithMany(c => c.Surveys)
                .HasForeignKey(a => a.FrequencyID);

            #endregion

            #region SurveyFrequency

            modelBuilder.Entity<SurveyFrequency>()
                .ToTable("SurveyFrequency", "dbo");

            modelBuilder.Entity<SurveyFrequency>()
                .Property(s => s.Name);

            modelBuilder.Entity<SurveyFrequency>()
                .Property(s => s.NumQuestions);

            modelBuilder.Entity<SurveyFrequency>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<SurveyFrequency>()
                .HasMany(s => s.Surveys)
                .WithOne(c => c.SurveyFrequency);

            #endregion

            #region SurveyQuestion

            modelBuilder.Entity<SurveyQuestion>()
                .ToTable("SurveyQuestion", "dbo");

            modelBuilder.Entity<SurveyQuestion>()
                .Property(s => s.Driver);

            modelBuilder.Entity<SurveyQuestion>()
                .Property(s => s.SubDriver);

            modelBuilder.Entity<SurveyQuestion>()
                .Property(s => s.Question);

            modelBuilder.Entity<SurveyQuestion>()
                .Property(s => s.QuestionType);

            modelBuilder.Entity<SurveyQuestion>()
                .Property(s => s.QuestionOrder);

            modelBuilder.Entity<SurveyQuestion>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<SurveyQuestion>()
                .HasMany(s => s.SurveyResponses)
                .WithOne(c => c.SurveyQuestion);

            #endregion

            #region SurveyResponse

            modelBuilder.Entity<SurveyResponse>()
                .ToTable("SurveyResponse", "dbo");

            modelBuilder.Entity<SurveyResponse>()
                .Property(s => s.QuestionID);

            modelBuilder.Entity<SurveyResponse>()
                .Property(s => s.UserID);

            modelBuilder.Entity<SurveyResponse>()
                .Property(s => s.SurveyID);

            modelBuilder.Entity<SurveyResponse>()
                .Property(s => s.Answer);

            modelBuilder.Entity<SurveyResponse>()
                .Property(s => s.isDeleted);

            modelBuilder.Entity<SurveyResponse>()
                .HasOne(s => s.EmplonomyUser)
                .WithMany(c => c.SurveyResponses)
                .HasForeignKey(a => a.UserID);

            modelBuilder.Entity<SurveyResponse>()
                .HasOne(s => s.SurveyQuestion)
                .WithMany(c => c.SurveyResponses)
                .HasForeignKey(a => a.QuestionID);

            #endregion



        }
    }
}
