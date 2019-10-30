using Business.Repositories;
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
        [HttpGet]
        public List<Candidate> GetCandidates()
        {
            var lcandidate = new CandidatesService();

            return lcandidate.GetCandidates();
        }
    }
}
