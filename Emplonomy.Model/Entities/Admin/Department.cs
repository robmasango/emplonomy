using System.Collections.Generic;

namespace Emplonomy.Model
{
    public class Department : IEntityBase
    {
        public Department()
        {
            DepartmentManagers = new List<DepartmentManager>();
            Users = new List<EmplonomyUser>();
        }
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public int OrganisationID { get; set; }
        public bool? isDeleted { get; set; }

        public virtual Organisation Organisation { get; set; }
        public virtual ICollection<DepartmentManager> DepartmentManagers { get; set; }
        public virtual ICollection<EmplonomyUser> Users { get; set; }
    }
}
