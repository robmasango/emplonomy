using System.Collections.Generic;
using System.Linq;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Emplonomy.Logic.Repositories
{
    public class DepartmentManagerRepository :  EntityBaseRepository<DepartmentManager>, IDepartmentManagerRepository
    {
        private readonly EmplonomyContext _context;

        public DepartmentManagerRepository(EmplonomyContext context)
      : base(context)
    {
            this._context = context;
        }

        public DepartmentManager GetDepartmentManager(int id)
        {
            return FindSingle(subject => subject.ID == id);
        }

        public DepartmentManager GetDepartmentManagerByDepID(int id)
        {
            return FindSingle(subject => subject.DepartmentID == id);
        }

        public DepartmentManager GetDepartmentManagerByMagrID(int id)
        {
            return FindSingle(subject => subject.ManagerID == id);
        }

        public List<DepartmentManager> GetDepartmentManagers()
        {
            return LoadAll();
        }

        public DepartmentManager GetSpecificDepartmentManager(int depid, int empId, bool del)
        {
            var depMan = _context.Set<DepartmentManager>()
             .Where(x => x.DepartmentID == depid && x.ManagerID == empId && x.isDeleted == del)
             .ToList();

            return depMan.LastOrDefault();
        }

        public DepartmentManager AssignDepartmentManagerDeletedRestored(int id, bool del)
        {
            var depmagr = FindSingle(a => a.ID == id);
            if (depmagr != null)
            {
                depmagr.isDeleted = del;
            }
            return depmagr;
        }

        public List<DepartmentManager> getDeletedDepartmentManagers(bool deleted)
        {
            var depmagr = _context.Set<DepartmentManager>()
            .Where(x => x.isDeleted == deleted)
            .ToList();

            return depmagr;
        }
        public List<DepartmentManager> GetDepartmentManagerOrdered(string filter = null)
        {
            var deptmangr = _context.Set<DepartmentManager>()
            .Include(e => e.EmplonomyUser)
            .Include(e => e.Department)
            .OrderBy(c => c.ID)
            .Where(
                c => c.isDeleted == false &&
                c.EmplonomyUser.LastName.ToLower().Contains(filter) ||
                c.EmplonomyUser.FirstName.ToLower().Contains(filter) ||
                c.Department.DepartmentName.ToLower().Contains(filter)
                )
            .ToList();

            return deptmangr;
        }

        public int CountDepartmentManagers()
        {
            return _context.Set<DepartmentManager>().Count();
        }

        public void AddDepartmentManager(DepartmentManager dep)
        {
            Add(dep);
            Commit();
        }

        public void DeleteDepartmentManager(int Id)
        {
            DeleteWhere(c => c.ID == Id);
            Commit();
        }

        public void UpdateDepartmentManager(DepartmentManager dep)
        {
            Update(dep);
            Commit();
        }
    }
}
