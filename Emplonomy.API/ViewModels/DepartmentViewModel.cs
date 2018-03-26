using Emplonomy.Model;
using System.Collections.Generic;
using System.Linq;

namespace Emplonomy.Web.ViewModels
{
    public class DepartmentViewModel
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public int OrganisationID { get; set; }
        public string OrganisationName { get; set; }
        public bool? isDeleted { get; set; }

        public DepartmentViewModel()
        {
        }

        public DepartmentViewModel(Department i)
        {
            MapSingleDepartment(i);
        }

        public DepartmentViewModel MapSingleDepartment(Department department)
        {
            ID = department.ID;
            DepartmentName = department.DepartmentName;
            OrganisationID = department.OrganisationID;
            isDeleted = department.isDeleted;

            return this;
        }

        public Department ReverseMap()
        {
            var department = new Department
            {
                ID = this.ID,
                DepartmentName = this.DepartmentName,
                OrganisationID = this.OrganisationID,
                isDeleted = this.isDeleted,
            };
            return department;
        }

        public DepartmentViewModel ReverseMap(Department department)
        {
            return new DepartmentViewModel()
            {
            ID = department.ID,
            DepartmentName = department.DepartmentName,
            OrganisationID = department.OrganisationID,
            isDeleted = department.isDeleted,
            };
        }

        public static List<DepartmentViewModel> ReverseMapDepartments(List<Department> departments)
        {
            var departmentViewModel = new DepartmentViewModel();

            return departments.Select(department => departmentViewModel.ReverseMap(department)).ToList();
        }

        public static List<DepartmentViewModel> MultipleDepartmentMap(List<Department> departments)
        {
            List<DepartmentViewModel> departmentVM = new List<DepartmentViewModel>();
            foreach (var s in departments)
            {
                DepartmentViewModel sVm = new DepartmentViewModel(s);
                departmentVM.Add(sVm);
            }
            return departmentVM;
        }
    }

}