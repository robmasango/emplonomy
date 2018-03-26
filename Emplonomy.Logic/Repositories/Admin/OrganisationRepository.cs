using System.Collections.Generic;
using System.Linq;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;
using System;
using Microsoft.EntityFrameworkCore;

namespace Emplonomy.Logic.Repositories
{
    public class OrganisationRepository : EntityBaseRepository<Organisation>, IOrganisationRepository
    {
        private readonly EmplonomyContext _context;

        public OrganisationRepository(EmplonomyContext context)
        : base(context)
        {
            this._context = context;
        }

        public Organisation GetOrganisation(int id)
        {
            return FindSingle(subject => subject.ID == id);
        }


        public List<Organisation> GetOrganisations()
        {
            var organisations = _context.Set<Organisation>()
            .ToList();

            return organisations;
        }

        public Organisation GetOrganisation(string Org)
        {
            return FindSingle(a => a.OrganisationName.Equals(Org, StringComparison.OrdinalIgnoreCase));
        }

        public int CountOrganisations()
        {
            return _context.Set<Organisation>().Count();
        }

        public void AddOrganisation(Organisation org)
        {
            Add(org);
            Commit();
        }

        public void DeleteOrganisation(int Id)
        {
            DeleteWhere(c => c.ID == Id);
            Commit();
        }

        public void UpdateOrganisation(Organisation org)
        {
            Update(org);
            Commit();
        }

        public Organisation AssignOrganisationDeletedRestored(int id, bool del)
        {
            var organisation = FindSingle(a => a.ID == id);
            if (organisation != null)
            {
                organisation.isDeleted = del;
            }
            return organisation;
        }

        public List<Organisation> getDeletedOrganisations(bool deleted)
        {
            var organisation = _context.Set<Organisation>()
            .Where(x => x.isDeleted == deleted)
            .ToList();

            return organisation;
        }

        public List<Organisation> GetOrganisationsOrdered(int currentPage, int currentPageSize, string filter = null)
        {
            var record = _context.Set<Organisation>()
               .Include(s => s.Departments)
               .Include(s => s.OrganisationManagers)
               .Include(s => s.Location)
               .OrderBy(c => c.ID)
                    .Where(
                        c => c.isDeleted == false &&
                        c.OrganisationName.ToLower().Contains(filter))
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            return record;
        }

    }
}
