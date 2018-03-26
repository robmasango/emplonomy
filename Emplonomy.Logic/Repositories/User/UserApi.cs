using System.Collections.Generic;
using System.Linq;

namespace Emplonomy.API.User
{
    public class UserApi
    {
        protected readonly IUnitOfWorkFactory unitOfWorkFactory;
        protected readonly EmplonomyUserRepository userRepository;
        protected readonly UserAddressRepository userAddressRepository;
        protected readonly PasswordAnswerRepository passwordAnswerRepository;
        protected readonly IUnitOfWorkFactory unitOfWorkFactory;
        protected readonly EmplonomyUserRepository userRepository;
        protected readonly UserAddressRepository userAddressRepository;
        protected readonly EmployeeRepository employeeRepository;
        protected readonly JobHistoryRepository jobHistoryRepository;
        protected readonly DepartmentRepository departmentRepository;
        protected readonly JobRepository jobRepository;

        public UserApi(IUnitOfWorkFactory unitOfWorkFactory, EmplonomyUserRepository userRepository, UserAddressRepository userAddressRepository
                       ,PasswordAnswerRepository passwordAnswerRepository, EmplonomyUserRepository userRepository, UserAddressRepository userAddressRepository
                       ,EmployeeRepository employeeRepository, JobHistoryRepository jobHistoryRepository, DepartmentRepository departmentRepository, JobRepository jobRepository)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.userRepository = userRepository;
            this.userAddressRepository = userAddressRepository;
            this.passwordAnswerRepository = passwordAnswerRepository;
            this.userRepository = userRepository;
            this.userAddressRepository = userAddressRepository;
            this.employeeRepository = employeeRepository;
            this.jobHistoryRepository = jobHistoryRepository;
            this.departmentRepository = departmentRepository;
            this.jobRepository = jobRepository;
        }
        #region EmplonomyUser
        public List<EmplonomyUser> ShowAllUsers()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return userRepository.LoadAll();
            }
        }

        public EmplonomyUser GetUserInfo(int? Id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return userRepository.LoadById(Id);
            }
        }

        public EmplonomyUser GetCompletEmployeeUser(string email)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = uow.Context.Set<EmplonomyUser>()
                    .Where(x => x.EmailAddress == email)
                    .Include(x => x.UserAddresses)
                    .Include(x => x.Employee)
                    .FirstOrDefault();

                return user;
            }
        }

        public EmplonomyUser GetCompletEmployeeUser(int? userID)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = uow.Context.Set<EmplonomyUser>()
                    .Where(x => x.ID == userID)
                    .Include(x => x.UserAddresses)
                    .Include(x => x.Employee)
                    .FirstOrDefault();

                return user;
            }
        }

        public EmplonomyUser GetUserByEmailAddress(string email)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = uow.Context.Set<EmplonomyUser>()
                    .Where(x => x.EmailAddress == email)
                    .FirstOrDefault();

                return user;
            }
        }

        public int? GetEmployeeRoleID(string email)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var roleID = uow.Context.Set<EmplonomyUser>()
                    .Where(x => x.EmailAddress.Equals(email))
                    .Select(x => x.RoleID)
                    .FirstOrDefault();
                return roleID;
            }
        }

        public string GetEmployeeUserType(string email)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var roleID = uow.Context.Set<EmplonomyUser>()
                    .Where(x => x.EmailAddress.Equals(email))
                    .Select(x => x.RoleID)
                    .FirstOrDefault();
                return uow.Context.Set<Role>()
                       .Where(x => x.ID == roleID)
                       .Select(x => x.Name)
                       .FirstOrDefault();
            }
        }

        public int? GetUserType(string EmployeeNum)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            { 
                var roleID = uow.Context.Set<EmplonomyUser>()
                    .Where(x => x.EmployeeNumber.Equals(EmployeeNum))
                    .Select(x => x.RoleID)
                    .FirstOrDefault();

                return uow.Context.Set<Role>()
                       .Where(x => x.ID == roleID)
                       .Select(x => x.ID)
                       .FirstOrDefault();
            }
        }

        public int? GetUserTypeByID(int? userId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var roleID = uow.Context.Set<EmplonomyUser>()
                    .Where(x => x.ID == userId)
                    .Select(x => x.RoleID)
                    .FirstOrDefault();
                return uow.Context.Set<Role>()
                       .Where(x => x.ID == roleID)
                       .Select(x => x.ID)
                       .FirstOrDefault();
            }
        }

        public bool ValidateEmail(string email)
        {
            var e = userRepository.GetUserByEmail(email);

            if (e == null)
            {
                return true;
            }

            return false;
        }

        public void UpdateUser(EmplonomyUser user)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                userRepository.Save(user);
                uow.Commit();
            }
        }

        //public void ConfirmRegistration(int? ID, bool confirmed)
        //{
        //    using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
        //    {
        //         userRepository.ConfirmRegistration(ID, confirmed);
        //    }
        //}

        public void ConfirmRegistration(int? userID, bool confirm)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = userRepository.FindSingle(a => a.ID == userID);
                if (user != null)
                {
                    user.ConfirmedReg = confirm;
                }

                userRepository.Save(user);
                uow.Commit();
            }

        }

        public bool CheckConfirmReg(string email)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
               return userRepository.CheckConfirmReg(email);
            }
        }

        //please update
        public void UpdateUser(int? Id, int? roleId, ICollection<UserAddress> address, string empNum, string email, string emailAlt)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = userRepository.LoadById(Id);
                user.RoleID = roleId;
                user.UserAddresses = address;
                user.EmployeeNumber = empNum;
                user.EmailAddress = email;
                user.EmailAddressAlt = emailAlt;
            }
        }

        public void DeleteUser(EmplonomyUser user)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                userRepository.Delete(user);
                uow.Commit();
            }
        }

        public void DeleteUserById(int? Id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                userRepository.Delete(Id);
                uow.Commit();
            }
        }

        #endregion

        #region UserAddress

        public List<UserAddress> GetAddressOfUser(int? Id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return userRepository.LoadById(Id).UserAddresses.ToList();
            }
        }

        public UserAddress SaveUserAddress(int? userId, int? addresstype,bool? preffaddress, string streetadd, int? city, int? town, int? province, int? country, string Postal)
        {
            UserAddress address = null;

            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                   address = new UserAddress
                    {
                        EmplonomyUserID = userId,
                        AddressTypeID = addresstype,
                        PrefferedAddress = preffaddress,
                        StreetAddress = streetadd,
                        CityID = city,
                        TownID = town,
                        ProvDisID = province,
                        CountryID = country,
                        PostalCode = Postal
                    };
                     userAddressRepository.Save(address);
                    uow.Commit();

            }
            return address;
        }

        public UserAddress GetUserAddress(int? userId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var address =
                    userAddressRepository.FindSingle(
                                x => x.EmplonomyUserID == userId);

                return address;
            }
        }

        #endregion 

        #region PasswordAnswer

        public List<PasswordAnswer> GetPasswordAnswersofUser(int? userId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return passwordAnswerRepository.GetPasswordAnswers(userId);
            }
        }

        public List<PasswordAnswer> GetPasswordAnswers()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return passwordAnswerRepository.GetPasswordAnswers();
            }
        }


        public void SavePasswordAnswer(PasswordAnswer passwordAnswer)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                passwordAnswerRepository.Save(passwordAnswer);
                uow.Commit();
            }
        }

        public PasswordAnswer GetPasswordAnswer(int? userId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var passwordAnswer = passwordAnswerRepository.GetPasswordAnswer(userId); 

                return passwordAnswer;
            }
        }

        #endregion

        #region Employee

        //all employees activities
        public void AssignEmployeeDeletedRestored(int? id, bool del)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                employeeRepository.AssignEmployeeDeletedRestored(id, del);
                uow.Commit();
            }

        }
        public List<Employee> getDeletedEmployees(bool deleted)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return employeeRepository.getDeletedEmployees(deleted);
            }

        }

        public List<Employee> getDeletedManagerEmployees(int depId, bool deleted)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return employeeRepository.getDeletedManagerEmployees(depId, deleted);
            }

        }

        public List<Employee> GetEmployeesOrdered(string filter = null)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var record = uow.Context.Set<Employee>()
                   .OrderBy(c => c.ID)
                        .Where(
                            c => c.isDeleted == false &&
                            c.LastName.ToLower().Contains(filter) ||
                            c.FirstName.ToLower().Contains(filter) ||
                            c.PhoneCell.ToLower().Contains(filter) ||
                            c.IDNumber.ToLower().Contains(filter))
                        .ToList();
                return record;
            }
        }

        public List<Employee> GetManagerEmployees(int? depId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var record = uow.Context.Set<Employee>()
                   .OrderBy(c => c.ID)
                        .Where(c => c.isDeleted == false && c.DepartmentID == depId && c.isManager == false)
                        .ToList();
                return record;
            }
        }

        public List<Employee> GetManagerEmployeesOrdered(int depID, string filter = null)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var record = uow.Context.Set<Employee>()
                   .OrderBy(c => c.ID)
                        .Where(

                            c => c.isDeleted == false &&
                            c.DepartmentID == depID &&
                            c.isManager == false &&
                            c.LastName.ToLower().Contains(filter) ||
                            c.FirstName.ToLower().Contains(filter) ||
                            c.PhoneCell.ToLower().Contains(filter) ||
                            c.IDNumber.ToLower().Contains(filter))
                        .ToList();
                return record;
            }
        }
        public Employee GetEmployeeByID(int? id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return employeeRepository.GetEmployee(id);
            }
        }

        public Employee GetDepartmentManager(int? depId, bool mangrYes)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return employeeRepository.getDepartmentManager(depId, mangrYes);
            }
        }

        public List<Employee> GetEmployees()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return employeeRepository.GetEmployees();
            }
        }

        public void AddEmployee(Employee employee)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                employeeRepository.Save(employee);
                uow.Commit();
            }
        }

        public void DeleteEmployee(int? Id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                employeeRepository.Delete(Id);
                uow.Commit();
            }
        }

        public void SaveEmployee(Employee employee)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                employeeRepository.Save(employee);

                uow.Commit();
            }
        }

        public Employee RegisterEmployee(int? id, string name, string surname, string phone, int? depId)
        {
            Employee user = null;

            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var existingUser = employeeRepository.GetEmployee(id);
                if (existingUser != null)
                {
                    return null;
                }

                DateTime birthdate = new DateTime(1900, 1, 1);
                DateTime resignationDate = new DateTime(1900, 1, 1);

                user = new Employee
                {
                    ID = id,
                    DepartmentID = depId,
                    JobID = 4,
                    isManager = false,
                    Salary = 0,
                    FirstName = name,
                    LastName = surname,
                    Birthdate = birthdate,
                    HireDate = DateTime.Now,
                    ResignationDate = resignationDate,
                    PhoneCell = phone,
                    AvatarURL = "AvatarFilePath",
                    isDeleted = false

                };

                employeeRepository.Save(user);
                uow.Commit();
            }
            return user;
        }

        public Employee RegisterManager(int? id, string name, string surname, string phone, int? depId)
        {
            Employee user = null;

            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var existingUser = employeeRepository.GetEmployee(id);
                if (existingUser != null)
                {
                    return null;
                }

                DateTime birthdate = new DateTime(1900, 1, 1);
                DateTime resignationDate = new DateTime(1900, 1, 1);

                user = new Employee
                {
                    ID = id,
                    DepartmentID = depId,
                    JobID = 4,
                    isManager = true,
                    Salary = 0,
                    FirstName = name,
                    LastName = surname,
                    Birthdate = birthdate,
                    HireDate = DateTime.Now,
                    ResignationDate = resignationDate,
                    PhoneCell = phone,
                    AvatarURL = "AvatarFilePath",
                    isDeleted = false

                };

                employeeRepository.Save(user);
                uow.Commit();
            }
            return user;
        }

        public Employee RegisterTopManager(int? id)
        {
            Employee user = null;

            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var existingUser = employeeRepository.GetEmployee(id);
                if (existingUser != null)
                {
                    return null;
                }

                DateTime birthdate = new DateTime(1900, 1, 1);
                DateTime resignationDate = new DateTime(1900, 1, 1);

                user = new Employee
                {
                    ID = id,
                    DepartmentID = 1,
                    JobID = 1,
                    isManager = true,
                    Salary = 0,
                    Birthdate = birthdate,
                    HireDate = DateTime.Now,
                    ResignationDate = resignationDate,
                    AvatarURL = "AvatarFilePath",
                    isDeleted = false
                };

                employeeRepository.Save(user);
                uow.Commit();
            }
            return user;
        }

        public void signup(int? id, string firstname, string lastname, string phonecell)
        {

            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                employeeRepository.signup(id, firstname, lastname, phonecell);
                uow.Commit();
            }

        }

        public void UpdateEmployee(Employee employee)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                employeeRepository.Save(employee);

                uow.Commit();
            }
        }

        public void AssignEmployeeJob(int? id, int? JobId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                employeeRepository.AssignEmployeeJob(id, JobId);
                uow.Commit();
            }
        }

        public void AssignDepartment(int? id, int? DepID)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                employeeRepository.AssignEmployeeDepartment(id, DepID);
                uow.Commit();
            }

        }

        #endregion

        #region Jobhistory

        public JobHistory GetJobHistoryByID(int? id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return jobHistoryRepository.GetJobHistory(id);
            }
        }

        public List<JobHistory> GetJobHistories()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return jobHistoryRepository.GetJobHistories();
            }
        }

        public void AddJobHistory(JobHistory jobHistory)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                jobHistoryRepository.Save(jobHistory);
                uow.Commit();
            }
        }

        public void DeleteJobHistory(int? Id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                jobHistoryRepository.Delete(Id);
                uow.Commit();
            }
        }


        public void UpdateJobHistory(JobHistory jobHistory)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                jobHistoryRepository.Save(jobHistory);
                uow.Commit();
            }
        }

        #endregion

        #region DepartmentManager

        public DepartmentManager GetDepartmentManagerByID(int id)
        {

            {
                return departManagerRepository.GetDepartmentManager(id);
            }
        }

        public DepartmentManager GetDepartmentManagerByDepID(int id)
        {

            {
                return departManagerRepository.GetDepartmentManagerByDepID(id);
            }
        }

        public DepartmentManager GetSpecificDepartmentManager(int depid, int manId, bool del)
        {

            {
                return departManagerRepository.GetSpecificDepartmentManager(depid, manId, del);
            }
        }

        public DepartmentManager GetDepartmentManagerByMagrID(int id)
        {

            {
                return departManagerRepository.GetDepartmentManagerByMagrID(id);
            }
        }

        public List<DepartmentManager> GetDepartmentManagers()
        {

            {
                return departManagerRepository.LoadAll();
            }
        }

        public void AddDepartmentManager(DepartmentManager DepartmentManager)
        {

            {
                departManagerRepository.Add(DepartmentManager);
                uow.Commit();
            }
        }

        public void DeleteDepartmentManager(int Id)
        {

            {
                departManagerRepository.DeleteWhere(c => c.ID == Id);
                uow.Commit();
            }
        }


        public void UpdateDepartmentManager(DepartmentManager DepartmentManager)
        {

            {
                departManagerRepository.Add(DepartmentManager);
                uow.Commit();
            }
        }

        public void AssignDepartmentManagerDeletedRestored(int id, bool del)
        {

            {
                departManagerRepository.AssignDepartmentManagerDeletedRestored(id, del);
                uow.Commit();
            }

        }
        public List<DepartmentManager> getDeletedDepartmentManagers(bool deleted)
        {

            {
                return departManagerRepository.getDeletedDepartmentManagers(deleted);
            }

        }
        //fix

        public List<DepartmentManager> GetDepartmentManagerOrdered(string filter = null)
        {

            {
                return departManagerRepository.GetDepartmentManagerOrdered(filter);
            }
        }

        #endregion

        #region OrganisationManager

        public OrganisationManager GetOrganisationManagerByID(int id)
        {

            {
                return orgManagerRepository.GetOrganisationManager(id);
            }
        }

        public List<OrganisationManager> GetOrganisationManagers()
        {

            {
                return orgManagerRepository.LoadAll();
            }
        }

        public void AddOrganisationManager(OrganisationManager OrganisationManager)
        {

            {
                orgManagerRepository.Add(OrganisationManager);
                uow.Commit();
            }
        }

        public void DeleteOrganisationManager(int Id)
        {

            {
                orgManagerRepository.DeleteWhere(c => c.ID == Id);
                uow.Commit();
            }
        }


        public void UpdateOrganisationManager(OrganisationManager OrganisationManager)
        {

            {
                orgManagerRepository.Add(OrganisationManager);
                uow.Commit();
            }
        }

        public void AssignOrganisationManagerDeletedRestored(int id, bool del)
        {

            {
                orgManagerRepository.AssignOrganisationManagerDeletedRestored(id, del);
                uow.Commit();
            }

        }
        public List<OrganisationManager> getDeletedOrganisationManagers(bool deleted)
        {

            {
                return orgManagerRepository.getDeletedOrganisationManagers(deleted);
            }

        }
        //fix
        public List<OrganisationManager> GetOrganisationManagersOrdered(string filter = null)
        {

            {
                return orgManagerRepository.GetOrganisationManagerOrdered(filter);
            }
        }

        #endregion

        #region SendShortMessage

        public SendShortMessage GetSendShortMessageByID(int? id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return sendShortMessageRepository.GetSendShortMessage(id);
            }
        }

        public List<SendShortMessage> GetSendShortMessages()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return sendShortMessageRepository.LoadAll();
            }
        }

        public void AddSendShortMessage(SendShortMessage SendShortMessage)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                sendShortMessageRepository.Save(SendShortMessage);
                uow.Commit();
            }
        }

        public void DeleteSendShortMessage(int? Id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                sendShortMessageRepository.Delete(Id);
                uow.Commit();
            }
        }


        public void UpdateSendShortMessage(SendShortMessage SendShortMessage)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                sendShortMessageRepository.Save(SendShortMessage);
                uow.Commit();
            }
        }

        public void AssignSendShortMessageDeletedRestored(int? id, bool del)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                sendShortMessageRepository.AssignSendShortMessageDeletedRestored(id, del);
                uow.Commit();
            }

        }
        public List<SendShortMessage> getDeletedSendShortMessages(bool deleted)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return sendShortMessageRepository.getDeletedSendShortMessages(deleted);
            }

        }

        #endregion

        #region AssignRole
        public void AssignUserRole(int? id, int? roleId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                userRepository.AssignUserRole(id, roleId);
                uow.Commit();
            }
        }
        #endregion

    }
}
