using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

using Pizzas.API.Models;

namespace Pizzas.API.Utils
{
// test
    public static class BD
    {
        private static string _connectionString = @$"Server=A-PHZ2-CEO-013;DataBase=DAI-Pizzas;Trusted_Connection=True";

        public static List<Pizza> GetAll()
        {
            string sqlQuery;
            List<Pizza> returnList;
            returnList = new List<Pizza>();
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                sqlQuery = "SELECT Id, Nombre, LibreGluten, Importe, Descripcion FROM Pizzas";
                returnList = db.Query<Pizza>(sqlQuery).ToList();
            }
            return returnList;
        }

        public static Pizza GetById(int id)
        {
            string sqlQuery;
            Pizza returnEntity;
            sqlQuery = "SELECT Id, Nombre, LibreGluten, Importe, Descripcion FROM Pizzas WHERE Id = @idPizza";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                returnEntity = db.QueryFirstOrDefault<Pizza>(sqlQuery, new { idPizza = id });
            }
            return returnEntity;
        }

        public static int Insert(Pizza pizza)
        {
            string sqlQuery;
            int intRowsAffected = 0;
            sqlQuery = "INSERT INTO Pizzas (Nombre, LibreGluten, Importe, Descripcion) VALUES (@nombre, @libreGluten, @importe, @descripcion)";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                intRowsAffected = db.Execute(sqlQuery, new { nombre = pizza.Nombre, libreGluten = pizza.LibreGluten, importe = pizza.Importe, descripcion = pizza.Descripcion });
            }
            return intRowsAffected;
        }

        public static int UpdateById(Pizza pizza)
        {
            string sqlQuery;
            int intRowsAffected = 0;
            sqlQuery = "UPDATE Pizzas SET Nombre = @nombre, LibreGluten = @libreGluten, Importe = @importe, Descripcion = @descripcion WHERE Id = @idPizza";
            using (var db = new SqlConnection(_connectionString))
            {
                intRowsAffected = db.Execute(sqlQuery, new { idPizza = pizza.Id, nombre = pizza.Nombre, libreGluten = pizza.LibreGluten, importe = pizza.Importe, descripcion = pizza.Descripcion });
            }
            return intRowsAffected;
        }

        public static int DeleteById(int id)
        {
            string sqlQuery;
            int intRowsAffected = 0;

            sqlQuery = "DELETE FROM Pizzas WHERE Id = @idPizza";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                intRowsAffected = db.Execute(sqlQuery, new { idPizza = id });
            }
            return intRowsAffected;
        }
    }
}

