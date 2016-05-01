using SalesTax.Billing;
using SalesTax.Products;
using SalesTax.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Shopping
{
    public class ShoppingStore
    {
        private ShoppingCart shoppingCart;
        private StoreShelf storeShelf;
        private PaymentCounter paymentCounter;
        private string country;

        public ShoppingStore()
        {
            country = "Local";
            shoppingCart = new ShoppingCart();
            paymentCounter = new PaymentCounter(country);
            storeShelf = new StoreShelf();
        }

        public void RetrieveOrderAndPlaceInCart(String name, double price, bool imported, int quantity)
        {
            Product product = storeShelf.SearchAndRetrieveItemFromShelf(name, price, imported, quantity);
            shoppingCart.AddItemToCart(product);
        }

        public void GetSalesOrder()
        {
            do
            {
                String name = GetProductName();
                double price = GetProductPrice();
                bool imported = IsProductImported();
                int quantity = GetQuantity();
                RetrieveOrderAndPlaceInCart(name, price, imported, quantity);
            }
            while (IsAddAnotherProduct());
        }

        public void CheckOut()
        {
            paymentCounter.billItemsInCart(shoppingCart);
            Receipt receipt = paymentCounter.GetReceipt();
            paymentCounter.PrintReceipt(receipt);
        }

        public String GetProductName()
        {
            Console.WriteLine("Enter the product name:\n");
            return Console.ReadLine();
        }

        public double GetProductPrice()
        {
            Console.WriteLine("Enter the product price:\n");
            var input = Console.ReadLine();
            double val;
            while (!(double.TryParse(input, out val)))
            {
                Console.WriteLine("Invalid price. Enter a number");
            }

            return val;
        }

        public bool IsProductImported()
        {
            Console.WriteLine("Is product imported or not?(Y/N)\n");
            var input = Console.ReadLine();
            bool isValid = false;
            while (!isValid)
            {
                if (input == "Y")
                    isValid = true;
                else if (input == "N")
                    isValid = true;
                else
                    Console.WriteLine("Invalid input. Enter (Y/N)");
            }

            if (input == "Y")
                return true;
            else
                return false;
        }

        public int GetQuantity()
        {
            Console.WriteLine("Enter the quantity:\n");
            var input = Console.ReadLine();
            int intVal;
            while (!(int.TryParse(input, out intVal)))
            {
                Console.WriteLine("Invalid input. Enter a integer");
            }
            return intVal;
        }

        public bool IsAddAnotherProduct()
        {
            Console.WriteLine("Do you want to add another Product?(Y/N)");

            var input = Console.ReadLine();
            while (!(input == "Y" || input == "N"))
            {
                Console.WriteLine("Invalid input. Enter (Y/N)");
            }

            bool addAnotherProduct = TaxUtil.ParseBoolean(Convert.ToChar(input));
            return addAnotherProduct;
        }
    }
}
