using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICandidatesService
    {
        Task<List<CandidateDTO>> GetCandidatesAsync();
        Task<List<ResultModel>> GetResultsAsync();
        Task<List<CandidateDTO>> CalculCandidatesNotes();
    }
}
