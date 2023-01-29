using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_cons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EtsManager manager = new EtsManager();
            while (true)
            {
                Console.WriteLine("Welcome to your gallery management system\n");
                Console.WriteLine("Please select an option: \n" +
                    "1 - Add Sponsor \n" +
                    "2 - Add Donor \n" +
                    "3 - Add Donation \n" +
                    "4 - Add Prize \n" +
                    "5 - Donors infos \n" +
                    "6 - Exit \n");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        //manager.AddSponsor();
                        //manager.();
                        break;
                    case 2:
                        while (true)
                        {
                            manager.AddDonor();
                            manager.listDonors();
                            break;
                        }
                        break;
                    case 3:
                        manager.AddDonation();
                        manager.listDonations();
                        break;
                    case 4:
                        //manager.();
                        break;
                    case 5:
                        //manager.();
                        break;
                    case 6:
                        Console.WriteLine("Thank you for using the system. Goodbye!");
                        Environment.Exit(0);
                        break;
                        //default: Console.WriteLine("Please enter a valid option");
                }
            }
        }
    }
}

