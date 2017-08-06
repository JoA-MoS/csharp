using System;
using System.Collections.Generic;
using DbConnection;

namespace MySQL_CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Getusers();

            var user = new {
                FirstName=Console.ReadLine(),
                LastName=Console.ReadLine(),
                FavoritNumber=Console.ReadLine(),
            };

            string sqlInsert = $@"INSERT INTO `consoledb`.`users`
                                (
                                `FirstName`,
                                `LastName`,
                                `FavoritNumber`)
                                VALUES
                                (""{user.FirstName}"",
                                ""{user.LastName}"",
                                {user.FavoritNumber});";
            DbConnector.Execute(sqlInsert);
            Getusers();
        }

        private static void Getusers()
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            results = DbConnector.Query("SELECT * FROM users");

            foreach (Dictionary<string, object> item in results)
            {
                foreach (var v in item.Values)
                {
                    System.Console.Write(v);
                }
                System.Console.WriteLine();
            }
        }
    }
}
