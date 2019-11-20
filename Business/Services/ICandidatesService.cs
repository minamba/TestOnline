
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICandidatesService
    {
        Task<List<CandidateDTO>> GetCandidatesAsync();
        Task<double> GetAverageAsync();
        Task<double> GetEcartTypeAsync();
        Task<CandidateDTO> AddCandidateTestAsync(string firstName, string lastName, string testName);
        //Task<List<CandidateDTO>> CalculCandidatesNotes();
    }
}
