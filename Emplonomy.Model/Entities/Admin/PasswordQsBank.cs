using System.Collections.Generic;

namespace Emplonomy.Model
{
    public class PasswordQsBank : IEntityBase
    {
        public PasswordQsBank()
        {
            Users = new List<EmplonomyUser>();
        }
        public int ID { get; set; }
        public string PasswordQuestion { get; set; }
        public bool? isDeleted { get; set; }

        public virtual ICollection<EmplonomyUser> Users { get; set; }
    }
}
