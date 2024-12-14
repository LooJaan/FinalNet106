using AppAPI.Context;
using AppData;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repositories
{
	public class ProductRepo : IProductRepo
	{
		private readonly MyDbContext _db;
		public ProductRepo(MyDbContext db)
		{
			_db = db;
		}
		public void Create(Product product)
		{
			_db.Products.Add(product);
			_db.SaveChanges();
		}

		public void Delete(int id)
		{
			var prDelete = _db.Products.Find(id);
			if (prDelete != null)
			{
				_db.Products.Remove(prDelete);
				_db.SaveChanges();
			}
		}

		public IEnumerable<Product> GetAll() => _db.Products.ToList();
		
			
		public Product GetById(int id) => _db.Products.Find(id);

		public void Update(Product product)
		{
			_db.Entry(product).State = EntityState.Modified;
			_db.SaveChanges();
		}
	}
}
