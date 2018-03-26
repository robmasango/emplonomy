namespace Emplonomy.Model
{
    public class Provisioned : IEntityBase
    {
        public int ID { get; set; }
        public string EmailAddress { get; set; }
        public int RoleID { get; set; }
        public bool? isDeleted { get; set; }

    }
}
