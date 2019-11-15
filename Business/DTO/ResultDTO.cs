﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ResultDTO
    {
        public int? CandidateId { get; set; }
        public int? AnswerId { get; set; }
        public int? IsGood { get; set; }

        public ResultDTO()
        { }

        public ResultDTO(int? candidateId, int? answerId, int? isGood)
        {
            CandidateId = candidateId;
            AnswerId = answerId;
            IsGood = isGood;
        }

 
    }


}
