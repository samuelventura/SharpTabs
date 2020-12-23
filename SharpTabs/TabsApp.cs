using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharpTabs
{
    public class TabDto : ISessionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TabFactory : ISessionFactory
    {
        private readonly string path;
        public string Name => "SharpTabs";
        public string Ext => "SharpTabs";
        public string Title => $"SharpTabs App {TabsTools.Version()}";
        public string Status => path;
        public Icon Icon => TabsTools.ExeIcon();
        public bool HasSetup => true;

        public TabFactory(string path)
        {
            this.path = path ?? SessionDao.DefaultPath(Name);
        }

        public ISessionDto[] Load()
        {
            return Load(path);
        }

        public ISessionDto[] Load(string path)
        {
            SessionDao.Retype(path, 1, typeof(TabDto));
            return SessionDao.Load<TabDto>(path);
        }

        public void Unload(Control control)
        {
            if (control is Panel) return;
            throw new Exception("Invalid control");
        }

        public void Save(ISessionDto[] dtos)
        {
            Save(path, dtos);
        }

        public void Save(string path, ISessionDto[] dtos)
        {
            SessionDao.Save(path, dtos);
        }

        public void Setup(Control obj)
        {
            MessageBox.Show("Setup goes here", "Setup");
        }

        public Control New()
        {
            return Wrap(new TabDto
            {
                Name = SessionDao.NewName()
            });
        }

        public ISessionDto Unwrap(Control obj)
        {
            var control = obj as Panel;
            return new TabDto 
            { 
                Name = control.Text 
            };
        }

        public Control Wrap(ISessionDto obj)
        {
            var dto = obj as TabDto;
            return new Panel
            {
                Text = dto.Name,
            };
        }
    }
}
