using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Controllers
{
    public class ProductController : ApiController
    {
        Models.ProductDataSource productDS;

        public ProductController()
        {
            productDS = ProductDataSource.Instance;
        }

        /// <summary>
        /// Get a list of all the products for sale, including their prices.
        /// </summary>
        /// <returns>All projects in the shop</returns>
        public IEnumerable<Product> Get()
        {
            return productDS.GetProducts();
        }

        /// <summary>
        /// Get the details for a particular product
        /// </summary>
        /// <param name="name">The unique name of the product you want to get</param>
        /// <returns>A particular product from the shop</returns>
        public Product Get([FromUri]string name)
        {
            return productDS.GetProduct(name);
        }

        /// <summary>
        /// Add a new product to the shop
        /// </summary>
        /// <param name="name">Name of product (unique id)</param>
        /// <param name="unit_price">Price for one</param>
        /// <param name="special_qty">Number required for a special price</param>
        /// <param name="special_price">The special price for each whole number of special_qty</param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public IHttpActionResult Post([FromUri]string name, [FromUri]decimal unit_price, [FromUri]int special_qty, [FromUri]decimal special_price)
        {
            productDS.AddProduct(name, unit_price, special_qty, special_price);

            return Ok();
        }

        /// <summary>
        /// Add a new product to the shop
        /// </summary>
        /// <param name="name">Existing name of product (unique id)</param>
        /// <param name="newName">The new name for the product (unique id)</param>
        /// <param name="unit_price">Price for one</param>
        /// <param name="special_qty">Number required for a special price</param>
        /// <param name="special_price">The special price for each whole number of special_qty</param>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        public IHttpActionResult Put([FromUri]string name, [FromUri]string newName, [FromUri]decimal unit_price, [FromUri]int special_qty, [FromUri]decimal special_price)
        {
            productDS.UpdateProduct(name, newName, unit_price, special_qty, special_price);

            return Ok();
        }

        /// <summary>
        /// Remove a product from the shop
        /// </summary>
        /// <param name="name">The unique name of the product you want to remove</param>
        /// <returns></returns>
        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete([FromUri]string name)
        {
            productDS.RemoveProduct(name);

            return Ok();
        }
    }
}
