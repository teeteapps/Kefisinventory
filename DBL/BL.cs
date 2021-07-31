using DBL.Models;
using DBL.UOW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBL
{
    public class BL
    {
        private UnitOfWork db;
        private string _connString;
        public string LogFile { get; set; }
        public BL(string connString)
        {
            this._connString = connString;
            db = new UnitOfWork(connString);
        }

        public Task<UserModel> Login(string userName, string password)
        {
            return Task.Run(() =>
            {
                UserModel userModel = new UserModel { };
                var resp = db.SecurityRepository.Login(userName);
                if (resp.RespStatus == 0)
                {

                    if (password == resp.Data3)
                    {
                        userModel = new UserModel
                        {
                            Usercode = Convert.ToInt64(resp.Data1),
                            Fullname = resp.Data2,
                            Email = resp.Data4,
                            profilecode = Convert.ToInt32(resp.Data5),

                        };
                        return userModel;
                    }
                    else
                    {
                        userModel.RespStatus = 1;
                        userModel.RespMessage = "Incorrect Password!";
                    }
                }
                else
                {
                    userModel.RespStatus = 1;
                    userModel.RespMessage = "Incorrect Password!";
                }

                return userModel;
            });
        }


        public async Task<IEnumerable<Products>> Getallproductslist()
        {
            return await Task.Run(() =>
            {
                var Resp = db.ProductRepository.Getallproductslist();
                return Resp;
            });
        }
        public async Task<BaseEntity> Makeasale(long id)
        {
            return await Task.Run(() =>
            {
                var Resp = db.ProductRepository.Makeasale(id);
                return Resp;
            });
        }
        public async Task<IEnumerable<Companypurchase>> Productreorderunprocessedlist()
        {
            return await Task.Run(() =>
            {
                var Resp = db.ProductRepository.Productreorderunprocessedlist();
                return Resp;
            });
        }
        public async Task<IEnumerable<Companypurchase>> Productreorderprocessedlist()
        {
            return await Task.Run(() =>
            {
                var Resp = db.ProductRepository.Productreorderprocessedlist();
                return Resp;
            });
        }
        public async Task<BaseEntity> Makeadispatch(long id)
        {
            return await Task.Run(() =>
            {
                var Resp = db.ProductRepository.Makeadispatch(id);
                return Resp;
            });
        }
    }
}
