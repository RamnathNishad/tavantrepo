using System.ComponentModel.DataAnnotations.Schema;

namespace EFRelationShipsDemo
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }

    public class SubCategory
    {
        public int Id{get; set;}
        public string SubCategoryName { get; set; }

        [ForeignKey("CatId")]    
        public Category Category { get; set; }

        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id{get; set;}
        public string ProductName { get; set; }
        public int Price { get; set; }

        [ForeignKey("SubCategoryId")]    
        public SubCategory SubCategory { get; set; }
    }
}
