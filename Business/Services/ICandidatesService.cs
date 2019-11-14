﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICandidatesService
    {
        Task<List<CandidateDTO>> GetCandidatesAsync();
        Task<List<ResultDTO>> GetResultsAsync();
        Task<List<CandidateDTO>> CalculCandidatesNotes();
    }
}
