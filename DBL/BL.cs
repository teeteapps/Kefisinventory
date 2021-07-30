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
