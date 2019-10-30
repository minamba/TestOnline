using coreEntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public interface ICandidatesService
    {
        List<Candidate> GetCandidates();
    }
}
