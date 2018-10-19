<h1>C# Logging lib</h1><br>
<b> How to use manual :</b><br>

using Org.Apollo.Logging;
using System;

namespace LogDemo
{
    public class Program
    {
        private Log _log = Log.Instance;
        private static string NameSpace = typeof(Program).FullName;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Add(2, 4);
            Console.ReadKey();
        }
        public int Add(int a, int b)
        {
            _log.Info(new ErrorDetails() { ErrorSignature = "Add method started execution.", FullNameSpace = NameSpace});
            int result = -1;
            try
            {
                _log.Warning(new ErrorDetails() { ErrorSignature = "After this step we might get excpetion. Be prepared.", FullNameSpace = NameSpace });
                throw new ArgumentNullException();

                result = a + b;
            }
            catch(Exception e)
            {  
                _log.Error(new ErrorDetails()
                {
                    ErrorSignature = e.Message,
                    ErrorCode = e.HResult,
                    StackTrace = e.StackTrace,
                    FullNameSpace = NameSpace
                });
            }

            return result;
        }
    }
}


<br><br>
File : App.config - few parameters we have to set before using this lib :
<br>
<appSettings>
	<add key="Name" value="Org.Apollo.Logging"/>
	<add key="FilePath" value="C:\Logs\TestProject01\"/>
	<add key="FileName" value="Test-project01-{0}"/>
	<add key="FileSplitSizeInMb" value="1"/>
	<add key="Mode" value="Debug"/>
	<add key="Env" value="TUP"/>
	<add key="IsLogOn" value="True"/>
</appSettings>
<br>
