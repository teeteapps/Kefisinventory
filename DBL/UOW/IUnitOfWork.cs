using DBL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.UOW
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ISecurityRepository SecurityRepository { get; }
    }
}
