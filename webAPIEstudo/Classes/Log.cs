using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace webAPIEstudo.Classes
{
    public static class Log
    {

        private static log4net.ILog log;


        public enum ELogLevel
        {
            Debug
            , Info
            , Error
        }

        public static void Write(string message, ELogLevel logLevel=ELogLevel.Info)
        {

            try
            {

                if (log == null)
                    log = LogManager.GetLogger("webApi");

                if (logLevel == ELogLevel.Info)
                    log.Info(message);
                else if (logLevel == ELogLevel.Debug)
                    log.Debug(message);
                else if (logLevel == ELogLevel.Error)
                    log.Error(message);

            }
            catch (Exception ex)
            {
                string retorno = ex.StackTrace;
            }

        }
    }

    public class ErrorLog
    {
        public string processo { get; set; }
        public string message { get; set; }
        public string stackTrace { get; set; }

    }

}