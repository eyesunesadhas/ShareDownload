using ShareWatch.Properties;
using System;
using System.IO;

namespace ShareWatch.Common
{

    public class Logger
    {
        public static string fileName = $@"{Settings.Default.LoggingFolder}\{Settings.Default.ApplicationName}{DateTime.Now:yyyyMMddHH}.log";

        public static void Clear()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public static void Log(string Message)
        {
            Logger log = new Logger();
            log.LogMessage(Message);
        }


        public void LogMessage(string Message)
        {
            lock (this)
            {
                CreateFolderIfNeeded();
                using TextWriter tr = File.AppendText(fileName);
                tr.WriteLine(Message);
                tr.Close();
            }
        }

        private static void CreateFolderIfNeeded()
        {
            FileInfo fi = new FileInfo(fileName);
            string folder = fi.DirectoryName;
            if (Directory.Exists(folder))
            {
                return;
            }
            Directory.CreateDirectory(folder);
        }

        public static void Log(string PackageName, string Message)
        {
            CreateFolderIfNeeded();
            using TextWriter tr = File.AppendText(fileName);
            tr.WriteLine($"{Message}\t{PackageName}");
            tr.Close();
        }

        public static void LogError(string Step, string Message)
        {
            CreateFolderIfNeeded();
            Log($"{Step}\t{Message}");
        }

        public static void LogException(Exception ex)
        {
            CreateFolderIfNeeded();
            string msg = ex.Message;
            msg = $"{msg}\n{ex.StackTrace}";
            Log(msg);
        }
    }
}
