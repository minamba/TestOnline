using Business.Models;
using Business.Repositories;
using Business.Services;
using coreEntityFramework;
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

        [HttpGet]
        public async Task<ActionResult> GetCandidatesAsync()
        {
            List<CandidateModel> lstCandidate = await _service.GetCandidatesAsync();
            return Ok(lstCandidate);
        }


    }
}
