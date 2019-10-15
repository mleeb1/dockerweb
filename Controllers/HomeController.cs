using System;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DockerWeb.Models;

namespace DockerWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Outside Docker = Data Source=.;Initial Catalog=Docker;Persist Security Info=True;User ID=sa;Password=yourStrong(!)Password
            // Inside = Data Source=dockerdb;Initial Catalog=Docker;Persist Security Info=True;User ID=sa;Password=yourStrong(!)Password
            using(var conn = new SqlConnection("Data Source=dockerdb;Initial Catalog=Docker;Persist Security Info=True;User ID=sa;Password=yourStrong(!)Password"))
            {
                // Create the Command and Parameter objects.
                var command = new SqlCommand("SELECT * FROM PRODUCT", conn);

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    conn.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ViewData["Title"] = reader[1];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                conn.Close();
            };

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
