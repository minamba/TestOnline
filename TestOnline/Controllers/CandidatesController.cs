using AutoMapper;
using Business;
using Business.Models;
using Business.Repositories;
using Business.Services;
using coreEntityFramework;
using Dal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        [Route("Candidates")]
        [HttpGet]
        public async Task<List<CandidateDTO>> GetCandidatesAsync()
        {
            var candidates = await _service.GetCandidatesAsync();

            //return Ok(candidates);
            return candidates;
        }


        [Route("Average")]
        [HttpGet]
        public async Task<IActionResult> GetAverageAsync()
        {
            double average = await _service.GetAverageAsync();

            return Ok(average);
        }


        [Route("EcartType")]
        [HttpGet]
        public async Task<IActionResult> GetEcartTypeAsync()
        {
            double ecartType = await _service.GetEcartTypeAsync();

            return Ok(ecartType);
        }


        [Route("Candidates")]
        [HttpPost]
        public async Task<IActionResult> AddCandidateTestAsync([FromBody] Candidate candidate)
        {            
            return CreatedAtAction("AddCandidateTestAsync", candidate);
        }


        [Route("Cars")]
        [HttpPost]
        public async Task<IActionResult> CreateCarAsync([FromBody] Car car)
        {
            // Call service;
            Car result = new Car();

            return CreatedAtAction("AddCarAsync", result);
        }

        public class Car
        {
            [Required]
            public string Mark { get; set; }

            public string Model { get; set; }

            [Required]
            public int Year { get; set; }
        }
    }
}
