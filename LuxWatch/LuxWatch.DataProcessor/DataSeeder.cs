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

            brands.Add(new Brand() { Name = "Rolex" });
            brands.Add(new Brand() { Name = "Patek Philippe" });
            brands.Add(new Brand() { Name = "Audemars Piguet" });
            brands.Add(new Brand() { Name = "Richard Mille" });
            brands.Add(new Brand() { Name = "Casio" });
            brands.Add(new Brand() { Name = "Hamilton" });
            brands.Add(new Brand() { Name = "Omega" });
            brands.Add(new Brand() { Name = "Fossil" });
            brands.Add(new Brand() { Name = "Bvlgari" });
            service.AddBrands(brands);

            materials.Add(new Material() { Type = "Stainless Steel" });
            materials.Add(new Material() { Type = "Rose Gold" });
            materials.Add(new Material() { Type = "Yellow Gold" });
            materials.Add(new Material() { Type = "White Gold" });
            materials.Add(new Material() { Type = "Platinium" });
            materials.Add(new Material() { Type = "Saphire" });
            materials.Add(new Material() { Type = "Titanium" });
            service.AddMaterials(materials);

            categories.Add(new Category() { Sex = "Male" });
            categories.Add(new Category() { Sex = "Female" });
            categories.Add(new Category() { Sex = "Unisex" });
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
