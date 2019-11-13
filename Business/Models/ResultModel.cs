using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class ResultModel
    {
        public int? _CandidateId { get; set; }
        public int? _AnswerId { get; set; }

        public ResultModel(int? candidateId, int? answerId)
        {
            _CandidateId = candidateId;
            _AnswerId = answerId;
        }
    }


}
