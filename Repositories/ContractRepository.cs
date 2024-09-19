
using Microsoft.EntityFrameworkCore;
using WebAPI.Dtos.Contract;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly AppDbContext _context;
        public ContractRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<bool> ContractExist(int id)
        {
            return _context.Contracts.AnyAsync(c => c.Id == id);
        }

        public async Task<Contract> CreateAsync(Contract contract)
        {
            await _context.Contracts.AddAsync(contract);
            await _context.SaveChangesAsync();
            return contract;
        }

        public async Task<Contract?> DeleteAsync(int id)
        {
            var contract = await _context.Contracts.Include(s => s.Settlements).FirstOrDefaultAsync(x => x.Id == id);
            if(contract == null)
            {
                return null;
            }
            _context.Remove(contract);
            await _context.SaveChangesAsync();
            return contract;
        }

        public async Task<List<Contract>> GetAllAsync()
        {
            return await _context.Contracts.Include(s => s.Settlements).ToListAsync();
        }

        public async Task<Contract?> GetByIdAsync(int id)
        {
            return await _context.Contracts.Include(s => s.Settlements).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Contract?> UpdateAsync(int id, UpdateContractDto dto)
        {
            var contract = await _context.Contracts.FirstOrDefaultAsync(x => x.Id == id);
            if (contract == null)
            {
                return null;
            }
            contract.Name = dto.Name;
            await _context.SaveChangesAsync();
            return contract;
        }
    }
}
