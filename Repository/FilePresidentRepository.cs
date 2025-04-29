using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Repository
{
    public class FilePresidentRepository: IPresidentRepository
    {
       
            private readonly string _filePath;

            public FilePresidentRepository()
            {
                _filePath = "aaaa";
            }

            public async Task<IEnumerable<President>> GetPresidentsAsync()
            {
                var presidentsJson = await File.ReadAllTextAsync(_filePath);
                var presidents = JsonConvert.DeserializeObject<List<President>>(presidentsJson);
                return presidents;
            }

            public async Task<President> GetPresidentByIdAsync(int id)
            {
                var presidents = (await GetPresidentsAsync()).ToList();
                return presidents.FirstOrDefault(p => p.Id == id);
            }

            public async Task AddPresidentAsync(President president)
            {
                var presidents = (await GetPresidentsAsync()).ToList();
                presidents.Add(president);
                await WritePresidentsToFileAsync(presidents);
            }

            public async Task UpdatePresidentAsync(President president)
            {
                var presidents = (await GetPresidentsAsync()).ToList();
                var existingPresident = presidents.FirstOrDefault(p => p.Id == president.Id);
                if (existingPresident != null)
                {
                    // Update the existing President
                    existingPresident.Name = president.Name;
                    existingPresident.Birthdate = president.Birthdate;
                    existingPresident.InaugurationDate = president.InaugurationDate;
                    existingPresident.TermCount = president.TermCount;
                    await WritePresidentsToFileAsync(presidents);
                }
            }

            public async Task DeletePresidentAsync(int id)
            {
                var presidents = (await GetPresidentsAsync()).ToList();
                var existingPresident = presidents.FirstOrDefault(p => p.Id == id);
                if (existingPresident != null)
                {
                    // Remove the existing President
                    presidents.Remove(existingPresident);
                    await WritePresidentsToFileAsync(presidents);
                }
            }

            private async Task WritePresidentsToFileAsync(IEnumerable<President> presidents)
            {
                var presidentsJson = JsonConvert.SerializeObject(presidents, Newtonsoft.Json.Formatting.Indented);
                await File.WriteAllTextAsync(_filePath, presidentsJson);
            }
        }

    }

