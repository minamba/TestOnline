using Business.Repositories;
using coreEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class CandidateRepository : ICandidatesRepository
    {
        public List<Candidate> GetCandidates()
        {
            using (var dbcontext = new MyFirstFullStackApp_DevContext()) {

                var lcandidate = dbcontext.Candidate.ToList();

                return lcandidate;
            }
        }
    }
}
