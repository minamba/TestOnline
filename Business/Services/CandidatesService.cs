using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Services;
using Business.Models;

namespace Business.Repositories
{
    public class CandidatesService : ICandidatesService
    {
        private ICandidatesRepository _repository;

        public CandidatesService(ICandidatesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CandidateDTO>> GetCandidatesAsync()
        {
            return await CalculCandidatesNotes();
        }

        public async Task<List<CandidateDTO>> CalculCandidatesNotes()
        {
            var candidatesDTO= new List<CandidateDTO>();
            int? note = 0;
            var candidates = await _repository.GetCandidatesAsync();
            var tests = await _repository.GetTestsAsync();
            var answers = await _repository.GetAnswersAsync();

            foreach (var c in candidates)
            {
                foreach (var t in tests)
                {
                    if (c.Test.Id == t.Id)
                    {
                        foreach (var cr in c.Result)
                        {
                            foreach(var a in answers) {

                                if (cr.AnswerId == a.Id)
                                {
                                    if (a.IsGood == 1)
                                    {
                                        note = note + 1;
                                    }
                                }
                            }                         
                        }
                    }
                }
               candidatesDTO.Add(
                    new CandidateDTO(c.FirstName, c.LastName, c.Test.Title,(int) note)
                );
                note = 0;
            }

            return candidatesDTO;
        }

        public async Task<double> GetAverageAsync()
        {
            int average = 0;
            var candidates = await GetCandidatesAsync();
            int numberOfCandidates = candidates.Count;

            foreach (var c in candidates)
            {
                average = average + c.Note;
            }

            average = average / numberOfCandidates;

            if(average != 0)
            {

                if (average < 0)
                {
                    throw new Exception("Un problème a été rencontré, la moyenne est inferieur à zero ");
                }
                else
                {

                    return average;
                }             
            }
            else
            {
                throw new Exception("un problème à été rencontré, la moyenne est à zero");
            }
          
        }

        public async Task<double> GetEcartTypeAsync()
        {
            double variance = 0;
            double puissance = 0;
            double ecartType = 0;
            double average = await GetAverageAsync();
            var candidates = await GetCandidatesAsync();
            
            foreach(var c in candidates)
            {
                puissance = c.Note - average;
                puissance = Math.Pow(puissance,2);

                variance = variance + puissance;
                puissance = 0;
            }
            variance = variance / candidates.Count;
            ecartType = Math.Sqrt(variance);


            return ecartType;
        }

        public async Task<Candidate> AddCandidateTestAsync(Candidate candidate)
        {
            return await _repository.AddCandidateTestAsync(candidate); 
        }
    }
}
