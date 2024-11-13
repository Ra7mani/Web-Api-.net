using System.Security.Cryptography.Xml;
using test_api.Model.Domaine;
using test_api.Model.Domaine.Entities;

namespace test_api.Infrastructure.DaoAcess
{
    public class ProductDao : IDAO
    {
        public Product AjouterProduct(Product product)
        {
            DB.products.Add(product);
            return product;
        }

        public void deleteProduct(int id)
        {

           DB.products.RemoveAll(x => x.ProductId == id);
        }

        public Product? GetProductById(int id)
        {
            foreach (Product product in DB.products) { 
               if(product.ProductId == id)
                    
                    return product;
            
            }
            return null;
        }

        public List<Product> GetProducts()
        {
           return DB.products;
        }

        public Product? updateProduct(int id , Product product)
        {
            var existingProduct = GetProductById(id);
            if (existingProduct == null) {
                return null;
            }
           
            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductDescription = product.ProductDescription;
            return existingProduct;

        }
    }
}
