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
                        "\nUS(To update a watch's size)\nDW(To delete a watch)\nAM(Add new material)\nAB(Add new brand)\nDB(Delete a brand)\nDM(Delete a material)\nQ(quit application)");
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
            Console.WriteLine("Input Material: ");
            string type = Console.ReadLine();

            foreach (var w in services.GetWatchesByMaterial(type))
            {
                Console.WriteLine();
                services.PrintWatch(w);
            }

        }

        public void GetWatchesCount()
        {
            Console.WriteLine($"Waches Count{services.WatchCount()}");
            
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
            Console.WriteLine("Material Successfully Added!");
        }
        public void AddBrand()
        {
            Console.WriteLine("Input brand name: ");
            string name = Console.ReadLine();
            services.AddBrand(name);
            Console.WriteLine("Brand Successfully Added!");
        }

        public void AddWatch()
        {
            Console.WriteLine("Input Reference Number:");
            string refnum = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input Brand:");
            string brand = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input Model:");
            string model = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input Material:");
            string material = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input Catergory:");
            string category = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input Size:");
            string size = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input Year:");
            string year = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Input Price:");
            string price = Console.ReadLine();
            Console.Clear();

            services.AddWatch(refnum, brand, model, material, category, size, year, price);
            Console.WriteLine("Watch Added Successfully!");
            
        }

        public void UpdatePrice()
        {
            Console.WriteLine("Input Watch Reference Number and New Price:");
            string input = Console.ReadLine();
            string refNum = input.Split(' ')[0];
            string price = input.Split(' ')[1];

            services.UpdateWatchPrice(refNum, price);
            Console.WriteLine("Watch Price Updated Successfully!");
            
        }

        public void UpdateSize()
        {
            Console.WriteLine("Input Watch Reference Number and New Size:");
            string input = Console.ReadLine();
            string refNum = input.Split(' ')[0];
            string size = input.Split(' ')[1];

            services.UpdateWatchSize(refNum, size);
            Console.WriteLine("Watch Size Updated Successfully!");
           
        }

        public void DeleteWatch()
        {
            Console.WriteLine("Input Watch Reference Number:");
            string refnum = Console.ReadLine();
            services.DeleteWatch(refnum);
            Console.WriteLine("Watch Successfully Deleted!");
            
        }
        public void DeleteBrand()
        {
            Console.WriteLine("Input Brand Name:");
            string name = Console.ReadLine();
            services.DeleteBrand(name);
            Console.WriteLine("Brand Successfully Deleted!");

        }
        public void DeleteMaterial()
        {
            Console.WriteLine("Input Material Type:");
            string type = Console.ReadLine();
            services.DeleteMaterial(type);
            Console.WriteLine("Material Successfully Deleted!");

        }
    }
}
