using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharpTabs
{
    public interface SessionFactory
    {
        bool HasSetup { get; }
        Icon Icon { get; }
        string Name { get; }
        string Ext { get; }
        string Title { get; }
        string Status { get; }
        Control New();
        SessionDto[] Load();
        SessionDto[] Load(string path);
        void Setup(Control control);
        void Unload(Control control);
        void Save(SessionDto[] dtos);
        void Save(string path, SessionDto[] dtos);
        Control Wrap(SessionDto dto);
        SessionDto Unwrap(Control control);
    }
}
