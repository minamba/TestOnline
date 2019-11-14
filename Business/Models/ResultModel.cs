using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class ResultModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AnswerId { get; set; }

        public ResultModel(string firstName, string lastName, int? answerId)
        {
            FirstName = firstName;
            LastName = lastName;
            AnswerId = answerId;
        }
    }


}
