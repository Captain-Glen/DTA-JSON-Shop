using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using System.Web.Services.Description;

namespace Controllers
{
       public class CartController : ApiController
    {
        protected CartDataSource cartDS;

        CartController()
        {
            // Load singleton instance of CartDataSource
            cartDS = CartDataSource.Instance;
        }

        /// <summary>
        /// Get the total cost of the cart
        /// </summary>
        /// <returns>The sum of the items in the cart including discounts from special quantities</returns>
        public decimal Get()
        {
            return cartDS.CartTotal();
        }

        /// <summary>
        /// Add an item to your cart
        /// </summary>
        /// <param name="name">The name of the product to add (unique id)</param>
        /// <param name="qty">The quantity of the product to add</param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public IHttpActionResult Post([FromUri]string name, [FromUri]int qty)
        {
            cartDS.AddProductToCart(name, qty);

            return Ok();
        }

        /// <summary>
        /// Update quantiy of item in your cart
        /// </summary>
        /// <param name="name">The name of the product to update (unique id)</param>
        /// <param name="qty">The updated quantiy</param>
        [System.Web.Http.HttpPut]
        public void Put([FromUri]string name, [FromUri]int qty)
        {
            cartDS.UpdateCartQty(name, qty);
        }

        /// <summary>
        /// Remove an item form your cart
        /// </summary>
        /// <param name="name">The name of the product to remove (unique id)</param>
        [System.Web.Http.HttpDelete]
        public void Delete(string name)
        {
            cartDS.removeProduct(name);
        }
    }
}
