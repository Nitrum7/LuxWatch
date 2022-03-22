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
            SeedWatches();
        }
        public void SeedWatches()
        {
            //string imageUrl = "https://freepngimg.com/thumb/coming_soon/4-2-coming-soon-png.png";

            if (service.GetWatches().Any())
            {
                Console.WriteLine("Database is not empty!");
                return;
            }

            List<Brand> brands = new List<Brand>();
            List<Material> materials = new List<Material>();
            List<Category> categories = new List<Category>();

            brands.Add(new Brand() { Id = 1, Name = "Rolex" });
            brands.Add(new Brand() { Id = 2, Name = "Patek Philippe" });
            brands.Add(new Brand() { Id = 3, Name = "Audemars Piguet" });
            brands.Add(new Brand() { Id = 4, Name = "Richard Mille" });
            brands.Add(new Brand() { Id = 5, Name = "Casio" });
            brands.Add(new Brand() { Id = 6, Name = "Hamilton" });
            brands.Add(new Brand() { Id = 7, Name = "Omega" });
            brands.Add(new Brand() { Id = 8, Name = "Fossil" });
            brands.Add(new Brand() { Id = 9, Name = "Bvlgari" });
            service.AddBrands(brands);

            materials.Add(new Material() { Id = 1, Type = "Stainless Steel" });
            materials.Add(new Material() { Id = 2, Type = "Rose Gold" });
            materials.Add(new Material() { Id = 3, Type = "Yellow Gold" });
            materials.Add(new Material() { Id = 4, Type = "White Gold" });
            materials.Add(new Material() { Id = 5, Type = "Platinium" });
            materials.Add(new Material() { Id = 6, Type = "Saphire" });
            materials.Add(new Material() { Id = 7, Type = "Titanium" });
            service.AddMaterials(materials);

            categories.Add(new Category() { Id = 1, Sex = "Male" });
            categories.Add(new Category() { Id = 2, Sex = "Female" });
            categories.Add(new Category() { Id = 3, Sex = "Unisex" });
            service.AddCategories(categories);

            for (int i = 0; i < 20; i++)
            {
                Random random = new Random();
                string refNum = $"{random.Next(10000, 9999999)}";
                string brand = brands[random.Next(1, brands.Count)].Name;
                string model = $"Model {i}";
                string material = materials[random.Next(1, materials.Count)].Type;
                string category = categories[random.Next(1, categories.Count)].Sex;
                string size = $"{random.Next(29, 50)}";
                string year = $"{random.Next(1880, DateTime.Today.Year)}";
                string price = $"{random.Next(1, 20000) * random.NextDouble():f2}";
                service.AddWatch(refNum, brand, model, material, category, size, year, price);
            }
        }
    }
}
