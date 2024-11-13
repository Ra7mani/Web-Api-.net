using System.ComponentModel.DataAnnotations;

namespace test_api.Model.Domaine.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }
}
