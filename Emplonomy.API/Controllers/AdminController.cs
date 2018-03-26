using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Emplonomy.Web.Models;
using Emplonomy.API.Core;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Emplonomy.API.Controllers
{
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private IAddressTypeRepository _addTypeRepo;
        private IDepartmentRepository _depRepo;
        int page = 1;
        int pageSize = 4;

        public AdminController(IAddressTypeRepository addressTypeRepository,
                                    IDepartmentRepository departmentRepository)
        {
            _addTypeRepo = addressTypeRepository;
            _depRepo = departmentRepository;
        }

        #region AddressType

        [AllowAnonymous]
        [HttpPost("AddAddressType")]
        public IActionResult AddAddressType(AddressTypeViewModel addresstypeVm)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _addTypeRepo.AddAddressType(addresstypeVm.ReverseMap());

            var addressType = _addTypeRepo.GetAddressType(addresstypeVm.ID);

            AddressTypeViewModel addTypeVM = new AddressTypeViewModel();
            addTypeVM.MapSingleAddressType(addressType);

            CreatedAtRouteResult response = CreatedAtRoute("GetAddressType", new { controller = "AddressTypes", id = addTypeVM.ID }, addTypeVM);

            return response;
        }

        [AllowAnonymous]
        [HttpGet("GetAddressTypes")]
        public IActionResult GetAddressTypes()
        {
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var addressT = _addTypeRepo.GetAddressTypes();

                if (addressT == null)
                {
                    return NotFound();
                }
                else
                {
                    var addressRecords = _addTypeRepo.GetAddressTypes();

                    var addresstypesVm = AddressTypeViewModel.MultipleAccTypesMap(addressRecords);

                    return new OkObjectResult(addresstypesVm);
                }
            }
        }

        [AllowAnonymous]
        [HttpGet("GetAddressTypesFilter")]
        public IActionResult GetAddressTypes(string filter = null)
        {
            var pagination = Request.Headers["Pagination"];
            List<AddressType> addresstypes = null;

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            int currentPage = page;
            int currentPageSize = pageSize;
            var totalUsers = _addTypeRepo.CountAddressTypes();
            var totalPages = (int)Math.Ceiling((double)totalUsers / pageSize);

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.Trim().ToLower();
                addresstypes = _addTypeRepo.GetAddressTypesOrdered(currentPage, currentPageSize, filter);
            }
            else {
                addresstypes = _addTypeRepo.GetAddressTypesOrdered(currentPage, currentPageSize, filter);
                //addresstypes = _addTypeRepo.GetAddressTypes();
            }

            var recordVm = AddressTypeViewModel.MultipleAccTypesMap(addresstypes);

            Response.AddPagination(page, pageSize, totalUsers, totalPages);

            return new OkObjectResult(recordVm);
        }

        [AllowAnonymous]
        [HttpGet("GetAddressType")]
        public IActionResult GetAddressType(int Id)
        {
            var addressT = _addTypeRepo.GetAddressType(Id);

            if (addressT == null)
            {
                //return NotFound();
                return new NotFoundResult();
            }
            else
            {
                var account = _addTypeRepo.GetAddressType(Id);

                AddressTypeViewModel recordVm = new AddressTypeViewModel();
                recordVm.MapSingleAddressType(account);

                return new OkObjectResult(recordVm);
            }
        }

        [AllowAnonymous]
        [HttpDelete("RemoveAddressType")]
        public IActionResult DeleteAddressType(int Id)
        {
            var addressT = _addTypeRepo.GetAddressType(Id);

            if (addressT == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _addTypeRepo.DeleteAddressType(Id);
                return new NoContentResult();
            }
        }

        [AllowAnonymous]
        [HttpPut("RestoreDelAddressTypes")]
        public IActionResult RestoreDelAddressTypes(int Id, bool del)
        {
            var addressT = _addTypeRepo.GetAddressType(Id);

            if (addressT == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _addTypeRepo.AssignAddressTypeDeletedRestored(Id, del);

                var addressT2 = _addTypeRepo.getDeletedAddressTypes(false);

                if (addressT2 == null)
                {
                    return new NotFoundResult();
                }
                else
                {
                    var addressRecords = _addTypeRepo.getDeletedAddressTypes(false);

                    var addresstypesVm = AddressTypeViewModel.MultipleAccTypesMap(addressRecords);

                    return new OkObjectResult(addresstypesVm);
                }


            }

        }

        [AllowAnonymous]
        [HttpPut("UpdateAddressType")]
        public IActionResult UpdateAddressType(AddressTypeViewModel addressType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addressT = _addTypeRepo.GetAddressType(addressType.ID);

            if (addressT == null)
            {
                return NotFound();
            }
            else
            {
                var newAddressType = addressType.ReverseMap();
                _addTypeRepo.UpdateAddressType(newAddressType);

                var AddressTVm = new AddressTypeViewModel(newAddressType);

                return new OkObjectResult(AddressTVm);
            }

        }

        [AllowAnonymous]
        [HttpPost("GetDeletedAddressTypes")]
        public IActionResult GetDeletedAddressTypes(bool deleted)
        {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var addressT = _addTypeRepo.getDeletedAddressTypes(deleted);

                if (addressT == null)
                {
                    return NotFound();
                }
                else
                {
                    var addressRecords = _addTypeRepo.getDeletedAddressTypes(deleted);

                    var addresstypesVm = AddressTypeViewModel.MultipleAccTypesMap(addressRecords);

                    return new OkObjectResult(addresstypesVm);
                }
        }
        #endregion

        #region Department

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("AddDepartment")]
        //public IActionResult AddDepartment( DepartmentViewModel departmentVm)
        //{

        //    _adminApi.AddDepartment(departmentVm.ReverseMap());
        //    var response = request.CreateResponse(HttpStatusCode.OK);

        //    return response;

        //}

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("AddDepartmentsAndManagers")]
        //public IActionResult AddDepartmentsAndManagers( DepartmentAndManagerViewModel dep)
        //{

        //    foreach (var item in dep.departments)
        //    {
        //        var OrgID = _adminApi.GetTop1Organisation().ID;
        //        DepartmentViewModel eachDep = new DepartmentViewModel();

        //        eachDep.OrganisationID = OrgID;
        //        eachDep.DepartmentName = item.DepartmentName;
        //        eachDep.isDeleted = false;

        //        _adminApi.AddDepartment(eachDep.ReverseMap());

        //        MishiftUser user = _membershipApi.RegisterUserManager(item.EmailAddress);
        //        if (user != null)
        //        {
        //            var depID = _adminApi.GetTop1Department(item.DepartmentName, OrgID, false).ID;
        //            Employee emp = _employeeApi.RegisterManager(user.ID, item.FirstName, item.LastName, item.PhoneCell, depID);
        //        }

        //        DepartmentManagerViewModel eachDepMan = new DepartmentManagerViewModel();

        //        var depIDMan = _adminApi.GetTop1Department(item.DepartmentName, OrgID, false).ID;

        //        eachDepMan.DepartmentID = depIDMan;
        //        eachDepMan.ManagerID = user.ID;
        //        eachDepMan.isDeleted = false;

        //        _adminApi.AddDepartmentManager(eachDepMan.ReverseMap());

        //    }

        //    var response = request.CreateResponse(HttpStatusCode.OK, new { Success = true });

        //    return response;

        //}

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("GetDepartments")]
        //public IActionResult GetDepartments()
        //{
        //    var records = _adminApi.GetDepartments();

        //    var departmentvm = DepartmentViewModel.MultipleDepartmentMap(records);

        //    foreach (var model in departmentvm)
        //    {
        //        model.OrganisationName = _adminApi.GetOrganisationByID(model.OrganisationID).OrganisationName;
        //    }

        //    var response = request.CreateResponse(HttpStatusCode.OK, departmentvm);

        //    return response;
        //}

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("GetOrgDepartments")]
        //public IActionResult GetOrgDepartments()
        //{
        //    var orgs = _adminApi.GetOrganisations();
        //    var deps = _adminApi.GetDepartments();

        //    var orgvm = OrganisationViewModel.MultipleOrganisationMap(orgs);
        //    var depvm = DepartmentViewModel.MultipleDepartmentMap(deps);

        //    var query = depvm   // your starting point - table in the "from" statement
        //       .Join(orgvm, // the source table of the inner join
        //          dep => dep.OrganisationID,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
        //          org => org.ID,   // Select the foreign key (the second part of the "on" clause)
        //          (dep, org) => new { ID = org.ID, OrganisationName = org.OrganisationName, DepID = dep.ID, DepartmentName = dep.DepartmentName }).ToList();

        //    var result = query.GroupBy(records => new { records.ID, records.OrganisationName })
        //        .Select(group => new { Organisation = group.Key, departments = group.Select(dep => new { DepID = dep.DepID, DepartmentName = dep.DepartmentName }).ToList() }).ToList();

        //    var response = request.CreateResponse(HttpStatusCode.OK, result);

        //    return response;



        //}


        //[AllowAnonymous]
        //[HttpPost]
        //[Route("RestoreDelDepartments")]
        //public IActionResult RestoreDelDepartments( int Id, bool del)
        //{

        //    _adminApi.AssignDepartmentDeletedRestored(Id, del);

        //    var response = request.CreateResponse(HttpStatusCode.OK, new { Success = true });

        //    return response;
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("GetDeletedDepartments")]
        //public IActionResult GetDeletedDepartments( bool deleted)
        //{
        //    var records = _adminApi.getDeletedDepartments(deleted);

        //    var departmentvm = DepartmentViewModel.MultipleDepartmentMap(records);

        //    foreach (var model in departmentvm)
        //    {
        //        model.OrganisationName = _adminApi.GetOrganisationByID(model.OrganisationID).OrganisationName;
        //    }

        //    var response = request.CreateResponse(HttpStatusCode.OK, departmentvm);

        //    return response;
        //}

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("GetDepartment")]
        //public IActionResult GetDepartment( int Id)
        //{
        //    var record = _adminApi.GetDepartmentByID(Id);
        //    DepartmentViewModel deaprtmentvm = new DepartmentViewModel();


        //    var dep = deaprtmentvm.MapSingleDepartment(record);

        //    dep.OrganisationName = _adminApi.GetOrganisationByID(dep.OrganisationID).OrganisationName;

        //    var response = request.CreateResponse(HttpStatusCode.OK, dep);

        //    return response;
        //}


        //[AllowAnonymous]
        //[HttpGet]
        //[Route("GetDepartmentOrgId")]
        //public IActionResult GetDepartmentOrgId( int Id)
        //{
        //    var account = _adminApi.GetDepartmentOrgID(Id);

        //    DepartmentViewModel deaprtmentvm = new DepartmentViewModel();
        //    deaprtmentvm.MapSingleDepartment(account);

        //    var response = request.CreateResponse(HttpStatusCode.OK, deaprtmentvm);

        //    return response;
        //}

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("GetTop1Department")]
        //public IActionResult GetTop1Department( string DepartmentName, int OrganisationID, bool isDeleted)
        //{
        //    var record = _adminApi.GetTop1Department(DepartmentName, OrganisationID, isDeleted);
        //    DepartmentViewModel depVm = new DepartmentViewModel();

        //    var dep = depVm.MapSingleDepartment(record);

        //    var response = request.CreateResponse(HttpStatusCode.OK, dep);

        //    return response;
        //}


        //[AllowAnonymous]
        //[HttpDelete]
        //[Route("RemoveDepartment")]
        //public IActionResult DeleteDepartment( int Id)
        //{

        //    _adminApi.DeleteDepartment(Id);

        //    var response = request.CreateResponse(HttpStatusCode.OK);

        //    return response;

        //}

        //[AllowAnonymous]
        //[HttpPut]
        //[Route("UpdateDepartment")]
        //public IActionResult UpdateDepartment( DepartmentViewModel accountType)
        //{
        //    var newDepartment = accountType.ReverseMap();

        //    _adminApi.UpdateDepartment(newDepartment);

        //    var departmentVm = new DepartmentViewModel(newDepartment);

        //    var response = request.CreateResponse(HttpStatusCode.Created, departmentVm);

        //    return response;
        //}

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("GetDepartmentsV2/{page:int=0}/{pageSize=4}/{filter?}")]
        //public IActionResult GetDepartmentsV2( int page, int pageSize, string filter = null)
        //{
        //    int currentPage = page.Value;
        //    int currentPageSize = pageSize.Value;

        //    IActionResult response = null;
        //    List<Department> departments = null;
        //    int totaldepartments = new int();

        //    if (!string.IsNullOrEmpty(filter))
        //    {
        //        filter = filter.Trim().ToLower();

        //        departments = _adminApi.GetDepartmentsOrdered(filter);
        //    }
        //    else
        //    {
        //        departments = _adminApi.getDeletedDepartments(false);
        //    }

        //    totaldepartments = departments.Count();
        //    departments = departments.Skip(currentPage * currentPageSize)
        //            .Take(currentPageSize)
        //            .ToList();

        //    var departmentvm = DepartmentViewModel.MultipleDepartmentMap(departments);

        //    PaginationSet<DepartmentViewModel> pagedSet = new PaginationSet<DepartmentViewModel>()
        //    {
        //        Page = currentPage,
        //        TotalCount = totaldepartments,
        //        TotalPages = (int)Math.Ceiling((decimal)totaldepartments / currentPageSize),
        //        Items = departmentvm
        //    };

        //    response = request.CreateResponse<PaginationSet<DepartmentViewModel>>(HttpStatusCode.OK, pagedSet);

        //    return response;
        //    //});
        //}

        #endregion

        #region Job

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("GetDeletedJobs")]
        //public IActionResult GetDeletedJobs( bool deleted)
        //{
        //    var records = _adminApi.getDeletedJobs(deleted);

        //    var jobsvm = JobViewModel.MultipleJobMap(records);

        //    var response = request.CreateResponse(HttpStatusCode.OK, jobsvm);

        //    return response;
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("RestoreDelJobs")]
        //public IActionResult RestoreDelJobs( int Id, bool del)
        //{

        //    _adminApi.AssignJobDeletedRestored(Id, del);

        //    var response = request.CreateResponse(HttpStatusCode.OK, new { Success = true });

        //    return response;
        //}

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("GetJobsV2/{page:int=0}/{pageSize=4}/{filter?}")]
        //public IActionResult GetJobsV2( int page, int pageSize, string filter = null)
        //{
        //    int currentPage = page.Value;
        //    int currentPageSize = pageSize.Value;

        //    IActionResult response = null;
        //    List<Job> jobs = null;
        //    int totaljobs = new int();

        //    if (!string.IsNullOrEmpty(filter))
        //    {
        //        filter = filter.Trim().ToLower();

        //        jobs = _adminApi.GetJobsOrdered(filter);
        //    }
        //    else
        //    {
        //        jobs = _adminApi.getDeletedJobs(false);
        //    }

        //    totaljobs = jobs.Count();
        //    jobs = jobs.Skip(currentPage * currentPageSize)
        //            .Take(currentPageSize)
        //            .ToList();

        //    var jobvm = JobViewModel.MultipleJobMap(jobs);

        //    PaginationSet<JobViewModel> pagedSet = new PaginationSet<JobViewModel>()
        //    {
        //        Page = currentPage,
        //        TotalCount = totaljobs,
        //        TotalPages = (int)Math.Ceiling((decimal)totaljobs / currentPageSize),
        //        Items = jobvm
        //    };

        //    response = request.CreateResponse<PaginationSet<JobViewModel>>(HttpStatusCode.OK, pagedSet);

        //    return response;
        //    //});
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("AddJob")]
        //public IActionResult AddJob( JobViewModel Job)
        //{
        //    _adminApi.AddJob(Job.ReverseMap());

        //    var response = request.CreateResponse(HttpStatusCode.OK);

        //    return response;
        //}

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("GetJobs")]
        //public IActionResult GetJobs()
        //{
        //    var records = _adminApi.GetJobs();

        //    var jobvm = JobViewModel.MultipleJobMap(records);

        //    var response = request.CreateResponse(HttpStatusCode.OK, jobvm);

        //    return response;
        //}

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("GetJob")]
        //public IActionResult GetJob( int Id)
        //{
        //    var account = _adminApi.GetJobByID(Id);

        //    JobViewModel accTypeVM = new JobViewModel();
        //    accTypeVM.MapSingleJob(account);

        //    var response = request.CreateResponse(HttpStatusCode.OK, accTypeVM);

        //    return response;
        //}


        //[AllowAnonymous]
        //[HttpDelete]
        //[Route("RemoveJob")]
        //public IActionResult DeleteJob( int Id)
        //{
        //    _adminApi.DeleteJob(Id);

        //    var response = request.CreateResponse(HttpStatusCode.OK);

        //    return response;
        //}

        //[AllowAnonymous]
        //[HttpPut]
        //[Route("UpdateJob")]
        //public IActionResult UpdateJob( JobViewModel job)
        //{
        //    var newJob = job.ReverseMap();

        //    _adminApi.UpdateJob(newJob);

        //    var jobVm = new JobViewModel(newJob);

        //    var response = request.CreateResponse(HttpStatusCode.Created, jobVm);

        //    return response;
        //}

        #endregion

    }
}
