using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICandidatesService
    {
        Task<List<CandidateDTO>> GetCandidatesAsync();
        Task<double> GetAverageAsync();
        Task<double> GetEcartTypeAsync();
        //Task<List<CandidateDTO>> CalculCandidatesNotes();
    }
}
