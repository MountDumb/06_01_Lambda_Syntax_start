using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LINQ_Examples
{
    class Program
    {
        #region Class Definitions
        public class Customer
        {
            public string First { get; set; }
            public string Last { get; set; }
            public string State { get; set; }
            public double Price { get; set; }
            public string[] Purchases { get; set; }
        }

        public class Distributor
        {
            public string Name { get; set; }
            public string State { get; set; }
        }

        public class CustDist
        {
            public string custName { get; set; }
            public string distName { get; set; }
        }

        public class CustDistGroup
        {
            public string custName { get; set; }
            public IEnumerable<string> distName { get; set; }
        }
        #endregion

        #region Create data sources

        static List<Customer> customers = new List<Customer>
        {
            new Customer {First = "Cailin", Last = "Alford", State = "GA", Price = 930.00, Purchases = new string[] {"Panel 625", "Panel 200"}},
            new Customer {First = "Theodore", Last = "Brock", State = "AR", Price = 2100.00, Purchases = new string[] {"12V Li"}},
            new Customer {First = "Jerry", Last = "Gill", State = "MI", Price = 585.80, Purchases = new string[] {"Bulb 23W", "Panel 625"}},
            new Customer {First = "Owens", Last = "Howell", State = "GA", Price = 512.00, Purchases = new string[] {"Panel 200", "Panel 180"}},
            new Customer {First = "Adena", Last = "Jenkins", State = "OR", Price = 2267.80, Purchases = new string[] {"Bulb 23W", "12V Li", "Panel 180"}},
            new Customer {First = "Medge", Last = "Ratliff", State = "GA", Price = 1034.00, Purchases = new string[] {"Panel 625"}},
            new Customer {First = "Sydney", Last = "Bartlett", State = "OR", Price = 2105.00, Purchases = new string[] {"12V Li", "AA NiMH"}},
            new Customer {First = "Malik", Last = "Faulkner", State = "MI", Price = 167.80, Purchases = new string[] {"Bulb 23W", "Panel 180"}},
            new Customer {First = "Serena", Last = "Malone", State = "GA", Price = 512.00, Purchases = new string[] {"Panel 180", "Panel 200"}},
            new Customer {First = "Hadley", Last = "Sosa", State = "OR", Price = 590.20, Purchases = new string[] {"Panel 625", "Bulb 23W", "Bulb 9W"}},
            new Customer {First = "Nash", Last = "Vasquez", State = "OR", Price = 10.20, Purchases = new string[] {"Bulb 23W", "Bulb 9W"}},
            new Customer {First = "Joshua", Last = "Delaney", State = "WA", Price = 350.00, Purchases = new string[] {"Panel 200"}}
        };

        static List<Distributor> distributors = new List<Distributor>
        {
            new Distributor {Name = "Edgepulse", State = "UT"},
            new Distributor {Name = "Jabbersphere", State = "GA"},
            new Distributor {Name = "Quaxo", State = "FL"},
            new Distributor {Name = "Yakijo", State = "OR"},
            new Distributor {Name = "Scaboo", State = "GA"},
            new Distributor {Name = "Innojam", State = "WA"},
            new Distributor {Name = "Edgetag", State = "WA"},
            new Distributor {Name = "Leexo", State = "HI"},
            new Distributor {Name = "Abata", State = "OR"},
            new Distributor {Name = "Vidoo", State = "TX"}
        };

        static double[] exchange = { 0.89, 0.65, 120.29 };

        static double[] ExchangedPrices = {827.70, 604.50, 111869.70,
                                        1869.00, 1,365.00, 252609.00,
                                        521.36, 380.77, 70465.88,
                                        455.68, 332.80, 61588.48,
                                        2018.34, 1474.07, 272793.66,
                                        920.26, 672.10, 124379.86,
                                        1873.45, 1368.25, 253210.45,
                                        149.34, 109.07, 20184.66,
                                        455.68, 332.80, 61588.48,
                                        525.28, 383.63, 70995.16,
                                        9.08, 6.63, 1226.96,
                                        311.50, 227.50, 42101.50};

        static string[] Purchases = {  "Panel 625", "Panel 200",
                                    "12V Li",
                                    "Bulb 23W", "Panel 625",
                                    "Panel 200", "Panel 180",
                                    "Bulb 23W", "12V Li", "Panel 180",
                                    "Panel 625",
                                    "12V Li", "AA NiMH",
                                    "Bulb 23W", "Panel 180",
                                    "Panel 180", "Panel 200",
                                    "Panel 625", "Bulb 23W", "Bulb 9W",
                                    "Bulb 23W", "Bulb 9W",
                                    "Panel 200"
                                 };
        #endregion

        static void Main(string[] args)
        {

            Program p = new Program();
            //p.ShowExchangePricesAboveThousand();
            //p.DrillCustomers();
            //p.ShowNames();
            p.Compound();
            //p.TakeThreeCustomers();
            //p.TakeThreeFromOregon();
            //p.OrderCustomersByFirstNameOrLength();
            //p.OrderCustomerByPrice();
            //p.OrderCustomersByFirstLengthLastAlphabetically();
            //p.GroupCustomersByFirstLetter();
            //p.GroupCustomersByState();
            //p.ShowCustomersWithDifferingLettersinFirstAndLastName();
            //p.TryOutAnyStatement();
            Console.ReadKey();
        }

        public void TryOutAnyStatement()
        {
            var cust = customers.Any(x => x.First.Contains("ed"));
            Console.WriteLine($"It's {cust} that a first name in Customers contains " + '"' + "ed" + "'");
                 
        }

        public void ShowCustomersWithDifferingLettersinFirstAndLastName()
        {
            var names = customers.Except(customers.Where(x => x.First[0] == x.Last[0]));

            foreach (var item in names)
            {
                Console.WriteLine(item.First + " " + item.Last);
            }
        }

        public void GroupCustomersByState()
        {
            var cust =
                from c in customers
                group c by c.State into cGrouped
                select cGrouped;

            foreach (var item in cust)
            {
                Console.WriteLine(item.Key);
                foreach (var cg in item)
                {
                    Console.WriteLine(cg.First + " " + cg.Last);
                }

            }
        }

        public void GroupCustomersByFirstLetter()
        {
            var cust =
                from c in customers
                group c by c.First[0] into cGrouped
                select cGrouped;

            foreach (var item in cust)
            {
                Console.WriteLine(item.Key);
                foreach (var cg in item)
                {
                    Console.WriteLine(cg.First + " " + cg.Last);
                }
                
            }
        }

        public void OrderCustomersByFirstLengthLastAlphabetically()
        {
            var cust = customers.OrderBy(x => x.First.Length).ThenBy(x => x.Last);

            foreach (var item in cust)
            {
                Console.WriteLine(item.First + ", " + item.Last);
            } 
                
        }

        public void ShowExchangePricesAboveThousand()
        {
            IEnumerable<double> exchangeQuery = ExchangedPrices;

            foreach (double item in exchangeQuery)
            {
                if (item < 1000)
                {
                    Console.WriteLine(item);
                }
            }
            //IEnumerable<double> exchangeQuery =
            //    from e in ExchangedPrices
            //    where e < 1000
            //    select e;
           
            //foreach (var item in exchangeQuery)
            //{
            //    Console.WriteLine(item);
            //}
            
        }

        public void DrillCustomers()
        {
            foreach (var item in customers)
            {
                if (item.State ==  "GA")
                {
                    foreach (var purchase in item.Purchases)
                    {
                        Console.WriteLine(purchase);
                    }
                        
                }
            }
            //IEnumerable<Customer> stateQuery =
            //   from c in customers
            //   where c.State == "GA"
            //   select c;

            //foreach (var item in stateQuery)
            //{
            //    Console.WriteLine(item.Last + ", " + item.Last + ":");
            //    foreach (var purchase in item.Purchases)
            //    {
            //        Console.WriteLine(purchase);
            //    }
               
                
            //}
        }

 
        public void ShowNames()
        {
            foreach (var item in customers)
            {
                Console.WriteLine($"{item.Last} , {item.First}");
            }
            //    var names =
            //    from c in customers
            //    //where c.State == "OR"
            //    select new { lastFirst = c.Last + ", " + c.First};


            //foreach (var item in names)
            //{
            //    Console.WriteLine(item.lastFirst);
            //}
        }

        public void Compound()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var cdPairs = new Dictionary<Customer, IList<Distributor>>();

            foreach (Customer item in customers)
            {
                IList<Distributor> dists = new List<Distributor>();
                foreach (Distributor distrib in distributors)
                {
                    if (item.State == distrib.State)
                    {
                        dists.Add(distrib);
                    }
                }
                cdPairs.Add(item, dists);
            }

            foreach (var item in cdPairs)
            {
                foreach (var d in item.Value)
                {
                    Console.WriteLine($"{item.Key.First} {item.Key.Last} {item.Key.State}");
                    Console.WriteLine($"{d.Name} {d.State}");
                    Console.WriteLine();
                }
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            

            Console.WriteLine("********************************************");

            sw.Reset();

            sw.Start();
            var compound =
                from c in customers
                from d in distributors
                where c.State == d.State
                select new { c, d };

            foreach (var item in compound)
            {
                Console.WriteLine(item.c.First + " " + item.c.Last + " " + item.c.State);
                Console.WriteLine(item.d.Name + " " + item.d.State);
                Console.WriteLine();
            }
            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        

        public void TakeThreeCustomers()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(customers[i].First);
            }

            Console.WriteLine("*******************************");
            var cust = customers.Take(3);

            foreach (var item in cust)
            {
                Console.WriteLine(item.First);
            }
        }
    
        public void TakeThreeFromOregon()
        {
            int counter = 1;

            for (int i = 0; i < customers.Count; i++) 
            {
                if (counter <= 3 && customers[i].State == "OR" )
                {
                    Console.WriteLine(customers[i].First);
                    counter++;
                    
                }
            }

            Console.WriteLine("*********************************");

            var cust = customers.Where(x => x.State == "OR").Take(3);
            foreach (var item in cust)
            {
                Console.WriteLine(item.First);
            }
        }

        public void OrderCustomersByFirstNameOrLength()
        {
            var cust =
                from c in customers
                orderby c.First.Length descending
                select c;
            //var cust = customers.OrderBy(x => x.First);

            foreach (var item in cust)
            {
                Console.WriteLine(item.First);
            }
        }

        public void OrderCustomerByPrice()
        {
            var cust =
             from c in customers
             orderby c.Price descending
             select c;
            //var cust = customers.OrderBy(x => x.First);

            foreach (var item in cust)
            {
                Console.WriteLine(item.First + ", " + item.Price);
            }
        }
    }
}
