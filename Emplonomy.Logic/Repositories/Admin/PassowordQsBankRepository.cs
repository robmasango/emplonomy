using System;
using System.Collections.Generic;
using System.Linq;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Emplonomy.Logic.Repositories
{
    public class PasswordQsBankRepository : EntityBaseRepository<PasswordQsBank>, IPasswordQsBankRepository
    {
        private readonly EmplonomyContext _context;

        public PasswordQsBankRepository(EmplonomyContext context)
        : base(context)
        {
            this._context = context;
        }

        public PasswordQsBank GetPasswordQsBank(int id)
        {
            return FindSingle(subject => subject.ID == id);
        }

        public List<PasswordQsBank> GetPasswordQsBanks()
        {
            return LoadAll();
        }

        public PasswordQsBank GetPasswordQsBank(string question)
        {
            return FindSingle(a => a.PasswordQuestion.Equals(question, StringComparison.OrdinalIgnoreCase));
        }

        public int CountPasswordQsBanks()
        {
            return _context.Set<PasswordQsBank>().Count();
        }

        public void AddPasswordQsBank(PasswordQsBank pass)
        {
            Add(pass);
            Commit();
        }

        public void DeletePasswordQsBank(int Id)
        {
            DeleteWhere(c => c.ID == Id);
            Commit();
        }

        public void UpdatePasswordQsBank(PasswordQsBank pass)
        {
            Update(pass);
            Commit();
        }

        public PasswordQsBank AssignPasswordQsBankDeletedRestored(int id, bool del)
        {
            var passQbank = FindSingle(a => a.ID == id);
            if (passQbank != null)
            {
                passQbank.isDeleted = del;
            }
            return passQbank;
        }

        public List<PasswordQsBank> getDeletedPasswordQsBanks(bool deleted)
        {
            var passQbank = _context.Set<PasswordQsBank>()
            .Where(x => x.isDeleted == deleted)
            .ToList();

            return passQbank;
        }


        public List<PasswordQsBank> GetPasswordQsBanksOrdered(int currentPage, int currentPageSize, string filter = null)
        {
            var record = _context.Set<PasswordQsBank>()
               .Include(s => s.Users)
               .OrderBy(c => c.ID)
                    .Where(
                        c => c.isDeleted == false &&
                        c.PasswordQuestion.ToLower().Contains(filter))
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            return record;
        }
    }
}
