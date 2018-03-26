using System;
using System.Collections.Generic;
using System.Linq;
using Emplonomy.Model;
using Emplonomy.Logic.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Emplonomy.Logic.Repositories
{
    public class ShortMessageRepository : EntityBaseRepository<ShortMessage>, IShortMessageRepository
    {
        private readonly EmplonomyContext _context;

        public ShortMessageRepository(EmplonomyContext context)
        : base(context)
        {
            this._context = context;
        }

        public ShortMessage GetShortMessage(int id)
        {
            return FindSingle(subject => subject.ID == id);
        }

        public List<ShortMessage> GetShortMessages()
        {
            return LoadAll();
        }

        public ShortMessage GetShortMessage(string name)
        {
            return FindSingle(a => a.smsText.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public int CountShortMessages()
        {
            return _context.Set<ShortMessage>().Count();
        }

        public void AddShortMessage(ShortMessage ShortMessage)
        {
            Add(ShortMessage);
            Commit();
        }

        public void DeleteShortMessage(int Id)
        {
            DeleteWhere(c => c.ID == Id);
            Commit();
        }

        public void UpdateShortMessage(ShortMessage ShortMessage)
        {
            Update(ShortMessage);
            Commit();
        }

        public ShortMessage AssignShortMessageDeletedRestored(int id, bool del)
        {
            var ShortMessage = FindSingle(a => a.ID == id);
            if (ShortMessage != null)
            {
                ShortMessage.isDeleted = del;
                Commit();
            }
            return ShortMessage;
        }

        public List<ShortMessage> getDeletedShortMessages(bool deleted)
        {
            var ShortMessage = _context.Set<ShortMessage>()
            .Where(x => x.isDeleted == deleted)
            .ToList();

            return ShortMessage;
        }

        public List<ShortMessage> GetShortMessagesOrdered(int currentPage, int currentPageSize, string filter = null)
        {
            var record = _context.Set<ShortMessage>()
               .Include(s => s.SendShortMessages)
               .OrderBy(c => c.ID)
                    .Where(
                        c => c.isDeleted == false &&
                        c.smsText.ToLower().Contains(filter))
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            return record;
        }
    }
}
