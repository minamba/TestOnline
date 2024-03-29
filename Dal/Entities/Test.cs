﻿using System;
using System.Collections.Generic;

namespace Dal.Entities
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



        public Test(int id, string title)
        {
            Id = id;
            Title = title;
        }
        
    }
}
