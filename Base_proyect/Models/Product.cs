namespace Base_proyect.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty!;
        public decimal Price { get; set; }
        public int stock { get; set; }

    }
}
