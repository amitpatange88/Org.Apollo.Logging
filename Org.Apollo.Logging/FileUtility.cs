using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Apollo.Logging
{
    /// <summary>
    /// File Operations are handled here.
    /// </summary>
    public class FileUtility : ConfigurationElement
    {
        private string _Path = string.Empty;
        private string _FileName = string.Empty;
        private string _FileLocation = string.Empty;

        //Assigning objects here only immplies lazy loading in Singleton design pattern.
        private static readonly Lazy<FileUtility> instance = new Lazy<FileUtility>(() => new FileUtility());

        public static FileUtility Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public FileUtility()
        {
        }

        [ConfigurationProperty("FilePath",IsRequired = true)]
        public string Path
        {
            get
            {
                _Path = ConfigurationManager.AppSettings["FilePath"];
                return _Path;
            }
            private set { }
        }

        [ConfigurationProperty("FileName", IsRequired = true)]
        public string FileName
        {
            get
            {
                _FileName = ConfigurationManager.AppSettings["FileName"];
                return _FileName;
            }
            private set { }
        }

        public FileUtility(string path, string fileName)
        {
            _Path = path;
            _FileName = fileName;
        }

        public bool WriteLog(string content)
        {
            bool IsDone = false;
            try
            {
                CreateFileIfNotExists();

                using (StreamWriter w = File.AppendText(_FileLocation))
                {
                    w.WriteLine(content);
                    IsDone = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return IsDone;
        }

        private void CreateFileIfNotExists()
        {
            bool IsExist = File.Exists(MakeFileName());
            if (!IsExist)
            {
                var file = File.Create(_FileLocation);
                file.Close();
            }
        }

        /// <summary>
        /// Return file size in bytes.
        /// InMb = bytes / 1000000
        /// </summary>
        /// <param name="_FileLocation"></param>
        /// <returns></returns>
        private long GetFileSize(string _FileLocation)
        {
            return new System.IO.FileInfo(_FileLocation).Length;
        }

        public void WriteLog_Copy(string content)
        {
            try
            {
                //CreateFile();
                using (StreamWriter w = File.AppendText(_FileLocation))
                {
                    w.WriteLine(content);
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string MakeFileName()
        {
            _FileLocation = Path + string.Format(FileName, DateTime.Now.ToString("yyyyMMdd")) + ".txt";

            return _FileLocation;
        }
    }
}
