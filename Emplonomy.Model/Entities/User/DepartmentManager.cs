namespace Emplonomy.Model
{
  public partial class DepartmentManager :IEntityBase
    {

        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public int ManagerID { get; set; }
        public bool? isDeleted { get; set; }

        public virtual Department Department { get; set; }
        public virtual EmplonomyUser EmplonomyUser { get; set; }

    }
}
