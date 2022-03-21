namespace LuxWatch.DataProcessor
{
    using LuxWatch.Model;
    using LuxWatch.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class DataSeeder
    {
        private Services service = new Services();

        public DataSeeder()
        {
            SeedProducts();
        }
        public void SeedProducts()
        {
            string imageUrl = "https://freepngimg.com/thumb/coming_soon/4-2-coming-soon-png.png";

            if (service.GetWatches().Any())
            {
                Console.WriteLine("Database is not empty!");
                return;
            }

            List<Brand> brands = new List<Brand>();
            List<Material> materials = new List<Material>();
            List<Category> categories = new List<Category>();
            List<Watch> watches = new List<Watch>();

            brands.Add(new Brand() { Name = "Rolex" });
            brands.Add(new Brand() { Name = "Patek Philippe" });
            brands.Add(new Brand() { Name = "Audemars Piguet" });
            brands.Add(new Brand() { Name = "Richard Mille" });
            brands.Add(new Brand() { Name = "Casio" });
            brands.Add(new Brand() { Name = "Hamilton" });
            brands.Add(new Brand() { Name = "Omega" });
            brands.Add(new Brand() { Name = "Fossil" });
            brands.Add(new Brand() { Name = "Bvlgari" });

            materials.Add(new Material() { Type = "Stainless Steel" });
            materials.Add(new Material() { Type = "Rose Gold" });
            materials.Add(new Material() { Type = "Yellow Gold" });
            materials.Add(new Material() { Type = "White Gold" });
            materials.Add(new Material() { Type = "Platinium" });
            materials.Add(new Material() { Type = "Saphire" });
            materials.Add(new Material() { Type = "Titanium" });

            categories.Add(new Category() { Sex = "Male" });
            categories.Add(new Category() { Sex = "Female" });
            categories.Add(new Category() { Sex = "Unisex" });

            for (int i = 0; i < 20; i++)
            {
                Random random = new Random();

            }
        }
    }
}
