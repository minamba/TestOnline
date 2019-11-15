using Business;
using Business.Models;
using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Profile
{
    public class ResultToResultDTO : AutoMapper.Profile
    {
        public ResultToResultDTO()
        {
            CreateMap<Result, ResultDTO>().ReverseMap();
        }
    }
}
