namespace LuxWatch.Service
{

    using Data;
    using Model;
    using System.Linq;
    using System.Collections.Generic;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Services
    {

        private AppDbContext context = new AppDbContext();

        public int WatchCount()
        {
            return this.context.Watches.Count();
        }

        public Watch GetWatch(string refnum)
        {
            if (string.IsNullOrWhiteSpace(refnum))
            {
                throw new ArgumentException("Invalid reference number!");
            }
            Watch watch = this.context.Watches.FirstOrDefault(x => x.RefNum == refnum);
            if (watch == null)
            {
                throw new ArgumentException("Invalid reference number!");
            }
            return watch;
        }

        public string[] GetBrandsName()
        {
            return this.context.Brands.Select(x => x.Name).ToArray();
        }

        public ICollection<Watch> GetWatchesByBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentException("Invalid brand name!");
                
            }
            ICollection<Watch> watches = this.context.Watches.Where(x => x.Brand.Name == brand).ToArray();
            if (!watches.Any())
            {
                throw new ArgumentException("Not existing brand!");
                
            }
            return watches;
        }

        public void AddWatch(string refNum, string brand, string model, string material, string category, string size, string year, string price)
        {
            if (string.IsNullOrWhiteSpace(refNum))
            {
                throw new ArgumentException("Invalid reference number!");
            }

            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentException("Invalid brand name!");
            }
            if (this.context.Watches.Where(x => x.Brand.Name == brand) == null)
            {
                throw new ArgumentException("Not existing brand!");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Invalid watch model!");
            }

            if (string.IsNullOrWhiteSpace(material))
            {
                throw new ArgumentException("Invalid material!");
            }
            if (this.context.Watches.Where(x => x.Material.Type == material) == null)
            {
                throw new ArgumentException("Not existing material!");
            }
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("Invalid category!");
            }
            if (this.context.Watches.Where(x => x.Category.Sex == category) == null)
            {
                throw new ArgumentException("Not existing category!");
            }

            if (!int.TryParse(size, out _))
            {
                throw new ArgumentException("Invalid Size!");
            }
            if (int.Parse(size) < 29 || int.Parse(size) > 50)
            {
                throw new ArgumentException("Invalid Size!");
            }

            if (!(int.Parse(year) <= DateTime.Today.Year && int.Parse(year) >= 1880))
            {
                throw new ArgumentException("Invalid Year!");
            }

            if (!decimal.TryParse(price, out _))
            {
                throw new ArgumentException("Invalid Price!");
            }


            Watch watch = new Watch()
            {
                RefNum = refNum,
                BrandId = GettBrandIdbyName(brand),
                Model = model,
                MaterialId = GetMaterialIdbyType(material),
                CategoryId = GetCategoryIdbySex(category),
                Size = int.Parse(size),
                Year = int.Parse(year),
                Price = decimal.Parse(price)
            };

            context.Watches.Add(watch);
            context.SaveChanges();
        }
        public int GetCategoryIdbySex(string sex)
        {
            int Id = 1;
            var a = this.context.Categories.Where(x => x.Sex != null).ToList();
            foreach (var name in a)
            {
                if (sex != name.Sex)
                {
                    Id++;
                    
                }
                else
                {
                    break;
                }
            }
            return Id;
        }
        public int GetMaterialIdbyType(string type)
        {
            int Id = 1;
            var a = this.context.Materials.Where(x => x.Type != null).ToList();
            foreach (var name in a)
            {
                if (type != name.Type)
                {
                    Id++;

                }
                else
                {
                    break;
                }
            }
            return Id;
        }
        public int GettBrandIdbyName(string name)
        {
            int Id = 1;
            var a = this.context.Brands.Where(x => x.Name != null).ToList();
            foreach (var brand in a)
            {
                if (name != brand.Name)
                {
                    Id++;

                }
                else
                {
                    break;
                }
                
            }
            return Id;
        }
        public void UpdateWatchPrice(string watchrefnum, string price)
        {

            if (string.IsNullOrWhiteSpace(watchrefnum))
            {
                throw new ArgumentException("Invalid reference number!");
            }
            if (!double.TryParse(price, out _))
            {
                throw new ArgumentException("Invalid size price");
            }
            Watch watch = GetWatch(watchrefnum);
            watch.Price = decimal.Parse(price);
            context.Watches.Update(watch);
            context.SaveChanges();

        }
        public void UpdateProductImageUrl(string watchrefnum, string url)
        {

            if (string.IsNullOrWhiteSpace(watchrefnum))
            {
                throw new ArgumentException("Invalid reference number!");
            }
            Watch watch = GetWatch(watchrefnum);
            watch.ImageUrl = url;
            context.Watches.Update(watch);
            context.SaveChanges();
        }

        public void UpdateWatchSize(string watchrefnum, string size)
        {

            if (string.IsNullOrWhiteSpace(watchrefnum))
            {
                throw new ArgumentException("Invalid reference number!");
            }
            if (!double.TryParse(size, out _))
            {
                throw new ArgumentException("Invalid watch size");
            }
            Watch watch = GetWatch(watchrefnum);
            watch.Size = int.Parse(size);
            context.Watches.Update(watch);
            context.SaveChanges();
        }

        public void DeleteWatch(string watchrefnum)
        {

            if (string.IsNullOrWhiteSpace(watchrefnum))
            {
                throw new ArgumentException("Invalid reference number!");
            }
            var watch = GetWatch(watchrefnum);
            context.Watches.Remove(watch);
            context.SaveChanges();
        }

        public void PrintWatch(Watch watch)
        {
            Console.WriteLine($"Reference Number: {watch.RefNum}\nBrand: {watch.Brand.Name}\nModel: {watch.Model}\nSize: {watch.Size}\nMaterial: {watch.Material.Type}\nCategory: {watch.Category.Sex}\nYear: {watch.Year}\nPrice: {watch.Price}");
        }


    }
}
