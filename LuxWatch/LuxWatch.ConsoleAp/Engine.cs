namespace LuxWatch.ConsoleAp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Service;
    using Model;


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
                    Console.WriteLine("Select WC(To get watches' count)\nGW(To find a watch by reference number)\nGBN(To get all available brands)\nGWBB(To get all watches by their brand)\nAW(To add a watch)\nUP(To update a watch's price)\nUS(To update a watch's size)\nDW(To delete a watch)");
                    string option = Console.ReadLine().ToUpper();
                    //Console.Clear();
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
                            GetWatchByBrand();
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
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public void GetWatchesCount()
        {
            Console.WriteLine(services.WatchCount());
            Console.ReadLine();
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
            Console.ReadLine();
        }

        public void GetWatchByBrand()
        {
            Console.WriteLine("Input brand:");
            string brand = Console.ReadLine();

            foreach (var w in services.GetWatchesByBrand(brand))
            {
                services.PrintWatch(w);
            }
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
            Console.WriteLine("Watch Price Updated Successfully!");
        }

        public void DeleteWatch()
        {
            Console.WriteLine("Input Watch Reference Number:");
            string refnum = Console.ReadLine();
            services.DeleteWatch(refnum);
        }
    }
}
