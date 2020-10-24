using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharpTabs
{
    public interface SessionFactory
    {
        Icon Icon { get; }
        string Name { get; }
        string Ext { get; }
        string Title { get; }
        string Status { get; }
        Control New();
        object[] Load();
        object[] Load(string path);
        void Unload(Control control);
        void Save(object[] dtos);
        void Save(string path, object[] dtos);
        Control Wrap(object dto);
        object Unwrap(Control control);
    }
}
