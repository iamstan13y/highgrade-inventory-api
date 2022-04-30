using HighGradeInventory.API.Models.Data;
using HighGradeInventory.API.Models.Local;
using HighGradeInventory.API.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighGradeInventory.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStock() => Ok(await _stockRepository.GetAllAsync());

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetStock(int id)
        {
            var result = await _stockRepository.GetByIdAsync(id);

            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostStock(StockRequest request)
        {
            var result = await _stockRepository.AddAsync(new Stock
            {
                InventoryId = request.InventoryId,
                Quantity = request.Quantity
            });

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> PutStock(UpdateStockRequest request)
        {
            var result = await _stockRepository.UpdateAsync(new Stock
            {
                Id = request.Id,
                InventoryId = request.InventoryId,
                Quantity = request.Quantity
            });

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-by-inventoryId/{inventoryId}")]
        public async Task<IActionResult> Get(int inventoryId) => Ok(await _stockRepository.GetByInventoryIdAsync(inventoryId));
    }
}