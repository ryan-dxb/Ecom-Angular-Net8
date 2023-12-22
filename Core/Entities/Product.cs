namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public double Price { get; set; }
        public int ProductTypeId { get; set; } // Foreign key
        public int ProductBrandId { get; set; } // Foreign key

        // Navigation properties
        public ProductType ProductType { get; set; }
        public ProductBrand ProductBrand { get; set; }
    }
}
