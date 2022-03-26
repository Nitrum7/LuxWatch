namespace LuxWatch.ConsoleAp
{
    using System;
    using Service;


    public class Engine
    {
        Services services;

        public Engine()
        {
            services = new Services();
            Run();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nSelect:\nWC(To get watches' count)\nGW(To find a watch by reference number)\nGBN(To get all available brands)\nGWBB(To get all watches by their brand)\nAW(To add a watch)\nUP(To update a watch's price)" +
                        "\nUS(To update a watch's size)\nDW(To delete a watch)\nAM(To add a new material)\nAB(To add a new brand)\nDB(To delete a brand)\nDM(To delete a material)\nQ(Quit application)");
                    string option = Console.ReadLine().ToUpper();

                    switch (option)
                    {
                        case "WC":
                            GetWatchesCount();
                            break;
                        case "GW":
                            GetWatch();
                            break;
                        case "GBN":
                            GetBrandsName();
                            break;
                        case "GWBB":
                            GetWatchesByBrand();
                            break;
                        case "AW":
                            AddWatch();
                            break;
                        case "UP":
                            UpdatePrice();
                            break;
                        case "US":
                            UpdateSize();
                            break;
                        case "DW":
                            DeleteWatch();
                            break;
                        case "AM":
                            AddMaterial();
                            break;
                        case "AB":
                            AddBrand();
                            break;
                        case "DB":
                            DeleteBrand();
                            break;
                        case "DM":
                            DeleteMaterial();
                            break;
                        case "GWBM":
                            GetWatchesByMateral();
                            break;
                        case "Q":
                            Environment.Exit(0);
                            break;
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        public void GetWatchesByMateral()
        {
            Console.WriteLine("Input material: ");
            string type = Console.ReadLine();

            foreach (var w in services.GetWatchesByMaterial(type))
            {
                Console.WriteLine();
                services.PrintWatch(w);
            }
        }

        public void GetWatchesCount()
        {
            Console.WriteLine($"Waches count: {services.WatchCount()}");          
        }

        public void GetWatch()
        {
            Console.WriteLine("Input watch reference number:");
            string input = Console.ReadLine();
            services.PrintWatch(services.GetWatch(input));           
        }

        public void GetBrandsName()
        {
            foreach (var b in services.GetBrandsName())
            {
                Console.WriteLine(b.ToString());
            }           
        }

        public void GetWatchesByBrand()
        {
            Console.WriteLine("Input brand: ");
            string brand = Console.ReadLine();

            foreach (var w in services.GetWatchesByBrand(brand))
            {
                services.PrintWatch(w);
            }           
        }
        public void AddMaterial()
        {
            Console.WriteLine("Input material type: ");
            string materal = Console.ReadLine();
            services.AddMaterial(materal);
            Console.WriteLine("Material successfully added!");
        }
        public void AddBrand()
        {
            Console.WriteLine("Input brand name: ");
            string name = Console.ReadLine();
            services.AddBrand(name);
            Console.WriteLine("Brand successfully added!");
        }

        public void AddWatch()
        {
            Console.WriteLine("Input reference number:");
            string refnum = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input brand:");
            string brand = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input model:");
            string model = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input material:");
            string material = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input catergory(Male, Female, Unisex):");
            string category = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input size:");
            string size = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input year:");
            string year = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input price:");
            string price = Console.ReadLine();
            Console.Clear();

            services.AddWatch(refnum, brand, model, material, category, size, year, price);
            Console.WriteLine("Watch added successfully!");           
        }

        public void UpdatePrice()
        {
            Console.WriteLine("Input watch reference number and new price:");
            string input = Console.ReadLine();
            string refNum = input.Split(' ')[0];
            string price = input.Split(' ')[1];

            services.UpdateWatchPrice(refNum, price);
            Console.WriteLine("Watch price updated successfully!");
            
        }

        public void UpdateSize()
        {
            Console.WriteLine("Input watch reference number and new size:");
            string input = Console.ReadLine();
            string refNum = input.Split(' ')[0];
            string size = input.Split(' ')[1];

            services.UpdateWatchSize(refNum, size);
            Console.WriteLine("Watch size updated successfully!");           
        }

        public void DeleteWatch()
        {
            Console.WriteLine("Input watch reference number:");
            string refnum = Console.ReadLine();
            services.DeleteWatch(refnum);
            Console.WriteLine("Watch successfully deleted!");           
        }
        public void DeleteBrand()
        {
            Console.WriteLine("Input brand name:");
            string name = Console.ReadLine();
            services.DeleteBrand(name);
            Console.WriteLine("Brand successfully deleted!");

        }
        public void DeleteMaterial()
        {
            Console.WriteLine("Input material type:");
            string type = Console.ReadLine();
            services.DeleteMaterial(type);
            Console.WriteLine("Material successfully deleted!");
        }
    }
}
