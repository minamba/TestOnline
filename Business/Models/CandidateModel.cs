using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class CandidateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? TestId { get; set; }


        public CandidateModel(string firstName, string lastName, int testId)
        {
            FirstName = firstName;
            LastName = lastName;
            TestId = testId;

        }
    }
}
