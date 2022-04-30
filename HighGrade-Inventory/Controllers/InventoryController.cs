using HighGradeInventory.API.Models.Data;
using HighGradeInventory.API.Models.Local;
using HighGradeInventory.API.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighGradeInventory.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(InventoryRequest request)
        {
            var result = await _inventoryRepository.AddAsync(new Inventory
            {
                ColourName = request.ColourName,
                Quantity = request.Quantity,
                AlertLevel = request.AlertLevel,
            });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _inventoryRepository.GetAllAsync());

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _inventoryRepository.GetByIdAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }
    }
}