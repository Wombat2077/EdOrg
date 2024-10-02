using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;


namespace EdOrg.Utils
{
    public class Hasher
    {
        static string Salt = "$2b$12$I8Ygi52lQ4IciIgWnurWAO";
        public static string Hash(string Password)
        {
             return BCrypt.Net.BCrypt.HashPassword(Password, Salt);
        }
        public static bool Check(string Password, string Hash)
        {
            return BCrypt.Net.BCrypt.Verify(Password, Hash);
        }
    }
}
