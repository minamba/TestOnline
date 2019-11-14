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
using AutoMapper;
using Dal.Profile;
using Business;

namespace Dal.Repositories
{
    public class CandidateRepository : ICandidatesRepository
    {
        public MyFirstFullStackApp_DevContext _MyContext { get; set; }
        private readonly IMapper _mapper;


        public CandidateRepository(MyFirstFullStackApp_DevContext dbcontext, IMapper mapper)
        {
            _mapper = mapper;
            _MyContext = dbcontext;
        }


        public async Task<List<CandidateDTO>> GetCandidatesAsync()
        {
            var candidateEntity = await _MyContext.Candidate.Include("Test").Include("Result").ToListAsync();
            var candidateModel = candidateEntity.Select(c => new CandidateDTO(c.FirstName,c.LastName,c.Test.Title,0)).ToList();

            return _mapper.Map<List<CandidateDTO>>(candidateEntity);
        }


        public async Task<List<ResultModel>> GetResultsAsync()
        {
            var candidateResults = await _MyContext.Result.ToListAsync();
            var resultModel = candidateResults.Select(r => new ResultModel(r.Candidate.FirstName, r.Candidate.LastName, r.AnswerId)).ToList();

            return _mapper.Map<List<ResultModel>>(candidateResults);
        }

    }
}

