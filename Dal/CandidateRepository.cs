using Business.Repositories;
using coreEntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class CandidateRepository : ICandidatesRepository
    {
        public Task<List<Candidate>> GetCandidates()
        {
            using (var dbcontext = new MyFirstFullStackApp_DevContext()) {

                 var lcandidate = dbcontext.Candidate.ToListAsync();

                return lcandidate;
            }
        }
    }
}
