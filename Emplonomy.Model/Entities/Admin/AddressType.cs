using System.Collections.Generic;

namespace Emplonomy.Model
{
    public class AddressType : IEntityBase
    {
        public AddressType()
        {
            UserAddresses = new List<UserAddress>();
        }
        public int ID { get; set; }
        public string AddressTypeDesc { get; set; }
        public bool? isDeleted { get; set; }

        public virtual List<UserAddress> UserAddresses { get; set; }

    }
}
