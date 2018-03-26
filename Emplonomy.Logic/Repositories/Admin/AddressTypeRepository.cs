using System;
using System.Collections.Generic;
using System.Linq;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Emplonomy.Logic.Repositories
{
    public class AddressTypeRepository : EntityBaseRepository<AddressType>, IAddressTypeRepository
    {
        private readonly EmplonomyContext _context;

        public AddressTypeRepository(EmplonomyContext context)
        : base(context)
        {
            this._context = context;
        }

        public AddressType GetAddressType(int id)
        {
            return FindSingle(subject => subject.ID == id);
        }

        public List<AddressType> GetAddressTypes()
        {
            return LoadAll();
        }

        public AddressType GetAddressType(string name)
        {
            return FindSingle(a => a.AddressTypeDesc.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public int CountAddressTypes()
        {
            return _context.Set<AddressType>().Count();
        }

        public void AddAddressType(AddressType AddressType)
        {
            Add(AddressType);
            Commit();
        }

        public void DeleteAddressType(int Id)
        {
            DeleteWhere(c => c.ID == Id);
            Commit();
        }

        public void UpdateAddressType(AddressType AddressType)
        {
            Update(AddressType);
            Commit();
        }

        public AddressType AssignAddressTypeDeletedRestored(int id, bool del)
        {
            var AddressType = FindSingle(a => a.ID == id);
            if (AddressType != null)
            {
                AddressType.isDeleted = del;
                Commit();
            }
            return AddressType;
        }

        public List<AddressType> getDeletedAddressTypes(bool deleted)
        {
            var AddressType = _context.Set<AddressType>()
            .Where(x => x.isDeleted == deleted)
            .ToList();

            return AddressType;
        }

        public List<AddressType> GetAddressTypesOrdered(int currentPage, int currentPageSize, string filter = null)
        {
            var record = _context.Set<AddressType>()
               .Include(s => s.UserAddresses)
               .OrderBy(c => c.ID)
                    .Where(
                        c => c.isDeleted == false &&
                        c.AddressTypeDesc.ToLower().Contains(filter))
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();               

            return record;
        }
    }
}
