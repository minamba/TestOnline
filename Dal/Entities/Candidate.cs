using System;
using System.Collections.Generic;

namespace Dal.Entities
{
    public partial class Candidate
    {
        public Candidate()
        {
            Result = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? TestId { get; set; }

        public virtual Test Test { get; set; }
        public virtual ICollection<Result> Result { get; set; }


        public Candidate(string firstName , string lastName, int testId)
        {
            FirstName = firstName;
            LastName = lastName;
            TestId = testId;              
        }
    }
}
