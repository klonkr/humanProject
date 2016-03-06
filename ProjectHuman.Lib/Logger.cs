using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHuman.Lib
{
    public class Logger
    {
        public void DatabaseAction(string logMessage)
        {
            StreamWriter streamWriter = new StreamWriter("logger.txt", true);
            streamWriter.WriteLine($"{DateTime.Now}\t{logMessage}");
            streamWriter.Flush();
            streamWriter.Close();

        }
    }
}
