using System;
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

        public static string DefaultFolder(string name)
        {
            if (IsDebug())
            {
                var entry = Assembly.GetEntryAssembly().Location;
                return Path.GetDirectoryName(entry);
            }
            else 
            {
                var root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var folder = Path.Combine(root, name);
                Directory.CreateDirectory(folder);
                return folder;
            }
        }

        public static void SetupCatcher(string name)
        {
            Application.ThreadException += (s, t) =>
            {
                var ex = t.Exception;
                var folder = DefaultFolder(name);
                var path = Dump(folder, ex);
                Process.Start(path);
                var msg = string.Format("{0}\n{1} {2}", path, ex.GetType().FullName, ex.Message);
                MessageBox.Show(msg, $"{name} Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1); //Application.Exit calls MainForm.OnClose
            };
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
    }
}
