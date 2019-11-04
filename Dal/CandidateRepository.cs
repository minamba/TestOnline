using coreEntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Business.Repositories;

namespace Dal
{
    public class CandidateRepository : ICandidatesRepository
    {
         public async Task<List<CandidateModel>> GetCandidatesAsync()
        {
            using (var dbcontext = new MyFirstFullStackApp_DevContext()) {

                var candidateEntity = await dbcontext.Candidate.ToListAsync();
                var CandidateModel = candidateEntity.Select(c => new CandidateModel(c.FirstName,c.LastName,(int)c.TestId));

                return CandidateModel.ToList();
            }
        }
    }
}
