using System.Collections.Generic;
using System.Linq;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Emplonomy.Logic.Repositories
{
    public class OrganisationManagerRepository : EntityBaseRepository<OrganisationManager>, IOrganisationManagerRepository
    {
        private readonly EmplonomyContext _context;

        public OrganisationManagerRepository(EmplonomyContext context)
      : base(context)
        {
            this._context = context;
        }

        public OrganisationManager GetOrganisationManager(int id)
        {
            return FindSingle(subject => subject.ID == id);
        }

        public List<OrganisationManager> GetOrganisationManagers()
        {
            return LoadAll();
        }

        public OrganisationManager AssignOrganisationManagerDeletedRestored(int id, bool del)
        {
            var orgmagr = FindSingle(a => a.ID == id);
            if (orgmagr != null)
            {
                orgmagr.isDeleted = del;
            }
            return orgmagr;
        }

        public List<OrganisationManager> getDeletedOrganisationManagers(bool deleted)
        {
            var orgmagr = _context.Set<OrganisationManager>()
            .Where(x => x.isDeleted == deleted)
            .ToList();

            return orgmagr;
        }

        public List<OrganisationManager> GetOrganisationManagerOrdered(string filter = null)
        {
            var deptmangr = _context.Set<OrganisationManager>()
            .Include(e => e.EmplonomyUser)
            .Include(e => e.Organisation)
            .OrderBy(c => c.ID)
            .Where(
                c => c.isDeleted == false &&
                c.EmplonomyUser.LastName.ToLower().Contains(filter) ||
                c.EmplonomyUser.FirstName.ToLower().Contains(filter) ||
                c.Organisation.OrganisationName.ToLower().Contains(filter) ||
                c.Organisation.Industry.ToLower().Contains(filter)
                )
            .ToList();

            return deptmangr;
        }
    }
}
