using Emplonomy.Model;
using System.Collections.Generic;

namespace Emplonomy.Logic.Abstract
{
    //Admin
    public interface IAddressTypeRepository : IEntityBaseRepository<AddressType> {
        List<AddressType> GetAddressTypes();
        List<AddressType> GetAddressTypesOrdered(int currentPage, int currentPageSize, string filter = null);
        int CountAddressTypes();
        AddressType GetAddressType(int id);
        void AddAddressType(AddressType AddressType);
        void DeleteAddressType(int Id);
        void UpdateAddressType(AddressType AddressType);
        AddressType GetAddressType(string AddressTypename);
        AddressType AssignAddressTypeDeletedRestored(int id, bool del);
        List<AddressType> getDeletedAddressTypes(bool deleted);
    }

    public interface IDepartmentRepository : IEntityBaseRepository<Department> {
        List<Department> GetDepartments();
        List<Department> GetDepartmentsOrdered(int currentPage, int currentPageSize, string filter = null);
        int CountDepartments();
        Department GetDepartment(int id);
        void AddDepartment(Department Department);
        void DeleteDepartment(int Id);
        void UpdateDepartment(Department dep);
        Department GetDepartment(string name);
        Department AssignDepartmentDeletedRestored(int id, bool del);
        List<Department> getDeletedDepartments(bool deleted);
        Department GetTop1Department(string dep, int orgId, bool del);
    }


    public interface ILocationRepository : IEntityBaseRepository<Location> {
        List<Location> GetLocations();
        List<Location> GetLocationsOrdered(int currentPage, int currentPageSize, string filter = null);
        int CountLocations();
        Location GetLocation(int id);
        void AddLocation(Location Location);
        void DeleteLocation(int Id);
        void UpdateLocation(Location Location);
        Location GetLocation(string Locationname);
        Location AssignLocationDeletedRestored(int id, bool del);
        List<Location> getDeletedLocations(bool deleted);
    }

    public interface IOrganisationRepository : IEntityBaseRepository<Organisation> {
        List<Organisation> GetOrganisations();
        List<Organisation> GetOrganisationsOrdered(int currentPage, int currentPageSize, string filter = null);
        int CountOrganisations();
        Organisation GetOrganisation(int id);
        void AddOrganisation(Organisation Organisation);
        void DeleteOrganisation(int Id);
        void UpdateOrganisation(Organisation Organisation);
        Organisation GetOrganisation(string Organisationname);
        Organisation AssignOrganisationDeletedRestored(int id, bool del);
        List<Organisation> getDeletedOrganisations(bool deleted);
    }

    public interface IPasswordQsBankRepository : IEntityBaseRepository<PasswordQsBank> {
        List<PasswordQsBank> GetPasswordQsBanks();
        List<PasswordQsBank> GetPasswordQsBanksOrdered(int currentPage, int currentPageSize, string filter = null);
        int CountPasswordQsBanks();
        PasswordQsBank GetPasswordQsBank(int id);
        void AddPasswordQsBank(PasswordQsBank PasswordQsBank);
        void DeletePasswordQsBank(int Id);
        void UpdatePasswordQsBank(PasswordQsBank PasswordQsBank);
        PasswordQsBank GetPasswordQsBank(string PasswordQsBankname);
        PasswordQsBank AssignPasswordQsBankDeletedRestored(int id, bool del);
        List<PasswordQsBank> getDeletedPasswordQsBanks(bool deleted);
    }

    public interface IProvisionedRepository : IEntityBaseRepository<Provisioned> {
        List<Provisioned> GetProvisioneds();
        List<Provisioned> GetProvisionedsOrdered(int currentPage, int currentPageSize, string filter = null);
        int CountProvisioned();
        Provisioned GetProvisioned(int id);
        void AddProvisioned(Provisioned Provisioned);
        void DeleteProvisioned(int Id);
        void UpdateProvisioned(Provisioned Provisioned);
        Provisioned GetProvisioned(string Provisionedname);
        Provisioned AssignProvisionedDeletedRestored(int id, bool del);
        List<Provisioned> getDeletedProvisioneds(bool deleted);
    }

    public interface IShortMessageRepository : IEntityBaseRepository<ShortMessage> {
        List<ShortMessage> GetShortMessages();
        List<ShortMessage> GetShortMessagesOrdered(int currentPage, int currentPageSize, string filter = null);
        int CountShortMessages();
        ShortMessage GetShortMessage(int id);
        void AddShortMessage(ShortMessage ShortMessage);
        void DeleteShortMessage(int Id);
        void UpdateShortMessage(ShortMessage ShortMessage);
        ShortMessage GetShortMessage(string ShortMessagename);
        ShortMessage AssignShortMessageDeletedRestored(int id, bool del);
        List<ShortMessage> getDeletedShortMessages(bool deleted);
    }

    public interface ISendShortMessageRepository : IEntityBaseRepository<SendShortMessage> {
        List<SendShortMessage> GetSendShortMessages();
        List<SendShortMessage> GetSendShortMessagesOrdered(int currentPage, int currentPageSize, string filter = null);
        int CountSendShortMessages();
        SendShortMessage GetSendShortMessage(int id);
        void AddSendShortMessage(SendShortMessage SendShortMessage);
        void DeleteSendShortMessage(int Id);
        void UpdateSendShortMessage(SendShortMessage SendShortMessage);
        SendShortMessage GetSendShortMessage(string SendShortMessagename);
        SendShortMessage AssignSendShortMessageDeletedRestored(int id, bool del);
        List<SendShortMessage> getDeletedSendShortMessages(bool deleted);
    }

