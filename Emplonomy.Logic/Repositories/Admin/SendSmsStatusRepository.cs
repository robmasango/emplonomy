using System;
using System.Collections.Generic;
using System.Linq;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Emplonomy.Logic.Repositories
{
    public class SendSmsStatusRepository : EntityBaseRepository<SendSmsStatus>, ISendSmsStatusRepository
    {
        private readonly EmplonomyContext _context;

        public SendSmsStatusRepository(EmplonomyContext context)
        : base(context)
        {
            this._context = context;
        }

        public SendSmsStatus GetSendSmsStatus(int id)
        {
            return FindSingle(subject => subject.ID == id);
        }

        public List<SendSmsStatus> GetSendSmsStatuss()
        {
            return LoadAll();
        }

        public SendSmsStatus GetSendSmsStatus(string name)
        {
            return FindSingle(a => a.StatusDesc.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public int CountSendSmsStatuss()
        {
            return _context.Set<SendSmsStatus>().Count();
        }

        public void AddSendSmsStatus(SendSmsStatus SendSmsStatus)
        {
            Add(SendSmsStatus);
            Commit();
        }

        public void DeleteSendSmsStatus(int Id)
        {
            DeleteWhere(c => c.ID == Id);
            Commit();
        }

        public void UpdateSendSmsStatus(SendSmsStatus SendSmsStatus)
        {
            Update(SendSmsStatus);
            Commit();
        }

        public SendSmsStatus AssignSendSmsStatusDeletedRestored(int id, bool del)
        {
            var SendSmsStatus = FindSingle(a => a.ID == id);
            if (SendSmsStatus != null)
            {
                SendSmsStatus.isDeleted = del;
                Commit();
            }
            return SendSmsStatus;
        }

        public List<SendSmsStatus> getDeletedSendSmsStatuss(bool deleted)
        {
            var SendSmsStatus = _context.Set<SendSmsStatus>()
            .Where(x => x.isDeleted == deleted)
            .ToList();

            return SendSmsStatus;
        }

        public List<SendSmsStatus> GetSendSmsStatussOrdered(int currentPage, int currentPageSize, string filter = null)
        {
            var record = _context.Set<SendSmsStatus>()
               .Include(s => s.SendShortMessages)
               .OrderBy(c => c.ID)
                    .Where(
                        c => c.isDeleted == false &&
                        c.StatusDesc.ToLower().Contains(filter))
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            return record;
        }
    }
}
