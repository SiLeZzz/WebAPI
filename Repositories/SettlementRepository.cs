using Microsoft.EntityFrameworkCore;
using WebAPI.Dtos.Settlement;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class SettlementRepository : ISettlementsRepository
    {
        private readonly AppDbContext _context;
        public SettlementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Settlement?> CreateAsync(Settlement settlement)
        {
            await _context.Settlements.AddAsync(settlement);
            await _context.SaveChangesAsync();
            return settlement;
        }

        public async Task<Settlement?> DeleteAsync(int id)
        {
            var settlementExist = await _context.Settlements.FirstOrDefaultAsync(x => x.Id == id);
            if(settlementExist == null)
            {
                return null;
            }
            _context.Settlements.Remove(settlementExist);
            await _context.SaveChangesAsync();
            return settlementExist;
        }

        public async Task<List<Settlement>> GetAllAsync()
        {
            return await _context.Settlements.ToListAsync();
        }

        public async Task<Settlement?> GetByIdAsync(int id)
        {
            return await _context.Settlements.FindAsync(id);
            
        }

        public async Task<Settlement> UpdateAsync(int id, UpdateSettlementDto settlementDto)
        {
            var existingSettlement = await _context.Settlements.FirstOrDefaultAsync(x => x.Id == id);
            if (existingSettlement == null)
            {
                return null;
            }
            existingSettlement.Name = settlementDto.Name;
            existingSettlement.Price = settlementDto.Price;
            await _context.SaveChangesAsync();
            return existingSettlement;
        }
    }
}
