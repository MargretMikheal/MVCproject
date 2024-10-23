namespace MVCproject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
       // public string Photo {  get; set; }
        public int StockQuantity { get; set; }
        public byte[]? Photo { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
