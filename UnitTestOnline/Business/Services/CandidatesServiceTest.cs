using AutoMapper;
using Business.Models;
using Business.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace UnitTestOnline.Business.Services
{
    [TestClass]
    public class CandidatesServiceTest
    {
        [TestMethod]
        public async Task Shoud_Get_Candidates_In_CandidateService()
        {
            var candidateService = Substitute.For<ICandidatesRepository>();
            var lst = new List<CandidateModel> {
              new CandidateModel ("camara","minamba",1),
              new CandidateModel ("uzumaki","naruto",2),
              new CandidateModel ("uchiha","sasuke",3),
            };

            var mock = candidateService.GetCandidatesAsync().Returns(lst);
            var result = await candidateService.GetCandidatesAsync();

            CollectionAssert.AreEqual(lst, result);
        }
    }
}
