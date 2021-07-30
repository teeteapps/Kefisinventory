using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Models
{
    [Table("Products")]
    public class Products
    {
        [NotMapped]
        public static string TableName { get { return "Products"; } }

        public long Productid { get; set; }
        public string Productname { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Reorderlevel { get; set; }
        public DateTime Datereordered { get; set; }
        public DateTime Daterecieved { get; set; }
        public DateTime Datecreated { get; set; }
    }
}
