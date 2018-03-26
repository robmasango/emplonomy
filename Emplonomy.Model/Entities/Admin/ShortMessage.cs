using System.Collections.Generic;

namespace Emplonomy.Model
{
    public  class ShortMessage : IEntityBase
    {
        public ShortMessage()
        {
            SendShortMessages = new List<SendShortMessage>();
        }
        public int ID { get; set; }
        public string smsText { get; set; }
        public bool? isDeleted { get; set; }

        public virtual ICollection<SendShortMessage> SendShortMessages { get; set; }
    }
}
