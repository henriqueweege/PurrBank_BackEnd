using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Tools
{
    public static class AppSettings
    {
        public static ConnectionString ConnectionString { get; set; }
    }

    public class ConnectionString 
    {
        public string MySql { get; set; }
    }
}
