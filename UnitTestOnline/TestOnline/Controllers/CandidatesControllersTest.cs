using AutoMapper;
using Business;
using Business.Models;
using Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestOnline.Controllers;
namespace UnitTestOnline.TestOnline.Controllers
{
    [TestClass]
    public class CandidatesControllersTest
    {
        [TestMethod]
        public async Task Shoud_Get_Candidates_In_Controller()
        {
            var candidates = new List<CandidateDTO>()
            {
                new CandidateDTO ("camara", "minamba","c#",12),
                new CandidateDTO ("uzumaki", "naruto","python",14),
                new CandidateDTO ("uchiha", "sasuke",".net core",18)
            };
            var candidateService = Substitute.For<ICandidatesService>();
            candidateService.GetCandidatesAsync().Returns(candidates);
            var CandidateController = new CandidatesController(candidateService);

            var result = await CandidateController.GetCandidatesAsync();
            //var okResult = result as OkObjectResult;
            string serialize1 = JsonConvert.SerializeObject(candidates);
            string serialize2 = JsonConvert.SerializeObject(result);

            //Assert.AreEqual(200, okResult.StatusCode);
             Assert.AreEqual(serialize1, serialize2); //Test return objects 
        }

        [TestMethod]
        public async Task Shoud_Get_Average_In_Controller()
        {
            double average = 14;

            var candidateService = Substitute.For<ICandidatesService>();
            candidateService.GetAverageAsync().Returns(average);
            var candidateController = new CandidatesController(candidateService);
            var result = await candidateController.GetAverageAsync();
            string serialize1 = JsonConvert.SerializeObject(average);
            string serialize2 = JsonConvert.SerializeObject(result);

            Assert.AreEqual(serialize1, serialize2);
        }


        [TestMethod]
        public async Task Shoud_Get_EcartType_In_CandidateService()
        {
            double ecartType = 2.6;

            var candidateService = Substitute.For<ICandidatesService>();
            candidateService.GetEcartTypeAsync().Returns(ecartType);
            var candidateController = new CandidatesController(candidateService);
            var result = await candidateController.GetEcartTypeAsync();
            string serialize1 = JsonConvert.SerializeObject(ecartType);
            string serialize2 = JsonConvert.SerializeObject(result);


            Assert.AreEqual(serialize1, serialize2);
        }


        [TestMethod]
        public async Task Shoud_Add_CandidateTest_In_CandidateService()
        {
            var candidate = new Candidate()
            {
                FirstName = "Minamba",
                LastName = "Camara",
                Test = new TestModel()
                 {
                     Title ="c#"
                 }
            };

            var candidateService = Substitute.For<ICandidatesService>();
            candidateService.AddCandidateTestAsync(candidate).Returns(candidate);
            var candidateController = new CandidatesController(candidateService);
            var result = await candidateController.AddCandidateTestAsync(candidate);
            string serialize1 = JsonConvert.SerializeObject(candidate);
            string serialize2 = JsonConvert.SerializeObject(result);

            Assert.AreEqual(serialize1, serialize2);
        }


    }
}
