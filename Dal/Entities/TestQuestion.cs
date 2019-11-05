using System;
using System.Collections.Generic;

namespace Dal.Entities
{
    public partial class TestQuestion
    {
        public int Id { get; set; }
        public int? TestId { get; set; }
        public int? QuestionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual Test Test { get; set; }
    }
}
