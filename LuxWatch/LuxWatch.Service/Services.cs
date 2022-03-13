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

        public Watch GetWatch(int id)
        {
            return context.Watches.Find(id);
        }

        public string[] GetBrandName()
        {
            return this.context.Brands.Select(x => x.Name).ToArray();
        }

        public List<Watch> GetWatchesByBrand(string brandId)
        {
            List<Watch> watches = new List<Watch>();

            if (!int.TryParse(brandId, out _))
            {
                throw new ArgumentException("Invalid Brand Id!");
            }
            else if (int.Parse(brandId) < 1 || int.Parse(brandId) > 9)
            {
                throw new ArgumentException("Invalid Brand Id!");
            }

            Watch watch = new Watch();

            return watches; // <= TODO

        
        }

        public void AddWatch(string refNum, string brandId, string model, string material, string category, string size, string year, string price)
        {
            if (string.IsNullOrWhiteSpace(refNum))
            {
                throw new ArgumentException("Invalid product name!");
            }

            if (!int.TryParse(brandId, out _))
            {
                throw new ArgumentException("Invalid Brand Id!");
            }
            else if (int.Parse(brandId) < 1 || int.Parse(brandId) > 9)
            {
                throw new ArgumentException("Invalid Brand Id!");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Invalid watch model!");
            }

            if (!int.TryParse(material, out _))
            {
                throw new ArgumentException("Invalid Material Id!");
            }
            else if (int.Parse(material) < 1 || int.Parse(material) > 7)
            {
                throw new ArgumentException("Invalid Material Id!");
            }

            if (!int.TryParse(category, out _))
            {
                throw new ArgumentException("Invalid Category Id!");
            }
            if (int.Parse(category) < 1 || int.Parse(category) > 3)
            {
                throw new ArgumentException("Invalid Category Id!");
            }

            if (!int.TryParse(size, out _))
            {
                throw new ArgumentException("Invalid Size!");
            }
            if (int.Parse(size) < 29 || int.Parse(size) > 50)
            {
                throw new ArgumentException("Invalid Size!");
            }

            if (year.Length == 4 && int.Parse(year) < DateTime.Today.Year)
            {
                throw new ArgumentException("Invalid Year!");
            }

            if (!decimal.TryParse(price, out _))
            {
                throw new ArgumentException("Invalid Price!");
            }


            Watch watch = new Watch() {
                RefNum = refNum,
                BrandId = int.Parse(brandId),
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

        public void UpdateWatchPrice(int watchId, string price)
        {
            Watch watch = GetWatch(watchId);
            if (watch == null)
            {
                throw new ArgumentException("Invalid watch id");
            }
            if (!double.TryParse(price, out _))
            {
                throw new ArgumentException("Invalid size price");
            }

            watch.Price = decimal.Parse(price);
            context.Watches.Update(watch);
            context.SaveChanges();

        }

        public void UpdateWatchSize(int watchId, string size)
        {
            Watch watch = GetWatch(watchId);
            if (watch == null)
            {
                throw new ArgumentException("Invalid watch id");
            }
            if (!double.TryParse(size, out _))
            {
                throw new ArgumentException("Invalid watch size");
            }

            watch.Size = int.Parse(size);
            context.Watches.Update(watch);
            context.SaveChanges();
        }

        public void DeleteWatch(int watchId)
        {
            var watch = GetWatch(watchId);
            if (watch == null)
            {
                throw new ArgumentException("Invalid watch id");
            }
            context.Watches.Remove(watch);
            context.SaveChanges();
        }

    }
}
