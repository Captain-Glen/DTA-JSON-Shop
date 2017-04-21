using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;

namespace Models
{ 

    public class Prices
    {
        [JsonProperty("prices")]
        public List<Product> products;
    }

    public class Product
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("unit_price")]
        public decimal unit_price { get; set; }
        [JsonProperty("special_qty")]
        public int special_qty { get; set; }
        [JsonProperty("special_price")]
        public decimal special_price { get; set; }

        public Product (string name, decimal unit_price, int special_qty, decimal special_price)
        {
            this.name = name;
            this.unit_price = unit_price;
            this.special_qty = special_qty;
            this.special_price = special_price;
        }
     }

    public class ProductDataSource
    {

        // Class must be singleton as we need to store state due to lack of database set up
        private static ProductDataSource instance;
        private ProductDataSource()
        {
            string url = string.Format("https://api.myjson.com/bins/gx6vz");
            products = (_download_serialized_json_data<Prices>(url)).products;
        }
        public static ProductDataSource Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDataSource();
                }
                return instance;
            }
        }

        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        internal void UpdateProduct(string name, string newName, decimal unit_price, int special_qty, decimal special_price)
        {
            Product oldProduct = GetProduct(name);
            Product newProduct = new Models.Product(newName, unit_price, special_qty, special_price);

            products.Remove(oldProduct);
            products.Add(newProduct);
        }

        public static List<Product> products;

        public Product GetProduct(string name)
        {
            return products.Where
                                (x => string.Equals(name,
                                x.name,
                                System.StringComparison.CurrentCultureIgnoreCase)).First();
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void AddProduct(string name, decimal unit_price, int special_qty, decimal special_price)
        {
            products.Add(new Models.Product(name, unit_price, special_qty, special_price));
        }

        public void RemoveProduct(string name)
        {
            products.Remove(GetProduct(name));
        }
    }
}