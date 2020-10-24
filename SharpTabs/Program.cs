using System;
using System.Windows.Forms;

namespace SharpTabs
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var path = args.Length > 0 ? args[0] : null;
            var factory = new TabFactory(path);
            TabsTools.SetupCatcher(factory.Name);
            Application.Run(new MainForm(factory));
        }
    }
}
