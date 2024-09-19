using WebAPI.Dtos.Settlement;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface ISettlementsRepository
    {
        Task<List<Settlement>> GetAllAsync();
        Task<Settlement?> GetByIdAsync(int id);
        Task<Settlement> CreateAsync(Settlement settlement);
        Task<Settlement?> UpdateAsync(int id, UpdateSettlementDto settlementDto);
        Task<Settlement?> DeleteAsync(int id);

    }
}
