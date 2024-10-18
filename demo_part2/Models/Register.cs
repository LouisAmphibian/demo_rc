using System.Data.SqlClient;

namespace demo_part2.Models
{
    public class Register
    {
        //GETTER AND SETTER PROPERTIES
        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; }

        public string? Password { get; set; }


        //connection string class
        Connection connect = new Connection();


        //inserting user data
        public string insert_user(string username, string email, string role, string password)
        {
            //temp  variablo for message
            string message = "";

            //connect to database
            try
            {
                //open the connection
                using (SqlConnection connects = new SqlConnection(connect.connecting()))
                {
                    connects.Open();

                    //query
                    string query = "insert into users values('" + username + "' ,'" + email + "', '"+role + "','" + password + "')";

                    //execute command to insert user data
                    using (SqlCommand add_new_user = new SqlCommand(query, connects))
                    {
                        //then execute it
                        add_new_user.ExecuteNonQuery();

                        message = "done";
                    }


                    //then close it
                    connects.Close();

                }

            }
            catch (IOException error) 
            {
                message = error.Message;
            }

            
            return message;
        }
    }
}
