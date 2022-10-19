using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking_2
{
    //The Viewer class prints the assetslist as string lines in the console
    internal class Viewer
    {
        List<Asset> assetslist;
        internal Viewer(List<Asset> assetslist)
        {
            this.assetslist = assetslist;
        }
        //The method showAssetsList() shows the assetslist in the console
        internal void showAssetslist(List<Asset> assetslist)
        {
            //Printing the head of the table
            Console.WriteLine("\n" + "ID".PadRight(8) + "Typ".PadRight(14) + "Brand".PadRight(14) + "Model".PadRight(10) + "Office".PadRight(11)
            + "Purchase date".PadRight(16) + "Price in USD".PadRight(16) + "Currency".PadRight(12)
            + "Local price today".PadRight(14));

            Console.WriteLine("----".PadRight(8) + "----".PadRight(14) + "-----".PadRight(14) + "-----".PadRight(10) + "------".PadRight(11)
                + "-------------".PadRight(16) + "------------".PadRight(16) + "--------".PadRight(12)
                + "-----------------".PadRight(14));


            //Creation of a sorted list

            List<Asset> sortedAssetslist = assetslist.OrderBy(i => i.Office).ThenBy(i => i.Date_purchase).ToList();

            DateTime today = DateTime.Today; //The DateTime object of todays date

            foreach (Asset i in sortedAssetslist)
            {
                DateTime reddate = i.Date_purchase.AddMonths(33); //Limit for showing red row
                DateTime yellowdate = i.Date_purchase.AddMonths(30); //Limit for showing yellow row
                int value1 = today.CompareTo(reddate); //Greater than 0 when todays date is later than the limit
                int value2 = today.CompareTo(yellowdate); //Greater than 0 when todays date is later than the limit

                if (value1 > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; //Shows item in red
                }
                else if (value2 > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; //Shows item in yellow
                }
                //Prints the list with the assets
                Console.WriteLine(i.Id.ToString().PadRight(8) + i.Type.PadRight(14) + i.Brand.PadRight(14) + i.Model.PadRight(10) +
                i.Office.PadRight(11) + i.Date_purchase.ToShortDateString().PadRight(16) +
                i.Price_usd.ToString().PadRight(16) + i.Currency.PadRight(12) + i.Price_local_today.ToString());
                Console.ResetColor();
            }
        }
    }
}
