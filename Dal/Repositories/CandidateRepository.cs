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
            var candidateEntity = await _MyContext.Candidate.ToListAsync();
            var candidateModel = new List<CandidateDTO>();
            var ResultModel = new List<ResultModel>();

            for (int i = 0; i < candidateEntity.Count; i++)
            {
                var result = (from r in _MyContext.Result
                              where r.CandidateId == candidateEntity[i].Id
                              select r).ToList();

                ResultModel = result.Select(r => new ResultModel(r.CandidateId, r.AnswerId)).ToList();
                candidateModel = candidateEntity.Select(c => new CandidateDTO(c.FirstName = candidateEntity[i].FirstName, c.LastName = candidateEntity[i].LastName, c.Test.Title = candidateEntity[i].Test.Title, ResultModel)).ToList();
            }

            //return _mapper.Map<List<CandidateDTO>>(candidateEntity);
            return candidateModel;
        }
    }
}

