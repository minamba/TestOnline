namespace Business.Models
{
    public class ResultModel
    {
        public int? AnswerId { get; set; }
        public bool? IsGood { get; set; }

        public ResultModel(int? answerID, bool? isGood)
        {
            AnswerId = answerID;
            IsGood = isGood;
        }

        public ResultModel()
        {}
    }
}
