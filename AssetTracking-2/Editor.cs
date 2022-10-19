using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking_2
{
    internal class Editor
    {

        Calculator calculator = new Calculator();
        DateTime dateTime = new DateTime();
        internal void editAsset(MyDbContext context, int id)
        {
            var asset = context.Assets.SingleOrDefault(x => x.Id == id);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("From the list choose an attribute to edit!");
                string editorMenu = "\n1. Type\n2. Brand\n3. Model\n4. Office\n5. Date_purchase\n" +
                    "6. Price_usd\n";
                Console.Write(editorMenu);
                char menuChoice = Console.ReadKey(true).KeyChar;
                string currency = asset.Currency;
                decimal price_usd = asset.Price_usd;
                decimal price_local_today;
                string office = asset.Office;
                switch (menuChoice)
                {
                    case ('1'):
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter the new type of the asset (max 12 characters): ");
                            string type = Console.ReadLine();
                            if (type.Length > 12)
                            {
                                Console.WriteLine();
                                Console.WriteLine("To many caracters!");
                            }
                            else
                            {
                                asset.Type = type;
                                context.SaveChanges();
                                break; 
                            }
                        }
                        break;
                    case ('2'):
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter the brand of the asset (max 12 characters): ");
                            string brand = Console.ReadLine();
                            if (brand.Length > 12)
                            {
                                Console.WriteLine();
                                Console.WriteLine("To many caracters!");
                            }
                            else
                            {
                                asset.Brand = brand;
                                context.SaveChanges();
                                break;
                            }
                        }
                        break;
                    case ('3'):
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter the model of the asset (max 7 characters): ");
                            string model = Console.ReadLine();
                            if (model.Length > 7)
                            {
                                Console.WriteLine();
                                Console.WriteLine("To many caracters!");
                            }
                            else
                            {
                                asset.Model = model;
                                context.SaveChanges();
                                break;
                            }
                        }
                        break;
                    case ('4'):
                        bool isOk = true;
                        while (isOk)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Choose the office of the asset: ");
                            Console.WriteLine();
                            Console.WriteLine("1. Spain");
                            Console.WriteLine("2. Sweden");
                            Console.WriteLine("3. USA");
                            char option = Console.ReadKey(true).KeyChar;
                            switch (option)
                            {
                                case '1':
                                    office = "Spain";
                                    currency = "EUR";
                                    isOk = false;
                                    break;
                                case '2':
                                    office = "Sweden";
                                    currency = "SEK";
                                    isOk = false;
                                    break;
                                case '3':
                                    office = "USA";
                                    currency = "USD";
                                    isOk = false;
                                    break;
                            }
                        }
                        asset.Office = office;
                        asset.Currency = currency;
                        price_usd = asset.Price_usd;
                        price_local_today = calculator.ExchangeCounter(price_usd, currency);
                        asset.Price_local_today = price_local_today;
                        context.SaveChanges();
                        break;
                    case ('5'):
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter the new purchase date (on the form dd/mm/yyyy, e.g. 15/09/2022): ");
                            bool correctDate = DateTime.TryParse(Console.ReadLine(), out dateTime);
                            if (!correctDate)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Wrong format!");
                                Console.WriteLine();
                            }
                            else if (dateTime > DateTime.Now)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Purchase date can not be later than todays date!");
                                Console.WriteLine();
                            }
                            else
                            {
                                asset.Date_purchase = dateTime;
                                context.SaveChanges();
                                break;
                            }
                        }
                        break;
                    case ('6'):     
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter the new price in USD (max 12 characters): ");
                            try
                            {
                                price_usd = decimal.Parse(Console.ReadLine());
                                if (price_usd.ToString().Length > 12)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("To many caracters!");
                                }
                                else { break; }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Wrong format!");
                            }
                        }
                        string officeCountry = asset.Office;
                        switch (officeCountry)
                        {
                            case "Spain":
                                currency = "EUR";
                                isOk = false;
                                break;
                            case "Sweden":
                                currency = "SEK";
                                isOk = false;
                                break;
                            case "USA":
                                office = "USA";
                                currency = "USD";
                                isOk = false;
                                break;
                        }
                        price_local_today = calculator.ExchangeCounter(price_usd, currency);
                        asset.Price_usd = price_usd;
                        asset.Price_local_today = price_local_today;
                        context.SaveChanges();
                        break;
                }
                break;
            }
        }
    }
}
