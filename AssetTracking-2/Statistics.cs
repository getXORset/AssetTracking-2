using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking_2
{
    //The class Statistics delivers statistics in a report
    internal class Statistics
    {
        internal void showReport(MyDbContext context) //The method showReport prints the statistics in the console
        {
            List<Asset> computerList = context.Assets.Where(x => x.Type == "computer").ToList(); //Building of a list with the computer assets
            List <Asset> phoneList = context.Assets.Where(x => x.Type == "phone").ToList(); //Building of a list with phone assets
            decimal sum_usd = context.Assets.Sum(x => x.Price_usd); //Adds the sum in US dollar for all the assets
            int countComputers = computerList.Count(); //Variable for hosting the sum of computer assets
            int countPhones = phoneList.Count(); //Variable for hosting the sum of phone assets

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("  REPORT - ASSET DATABASE");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
            Console.WriteLine("  Number of computers: " + countComputers);
            Console.WriteLine();
            Console.WriteLine("  Number of phones: " + countPhones);
            Console.WriteLine();
            Console.WriteLine("  Total cost in US dollar: " + sum_usd);
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
        }
    }
}
