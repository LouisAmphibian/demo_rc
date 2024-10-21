using System.Data.SqlClient;

namespace demo_part2.Models
{
    public class Check_login
    {

        //add properties
        public string? Email { get; set; }

        public string? Role { get; set; }

        public string? Password { get; set; }

        //connection string
        Connection connect = new Connection();

        //METHOD to check the user
        public string login_user(string emails, string roles, string passwords)
        {
            //temp message 
            string message = "";
            try
            {
                //connect and open
                using (SqlConnection connects = new SqlConnection(connect.connecting()))
                {
                    //open connection
                    connects.Open();

                    //query-to retrieve
                    string query = "SELECT * FROM users WHERE email='" + emails + "'AND password='" + passwords + "';";

                    //string query = "SELECT * FROM users WHERE email = @Email AND role = @Role AND password = @Password"


                    /*
                    check if it recieves data"
                    Console.WriteLine(emails + " AND " + passwords);
                    */

                    //prepare to execute
                    using (SqlCommand prepare = new SqlCommand(query, connects))
                    {
                        //read the data
                        using (SqlDataReader find_user = prepare.ExecuteReader())
                        {
                            //then check if the user is found
                            if (find_user.HasRows)
                            {
                                //then assign message
                                message = "found";

                            }
                            else
                            {
                                message = "not";
                            }
                        }
                    }

                    //Close the connection
                    connects.Close();

                    if(message == "found")
                    {
                        upadate_active(Email);
                    }
                }
            }
            catch (IOException error_db)
            {
                message = error_db.Message;
            }
            return message;
        }

        //update active method
        public void upadate_active(string email)
        {

            try
            {
                using (SqlConnection connects = new SqlConnection(connect.connecting()))
                {
                    connects.Open();

                    string query = "UPDATE active SET email='" + email + "'";

                    using (SqlCommand command = new SqlCommand(query, connects))
                    {
                        command.ExecuteNonQuery();
                    }

                    connects.Close() ;
                }


            }
            catch (IOException error)
            {
                Console.WriteLine("Error"+  error.Message);
            }
        }


    }
}
