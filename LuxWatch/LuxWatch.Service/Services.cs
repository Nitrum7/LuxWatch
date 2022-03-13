namespace LuxWatch.Service
{

    using Data;
    using Model;
    using System.Linq;
    using System.Collections.Generic;
    using System;

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
            Watch watch = this.context.Watches.FirstOrDefault(x=>x.RefNum==refnum);
            return watch;
        }

        public string[] GetBrandsName()
        {
            return this.context.Brands.Select(x => x.Name).ToArray();
        }

        public List<Watch> GetWatchesByBrand(string brand)
        {
           
            if (!int.TryParse(brand, out _))
            {
                throw new ArgumentException("Invalid Brand!");
            }
            else if (int.Parse(brand) < 1 || int.Parse(brand) > 9)
            {
                throw new ArgumentException("Invalid Brand!");
            }
             List <Watch> watches = this.context.Watches.Where(x => x.Brand.Name == brand).ToList();
            return watches;

        }

        public void AddWatch(string refNum, string brand, string model, string material, string category, string size, string year, string price)
        {
            if (string.IsNullOrWhiteSpace(refNum))
            {
                throw new ArgumentException("Invalid reference number!");
            }

            if (!int.TryParse(brand, out _))
            {
                throw new ArgumentException("Invalid Brand!");
            }
            else if (int.Parse(brand) < 1 || int.Parse(brand) > 9)
            {
                throw new ArgumentException("Invalid Brand!");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Invalid watch model!");
            }

            if (!int.TryParse(material, out _))
            {
                throw new ArgumentException("Invalid Material!");
            }
            else if (int.Parse(material) < 1 || int.Parse(material) > 7)
            {
                throw new ArgumentException("Invalid Material!");
            }

            if (!int.TryParse(category, out _))
            {
                throw new ArgumentException("Invalid Category!");
            }
            if (int.Parse(category) < 1 || int.Parse(category) > 3)
            {
                throw new ArgumentException("Invalid Category!");
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


            Watch watch = new Watch() {
                RefNum = refNum,
                BrandId = int.Parse(brand),
                Model = model,
                MaterialId = int.Parse(material),
                CategoryId = int.Parse(category),
                Size = int.Parse(size),
                Year = int.Parse(year),
                Price = decimal.Parse(price)
            };

            context.Watches.Add(watch);
            context.SaveChanges();
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
            Console.WriteLine($"Reference Number: {watch.RefNum}\nBrand: {watch.Brand}\nModel: {watch.Model}\nSize: {watch.Size}\nMaterial: {watch.Material}\nCategory: {watch.Category}\nYear: {watch.Year}\nPrice: {watch.Price}");
        }

    }
}
