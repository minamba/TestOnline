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
    public class CandidatesController : Controller
    {
        private ICandidatesService _service;

        public CandidatesController(ICandidatesService service)
        {
            _service = service;
        }


        public JsonResult GetCandidates()
        {
            List<Candidate> lstCandidate = _service.GetCandidates();
            return Json(lstCandidate);
        }


    }
}
