using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumeCapstone7Api
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            var _httpContext = new HttpClient();
            _httpContext.BaseAddress = new Uri("https://localhost:5001/api/");
            var product = new Product();
            int selectProduct = 0;
            do
            {
                Console.WriteLine("Input a product Id");
                selectProduct = int.Parse(Console.ReadLine());
                if (selectProduct != 0)
                {
                    product = GetProduct(_httpContext, options, selectProduct).GetAwaiter().GetResult();
                    Console.WriteLine($"Product: {product.ProductName}");
                    Console.WriteLine($"Price: {product.UnitPrice}");
                    Console.WriteLine($"Product Id: {product.ProductId}");
                    Console.WriteLine($"Units In Stock: {product.UnitsInStock}");

                    Console.WriteLine("Press any key to continue....");
                    Console.ReadLine();
                }
                
            } while (selectProduct != 0);
            
           

        }
        public static async Task<Product> GetProduct(HttpClient httpClient, JsonSerializerOptions options, int productId)
        {
            var rawResult = await httpClient.GetAsync($"Product/{productId}");
            var resultAsJson = await rawResult.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<Product>(resultAsJson, options);

            return product;
        }
    }
}
