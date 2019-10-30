using coreEntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repositories
{
    public interface ICandidatesRepository
    {
        List<Candidate> GetCandidates();
    }
}
