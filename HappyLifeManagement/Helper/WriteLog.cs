using System;
using System.Web;

namespace HappyLifeManagement.Helper
{
    public class WriteLog
    {
        private static string PageName = HttpContext.Current.Handler.GetType().Name;
        private static log4net.ILog log = log4net.LogManager.GetLogger(PageName);

        public static void LogError(Exception ex)
        {
            log.Error(ex);
        }

        public static void LogWarning(Exception ex)
        {
            log.Warn(ex);
        }

        public static void LogInfo(Exception ex)
        {
            log.Info(ex);
        }

        public static void LogInfo(string message)
        {
            log.InfoFormat(message);
        }

        public static void LogFatal(Exception ex)
        {
            log.Fatal(ex);
        }
    }


    //Read more: http://thuyk.com/article/su-dung-log4net-de-ghi-log-trong-aspnet-1268#ixzz4cPZiqmww
}