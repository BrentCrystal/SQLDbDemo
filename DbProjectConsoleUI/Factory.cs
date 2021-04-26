using DbProjectLibrary.Data;
using DbProjectLibrary.Db;
using DbProjectLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DbProjectConsoleUI
{
    public static class Factory
    {
        public static ISqlDataAccess CreateSqlDataAccess(IConfiguration config)
        {
            return new SqlDataAccess(config);
        }

        public static ISqlCrud CreateSqlCrud(ISqlDataAccess dataAccess, IConnectionStringData connectionStringName)
        {
            return new SqlCrud(dataAccess, connectionStringName);
        }

        public static IConnectionStringData CreateConnectionStringName()
        {
            return new ConnectionStringData();
        }

        public static IConfiguration GetConnectionString(string connectionStringName = "Default")
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var config = builder.Build();

            return config;
        }
    }
}
