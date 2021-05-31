using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MMTShop.Business.Components;
using MMTShop.Business.Interfaces;
using MMTShop.Models;

namespace MMTShop.ConsoleApp
{
    class Program
    {
        private static readonly IApiGateway _apiGateway = new ApiGateway();
        private static string CATEGORIES_ENDPOINT = "https://localhost:44373/api/v1/products/categories";
        private static string FEATURED_PRODUCTS_ENDPOINT = "https://localhost:44373/api/v1/products/featured";
        private static string PRODUCTS_BY_CATEGORY_ENDPOINT = "https://localhost:44373/api/v1/products/category";
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            Console.WriteLine("Calling API To Get Featured Products...");
            var featuredProducts = await _apiGateway.GetAsync<List<Product>>(FEATURED_PRODUCTS_ENDPOINT);

            //Only attempt to print feature product information if the object returned from API call is not null
            if (featuredProducts != null)
            {
                Console.WriteLine("Featured Products Retrieved");
                Console.WriteLine("The Featured Products Are : ");
                PrintItemsInList(featuredProducts);
            }
            else
                Console.WriteLine("Could Not Retrieve Featured Products");

            Console.Write("Retrieving Categories...");
            var categories = await _apiGateway.GetAsync<List<Category>>(CATEGORIES_ENDPOINT);

            //Only attempt to print category information if the object returned from API call is not null
            if (categories != null)
            {
                Console.WriteLine("Categories Retrieved");
                Console.WriteLine("The Categories Are : ");
                PrintItemsInList(categories);
            }
            else
            {
                Console.WriteLine("Could Not Retrieve Categories");
                return;
            }

            Console.Write("Printing Products In Each Category..");

            foreach (var category in categories)
            {
                Console.WriteLine($"Retrieving Products In Category {category.Name}");
                var productsInCategory = await _apiGateway.GetAsync<List<Product>>($"{PRODUCTS_BY_CATEGORY_ENDPOINT}/{category.Id}");
                
                //Only attempt to print product information if the object returned from API call is not null
                if (productsInCategory != null)
                {
                    Console.WriteLine($"The Products For Category '{category.Name}' are : ");
                    PrintItemsInList(productsInCategory);
                }
                else
                    Console.WriteLine($"Could Not Retrieve Products For Category {category.Name}");
            }
            Console.ReadLine();
        }


        private static void PrintItemsInList<T>(List<T> listOfItems)
        {
            if (listOfItems.FirstOrDefault()?.GetType() == typeof(Product))
                foreach (Product product in listOfItems as List<Product>)
                    Console.WriteLine($"{product.Id} - {product.Name} - {product.Sku} - {product.Price}");
  
            else if (listOfItems.FirstOrDefault()?.GetType() == typeof(Category))
                foreach (Category category in listOfItems as List<Category>)
                    Console.WriteLine($"{category.Id} - {category.Name}");
            else
                Console.WriteLine("Unknown Object Type Passed In.... ");
        }

    }
}
