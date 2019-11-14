﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class ResultModel
    {
        public int? CandidateId { get; set; }
        public int? AnswerId { get; set; }

        public ResultModel(int? candidateId, int? answerId)
        {
            CandidateId = candidateId;
            AnswerId = answerId;
        }
    }


}
