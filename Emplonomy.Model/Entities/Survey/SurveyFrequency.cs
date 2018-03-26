using System.Collections.Generic;

namespace Emplonomy.Model
{
    public class SurveyFrequency : IEntityBase
    { 
        public SurveyFrequency()
        {
            Surveys = new List<Survey>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumQuestions { get; set; }
        public bool? isDeleted { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
