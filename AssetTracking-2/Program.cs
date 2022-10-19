using AssetTracking_2;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

List<Asset> assetslist = new List<Asset>(); //The list with the assets
Userdata userdata = new Userdata(); //The class for indata from the user
Viewer viewer = new Viewer(assetslist);
Editor editor = new Editor();
Statistics statistics = new Statistics();
MyDbContext context = new MyDbContext();

while (true)
{
    //The menu is showed for the user
    Console.WriteLine();
    Console.WriteLine("Choose an option in the menu");
    Console.WriteLine();
    Console.WriteLine("1. Add an asset");
    Console.WriteLine("2. Present the list of assets");
    Console.WriteLine("3. Edit an asset");
    Console.WriteLine("4. Delete an asset");
    Console.WriteLine("5. Statistic Report");
    Console.WriteLine("Press q for quit");
    char menuChoice = Console.ReadKey(true).KeyChar;

    switch (menuChoice)
    {
        //Adding of an asset
        case ('1'):
            Console.WriteLine();
            context.Assets.Add(userdata.Indata()); //An asset is added to the table Assets
            context.SaveChanges();
            //assetslist.Add(userdata.Indata());
            break;
        //Presentation of the assets in a list
        case ('2'):
            if (!context.Assets.Any())
            {
                Console.WriteLine();
                Console.WriteLine("No assets are registered yet!");
                break;
            }
            else
            {
                assetslist = context.Assets.ToList();
                viewer.showAssetslist(assetslist);
                Console.WriteLine();
                Console.Write("Press any key to continue!...");
                Console.ReadKey(true);
                break;
            }
        //Editing of an asset
        case ('3'):
            if (!context.Assets.Any())
            {
                Console.WriteLine();
                Console.WriteLine("No assets are registered yet!");
                Console.WriteLine();
                Console.Write("Press any key to continue!...");
                Console.ReadKey(true);
                break;
            }
            else
            {
                while (true)
                {
                    Console.WriteLine();
                    assetslist = context.Assets.ToList();
                    viewer.showAssetslist(assetslist);
                    Console.WriteLine();
                    Console.WriteLine("Select an id to edit and press enter");
                    bool correctId = int.TryParse(Console.ReadLine(), out int idNumber);
                    if (correctId && context.Assets.Any(x => x.Id == idNumber))
                    {
                        var asset = context.Assets.SingleOrDefault(x => x.Id == idNumber);
                        editor.editAsset(context, idNumber);
                        context.SaveChanges();
                        Console.WriteLine();
                        Console.WriteLine("Asset with ID " + asset.Id + " is now edited!");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You can only choose an id which is in the list!");
                        Console.Write("Press any key to continue!...");
                        Console.ReadKey(true);
                        break;
                    }
                }
                break;
            }
        //Deletion of an asset
        case ('4'):
            if (!context.Assets.Any())
            {
                Console.WriteLine();
                Console.WriteLine("No assets are registered yet!");
                Console.WriteLine();
                Console.Write("Press any key to continue!...");
                Console.WriteLine();
                Console.ReadKey(true);
                break;
            }
            else
            {
                while (true)
                {
                    Console.WriteLine();
                    assetslist = context.Assets.ToList();
                    viewer.showAssetslist(assetslist);
                    Console.WriteLine();
                    Console.WriteLine("Select an id to delete and press enter");
                    bool correctId = int.TryParse(Console.ReadLine(), out int idNumber);
                    if (correctId && context.Assets.Any(x => x.Id == idNumber))
                    {
                        var asset = context.Assets.SingleOrDefault(x => x.Id == idNumber);
                        context.Assets.Remove(asset);
                        context.SaveChanges();
                        Console.WriteLine();
                        Console.WriteLine("Asset with ID " + asset.Id + " is now removed!");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You can only choose an id which is in the list!");
                        Console.Write("Press any key to continue!...");
                        Console.WriteLine();
                        Console.ReadKey(true);
                        break;
                    }
                }
                break;
            }
        //Statistics reporting
        case ('5'):
            statistics.showReport(context);
            break;
        case ('q'):
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine();
            Console.WriteLine("You can only choose one of the alternatives in the menu!");
            continue;
    }
}