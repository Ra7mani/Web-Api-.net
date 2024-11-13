using test_api.Model.Domaine.Entities;

namespace test_api.Model.Domaine
{
    public interface IDAO
    {
        public List<Product> GetProducts();
        public Product? GetProductById(int id);
        public Product AjouterProduct(Product product);
        public  Product? updateProduct(int id , Product product);
        public void deleteProduct(int id);
    }
}
