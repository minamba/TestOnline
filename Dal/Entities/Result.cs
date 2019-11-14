using System;
using System.Collections.Generic;

namespace Dal.Entities
{
    public partial class Result
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? AnswerId { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual Candidate Candidate { get; set; }


        public Result(int? candidateId, int? answerId)
        {
            CandidateId = candidateId;
            AnswerId = answerId;
        }
    }
}
