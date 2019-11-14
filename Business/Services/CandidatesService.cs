using AutoMapper;
using Business.Models;
using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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



        public async Task<List<CandidateDTO>> GetCandidatesAsync()
        {
            var Candidates = await _repository.GetCandidatesAsync();

            return Candidates.ToList();
        }

        public async Task<List<ResultModel>> GetResultsAsync()
        {
            var results = await _repository.GetResultsAsync();

            return results;
        }


        public Task<List<CandidateDTO>> CalculCandidatesNotes()
        {
            throw new NotImplementedException();
        }
    }
}
