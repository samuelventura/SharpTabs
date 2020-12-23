using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace SharpTabs
{
    public partial class TabsTools
    {
        private static bool DEBUG;

        [Conditional("DEBUG")]
        public static void SetDebug()
        {
            DEBUG = true;
        }

        public static bool IsDebug()
        {
            SetDebug();
            return DEBUG;
        }

        public static bool IsControlDown()
        {
            return (Control.ModifierKeys & Keys.Control) == Keys.Control;
        }

        public static Icon ExeIcon()
        {
            var entry = Assembly.GetEntryAssembly().Location;
            return Icon.ExtractAssociatedIcon(entry);
        }

        public static string ExeVersion()
        {
            var entry = Assembly.GetEntryAssembly().Location;
            return FileVersionInfo.GetVersionInfo(entry).FileVersion;
        }

        public static string DefaultFolder(string name)
        {
            if (IsDebug())
            {
                var entry = Assembly.GetEntryAssembly().Location;
                return Path.GetDirectoryName(entry);
            }
            else 
            {
                var appdata = Environment.SpecialFolder.ApplicationData;
                var root = Environment.GetFolderPath(appdata);
                var folder = Path.Combine(root, name);
                Directory.CreateDirectory(folder);
                return folder;
            }
        }

        public static void SetupCatcher(string name)
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => { HandleException(name, e.Exception); };
            AppDomain.CurrentDomain.UnhandledException += (s, e) => { HandleException(name, e.ExceptionObject as Exception); };
        }

        public static string Dump(string folder, Exception ex)
        {
            var exceptions = Path.Combine(folder, "Exceptions");
            Directory.CreateDirectory(exceptions);
            var ts = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            var file = string.Format("exception-{0}.txt", ts);
            var path = Path.Combine(exceptions, file);
            File.WriteAllText(path, ex.ToString());
            return path;
        }        
        
        public static void HandleException(string name, Exception ex)
        {
            var folder = DefaultFolder(name);
            var path = Dump(folder, ex);
            Process.Start(path);
            MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1); //Application.Exit calls MainForm.OnClose
        }        
    }
}
