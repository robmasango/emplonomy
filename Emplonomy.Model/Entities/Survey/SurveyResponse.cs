namespace Emplonomy.Model
{
    public class SurveyResponse : IEntityBase
    {
        public int ID { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public int UserID { get; set; }
        public int Answer { get; set; }
        public bool? isDeleted { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual SurveyQuestion SurveyQuestion { get; set; }
        public virtual EmplonomyUser EmplonomyUser { get; set; }
    }
}
