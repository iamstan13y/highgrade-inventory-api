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
    }
}