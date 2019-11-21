using System.Collections.Generic;

namespace Business.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuestionId { get; set; }
        public int QuestionsNumber { get; set; }

        public TestModel(string title, int questionID, int questionsNumber)
        {
            Title = title;
            QuestionId = questionID;
            QuestionsNumber = questionsNumber;
        }

        public TestModel()
        {

        }
    }
}
