using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Business.Models;
using Dal.Entities;
using Business;

namespace Dal.Profile
{
    public class CandidateToCandidateModel : AutoMapper.Profile
    {
        public CandidateToCandidateModel()
        {
            CreateMap<Entities.Candidate, Entities.Candidate>().ReverseMap();
        }
    }
}