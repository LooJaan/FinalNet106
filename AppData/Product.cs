using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AppData
{
	public class Product
	{
		public int ProductID { get; set; }
		[Required(ErrorMessage = "TÊN KHÔNG ĐƯỢC ĐỂ TRỐNG")]
		[MinLength(1, ErrorMessage = "TÊN KHÔNG ĐƯỢC ĐỂ TRỐNG")]
		[RegularExpression(@"\S+", ErrorMessage = "KHÔNG ĐƯỢC ĐỂ TOÀN KHẢNG TRẮNG")]
		public string ProductName { get; set; }
		public string ImagePath { get; set; }
		[Range(0.01, double.MaxValue, ErrorMessage = "GIÁ PHẢI LỚN HƠN 0")]
		public decimal Price { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = "SỐ LƯỢNG PHẢI LỚN HƠN 0")]
		public int StockQuantity { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}
