﻿using AutoMapper;
using Business;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestOnline.Controllers;
using TestOnline.Logs;

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
            var logger = Substitute.For<ILog>();
            candidateService.GetCandidatesAsync().Returns(candidates);
            var CandidateController = new CandidatesController(candidateService, logger);

            var result = await CandidateController.GetCandidatesAsync();
            var okResult = result as OkObjectResult;
            //string serialize1 = JsonConvert.SerializeObject(candidates);
            //string serialize2 = JsonConvert.SerializeObject(result);

            Assert.AreEqual(200, okResult.StatusCode);
            /* Assert.AreEqual(serialize1, serialize2);*/ //Test return objects 
        }

        [TestMethod]
        public async Task Shoud_Get_Average_In_Controller()
        {
            //double average = 13;

            var candidates = new List<CandidateDTO>()
            {
                new CandidateDTO("minamba","camara","c#",10),
                new CandidateDTO("naruto","uzumaki","php",16),
                new CandidateDTO("sasuke","uchiha","python",13),
            };

            var candidateService = Substitute.For<ICandidatesService>();
            candidateService.GetCandidatesAsync().Returns(candidates);
            var logger = Substitute.For<ILog>();
            var candidateController = new CandidatesController(candidateService, logger);
            var result = await candidateController.GetAverageAsync();
            var okResult = result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        [DataRow(8)] // Un autre moyen de passer des paramètres pour les tests
        public async Task Shoud_Get_Average_In_CandidateService(double average)
        {
            var candidates = new List<CandidateDTO>()
            {
                new CandidateDTO("minamba","camara","c#",10),
                new CandidateDTO("naruto","uzumaki","php",8),
                new CandidateDTO("sasuke","uchiha","python",15),
            };

            var mockService = Substitute.For<ICandidatesService>();
            mockService.GetCandidatesAsync().Returns(candidates);
            var logger = Substitute.For<ILog>();
            var candidateController = new CandidatesController(mockService, logger);
            var result = await candidateController.GetAverageAsync();
            var okResult = result as OkObjectResult;


            Assert.AreEqual(200, okResult.StatusCode);
        }


        [TestMethod]
        public async Task Shoud_Get_EcartType_In_CandidateService()
        {
            double ecartType = 2.6;

            var mockService = Substitute.For<ICandidatesService>();
            mockService.GetEcartTypeAsync().Returns(ecartType);
            var logger = Substitute.For<ILog>();
            var candidateController = new CandidatesController(mockService, logger);
            var result = await candidateController.GetEcartTypeAsync();
            var okResult = result as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
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

            var mockService = Substitute.For<ICandidatesService>();
            mockService.AddCandidateTestAsync(candidate).Returns(candidate);
            var logger = Substitute.For<ILog>();
            var candidateController = new CandidatesController(mockService, logger);
            var result = await candidateController.AddCandidateTestAsync(candidate);
            var okResult = result as CreatedAtActionResult;

            Assert.AreEqual(201,okResult.StatusCode);
        }
    }
}
