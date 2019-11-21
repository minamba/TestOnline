using System.Collections.Generic;

namespace Business.Models
{
    public class Candidate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TestModel Test { get; set; }
        public IEnumerable<ResultModel> Result { get; set; }


        public Candidate(string firstName, string lastName, TestModel test, IEnumerable<ResultModel> result)
        {
            FirstName = firstName;
            LastName = lastName;
            Test = test;
            Result = result;
        }

        public Candidate()
        { }
    }
}
