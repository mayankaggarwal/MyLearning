using LoggerModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargeFileTransfer
{
    public class FileHandling
    {
        public ICustomLogger Logger;
        public FileHandling(ICustomLogger logger)
        {
            this.Logger = logger;
        }
        public string CreateFile(string folterPath,string fileName,int steps)
        {
            string path = Path.Combine(folterPath, fileName);
            if(Directory.Exists(folterPath) || String.IsNullOrEmpty(folterPath))
            {
                Logger.Log($"Started writing to file {path}");
                if (File.Exists(path))
                    File.Delete(path);
                using (StreamWriter writer = new StreamWriter(path, append: true))
                {
                    for (int j = 0; j < steps; j++)
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            writer.WriteLine("Hello from Mayank");
                        }
                    }
                }
                Logger.Log($"Completed writing to file {path}");
            }
            else
            {
                Logger.Log($"Directory with path {folterPath} does not exist");
            }

            return path;
        }
    }
}
