using AppData;
using Microsoft.AspNetCore.Components.Forms;

namespace Server.Service
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _httpClient;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public ProductService(HttpClient httpClient, IWebHostEnvironment webHostEnvironment)
		{
			_httpClient = httpClient;
			_webHostEnvironment = webHostEnvironment;
		}
		public async Task Create(Product product, IBrowserFile img)
		{
			if(img != null && img.Size > 0)
			{
				var upload = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
				var filePath = Path.Combine(upload, img.Name);

				if (!Directory.Exists(upload))
				{
					Directory.CreateDirectory(upload);
				}

				using(var stream = new FileStream(filePath, FileMode.Create))
				{
					await img.OpenReadStream().CopyToAsync(stream);
				}
				product.ImagePath = "/uploads/"  + img.Name;
			}

			await _httpClient.PostAsJsonAsync("api/Product", product);
		}

		public async Task Delete(int id)
		{
			await _httpClient.DeleteAsync($"api/Product/{id}");
		}

		public async Task<IEnumerable<Product>> GetAll()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/Product");
		}

		public async Task<Product> GetById(int id)
		{
			return await _httpClient.GetFromJsonAsync<Product>($"api/Product/{id}");
		}

		public async Task Update(Product product, IBrowserFile img)
		{
			if (img != null && img.Size > 0)
			{
				var upload = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
				var filePath = Path.Combine(upload, img.Name);

				if (!Directory.Exists(upload))
				{
					Directory.CreateDirectory(upload);
				}

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await img.OpenReadStream().CopyToAsync(stream);
				}
				product.ImagePath = "/uploads/" + img.Name;
			}

			await _httpClient.PutAsJsonAsync($"api/Product/{product.ProductID}", product);
		}
	}
}
