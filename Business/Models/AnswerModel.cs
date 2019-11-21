using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public int? IsGood { get; set; }


        public AnswerModel(int id, int questionId, string code, string label, int? isGood)
        {
            Id = id;
            QuestionId = questionId;
            Code = code;
            Label = label;
            IsGood = isGood;
        }

        public AnswerModel()
        {

        }
    }
}
