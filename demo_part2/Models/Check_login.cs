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
                    string query = "SELECT * FROM users WHERE email ='" + emails + "' and role '" + roles + "'and password = '" + passwords + "';";

                    //string query = "SELECT * FROM users WHERE email = @Email AND role = @Role AND password = @Password"

                    //prepare to execute
                    using (SqlCommand prepare = new SqlCommand(query, connects)) 
                    { 
                        //read the data
                        using (SqlDataReader find_user = prepare.ExecuteReader())
                        {
                            //then check if the user is found
                            if(find_user.HasRows) 
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
                }
            }
            catch (IOException error_db)
            {
                message = error_db.Message;
            }
            return message;
        }

    }



}
