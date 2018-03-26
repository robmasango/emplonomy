namespace Emplonomy.Model
{
  public partial class OrganisationManager :IEntityBase
    {
        public int ID { get; set; }
        public int OrganisationID { get; set; }
        public int ManagerID { get; set; }
        public bool? isDeleted { get; set; }

        public virtual Organisation Organisation { get; set; }
        public virtual EmplonomyUser EmplonomyUser { get; set; }

    }
}
