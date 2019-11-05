using System;
using System.Collections.Generic;

namespace Dal.Entities
{
    public partial class Answer
    {
        public Answer()
        {
            Result = new HashSet<Result>();
        }

        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public int? IsGood { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}
