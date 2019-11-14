using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class ResultModel
    {
        public int? CandidateId { get; set; }
        public int? AnswerId { get; set; }
        public int? IsGood { get; set; }

        public ResultModel(int? candidateId, int? answerId, int? isGood)
        {
            CandidateId = candidateId;
            AnswerId = answerId;
            IsGood = isGood;
        }
    }


}
