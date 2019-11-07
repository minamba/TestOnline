using AutoMapper;
using Business.Models;
using Business.Repositories;
using Business.Services;
using coreEntityFramework;
using Dal.Entities;
using Dal.Repositories;
using Dal.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TestOnline.Controllers;

namespace UnitTestOnline
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Shoud_Get_Candidates_In_Controller()
        {
            var candidateService = Substitute.For<ICandidatesService>();
            var CandidateController = new CandidatesController(candidateService);

            var result = await CandidateController.GetCandidatesAsync();
            var okResult = result as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }



        //[TestMethod]
        //public async Task Shoud_Get_Candidates_In_CandidateService()
        //{
        //    var iCandidateRepository = Substitute.For<ICandidatesRepository>();
        //    var CandidateService = new CandidatesService(iCandidateRepository);
     
        //    var result = await CandidateService.GetCandidatesAsync();

        //    CollectionAssert.AreEqual("", result);          
        //}



        [TestMethod]
        public async Task Shoud_Get_Candidates_In_CandidateRepository()
        {
            var options = new DbContextOptionsBuilder<MyFirstFullStackApp_DevContext>()
            .UseInMemoryDatabase(databaseName: "Get_candidates_repository")
            .Options;

            using (var context = new MyFirstFullStackApp_DevContext(options))
            {
                var candidateRepository = new CandidateRepository(context, AutomapperSingleton.Mapper);
                List<Candidate> expectedList;

                expectedList = context.Candidate.ToList();
                var result = await candidateRepository.GetCandidatesAsync();
               
                CollectionAssert.AreEqual(expectedList, result);
            }
        }

    }
}
