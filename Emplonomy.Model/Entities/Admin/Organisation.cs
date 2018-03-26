using System.Collections.Generic;

namespace Emplonomy.Model
{
  public partial class Organisation : IEntityBase
    {
        public Organisation()
        {
            Departments = new HashSet<Department>();
            OrganisationManagers = new HashSet<OrganisationManager>();
            Surveys = new HashSet<Survey>();
        }

        public int ID { get; set; }
        public int LocationID { get; set; }
        public string OrganisationName { get; set; }
        public string Industry { get; set; }
        public bool? isDeleted { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<OrganisationManager> OrganisationManagers { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual Location Location { get; set; }

    }
}
