using coreEntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Business.Repositories;
using Dal.Entities;

namespace Dal.Repositories
{
    public class CandidateRepository : ICandidatesRepository
    {

        public MyFirstFullStackApp_DevContext _MyContext { get; set; }

        public CandidateRepository(MyFirstFullStackApp_DevContext dbcontext)
        {
            _MyContext = dbcontext;
        }


        public async Task<List<CandidateModel>> GetCandidatesAsync()
        {
            var candidateEntity = await _MyContext.Candidate.ToListAsync();
            var CandidateModel = candidateEntity.Select(c => new CandidateModel(c.FirstName, c.LastName, (int)c.TestId));
            return CandidateModel.ToList();
        }
    }
}
