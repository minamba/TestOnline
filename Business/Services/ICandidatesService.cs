using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICandidatesService
    {
        Task<List<CandidateDTO>> GetCandidatesAsync();
        Task<List<CandidateDTO>> CalculCandidatesNotes();
    }
}
