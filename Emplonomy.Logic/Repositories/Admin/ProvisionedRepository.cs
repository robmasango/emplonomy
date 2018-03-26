using System;
using System.Collections.Generic;
using System.Linq;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;

namespace Emplonomy.Logic.Repositories
{
    public class ProvisionedRepository : EntityBaseRepository<Provisioned>, IProvisionedRepository
    {

        private readonly EmplonomyContext _context;

        public ProvisionedRepository(EmplonomyContext context)
      : base(context)
       {
            this._context = context;
        }

        public Provisioned GetProvisioned(int id)
        {
            return FindSingle(subject => subject.ID == id);
        }

        public List<Provisioned> GetProvisioneds()
        {
            return LoadAll();
        }

        public Provisioned GetProvisioned(string name)
        {
            return FindSingle(a => a.EmailAddress.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public int CountProvisioned()
        {
            return _context.Set<Provisioned>().Count();
        }

        public void AddProvisioned(Provisioned Provisioned)
        {
            Add(Provisioned);
            Commit();
        }

        public void DeleteProvisioned(int Id)
        {
            DeleteWhere(c => c.ID == Id);
            Commit();
        }

        public void UpdateProvisioned(Provisioned Provisioned)
        {
            Update(Provisioned);
            Commit();
        }

        public Provisioned AssignProvisionedDeletedRestored(int id, bool del)
        {
            var Provisioned = FindSingle(a => a.ID == id);
            if (Provisioned != null)
            {
                Provisioned.isDeleted = del;
                Commit();
            }
            return Provisioned;
        }

        public List<Provisioned> getDeletedProvisioneds(bool deleted)
        {
            var Provisioned = _context.Set<Provisioned>()
            .Where(x => x.isDeleted == deleted)
            .ToList();

            return Provisioned;
        }

        public List<Provisioned> GetProvisionedsOrdered(int currentPage, int currentPageSize, string filter = null)
        {
            var record = _context.Set<Provisioned>()
               .OrderBy(c => c.ID)
                    .Where(
                        c => c.isDeleted == false &&
                        c.EmailAddress.ToLower().Contains(filter))
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            return record;
        }
    }
}