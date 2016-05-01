using SalesTax.ProductFactories;
using SalesTax.TaxCalculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Products
{
    public class FoodProduct : Product
    {
        public FoodProduct()
            : base()
        {

        }

        public FoodProduct(String name, double price, bool imported, int quantity)
            : base(name, price, imported, quantity)
        {
        }

        public override ProductFactories.ProductFactory GetFactory()
        {
            return new FoodProductFactory();
        }

        public override double GetTaxValue(string country)
        {
            if (country == "Local")
                return LocalTaxValues.FOOD_TAX;
            else
                return 0;
        }
    }
}
