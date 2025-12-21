namespace HelloWorld.UI.Dtos.ProductDtos
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public string? CategoryId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
