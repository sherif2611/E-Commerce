namespace Domain.Models.Product
{
	public class ProductEntity:BaseEntity<int>
	{
		public string Name { get; set; } = default!;
		public string Description { get; set; } = default!;
		public string PictureUrl { get; set; } = default!;
		public decimal Price { get; set; }
    }
}