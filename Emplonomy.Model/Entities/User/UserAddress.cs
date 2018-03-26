namespace Emplonomy.Model
{
    public class UserAddress : IEntityBase
    {

        public int ID { get; set; }
        public int UserID { get; set; }
        public int AddressTypeID { get; set; }
        public bool? PrefferedAddress  { get; set; }
        public string StreetAddress { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool? isDeleted { get; set; }

        public virtual EmplonomyUser EmplonomyUser { get; set; }
        public virtual AddressType AddressType { get; set; }
    }
}
