using System;
using System.Collections.Generic;
using System.Linq;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Emplonomy.Logic.Repositories
{
    public class LocationRepository : EntityBaseRepository<Location>, ILocationRepository
    {
        private readonly EmplonomyContext _context;

        public LocationRepository(EmplonomyContext context)
        : base(context)
        {
            this._context = context;
        }

        public Location GetLocation(int id)
        {
            return FindSingle(subject => subject.ID == id);
        }

        public List<Location> GetLocations()
        {
            return LoadAll();
        }

        public Location GetLocation(string name)
        {
            return FindSingle(a => a.StreetName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public int CountLocations()
        {
            return _context.Set<Location>().Count();
        }

        public void AddLocation(Location Location)
        {
            Add(Location);
            Commit();
        }

        public void DeleteLocation(int Id)
        {
            DeleteWhere(c => c.ID == Id);
            Commit();
        }

        public void UpdateLocation(Location Location)
        {
            Update(Location);
            Commit();
        }

        public Location AssignLocationDeletedRestored(int id, bool del)
        {
            var Location = FindSingle(a => a.ID == id);
            if (Location != null)
            {
                Location.isDeleted = del;
                Commit();
            }
            return Location;
        }

        public List<Location> getDeletedLocations(bool deleted)
        {
            var Location = _context.Set<Location>()
            .Where(x => x.isDeleted == deleted)
            .ToList();

            return Location;
        }

        public List<Location> GetLocationsOrdered(int currentPage, int currentPageSize, string filter = null)
        {
            var record = _context.Set<Location>()
               .Include(s => s.Organisations)
               .OrderBy(c => c.ID)
                    .Where(
                        c => c.isDeleted == false &&
                        c.StreetName.ToLower().Contains(filter))
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            return record;
        }
    }
}
