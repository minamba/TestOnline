using Business.Services;
using coreEntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class CandidatesService : ICandidatesService
    {
        private ICandidatesRepository _repository;

        public Task<List<Candidate>> GetCandidates()
        {
            return _repository.GetCandidates();
        }
    }
}
