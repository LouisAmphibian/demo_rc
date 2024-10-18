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
        Connection connection = new Connection();


        //inserting user data
        public string insert_user(string username, string email, string roles, string password)
        {

            return  "";
        }
    }
}
