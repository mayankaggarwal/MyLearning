using LoggerModule;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace FileApi.Models
{
    public interface IFileOperations
    {
        IEnumerable<string> GetFileNames();
        string GetFilePath(string filename);
    }

    public class FileOperations: IFileOperations
    {
        private string dataFolder = "";
        private ICustomLogger Logger;
        public FileOperations(ICustomLogger logger)
        {
            Logger = logger;
            InitializeDataFolder();
            
        }

        private void InitializeDataFolder()
        {
            string folderPath = ConfigurationManager.AppSettings["dataFolder"].ToString();
            if(!String.IsNullOrEmpty(folderPath))
            {
                dataFolder = folderPath;
            }

            if(!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }
        }

        public IEnumerable<string> GetFileNames()
        {
            List<string> fileNames = new List<string>();
            if(!String.IsNullOrEmpty(dataFolder))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dataFolder);
                var filesInfo = dirInfo.GetFiles();
                if(filesInfo!= null)
                {
                    foreach(var fileInfo in filesInfo)
                    {
                        fileNames.Add(fileInfo.Name);
                    }
                }
            }

            return fileNames;
        }

        public string GetFilePath(string filename)
        {
            string filePath = string.Empty;
            if(!String.IsNullOrEmpty(dataFolder))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dataFolder);
                var filesInfo = dirInfo.GetFiles();
                if (filesInfo != null)
                {
                    foreach(var fileInfo in filesInfo)
                    {
                        if(fileInfo.Name.Contains(filename))
                        {
                            filePath = Path.Combine(dataFolder, fileInfo.Name);
                            return filePath;
                        }
                    }
                }
            }
            return filePath;
        }
    }
}