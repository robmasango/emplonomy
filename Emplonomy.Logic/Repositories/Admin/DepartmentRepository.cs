using System;
using System.Collections.Generic;
using System.Linq;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Emplonomy.Logic.Repositories
{

    public class DepartmentRepository : EntityBaseRepository<Department>, IDepartmentRepository
    {
        private readonly EmplonomyContext _context;
        public DepartmentRepository(EmplonomyContext context)
            : base(context)
        {
            this._context = context;
        }


        public Department GetDepartment(int id)
        {
            return FindSingle(dep => dep.ID == id);
        }


        public Department GetTop1Department(string dep, int orgId, bool del)
        {
            var department = _context.Set<Department>()
             .Where(x => x.DepartmentName == dep && x.OrganisationID == orgId && x.isDeleted == del)
             .ToList();

            return department.LastOrDefault();
        }
        public Department GetDepartmentOrgID(int id)
        {
            return FindSingle(dep => dep.OrganisationID == id);
        }

        public List<Department> GetDepartments()
        {
                var departments = _context.Set<Department>()
                .Include(c => c.Organisation)
                .ToList();

                return departments;
         }

        public Department GetDepartment(string name)
        {
            return FindSingle(a => a.DepartmentName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public int CountDepartments()
        {
            return _context.Set<Department>().Count();
        }

        public void AddDepartment(Department dep)
        {
            Add(dep);
            Commit();
        }

        public void DeleteDepartment(int Id)
        {
            DeleteWhere(c => c.ID == Id);
            Commit();
        }

        public void UpdateDepartment(Department dep)
        {
            Update(dep);
            Commit();
        }

        public Department AssignDepartmentDeletedRestored(int id, bool del)
        {
            var dept = FindSingle(a => a.ID == id);
            if (dept != null)
            {
                dept.isDeleted = del;
            }
            return dept;
        }

        public List<Department> getDeletedDepartments(bool deleted)
        {
            var dept = _context.Set<Department>()
            .Where(x => x.isDeleted == deleted)
            .ToList();

            return dept;
        }

        public List<Department> GetDepartmentsOrdered(int currentPage, int currentPageSize, string filter = null)
        {
            var record = _context.Set<Department>()
               .Include(s => s.Organisation)
               .Include(s => s.DepartmentManagers)
               .OrderBy(c => c.ID)
                    .Where(
                        c => c.isDeleted == false &&
                        c.DepartmentName.ToLower().Contains(filter))
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            return record;
        }


    }
}
