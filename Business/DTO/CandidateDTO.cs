using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class CandidateDTO
    {
        public string _FirstName { get; set; }
        public string _LastName { get; set; }
        public string _TestName { get; set; }
        public List<ResultModel> _CandidateResult { get; set; }

        public CandidateDTO(string firstName, string lastName, string testName, List<ResultModel> candidateResult)
        {
            _FirstName = firstName;
            _LastName = lastName;
            _TestName = testName;
            _CandidateResult = candidateResult;
        }
    }
}
