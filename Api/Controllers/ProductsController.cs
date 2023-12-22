using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcomDbContext dbContext;

        public ProductsController(EcomDbContext dbContext) // Dependency Injection (Database Context)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products =  await dbContext.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            dbContext.Add(product);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(product).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            dbContext.Remove(product);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
