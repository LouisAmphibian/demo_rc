using demo_part2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

namespace demo_part2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //1st check the connection
            try
            {
                Connection con = new Connection();

                //then check 
                using (SqlConnection connect = new SqlConnection(con.connecting()))
                {
                    //open the connection
                    connect.Open();
                    Console.WriteLine("connected");
                    connect.Close();
                }


            }
            catch (IOException error)
            {
                Console.WriteLine("Error: " + error.Message);
            }

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

        //http post for the register
        //Form the register form
        [HttpPost]
        public IActionResult Register_user(Register add_user)
        {
            //collect user data
            string name = add_user.Username;
            string email = add_user.Email;
            string password = add_user.Password;
            string role = add_user.Role;

            /*
            //check if all are collected
            Console.WriteLine("Name: " + name + "\nEmail: " + email + "\nRole: " + role);
            */

            //pass all the values to insert method
            string message = add_user.insert_user(name, email, password, role);

            //the check if the user inserted
            if (message == "done")
            {
                //track error output
                Console.WriteLine(message);

                //Redirect to logon
                return RedirectToAction("Login", "Home");

            }
            else
            {
                //track error output
                Console.WriteLine(message);

                //Redirect
                return RedirectToAction("Index", "Home");
            }

        }

        //for login page
        public IActionResult Login()
        {
            return View();
        }

        //login page POST
        [HttpPost]
        public IActionResult Login_user(Check_login user)
        {
            //then assign 
            string email = user.Email;
            string password = user.Password;
            string role = user.Role;

            string message = user.login_user(email, role, password);

            if (message == "found")
            {
                Console.WriteLine(message);
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                Console.WriteLine(message);
                return RedirectToAction("Login", "Home");
            }

        }


       

        [HttpPost]
        public IActionResult Claim_Sub(Claim insert)
        {
            //assign 
            string module_name = insert.User_Name;
            string hour_work = insert.Hours_worked;
            string hour_rate = insert.Hour_Rate;
            string description = insert.Description;

            string message = insert.insert_claim(module_name, hour_work, hour_rate, description);


            if (message == "done")
            {
                Console.WriteLine(message);
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                Console.WriteLine(message);
                return RedirectToAction("Dashboard", "Home");
            }
        }


        //OPEN Dash
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
