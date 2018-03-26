using System.Collections.Generic;

namespace Emplonomy.Model
{
    public class SurveyQuestion : IEntityBase
    {
        public SurveyQuestion()
        {
            SurveyResponses = new List<SurveyResponse>();
        }
        public int ID { get; set; }
        public string Driver { get; set; }
        public string SubDriver { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; } //Unique or Standard
        public int QuestionOrder { get; set; }
        public bool? isDeleted { get; set; }

        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
    }
}
