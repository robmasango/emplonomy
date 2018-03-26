using System.Collections.Generic;

namespace Emplonomy.Model
{
    public class Role : IEntityBase
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; }
        public decimal Val {get; set;}

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
