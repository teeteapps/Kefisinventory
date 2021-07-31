using DBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repository
{
   public interface ISecurityRepository
    {
        BaseEntity Login(string userName);
    }
}
