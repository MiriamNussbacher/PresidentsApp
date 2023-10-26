using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.PresidentService;

namespace Services
{
    
        public class PresidentService 
        {
           
            private PresidentRepository _presidentRepository= new PresidentRepository();
            public async Task<IEnumerable<President>> GetPresidentsAsync()
            {
                return await _presidentRepository.GetPresidentsAsync();
            }

            public async Task<President> GetPresidentByIdAsync(int id)
            {
                return await _presidentRepository.GetPresidentByIdAsync(id);
            }

            public async Task AddPresidentAsync(President president)
            {
                await _presidentRepository.AddPresidentAsync(president);
            }

            public async Task UpdatePresidentAsync(President president)
            {
                await _presidentRepository.UpdatePresidentAsync(president);
            }

            public async Task DeletePresidentAsync(int id)
            {
                await _presidentRepository.DeletePresidentAsync(id);
            }

            public async Task<IEnumerable<President>> GetPresidentsBornAfter(DateTime birthdate)
            {
                var presidents = await _presidentRepository.GetPresidentsAsync();
                return presidents.Where(president => president.Birthdate > birthdate);
            }

            public async Task<IEnumerable<President>> GetPresidentsWithMultipleTerms()
            {
                var presidents = await _presidentRepository.GetPresidentsAsync();
                return presidents.Where(president => president.TermCount > 1);
            }

            public async Task<double> CalculateAverageAgeAtInauguration()
            {
                var presidents = await _presidentRepository.GetPresidentsAsync();
                int count = presidents.Count();
                var totalAge = presidents.Sum(president => (president.InaugurationDate - president.Birthdate).TotalDays);
                return totalAge / count;
            }

           
        }
    
}
