using System;
using System.Collections.Generic;

namespace coreEntityFramework
{
    public partial class Test
    {
        public Test()
        {
            Candidate = new HashSet<Candidate>();
            TestQuestion = new HashSet<TestQuestion>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
        public virtual ICollection<TestQuestion> TestQuestion { get; set; }
    }
}
