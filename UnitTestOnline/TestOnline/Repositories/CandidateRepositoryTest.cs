using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using coreEntityFramework;
using Dal.Entities;
using Dal.Profile;
using Dal.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;

namespace UnitTestOnline.TestOnline.Repositories
{
    [TestClass]
    public class CandidateRepositoryTest
    {
        private static IMapper _mapper;

        public CandidateRepositoryTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CandidateToCandidateModel());
                mc.AddProfile(new ResultToResultDTO());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }

        [TestMethod]
        public async Task Shoud_Get_Candidates_In_CandidateRepository()
        {

            var options = new DbContextOptionsBuilder<MyFirstFullStackApp_DevContext>()
            .UseInMemoryDatabase(databaseName: "Get_candidates_repository")
            .Options;

            using (var context = new MyFirstFullStackApp_DevContext(options))
            {
                context.Candidate.Add(new Candidate("camara", "minamba",2));
                context.Candidate.Add(new Candidate("uzumaki", "naruto", 2));
                context.Candidate.Add(new Candidate("uchiha", "sasuke", 3));

                var candidateRepository = new CandidateRepository(context, _mapper);
                List<Candidate> expectedList;

                expectedList = context.Candidate.ToList();
                var result = await candidateRepository.GetCandidatesAsync();

                CollectionAssert.AreEqual(expectedList, result);
            }
        }

        [TestMethod]
        public async Task Shoud_Get_CandidatesResults_In_CandidateRepository()
        {
            var options = new DbContextOptionsBuilder<MyFirstFullStackApp_DevContext>()
            .UseInMemoryDatabase(databaseName: "Get_candidatesResult_repository")
            .Options;

            using (var context = new MyFirstFullStackApp_DevContext(options))
            {
                context.Result.Add(new Result(1, 1));
                context.Result.Add(new Result(1, 11));
                context.Result.Add(new Result(1, 22));
                var candidateRepository = new CandidateRepository(context, _mapper);
                List<Result> expectedList;

                expectedList = context.Result.ToList();
                var result = await candidateRepository.GetTestsAsync();

                CollectionAssert.AreEqual(expectedList, result);
            }
        }

        [TestMethod]
        public async Task Shoud_Get_TestAsync_In_CandidateRepository()
        {
            var options = new DbContextOptionsBuilder<MyFirstFullStackApp_DevContext>()
            .UseInMemoryDatabase(databaseName: "Get_candidatesTest_repository")
            .Options;


            using (var context = new MyFirstFullStackApp_DevContext(options))
            {
                context.Test.Add(new Test(1, "c#"));
                context.Test.Add(new Test(2, "php"));
                context.Test.Add(new Test(3, "python"));
                var candidateRepository = new CandidateRepository(context, _mapper);
                List<Test> expectedList;

                expectedList = context.Test.ToList();
                var result = await candidateRepository.GetTestsAsync();

                CollectionAssert.AreEqual(expectedList, result);
            }
        }

    }
}
