using Business.Models;
using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Profile
{
    public class ResultToResultModel : AutoMapper.Profile
    {
        public ResultToResultModel()
        {
            CreateMap<Result, ResultDTO>().ReverseMap();
        }
    }
}
