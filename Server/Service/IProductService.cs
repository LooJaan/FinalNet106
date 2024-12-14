using AppData;
using Microsoft.AspNetCore.Components.Forms;

namespace Server.Service
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetAll();
		Task<Product> GetById(int id);
		Task Create (Product product, IBrowserFile img);
		Task Update (Product product, IBrowserFile img);
		Task Delete (int id);
	}
}
