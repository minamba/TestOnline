using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TestOnline.Controllers;

namespace UnitTestOnline
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Shoud_Get_Candidates()
        {
            var candidateService = Substitute.For<ICandidatesService>();
            var CandidateController = new CandidatesController(candidateService);

            var result = await CandidateController.GetCandidatesAsync();
            var okResult = result as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
