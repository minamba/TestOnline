using AutoMapper;
using Business;
using Business.Models;
using Business.Repositories;
using Business.Services;
using coreEntityFramework;
using Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestOnline.Logs;

namespace TestOnline.Controllers
{
    [Route("api/[controller]")]
    public class CandidatesController : Controller
    {
        private ILog _logger;
        private ICandidatesService _service;

        public CandidatesController(ICandidatesService service, ILog logger)
        {
            _service = service;
            _logger = logger;
        }


        [Route("Candidates")]
        [HttpGet]
        public async Task<IActionResult> GetCandidatesAsync()
        {
            //Logger methodes
            //_logger.Information("Information is logged");
            //_logger.Warning("Warning is logged");
            //_logger.Debug("Debug log is logged");
            //_logger.Error("Error is logged");

            _logger.Information(JsonConvert.SerializeObject(_service.GetCandidatesAsync()));
            var candidates = await _service.GetCandidatesAsync();
            return Ok(candidates);
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
            _logger.Information(JsonConvert.SerializeObject(candidate));
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
