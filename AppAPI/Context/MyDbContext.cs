using AppData;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Context
{
	public class MyDbContext : DbContext
	{
		public MyDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Product> Products { get; set; }
	}
}
