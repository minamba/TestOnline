using Business;
using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Profile
{
    public class CandidateToCandidateDTO : AutoMapper.Profile
    {
        public CandidateToCandidateDTO()
        {
            CreateMap<Candidate, CandidateDTO>().ReverseMap();
        }
    }
}
