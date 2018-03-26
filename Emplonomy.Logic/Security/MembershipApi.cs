using System;

namespace Emplonomy.API.Security
{
    public class MembershipApi
    {
        private readonly EmplonomyUserRepository _userRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICryptoService _cryptoService;
        private readonly DataSession _dataSession;

        public MembershipApi(EmplonomyUserRepository userRepository, ICryptoService cryptoService,
            IUnitOfWorkFactory unitOfWorkFactory, DataSession dataSession)
        {
            this._userRepository = userRepository;
            this._cryptoService = cryptoService;
            this._unitOfWorkFactory = unitOfWorkFactory;
            this._dataSession = dataSession;
        }

        public bool employeeLoginEmpNum(string EmpNum, string password)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var EmplonomyUser = _userRepository.GetUserByEmployeeNumber(EmpNum);
                if (EmplonomyUser == null)
                {
                    return false;
                }

                if (IsPasswordValid(EmplonomyUser, password))
                {
                    return true;
                }
                else
                return false;
            }
        }

        public bool employeeLogin(string username, string password)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var EmplonomyUser = _userRepository.GetUserByEmail(username);
                if (EmplonomyUser == null)
                {
                    return false;
                }

                if (IsPasswordValid(EmplonomyUser, password))
                {
                    return true;
                }
                else
                   return false;
            }

        }

        public bool IsPasswordValid(EmplonomyUser user, string password)
        {
            return _cryptoService.HashPassword(password, user.PasswordSalt) == user.PasswordHash;
        }

       public EmplonomyUser RegisterUserEmployee(string userEmail)
        {
            EmplonomyUser user = null;

            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var existingUser = _userRepository.GetUserByEmail(userEmail);
                if (existingUser != null)
                {
                    return null;
                }

                int? EmpNumber = _userRepository.GetLastUserID() + 1;

                var salt = _cryptoService.CreateSalt();
                var password = "EmplonomyEmp";

                user = new EmplonomyUser
                {
                    RoleID = 4,
                    EmployeeNumber = "EmplonomyEmp" + EmpNumber,
                    EmailAddress = userEmail,
                    EmailAddressAlt = userEmail,
                    PasswordHash = _cryptoService.HashPassword(password, salt),
                    PasswordSalt = salt,
                    CreateDate = DateTime.Now,
                    LastLoginDate = DateTime.Now,
                    isDeleted = false,
                    isLoggedin = true,
                    ConfirmedReg = false,
                    FailedPasswordAttempts = 0,
                    AgreeTC = true
                };

                _userRepository.Save(user);
                uow.Commit();
            }
            return user;
        }

        public EmplonomyUser RegisterUserManager(string userEmail)
        {
            EmplonomyUser user = null;

            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var existingUser = _userRepository.GetUserByEmail(userEmail);
                if (existingUser != null)
                {
                    return null;
                }

                int? EmpNumber = _userRepository.GetLastUserID() + 1;

                var salt = _cryptoService.CreateSalt();
                var password = "Emplonomy";

                user = new EmplonomyUser
                {
                    RoleID = 3,
                    EmployeeNumber = "EmplonomyEmp" + EmpNumber,
                    EmailAddress = userEmail,
                    EmailAddressAlt = userEmail,
                    PasswordHash = _cryptoService.HashPassword(password, salt),
                    PasswordSalt = salt,
                    CreateDate = DateTime.Now,
                    LastLoginDate = DateTime.Now,
                    isDeleted = false,
                    isLoggedin = true,
                    ConfirmedReg = false,
                    FailedPasswordAttempts = 0,
                    AgreeTC = true
                };

                _userRepository.Save(user);
                uow.Commit();
            }
            return user;
        }


        public void UpdatePassword(string UserEmail, string password)
        {

            var salt = _cryptoService.CreateSalt();
            var PasswordH = _cryptoService.HashPassword(password, salt);
            var PasswordS = salt;

            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = _userRepository.GetUserByEmail(UserEmail);
                if (user != null)
                {
                    user.PasswordHash = PasswordH;
                    user.PasswordSalt = PasswordS;
                }
                _userRepository.Save(user);
                uow.Commit();
            }

   


        }


        public EmplonomyUser RegisterUserTopManager(string userEmail, string password, bool AgreeTC, int? roleID)
        {
            EmplonomyUser user = null;

            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var existingUser = _userRepository.GetUserByEmail(userEmail);
                if (existingUser != null)
                {
                    return null;
                }

                int? EmpNumber = _userRepository.GetLastUserID() + 1;

                var salt = _cryptoService.CreateSalt();

                user = new EmplonomyUser
                {
                    RoleID = 2,
                    EmployeeNumber = "EmplonomyEmp" + EmpNumber,
                    EmailAddress = userEmail,
                    EmailAddressAlt = userEmail,
                    PasswordHash = _cryptoService.HashPassword(password, salt),
                    PasswordSalt = salt,
                    CreateDate = DateTime.Now,
                    LastLoginDate = DateTime.Now,
                    isDeleted = false,
                    isLoggedin = true,
                    ConfirmedReg = false,
                    FailedPasswordAttempts = 0,
                    AgreeTC = AgreeTC
                };

                _userRepository.Save(user);
                uow.Commit();
            }
            return user;
        }

        public EmplonomyUser GetUserByEmail(string email)
        {
            EmplonomyUser user = null;

            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                user = _userRepository.GetUserByEmail(email);
            }

            return user;
        }
       public EmplonomyUser GetUserByEmpNum(string EmpNum)
        {
            EmplonomyUser user = null;

            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                user = _userRepository.GetUserByEmployeeNumber(EmpNum);
            }

            return user;
        }

        public EmplonomyUser GetUserById(int? id)
        {
            EmplonomyUser user = null;

            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                user = _userRepository.GetUserById(id);
            }

            return user;
        }

        public void UpdateUser(EmplonomyUser user)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _userRepository.Save(user);
                uow.Commit();
            }

        }


    }
}
