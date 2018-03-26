using System.Collections.Generic;

namespace Emplonomy.Model
{
    public class Survey : IEntityBase
    {
        public Survey()
        {
            SurveyResponses = new List<SurveyResponse>();
            SendShortMessages = new List<SendShortMessage>();
        }
        public int ID { get; set; }
        public int OrganisationID { get; set; }
        public int FrequencyID { get; set; }
        public string Title { get; set; }
        public int Version { get; set; }
        public bool? isDeleted { get; set; }

        public virtual Organisation Organisation { get; set; }
        public virtual SurveyFrequency SurveyFrequency { get; set; }

        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
        public virtual ICollection<SendShortMessage> SendShortMessages { get; set; }
    }
}
