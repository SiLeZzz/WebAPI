using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Dtos.Contract;
using WebAPI.Mappers;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/contract/[action]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        
        private readonly IContractRepository _repository;
        public ContractController(IContractRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var contracts = await _repository.GetAllAsync();
            var contractsDto = contracts.Select(c => c.ToContractDto());
            return Ok(contractsDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var contract = await _repository.GetByIdAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContractDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var contractModel = createDto.ToContractFromCreateDto();
            await _repository.CreateAsync(contractModel);
            return Ok(contractModel);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateContractDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var contractModel = await _repository.UpdateAsync(id, updateDto);
            if(contractModel == null)
            {
                return NotFound();
            }
            
            return Ok(contractModel);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var contractModel = await _repository.DeleteAsync(id);
            if (contractModel == null){
                return NotFound();
            }
            return NoContent();
        }
    }
}
