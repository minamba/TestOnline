using System.Collections.Generic;

namespace Business.Models
{
    public class CandidateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TestModel Test { get; set; }
        public IEnumerable<ResultModel> Result { get; set; }
    }
}
