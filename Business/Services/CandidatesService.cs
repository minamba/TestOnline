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

        public async Task<List<CandidateDTO>> GetCandidatesAsync()
        {
            var Candidates = await _repository.GetCandidatesAsync();

            return Candidates;
        }

        //public async Task<List<ResultModel>> GetResultsAsync()
        //{
        //    var results = await _repository.GetResultsAsync();

        //    return results;
        //}

        public async Task<List<CandidateDTO>> GetCandidatesWithNotes()
        {
            var candidates = this.GetCandidatesAsync();
            var note = 0;

            for (int i = 0; i < candidates.Result.Count; i++)
            {
                //do some stuff
            }


            return await candidates;

        }

    }
}
