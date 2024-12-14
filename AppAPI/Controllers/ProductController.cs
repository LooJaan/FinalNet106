using AppAPI.Repositories;
using AppData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepo _repo;
		public ProductController(IProductRepo repo)
		{
			_repo = repo;
		}
		[HttpGet]
		public ActionResult<IEnumerable<Product>> GetAll()
		{
			var products = _repo.GetAll();
			return Ok(products);
		}
		[HttpGet("{id}")]
		public ActionResult<Product> GetById(int id)
		{
			var product = _repo.GetById(id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}
		[HttpPost]
		public ActionResult<Product> Create(Product product)
		{
			_repo.Create(product);
			return CreatedAtAction(nameof(GetById), new {id = product.ProductID}, product);
		}
		[HttpPut("{id}")]
		public IActionResult Update (int id, Product product)
		{
			if(id != product.ProductID)
			{
				return BadRequest();
			}
			_repo.Update(product);
			return NoContent();
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_repo.Delete(id);
			return NoContent();
		}
	}
}
