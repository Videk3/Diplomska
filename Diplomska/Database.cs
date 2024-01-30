using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska
{
    class Database
    {
        NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres;" + "Password=postgres; Database=diplomska_db;");
        void Connect()
        {
            using (con)
            {
                con.Open();
            }
        }
        void Disconnect()
        {
            using (con)
            {
                con.Close();
            }
        }
    }
}
