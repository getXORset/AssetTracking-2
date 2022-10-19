using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking_2
{
    //The Asset class houses the properties for an asset
    public class Asset
    {
        public Asset(string type, string brand, string model, string office, DateTime date_purchase,
            decimal price_usd, string currency, decimal price_local_today)
        {
            Type = type;
            Brand = brand;
            Model = model;
            Office = office;
            Date_purchase = date_purchase;
            Price_usd = price_usd;
            Currency = currency;
            Price_local_today = price_local_today;
        }

        public int Id { get; set; }
        public String Type { get; set; }
        public String Brand { get; set; }
        public String Model { get; set; }
        public String Office { get; set; }
        public DateTime Date_purchase { get; set; }
        [Column(TypeName = "decimal(18,2)")] //This denotes the precision for the integer part and for the fractional part
        public decimal Price_usd { get; set; }
        public String Currency { get; set; }
        [Column(TypeName = "decimal(18,2)")] //This denotes the precision for the integer part and for the fractional part
        public decimal Price_local_today { get; set; }
    }
}
