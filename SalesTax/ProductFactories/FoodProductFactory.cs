using SalesTax.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.ProductFactories
{
    public class FoodProductFactory : ProductFactory
    {
        public override Products.Product CeateProduct(string name, double price, bool imported, int quantity)
        {
            return new FoodProduct(name, price, imported, quantity);
        }
    }
}
