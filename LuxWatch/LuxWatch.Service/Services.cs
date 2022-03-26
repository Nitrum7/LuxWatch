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
        public int WatchCountByBrand(string brand)
        {
            ICollection<Watch> watches = this.GetWatchesByBrand(brand);
            return watches.Count();
        }
        public int WatchCountByMaterial(string material)
        {
            ICollection<Watch> watches = this.GetWatchesByMaterial(material);
            return watches.Count();
        }
        public Material GetMaterial(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("Invalid type!");
            }
            Material material = this.context.Materials.FirstOrDefault(x => x.Type == type);
            if (material == null)
            {
                throw new ArgumentException("Invalid type!");
            }
            return material;
        }
        public Brand GetBrand(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid name!");
            }
            Brand brand = this.context.Brands.FirstOrDefault(x => x.Name == name);
            if (brand == null)
            {
                throw new ArgumentException("Invalid name!");
            }
            return brand;
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
        public string[] GetMaterialType()
        {
            return this.context.Materials.Select(x => x.Type).ToArray();
        }
        public string[] GetCategorySex()
        {
            return this.context.Categories.Select(x => x.Sex).ToArray();
        }
        public Watch[] GetAllWatches()
        {
            return this.context.Watches.OrderBy(x => x.Model).ToArray();
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
                throw new ArgumentException("Not an available brand!");

            }
            return watches;
        }
        public ICollection<Watch> GetWatchesByMaterial(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("Invalid type!");

            }
            ICollection<Watch> watches = this.context.Watches.Where(x => x.Material.Type == type).ToArray();
            if (!watches.Any())
            {
                throw new ArgumentException("Not existing type!");

            }
            return watches;
        }
        public ICollection<Watch> GetWatches(int page = 1, int itemsPerPage = 3)
        {
            return this.context.Watches
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();
        }
        public ICollection<Watch> GetWatchesByBrand(string brand, int page = 1, int itemsPerPage = 2)
        {
            return this.context.Watches
                .Where(x => x.Brand.Name == brand)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();
        }
        public ICollection<Watch> GetWatchesByMaterial(string material, int page = 1, int itemsPerPage = 2)
        {
            return this.context.Watches
                .Where(x => x.Material.Type == material)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();
        }
        public void AddBrand(string name)
        {
            int count = 1;
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid brand!");
            }
            var a = this.context.Brands.Where(x => x.Name != null).ToList();
            foreach (var brand1 in a)
            {
                if (name != brand1.Name)
                {
                    count++;

                }
            }
            if (count == a.Count)
            {
                throw new ArgumentException("Brand already exists!");

            }
            else
            {
                Brand brand = new Brand()
                {

                    Name = name
                };
                context.Brands.Add(brand);
                context.SaveChanges();
            }
        }
        public void AddMaterial(string type)
        {
            int count = 1;
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("Invalid material!");
            }
            var a = this.context.Materials.Where(x => x.Type != null).ToList();
            foreach (var material in a)
            {
                if (type != material.Type)
                {
                    count++;
                }
            }
            if (count == a.Count)
            {
                throw new ArgumentException("Material already exists!");
            }
            else
            {
                Material materia = new Material()
                {
                    Type = type
                };
                context.Materials.Add(materia);
                context.SaveChanges();
            }
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
                throw new ArgumentException("Not an existing brand!");
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
                throw new ArgumentException("Not an existing material!");
            }
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("Invalid category!");
            }
            if (this.context.Watches.Where(x => x.Category.Sex == category) == null)
            {
                throw new ArgumentException("Not an existing category!");
            }

            if (!int.TryParse(size, out _))
            {
                throw new ArgumentException("Invalid size!");
            }
            if (int.Parse(size) < 29 || int.Parse(size) > 50)
            {
                throw new ArgumentException("Invalid size!");
            }

            if (!(int.Parse(year) <= DateTime.Today.Year && int.Parse(year) >= 1880))
            {
                throw new ArgumentException("Invalid year!");
            }

            if (!decimal.TryParse(price, out _))
            {
                throw new ArgumentException("Invalid price!");
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
            int id = 1;
            var a = this.context.Categories.Where(x => x.Sex != null).ToList();
            foreach (var name in a)
            {
                if (sex != name.Sex)
                {
                    id++;
                }
                else
                {
                    break;
                }
            }
            if (id > a.Count())
            {
                throw new ArgumentException("Invalid category!");
            }
            else
            {
                return id;
            }
        }
        public int GetMaterialIdbyType(string type)
        {
            int id = 1;
            var a = this.context.Materials.Where(x => x.Type != null).ToList();
            foreach (var name in a)
            {
                if (type != name.Type)
                {
                    id++;
                }
                else
                {
                    break;
                }
            }
            if (id > a.Count())
            {
                throw new ArgumentException("Invalid material!");
            }
            else
            {
                return id;
            }
        }
        public int GettBrandIdbyName(string name)
        {
            int id = 1;
            var a = this.context.Brands.Where(x => x.Name != null).ToList();
            foreach (var brand in a)
            {
                if (name != brand.Name)
                {
                    id++;

                }
                else
                {
                    break;
                }

            }
            if (id > a.Count())
            {
                throw new ArgumentException("Invalid brand!");
            }
            else
            {
                return id;
            }
        }
        public void UpdateWatchPrice(string watchrefnum, string price)
        {

            if (string.IsNullOrWhiteSpace(watchrefnum))
            {
                throw new ArgumentException("Invalid reference number!");
            }
            if (!double.TryParse(price, out _))
            {
                throw new ArgumentException("Invalid price");
            }
            Watch watch = GetWatch(watchrefnum);
            watch.Price = decimal.Parse(price);
            context.Watches.Update(watch);
            context.SaveChanges();

        }
        public void UpdateWatchImageUrl(string watchrefnum, string url)
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
        public void DeleteMaterial(string type)
        {

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("Invalid type!");
            }
            var materal = GetMaterial(type);
            context.Materials.Remove(materal);
            context.SaveChanges();
        }
        public void DeleteBrand(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid name!");
            }
            var brand = GetBrand(name);
            context.Brands.Remove(brand);
            context.SaveChanges();
        }

        public string PrintWatchForm(Watch watch)
        {
            return ($"Reference number: {watch.RefNum}\nBrand: {watch.Brand.Name}\nModel: {watch.Model}\nSize: {watch.Size}\nMaterial: {watch.Material.Type}\nCategory: {watch.Category.Sex}\nYear: {watch.Year}\nPrice: {watch.Price}\n{new string('-', 50)}$\n");
        }
        public void PrintWatch(Watch watch)
        {
            Console.WriteLine($"Reference number: {watch.RefNum}\nBrand: {watch.Brand.Name}\nModel: {watch.Model}\nSize: {watch.Size}\nMaterial: {watch.Material.Type}\nCategory: {watch.Category.Sex}\nYear: {watch.Year}\nPrice: {watch.Price}$");
        }

        public void AddBrands(List<Brand> brands)
        {
            foreach (var name in brands)
            {
                int count = 1;
                if (string.IsNullOrWhiteSpace(name.Name))
                {
                    throw new ArgumentException("Invalid brand!");
                }
                var a = this.context.Brands.Where(x => x.Name != null).ToList();
                foreach (var brand1 in a)
                {
                    if (name.Name != brand1.Name)
                    {
                        count++;

                    }
                }
                if (count == a.Count)
                {
                    throw new ArgumentException("Brand already exists!");

                }
                else
                {
                    Brand brand = new Brand()
                    {

                        Name = name.Name
                    };
                    context.Brands.Add(brand);
                    context.SaveChanges();
                }
            
            }
        }

        public void AddMaterials(List<Material> materials)
        {
            foreach (var type in materials)
            {
                int count = 1;
                if (string.IsNullOrWhiteSpace(type.Type))
                {
                    throw new ArgumentException("Invalid material!");
                }
                var a = this.context.Materials.Where(x => x.Type != null).ToList();
                foreach (var material in a)
                {
                    if (type.Type != material.Type)
                    {
                        count++;
                    }
                }
                if (count == a.Count)
                {
                    throw new ArgumentException("Material already exists!");
                }
                else
                {
                    Material materia = new Material()
                    {
                        Type = type.Type
                    };
                    context.Materials.Add(materia);
                    context.SaveChanges();
                }
            }
            
        }

        public void AddCategories(List<Category> categories)
        {
            foreach (var sex in categories)
            {
                int count = 1;
                if (string.IsNullOrWhiteSpace(sex.Sex))
                {
                    throw new ArgumentException("Invalid category!");
                }
                var a = this.context.Categories.Where(x => x.Sex != null).ToList();
                foreach (var category1 in a)
                {
                    if (sex.Sex != category1.Sex)
                    {
                        count++;
                    }
                }
                if (count == a.Count)
                {
                    throw new ArgumentException("Category already exists!");
                }
                else
                {
                    Category category = new Category()
                    {
                        Sex = sex.Sex
                    };
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
            }

        }

    }
}
