namespace Emplonomy.Model
{
    public class SendShortMessage : IEntityBase
    {

        public int ID { get; set; }
        public int smsID { get; set; }
        public int SurveyID { get; set; }
        public int smsStatusID { get; set; }
        public bool? isDeleted { get; set; }

        public virtual SendSmsStatus SendSmsStatus { get; set; }
        public virtual ShortMessage ShortMessage { get; set; }
        public virtual Survey Survey { get; set; }
    }
}