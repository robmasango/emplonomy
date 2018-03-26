using System;
using System.Collections.Generic;
using System.Linq;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Emplonomy.Logic.Repositories
{
    public class RoleRepository : EntityBaseRepository<Role>, IRoleRepository
    {
        private readonly EmplonomyContext _context;

        public RoleRepository(EmplonomyContext context)
        : base(context)
        {
            this._context = context;
        }

        public Role GetRole(int id)
        {
            return FindSingle(subject => subject.ID == id);
        }

        public List<Role> GetRoles()
        {
            return LoadAll();
        }

        public Role GetRole(string name)
        {
            return FindSingle(a => a.Description.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public int CountRoles()
        {
            return _context.Set<Role>().Count();
        }

        public void AddRole(Role Role)
        {
            Add(Role);
            Commit();
        }

        public void DeleteRole(int Id)
        {
            DeleteWhere(c => c.ID == Id);
            Commit();
        }

        public void UpdateRole(Role Role)
        {
            Update(Role);
            Commit();
        }

        public Role AssignRoleDeletedRestored(int id, bool del)
        {
            var Role = FindSingle(a => a.ID == id);
            if (Role != null)
            {
                Role.isDeleted = del;
                Commit();
            }
            return Role;
        }

        public List<Role> getDeletedRoles(bool deleted)
        {
            var Role = _context.Set<Role>()
            .Where(x => x.isDeleted == deleted)
            .ToList();

            return Role;
        }

        public List<Role> GetRolesOrdered(int currentPage, int currentPageSize, string filter = null)
        {
            var record = _context.Set<Role>()
               .OrderBy(c => c.ID)
                    .Where(
                        c => c.isDeleted == false &&
                        c.Description.ToLower().Contains(filter))
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            return record;
        }
    }
}