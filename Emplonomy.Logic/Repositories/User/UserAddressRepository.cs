using System.Collections.Generic;
using System.Linq;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Emplonomy.Logic.Repositories
{
    public class UserAddressRepository : EntityBaseRepository<UserAddress>, IUserAddressRepository
    {
        private readonly EmplonomyContext _context;

        public UserAddressRepository(EmplonomyContext context)
            : base(context)
        {
            _context = context;
        }

        public UserAddress GetUserAddress(int userID)
        {
            var userAdd = _context.Set<UserAddress>()
                .Where(x => x.UserID == userID)
                .Include(c => c.EmplonomyUser)
                .Include(c => c.AddressType)
                .Include(c => c.City)
                .Include(c => c.Town)
                .Include(c => c.Province)
                .Include(c => c.Country)
                .FirstOrDefault();

            return userAdd;
        }
        public List<UserAddress> GetUserAddresses(int userId)
        {
            var userAdd = _context.Set<UserAddress>()
            .Where(x => x.UserID == userId)
            .Include(c => c.EmplonomyUser)
            .Include(c => c.AddressType)
            .Include(c => c.City)
            .Include(c => c.Town)
            .Include(c => c.Province)
            .Include(c => c.Country)
            .ToList();

            return userAdd;
        }

        public List<UserAddress> GetUserAddresses()
        {
            var userAdd = _context.Set<UserAddress>()
            .Include(c => c.EmplonomyUser)
            .Include(c => c.AddressType)
            .Include(c => c.City)
            .Include(c => c.Town)
            .Include(c => c.Province)
            .Include(c => c.Country)
            .ToList();

            return userAdd;
        }

        public UserAddress AssignUserAddressDeletedRestored(int id, bool del)
        {
            var userAdd = FindSingle(a => a.ID == id);
            if (userAdd != null)
            {
                userAdd.isDeleted = del;
            }
            return userAdd;
        }

        public List<UserAddress> getDeletedUserAddresses1(bool deleted)
        {
            var userAdd = _context.Set<UserAddress>()
            .Where(x => x.isDeleted == deleted)
            .ToList();

            return userAdd;
        }
        public List<UserAddress> getDeletedUserAddresses2(bool deleted)
        {
            var userAdd = _context.Set<UserAddress>()
            .Where(x => x.isDeleted == deleted)
            .Include(c => c.EmplonomyUser)
            .Include(c => c.AddressType)
            .Include(c => c.City)
            .Include(c => c.Town)
            .Include(c => c.Province)
            .Include(c => c.Country)
            .ToList();

            return userAdd;
        }

    }
}