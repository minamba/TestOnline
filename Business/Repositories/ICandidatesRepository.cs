using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Repositories
{
    public interface ICandidatesRepository
    {
        Task<List<CandidateModel>> GetCandidatesAsync();
        Task<List<TestModel>> GetTestsAsync();
        Task<List<AnswerModel>> GetAnswersAsync();
    }
}
