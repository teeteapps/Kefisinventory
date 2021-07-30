using DBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repository
{
   public interface IProductRepository
    {
        IEnumerable<Products> Getallproductslist();
        BaseEntity Makeasale(long id);
        IEnumerable<Companypurchase> Productreorderunprocessedlist();
        IEnumerable<Companypurchase> Productreorderprocessedlist();

        BaseEntity Makeadispatch(long id);
    }
}
