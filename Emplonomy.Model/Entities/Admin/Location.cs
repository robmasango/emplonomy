using System.Collections.Generic;

namespace Emplonomy.Model
{
    public partial class Location : IEntityBase
    {
        public Location()
        {
            Organisations = new HashSet<Organisation>();
        }
        public int ID { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool? isDeleted { get; set; }

        public virtual ICollection<Organisation> Organisations { get; set; }
    }
}
