using AutoMapper;
using Business.Models;
using Business.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class CandidatesService : ICandidatesService
    {
        private ICandidatesRepository _repository;

        public CandidatesService(ICandidatesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CandidateModel>> GetCandidatesAsync()
        {
            var listCandidate = await _repository.GetCandidatesAsync();

            return listCandidate;
        }
    }
}
