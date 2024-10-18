using System.Data.SqlClient;
using System;
using System.Data;

namespace demo_part2.Models
{
    public class Claim
    {
        public string User_Name { get; set; }
        public string Hours_worked { get; set; }
        public string Hour_Rate { get; set; }
        public string Description { get; set; }

        //Always connect when having ti use sql
        Connection connect = new Connection();

        public string insert_claim(string module, string hours_worked, string rate, string note)
        {
            //temp  variablo for message
            string message = "";

            //getting user data with methods
            string user_Id = get_id();
            string user_Email = get_email();

            string total = "" + (int.Parse(hours_worked) * int.Parse(rate));

            //
            string query = "INSERT INTO claiming VALUES('" + user_Email + "','" + module + "','" + user_Id + "','" + hours_worked + "','" + rate + "','" + note + "','non','none','" + total + "','pending');";

            try
            {
                using (SqlConnection connects = new SqlConnection(connect.connecting()))
                {
                    //open connection
                    connects.Open();

                    //string query = "SELECT * FROM users WHERE email = @Email AND role = @Role AND password = @Password"

                    //prepare to execute
                    using (SqlCommand done = new SqlCommand(query, connects))
                    {
                        done.ExecuteNonQuery();
                        message = "done";


                    }
                }

            }
            catch (Exception error)
            {
            message = error.Message;
            }

            return message;
        }

        public string get_id()
        {
            //hold id 
            string hold_id = "";

            try
            {
                using (SqlConnection connects = new SqlConnection(connect.connecting()))
                {
                    //open connection
                    connects.Open();

                    using (SqlCommand prepare = new SqlCommand("SELECT * FROM active", connects))
                    {
                        using (SqlDataReader getID = prepare.ExecuteReader())
                        {
                            if (getID.Read())
                            {
                                //check all but get one
                                while (getID.Read())
                                {
                                    //then get id
                                    hold_id = getID["id"].ToString();
                                }
                            }

                            getID.Close();
                        }
                    }

                    connects.Close();
                }
            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);
                hold_id = error.Message;
            }
            return hold_id;

        }

        public string get_email()
        {
            //hold email 
            string hold_email = "";

            try
            {
                using (SqlConnection connects = new SqlConnection(connect.connecting()))
                {
                    //open connection
                    connects.Open();

                    using (SqlCommand prepare = new SqlCommand("SELECT * FROM active", connects))
                    {
                        using (SqlDataReader getEmail = prepare.ExecuteReader())
                        {
                            if (getEmail.Read())
                            {
                                //check all but get one
                                while (getEmail.Read())
                                {
                                    //then get id
                                    hold_email = getEmail["email"].ToString();
                                }
                            }

                            getEmail.Close();
                        }
                    }

                    connects.Close();
                }
            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);
                hold_email = error.Message;
            }
            return hold_email;

        }
    }
}
