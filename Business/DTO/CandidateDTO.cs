using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class CandidateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TestName { get; set; }
        public int Note { get; set; }

        public CandidateDTO()
        {}

        public CandidateDTO(string firstName, string lastName, string testName, int note)
        {
            FirstName = firstName;
            LastName = lastName;
            TestName = testName;
            Note = note;
        }
    }
}
