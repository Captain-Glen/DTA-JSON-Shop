using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Cart
    {
        public Product product { get; set; }
        public int qty { get; set; }
    }

    public class CartDataSource
    {
        public List<Cart> myCart = new List<Cart>();

        // Class must be singleton as we need to store state due to lack of database set up
        private static CartDataSource instance;
        private CartDataSource() { }
        public static CartDataSource Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CartDataSource();
                }
                return instance;
            }
        }

        public void AddProductToCart(string name, int qty)
        {
            ProductDataSource productDS = ProductDataSource.Instance;

            Cart cart = new Models.Cart();
            cart.product = productDS.GetProduct(name);
            cart.qty = qty;

            myCart.Add(cart);
        }

        internal void UpdateCartQty(string name, int qty)
        {
            ProductDataSource productDS = ProductDataSource.Instance;
            Product product = productDS.GetProduct(name);

            // Find product in cart
            Cart cart = myCart.Where
                    (x => string.Equals(product.name,
                    x.product.name,
                    System.StringComparison.CurrentCultureIgnoreCase)).First();

            // update quanity
            cart.qty = qty;
        }

        internal void removeProduct(string name)
        {
            ProductDataSource productDS = ProductDataSource.Instance;
            Product product = productDS.GetProduct(name);

            // Find product in cart
            Cart cart = myCart.Where
                    (x => string.Equals(product.name,
                    x.product.name,
                    System.StringComparison.CurrentCultureIgnoreCase)).First();

            // Remove item
            myCart.Remove(cart);
        }

        public decimal CartTotal()
        {
            decimal total = 0;
            
            foreach (Cart cart in myCart)
            {
                // While there are enough for the discount.  Give the discounted rate
                int tempQty = cart.qty;
                while (tempQty >= cart.product.special_qty & cart.product.special_qty != 0)
                {
                    total += cart.product.special_price;
                    tempQty -= cart.product.special_qty;
                }

                // Any leftovers are calculated at the normal rate
                total += cart.product.unit_price * tempQty;
            }

            return total;
        }
    }
}