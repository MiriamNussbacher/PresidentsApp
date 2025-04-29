using Entities;

namespace Repository
{
    public interface IPresidentRepository
    {
        Task AddPresidentAsync(President president);
        Task DeletePresidentAsync(int id);
        Task<President> GetPresidentByIdAsync(int id);
        Task<IEnumerable<President>> GetPresidentsAsync();
        Task UpdatePresidentAsync(President president);
    }
}