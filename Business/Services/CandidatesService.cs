using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;

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
            var candidates = await _repository.GetCandidatesAsync();
            var tests = await _repository.GetTestsAsync();

            // TODO call CalculCandidatesNotes


            return candidates.Select(c => new CandidateDTO
            {
                // TODO remplir les champs utiles
            }).ToList();
        }

        public async Task<List<CandidateDTO>> CalculCandidatesNotes()
        {
            return null;
        }
    }
}
