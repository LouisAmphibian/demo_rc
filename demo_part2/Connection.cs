using System.Reflection.Metadata.Ecma335;

namespace demo_part2
{
    public class Connection
    {
        //Return connection string method
        public string connecting()
        {
           //RETURN CONNECTION
            return "Data Source=(localdb)\\demo_p2;Initial Catalog=demo_db;";
        }
        
    }
}
