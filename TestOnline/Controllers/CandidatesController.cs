using AutoMapper;
using Business;
using Business.Models;
using Business.Repositories;
using Business.Services;
using coreEntityFramework;
using Dal;
using Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestOnline.Controllers
{
    [Route("api/[controller]")]
    public class CandidatesController : Controller
    {
        private ICandidatesService _service;

        public CandidatesController(ICandidatesService service)
        {
            _service = service;
        }

        [Route("GetCandidates")]
        [HttpGet]
        public async Task<List<CandidateDTO>> GetCandidatesAsync()
        {
            var candidates = await _service.GetCandidatesAsync();

            //return Ok(candidates);
            return candidates;
        }

        [Route("GetAverage")]
        [HttpGet]
        public async Task<double> GetAverageAsync()
        {
            double average = await _service.GetAverageAsync();

            return average;
        }

        [Route("GetEcartType")]
        [HttpGet]
        public async Task<double> GetEcartTypeAsync()
        {
            double ecartType = await _service.GetEcartTypeAsync();

            return ecartType;
        }




    }
}
