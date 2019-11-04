using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class CandidateModel
    {
        public string _FirstName { get; set; }
        public string _LastName { get; set; }
        public int? _TestId { get; set; }


        public CandidateModel(string firstName, string lastName, int testId)
        {
            _FirstName = firstName;
            _LastName = lastName;
            _TestId = testId;

        }
    }
}
