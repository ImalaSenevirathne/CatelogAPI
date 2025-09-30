using CatalogAPI.Entities;
using CatalogAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogRepository _repository;

        public CatalogController(ICatalogRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public  async Task<IEnumerable<Item>> Get() => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(string id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Item item)
        {
            await _repository.CreateAsync(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Item item)
        {
            var existingItem = await _repository.GetByIdAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            item.Id = id; // Ensure the ID remains the same
            var updated = await _repository.UpdateAsync(id, item);
            if (!updated)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating item");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var existingItem = await _repository.GetByIdAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting item");
            }
            return NoContent();
        }
    }
}
