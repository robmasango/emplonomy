using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;
using Emplonomy.API.ViewModels;
using System.Threading.Tasks;
using Emplonomy.API.Core;
using System;

namespace Emplonomy.API.Controllers
{
    [Route("api/User")]
    public class UserController : Controller
    {
        private IEmplonomyUserRepository _empluser;
        private ILoggingRepository _loggingRepository;

        public UserController( IEmplonomyUserRepository emplonomyUserRepository, ILoggingRepository loggingRepository)
        {
            _empluser = emplonomyUserRepository;
            _loggingRepository = loggingRepository;
        }

        #region Register&Login

        [AllowAnonymous]
        [HttpGet("VerifyPassword")]
        public IActionResult VerifyPassword(int userId, string password)
        {
            IActionResult _result = new ObjectResult(false);
            GenericResult _authenticationResult = null;
            try
            {
                var user = _empluser.GetUserById(userId);

                var isValid = _empluser.IsPasswordValid(user, password);

                if (isValid)
                {
                    return new OkObjectResult(true);
                }
                else
                {
                    return new OkObjectResult(false);
                }
            }
            catch (Exception ex)
            {
                _authenticationResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace });
                _loggingRepository.Commit();
            }

            _result = new ObjectResult(_authenticationResult);
            return _result;

        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginViewModel userVm)
        {
            IActionResult _result = new ObjectResult(false);
            GenericResult _authenticationResult = null;

            try
            {

                if (!ModelState.IsValid)
                {
                    var loginEmployeeSuccess = _empluser.UserLogin(userVm.UserEmail, userVm.Password);

                    if (loginEmployeeSuccess)
                    {
                        var loggedInUser = _empluser.GetUserByEmail(userVm.UserEmail);
                        var user = (new EmplonomyUserViewModel()).ReverseMapUser(loggedInUser);

                        SetUserName(user);
                        SetDepartmentID(user);


                        _authenticationResult = new GenericResult()
                        {
                            Succeeded = true,
                            Message = "Authentication succeeded",

                        };

                    }
                    else
                    {
                        _authenticationResult = new GenericResult()
                        {
                            Succeeded = false,
                            Message = "Authentication failed"
                        };
                    }
                }
            }

            catch (Exception ex)
            {
                _authenticationResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace});
                _loggingRepository.Commit();
            }

            _result = new ObjectResult(_authenticationResult);
            return _result;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync("Cookies");
                return Ok();
            }
            catch (Exception ex)
            {
                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace});
                _loggingRepository.Commit();

                return BadRequest();
            }

        }

        private void SetDepartmentID([FromBody] EmplonomyUserViewModel userVm)
        {
            try
            {
                if (userVm.RoleID == 3)
                {
                    var department = _empluser.getDepartmentManager(userVm.ID, true).DepartmentID;
                    userVm.DepartmentID = department;
                }
            }

            catch (Exception ex)
            {
                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace});
                _loggingRepository.Commit();
            }
        }

        private void SetUserName([FromBody] EmplonomyUserViewModel userVm)
        {
            try
            {
                if (userVm.RoleID == 4 || userVm.RoleID == 3 || userVm.RoleID == 2 || userVm.RoleID == 1)
                {
                    var tempUser = _empluser.GetUserById(userVm.ID);
                    var fullName = tempUser.FirstName + " "
                                    + tempUser.LastName;
                    userVm.Name = fullName;
                }
            }

           catch (Exception ex)
            {
                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace });
                _loggingRepository.Commit();
            }
        }

        [AllowAnonymous]
        [Route("RegisterUser")]
        [HttpPost]
        public IActionResult RegisterUser([FromBody]  RegistrationViewModel newUser)
        {
            IActionResult _result = new ObjectResult(false);
            GenericResult _registrationResult = null;
            try
            {
                if (ModelState.IsValid)
                {
                    if (newUser.RoleID != 0)
                    {
                        if (newUser.RoleID == 1 || newUser.RoleID == 2)
                        {
                            EmplonomyUser user = _empluser.RegisterManager(newUser.EmailAddress, newUser.Password, newUser.FirstName, newUser.LastName, newUser.PhoneCell, newUser.DepartmentID);

                            if (user != null)
                            {
                                _registrationResult = new GenericResult()
                                {
                                    Succeeded = true,
                                    Message = "Registration succeeded"
                                };
                            }
                        }

                        if (newUser.RoleID == 3)
                        {
                            EmplonomyUser user = _empluser.RegisterUser(newUser.EmailAddress, newUser.Password, newUser.FirstName, newUser.LastName, newUser.PhoneCell, newUser.DepartmentID);
                            if (user != null)
                            {
                                _registrationResult = new GenericResult()
                                {
                                    Succeeded = true,
                                    Message = "Registration succeeded"
                                };
                            }
                        }
                    }

                }
                else
                {
                    _registrationResult = new GenericResult()
                    {
                        Succeeded = false,
                        Message = "Invalid fields."
                    };
                }

            }

            catch (Exception ex)
            {
                _registrationResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
                _loggingRepository.Commit();
            }

            _result = new ObjectResult(_registrationResult);
            return _result;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("RegisterManagerEmployees")]
        public IActionResult RegisterManagerEmployees([FromBody] EmployeesViewModel emp)
        {
            IActionResult _result = new ObjectResult(false);
            GenericResult _registrationResult = null;

            try
            {
                foreach (var item in emp.employees)
                {
                    if (!ModelState.IsValid)
                    {
                        _registrationResult = new GenericResult()
                        {
                            Succeeded = false,
                            Message = "Invalid fields."
                        };
                    }
                    else
                    {
                        EmplonomyUser user = _empluser.RegisterUser(item.EmailAddress, item.Password, item.FirstName, item.LastName, item.PhoneCell, item.DepId);
                        if (user != null)
                        {
                            _registrationResult = new GenericResult()
                            {
                                Succeeded = true,
                                Message = "Registration succeeded",

                            };
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                _registrationResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
                _loggingRepository.Commit();
            }

            _result = new ObjectResult(_registrationResult);
            return _result;


        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Signup")]
        public IActionResult Signup([FromBody] RegistrationViewModel newUser)
        {

            IActionResult _result = new ObjectResult(false);
            GenericResult _registrationResult = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    _registrationResult = new GenericResult()
                    {
                        Succeeded = false,
                        Message = "Invalid fields."
                    };
                }
                else
                {
                    var user = _empluser.GetUserByEmail(newUser.EmailAddress);

                    var employee = _empluser.GetUserById(user.ID);
                    if (user != null)
                    {

                        employee.FirstName = newUser.FirstName;
                        employee.LastName = newUser.LastName;
                        employee.PhoneCell = newUser.PhoneCell;
                        employee.isOrgManager = newUser.isOrgManager;


                        _empluser.UpdateUser(employee);
                        _empluser.ConfirmRegistration(user.ID, true);

                        var usernew = (new EmplonomyUserViewModel()).ReverseMapUser(user);

                        SetUserName(usernew);

                        _result = new OkObjectResult(new { success = true, usernew });
                    }

                }
            }

           catch (Exception ex)
            {
                _registrationResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
                _loggingRepository.Commit();
            }

            _result = new ObjectResult(_registrationResult);
            return _result;
        }

        #endregion

    }
}
