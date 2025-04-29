using Entities;

namespace Services
{
    public interface IPresidentService
    {
        Task AddPresidentAsync(President president);
        Task<double> CalculateAverageAgeAtInauguration();
        Task DeletePresidentAsync(int id);
        Task<President> GetPresidentByIdAsync(int id);
        Task<IEnumerable<President>> GetPresidentsAsync();
        Task<IEnumerable<President>> GetPresidentsBornAfter(DateTime birthdate);
        Task<IEnumerable<President>> GetPresidentsWithMultipleTerms();
        Task UpdatePresidentAsync(President president);
    }
}