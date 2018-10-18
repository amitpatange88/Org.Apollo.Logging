using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Apollo.Logging
{
    public class FileUtility
    {
        private string _Path = string.Empty;
        private string _FileName = string.Empty;

        public FileUtility(string path, string fileName)
        {
            _Path = path;
            _FileName = fileName;
        }

        public bool CreateFile()
        {
            bool IsFileCreated = false;
            try
            {
                if (!File.Exists(_Path))
                {
                    File.Create(_Path);
                    IsFileCreated = true;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return IsFileCreated;
        }

        public void WriteLog(string content)
        {
            try
            {
                CreateFile();
                
                using (StreamWriter w = File.AppendText(_Path))
                {
                    w.WriteLine(content);
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
