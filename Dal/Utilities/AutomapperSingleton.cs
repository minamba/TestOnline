using AutoMapper;
using Dal.Profile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Utilities
{
    public class AutomapperSingleton
    {
        private static IMapper _mapper;
        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new CandidateToCandidateModel());
                    });
                    IMapper mapper = mappingConfig.CreateMapper();
                    _mapper = mapper;
                }
                return _mapper;
            }

        }
    }
}
