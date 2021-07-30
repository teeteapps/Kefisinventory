using Dapper;
using DBL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repository
{
    public class ProductRepository:BaseRepository,IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {
        }
        public IEnumerable<Products> Getallproductslist()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Products>(GetAllStatement(Products.TableName)).ToList();
            }
        }
        public BaseEntity Makeasale(long  id)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return connection.Query<BaseEntity>("Usp_Makeasale", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public IEnumerable<Companypurchase> Productreorderunprocessedlist()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Companypurchase>(FindStatement(Companypurchase.TableName, "Orderstatus"), param: new { Id = "unprocessed" }).ToList();
            }
        }
        public IEnumerable<Companypurchase> Productreorderprocessedlist()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Companypurchase>(FindStatement(Companypurchase.TableName, "Orderstatus"), param: new { Id = "processed" }).ToList();
            }
        }
        public BaseEntity Makeadispatch(long id)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return connection.Query<BaseEntity>("Usp_Makeadispatch", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
