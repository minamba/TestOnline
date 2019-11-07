﻿using AutoMapper;
using Business.Models;
using Business.Repositories;
using Business.Services;
using coreEntityFramework;
using Dal.Entities;
using Dal.Profile;
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

namespace UnitTestOnline.TestOnline.Repositories
{
    [TestClass]
    public class CandidateRepositoryTest
    {
        [TestMethod]
        public async Task Shoud_Get_Candidates_In_CandidateRepository()
        {
            var options = new DbContextOptionsBuilder<MyFirstFullStackApp_DevContext>()
            .UseInMemoryDatabase(databaseName: "Get_candidates_repository")
            .Options;

            using (var context = new MyFirstFullStackApp_DevContext(options))
            {
                context.Candidate.Add(new Candidate("camara", "minamba", 1));
                context.Candidate.Add(new Candidate("uzumaki", "naruto", 2));
                context.Candidate.Add(new Candidate("uchiha", "sasuke", 3));

                var candidateRepository = new CandidateRepository(context,AutomapperSingleton.Mapper);
                List<Candidate> expectedList;

                expectedList = context.Candidate.ToList();
                var result = await candidateRepository.GetCandidatesAsync();

                CollectionAssert.AreEqual(expectedList, result);
            }
        }
    }
}
