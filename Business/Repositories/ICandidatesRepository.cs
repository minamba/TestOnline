﻿using coreEntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public interface ICandidatesRepository
    {
        Task<List<Candidate>> GetCandidates();
    }
}
