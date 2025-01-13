using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Helpers
{
    public  class ConnectionStr
    {
        public static string GetconnectionStr()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();

            string path = Directory.GetCurrentDirectory();
            configurationManager.SetBasePath(path);
            configurationManager.AddJsonFile("appsettings.json");

            string? connectionStr = configurationManager.GetConnectionString("MsSql");
            if(string.IsNullOrEmpty(connectionStr) )
            {
                throw new Exception("Something went wrong");
            }

            return connectionStr;
        }
       
       
    }
}
