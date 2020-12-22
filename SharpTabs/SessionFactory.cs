using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharpTabs
{
    public interface ISessionFactory
    {
        bool HasSetup { get; }
        Icon Icon { get; }
        string Name { get; }
        string Ext { get; }
        string Title { get; }
        string Status { get; }
        Control New();
        ISessionDto[] Load();
        ISessionDto[] Load(string path);
        void Setup(Control control);
        void Unload(Control control);
        void Save(ISessionDto[] dtos);
        void Save(string path, ISessionDto[] dtos);
        Control Wrap(ISessionDto dto);
        ISessionDto Unwrap(Control control);
    }
}
