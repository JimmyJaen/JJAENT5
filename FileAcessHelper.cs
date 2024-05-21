using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJAENT5
{
    public class FileAcessHelper
    {
        public static string GetLocalFilePath(String filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }

    }
}
