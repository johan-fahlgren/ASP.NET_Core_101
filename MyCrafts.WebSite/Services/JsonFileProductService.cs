﻿using MyCrafts.WebSite.Models;
using System.Text.Json;

namespace MyCrafts.WebSite.Services
{
    public class JsonFileProductService
    {
        public JsonFileProductService(
            IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment;

        private string JsonFileName
        {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath,
                    "data", "products.json");
            }
        }
        public IEnumerable<Product>? GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(
                    jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true });

            }
        }

    }
}