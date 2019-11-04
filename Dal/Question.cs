using System;
using System.Collections.Generic;

namespace coreEntityFramework
{
    public partial class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
            TestQuestion = new HashSet<TestQuestion>();
        }

        public int Id { get; set; }
        public string Statement { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }
        public virtual ICollection<TestQuestion> TestQuestion { get; set; }
    }
}
