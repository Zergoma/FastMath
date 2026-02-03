using System;
using System.Collections.Generic;
using System.Text;

namespace FastMath
{
    static public class Constantes
    {
        static public string UsersConfigurationPathXml()
        {
            string currentDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(currentDir, "usersConfig.xml"); ;
        }

        static public string UsersConfigurationPathJson()
        {
            string currentDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(currentDir, "usersConfig.json"); ;
        }
    }
}
