using System.Collections.Generic;

namespace Emplonomy.Model
{
    public  class SendSmsStatus : IEntityBase
    {
        public SendSmsStatus()
        {
            SendShortMessages = new List<SendShortMessage>();
        }
        public int ID { get; set; }
        public string StatusDesc { get; set; }
        public bool? isDeleted { get; set; }

        public virtual ICollection<SendShortMessage> SendShortMessages { get; set; }

    }
}
