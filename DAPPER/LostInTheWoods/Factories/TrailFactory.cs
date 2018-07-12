using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using LostInTheWoods.Models;
using System;
using System.Threading.Tasks;

namespace LostInTheWoods.Factory
{
    public class TrailFactory
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=mydbs;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }
        //USERFACTORY CLASS DEFINITION
 
        public void Add(Trail NewTrail)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO trails (TrailName, Description, TrailLength, ElevationChange, Longitude, Latitude) VALUES (@TrailName, @Description, @TrailLength, @ElevationChange, @Longitude, @Latitude)";
                dbConnection.Open();
                dbConnection.Execute(query, NewTrail);
            }
        }
        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM trails";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query).ToList();
            }
        }
        public Trail FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            { 
                string query = "SELECT * FROM trails WHERE id = @Id";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query, new { Id = id }).FirstOrDefault();
            }
        }

    }
}
