using WebAPI.Dtos.Contract;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IContractRepository
    {
        Task<List<Contract>> GetAllAsync();
        Task<Contract?> GetByIdAsync(int id);
        Task<Contract> CreateAsync(Contract contract);
        Task<Contract?> UpdateAsync(int id, UpdateContractDto dto);
        Task<Contract?> DeleteAsync(int id);
        Task<bool> ContractExist(int id);
    }
}
