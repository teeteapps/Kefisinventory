using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Models
{
    [Table("Companypurchase")]
    public class Companypurchase
    {
        [NotMapped]
        public static string TableName { get { return "Companypurchase"; } }

        public long Orderid { get; set; }
        public long Productid { get; set; }
        public string Productname { get; set; }
        public int Orderquantity { get; set; }
        public string Orderstatus { get; set; }
        public DateTime Dateordered { get; set; }
        public DateTime Datedispatched { get; set; }
        public DateTime Datecreated { get; set; }
    }
}
