using SalesTax.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Shopping
{
    public class StoreShelf
    {
        private readonly Dictionary<string, Product> productItems;

        public StoreShelf()
        {
            productItems = new Dictionary<string, Product>();
            AddProductItemsToShelf("book", new BookProduct());
            AddProductItemsToShelf("music cd", new MiscellaneousProduct());
            AddProductItemsToShelf("chocolate bar", new FoodProduct());
            AddProductItemsToShelf("box of chocolates", new FoodProduct());
            AddProductItemsToShelf("bottle of perfume", new MiscellaneousProduct());
            AddProductItemsToShelf("packet of headache pills", new MedicalProduct());
        }

        public void AddProductItemsToShelf(String productItem, Product productCategory)
        {
            productItems.Add(productItem, productCategory);
        }

        public Product SearchAndRetrieveItemFromShelf(String name, double price, bool imported, int quantity)
        {
            Product productItem = productItems[name].GetFactory().CeateProduct(name, price, imported, quantity);
            return productItem;
        }

        public int GetShelfSize()
        {
            return productItems.Count;
        }
    }
}
