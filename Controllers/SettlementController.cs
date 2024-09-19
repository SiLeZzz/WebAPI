using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos.Settlement;
using WebAPI.Mappers;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/settlement/[action]")]
    [ApiController]
    public class SettlementController : ControllerBase
    {
        private readonly ISettlementsRepository _repository;
        private readonly IContractRepository _contractRepo;
        public SettlementController(ISettlementsRepository repository, IContractRepository contractRepo)
        {
            _repository = repository;
            _contractRepo = contractRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var settlements = await _repository.GetAllAsync();
            var settlementsDto = settlements.Select(s => s.ToSettlementDto());
            return Ok(settlementsDto);

        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var settlement = await _repository.GetByIdAsync(id);
            if(settlement == null)
            {
                return NotFound();
            }
            return Ok(settlement.ToSettlementDto());
        }
        [HttpPost("{contractId:int}")]
        public async Task<IActionResult> Create([FromRoute] int contractId, [FromBody] CreateSettlementDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!await _contractRepo.ContractExist(contractId))
            {
                return BadRequest("Contract does not exist");
            }
            var settlementModel = createDto.ToSettlement(contractId);
            await _repository.CreateAsync(settlementModel);
            return Ok(settlementModel.ToSettlementDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSettlementDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var settlement = await _repository.UpdateAsync(id, updateDto);
            if(settlement == null)
            {
                return NotFound("Settlement does not exist");
            }
            return Ok(settlement.ToSettlementDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var settlement = await _repository.DeleteAsync(id);
            if(settlement == null)
            {
                return NotFound("Settlement does not exist");
            }
            return NoContent();
        }
    }
}
