using AutoMapper;
using Business;
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
using Newtonsoft.Json;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    }
}