    public interface ISendSmsStatusRepository : IEntityBaseRepository<SendSmsStatus> {
        List<SendSmsStatus> GetSendSmsStatuss();
        List<SendSmsStatus> GetSendSmsStatussOrdered(int currentPage, int currentPageSize, string filter = null);
        int CountSendSmsStatuss();
        SendSmsStatus GetSendSmsStatus(int id);
        void AddSendSmsStatus(SendSmsStatus SendSmsStatus);
        void DeleteSendSmsStatus(int Id);
        void UpdateSendSmsStatus(SendSmsStatus SendSmsStatus);
        SendSmsStatus GetSendSmsStatus(string SendSmsStatusname);
        SendSmsStatus AssignSendSmsStatusDeletedRestored(int id, bool del);
        List<SendSmsStatus> getDeletedSendSmsStatuss(bool deleted);
    }

    public interface IRoleRepository : IEntityBaseRepository<Role> {
        List<Role> GetRoles();
        List<Role> GetRolesOrdered(int currentPage, int currentPageSize, string filter = null);
        int CountRoles();
        Role GetRole(int id);
        void AddRole(Role Role);
        void DeleteRole(int Id);
        void UpdateRole(Role Role);
        Role GetRole(string Rolename);
        Role AssignRoleDeletedRestored(int id, bool del);
        List<Role> getDeletedRoles(bool deleted);
    }

    public interface ILoggingRepository : IEntityBaseRepository<Error> {}

    //User

    public interface IDepartmentManagerRepository : IEntityBaseRepository<DepartmentManager> {
        DepartmentManager GetDepartmentManager(int id);
        DepartmentManager GetDepartmentManagerByDepID(int id);
        DepartmentManager GetDepartmentManagerByMagrID(int id);
        List<DepartmentManager> GetDepartmentManagers();
        DepartmentManager GetSpecificDepartmentManager(int depid, int empId, bool del);
        DepartmentManager AssignDepartmentManagerDeletedRestored(int id, bool del);
        List<DepartmentManager> getDeletedDepartmentManagers(bool deleted);
        List<DepartmentManager> GetDepartmentManagerOrdered(string filter = null);
        int CountDepartmentManagers();
        void AddDepartmentManager(DepartmentManager Dep);
        void DeleteDepartmentManager(int Id);
        void UpdateDepartmentManager(DepartmentManager Dep);
    }

    public interface IEmplonomyUserRepository : IEntityBaseRepository<EmplonomyUser> {

        EmplonomyUser signup(int id, string firstname, string lastname, string phonecell);
        EmplonomyUser GetUserById(int id);
        EmplonomyUser GetUserByEmail(string email);
        EmplonomyUser GetUserByEmpNum(string empnum);
        EmplonomyUser GetCompleteUserByEmail(string email);
        EmplonomyUser GetCompletUserByID(int userID);
        EmplonomyUser GetCompletUserByEmpNum(string empNum);
        List<EmplonomyUser> GetUsersOrdered(string filter = null);
        List<EmplonomyUser> getDeletedManagerEmployees(int depId, bool deleted);
        EmplonomyUser getDepartmentManager(int DepID, bool MangrYes);
        List<EmplonomyUser> GetManagerEmployees(int depId);
        List<EmplonomyUser> GetManagerEmployeesOrdered(int depID, string filter = null); //Fix
        List<EmplonomyUser> getDeletedUsers(bool deleted);
        EmplonomyUser GetUser(int Id);
        EmplonomyUser RegisterUser(string userEmail, string password, string name, string surname, string phone, int depId);
        EmplonomyUser RegisterManager(string userEmail, string password, string name, string surname, string phone, int depId);
        bool UserLoginUserName(string empnum, string password);
        bool IsPasswordValid(EmplonomyUser user, string password);
        bool UserLogin(string email, string password);
        EmplonomyUser AssignUserDeletedRestored(int id, bool del);
        EmplonomyUser ConfirmRegistration(int id, bool confirmed);
        EmplonomyUser UpdateUserPassword(string userEmail, string passwordh, string passords);
        EmplonomyUser AssignUserDepartment(int id, int DepId);
        //EmplonomyUser AssignUserRole(int id, int roleId);
        EmplonomyUser AssignUserPasswordQuestion(int id, int PwordQId);
        int CountUsers();
        void AddUser(EmplonomyUser user);
        void DeleteUser(int Id);
        void UpdateUser(EmplonomyUser user);
        bool CheckConfirmReg(string email);
        bool ValidateEmail(string email);
        int GetLastUserID();
        int GetNumberOfUsersRegistered();
        //int GetNumberOfUserRegisteredByRole(int role);
        //int GetUserRoleByEmpNum(string empnum);
        //int GetUserRoleByID(int userId);
    }

    public interface IUserRoleRepository : IEntityBaseRepository<UserRole> { }

    public interface IOrganisationManagerRepository : IEntityBaseRepository<OrganisationManager> { }

    public interface IUserAddressRepository : IEntityBaseRepository<UserAddress> { }

}
