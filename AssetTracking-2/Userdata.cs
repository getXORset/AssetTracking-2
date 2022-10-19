using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking_2
{
         //The class Userdata handles user data
        internal class Userdata
        {
            //Initiation of variables
            DateTime dateTime = new DateTime();
            string type;
            string brand;
            string model;
            string office;
            string currency;
            char option;
            decimal price_usd;
            decimal price_local_today;
            Calculator calculator = new Calculator();

            //Method for indata and indata control
            public Asset Indata()
            {
            //Entering of the type of asset    
            while (true)
                {
                    Console.WriteLine("Enter the type of the asset (max 12 characters): ");
                    type = Console.ReadLine();
                    if (type.Length > 12)
                    {
                        Console.WriteLine();
                        Console.WriteLine("To many caracters!");
                    }
                    else { break; }
                }
            //Entering of the brand of the asset    
            while (true)
                {
                    Console.WriteLine("Enter the brand of the asset (max 12 characters): ");
                    brand = Console.ReadLine();
                    if (brand.Length > 12)
                    {
                        Console.WriteLine();
                        Console.WriteLine("To many caracters!");
                    }
                    else { break; }
                }

                while (true)
                {
                    Console.WriteLine("Enter the model of the asset (max 7 characters): ");
                    model = Console.ReadLine();
                    if (model.Length > 7)
                    {
                        Console.WriteLine();
                        Console.WriteLine("To many caracters!");
                    }
                    else { break; }
                }
                bool isOk = true;
                while (isOk) //Entering of the office
                {
                    Console.WriteLine("Choose the office of the asset: ");
                    Console.WriteLine();
                    Console.WriteLine("1. Spain");
                    Console.WriteLine("2. Sweden");
                    Console.WriteLine("3. USA");
                    option = Console.ReadKey(true).KeyChar;
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
                        default:
                            Console.WriteLine("You can only choose one of the three alternatives in the menu");
                            break;
                    }
                }
                //Entering of the purchase date
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the purchase date (on the form dd/mm/yyyy, e.g. 15/09/2022): ");
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
                        break;
                    }
                }

            //Entering of the price in US dollar    
            while (true)
                {
                    Console.WriteLine("Enter the price in USD (max 12 characters): ");
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
                //The price in local currency is calculated
                price_local_today = calculator.ExchangeCounter(price_usd, currency);

                //The asset is built and returned to the program class
                Asset asset = new Asset(type, brand, model, office, dateTime, price_usd, currency, price_local_today);
                return asset;
            }

        }
}
