using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Repositories
{
    public interface ICandidatesRepository
    {
        Task<List<Candidate>> GetCandidatesAsync();
        Task<List<TestModel>> GetTestsAsync();
        Task<List<AnswerModel>> GetAnswersAsync();
        Task<Candidate> AddCandidateTestAsync(Candidate candidate);
    }
}
