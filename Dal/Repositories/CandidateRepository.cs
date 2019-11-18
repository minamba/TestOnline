using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Models;
using Business.Repositories;
using coreEntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class CandidateRepository : ICandidatesRepository
    {
        public MyFirstFullStackApp_DevContext _context { get; set; }
        private readonly IMapper _mapper;

        public CandidateRepository(MyFirstFullStackApp_DevContext dbcontext, IMapper mapper)
        {
            _mapper = mapper;  
            _context = dbcontext;
        }

        public async Task<List<CandidateModel>> GetCandidatesAsync()
        {
            var candidateEntity = await _context.Candidate.Include(c => c.Test).Include(c => c.Result).ToListAsync();
            var candidateModel = candidateEntity.Select(c => new CandidateModel
            {
                LastName = c.LastName,
                FirstName = c.FirstName,
                Test = new TestModel ()
                {
                    Title = c.Test.Title
                },
                Result = c.Result.Select(r => new ResultModel
                {
                   AnswerId = r.AnswerId
                })
            }).ToList();

            return candidateModel;
        }

        public async Task<List<TestModel>> GetTestsAsync()
        {
            var testEntity = await _context.Test.Include(c => c.TestQuestion).ToListAsync();
            var testModel = testEntity.Select(t => new TestModel
            {
                Title = t.Title,
                QuestionId = t.Id,
                QuestionsNumber = t.TestQuestion.Count
            }).ToList();

            return testModel;
        }


        public async Task<List<AnswerModel>> GetAnswersAsync()
        {
            var answerEntity = await _context.Answer.ToListAsync();
            var answerModel = answerEntity.Select(a => new AnswerModel
            {
                Id = a.Id,
                QuestionId = a.QuestionId,
                Code = a.Code,
                IsGood = a.IsGood,
                Label = a.Label
            }).ToList();

            return answerModel;
        }

        //// Get old result
        //public async Task<List<ResultModel>> GetResultsAsync()
        //{
        //    var resultEntity = await _context.Result.Include(r => r.Answer).ToListAsync();
        //    var resultModel = resultEntity.Select(r => new ResultModel
        //    {
        //        AnswerId = r.AnswerId,
        //        IsGood = r.Answer == null ? false : r.Answer.IsGood
        //        //IsGood = r.Answer?.IsGood // Idem que la ligne, nouveauté de C# 7.???
        //    }).ToList();

        //    return resultModel;
        //}
    }
}

