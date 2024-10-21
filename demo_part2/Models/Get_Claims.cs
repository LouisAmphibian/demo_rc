using System;
using System.Collections;
using System.Data.SqlClient;

namespace demo_part2.Models
{
    public class Get_Claims
    {
        public ArrayList Email { get; set; } = new ArrayList();
        public ArrayList Module { get; set; } = new ArrayList();

        public ArrayList Id {  get; set; } = new ArrayList(); 
        public ArrayList Hours { get; set; } = new ArrayList();
        public ArrayList Rate { get; set; } = new ArrayList();

        public ArrayList Note { get; set; } = new ArrayList();

        public ArrayList Total { get; set; } = new ArrayList();

        public ArrayList Status { get; set; } = new ArrayList();

        public ArrayList Filename { get; set; } = new ArrayList();

        Connection connect =  new Connection();

        public Get_Claims()
        {
            string emails = gets_email();



            //use 3 using
            try
            {
                using (SqlConnection connects = new SqlConnection(connect.connecting()))
                {
                    //open connection
                    connects.Open();

                    using (SqlCommand prepare = new SqlCommand("SELECT * FROM claiming WHERE email='"+emails+"';", connects))
                    {
                        using (SqlDataReader getEmail = prepare.ExecuteReader())
                        {
                            if (getEmail.Read())
                            {
                                //check all but get one
                                while (getEmail.Read())
                                {
                                    //then get id
                                   // hold_email = getEmail["email"].ToString();

                                    Email.Add(getEmail["email"].ToString());
                                    Module.Add(getEmail["module"].ToString());
                                    Id.Add(getEmail["user_id"].ToString());
                                    Hours.Add(getEmail["hours"].ToString());
                                    Rate.Add(getEmail["rate"].ToString());
                                    Note.Add(getEmail["note"].ToString());
                                    Total.Add(getEmail["total"].ToString());
                                    Status.Add(getEmail["status"].ToString());
                                    Filename.Add(getEmail["file_name"].ToString());
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
                
            }

        }

        public string gets_email()
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
