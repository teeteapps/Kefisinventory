using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Models
{
    public class UserModel
    {
        public long Usercode { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int profilecode { get; set; }
        public int RespStatus { get; set; }
        public string RespMessage { get; set; }
    }
}
