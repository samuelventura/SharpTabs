using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharpTabs
{
    public class TabDto : SessionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TabFactory : SessionFactory
    {
        private readonly string path;
        public string Name => "SharpTabs";
        public string Ext => "SharpTabs";
        public string Title => "SharpTabs App";
        public string Status => path;
        public Icon Icon => Resource.SampleIcon;

        public TabFactory(string path)
        {
            this.path = path ?? SessionDao.DefaultPath(Name);
        }

        public SessionDto[] Load()
        {
            return Load(path);
        }

        public SessionDto[] Load(string path)
        {
            SessionDao.Exec(path, (db) => 
            {
                if (TabsTools.IsDebug())
                {
                    //force migration
                    //db.Engine.UserVersion = 0;
                }
                //migration
                if (db.Engine.UserVersion < 1)
                {
                    var assy = typeof(TabDto).Assembly.FullName;
                    var type = typeof(TabDto).FullName;
                    db.Engine.Run($"db.sessions.update _type='{type}, {assy}'"); 
                    db.Engine.UserVersion = 1;
                }
            });
            return SessionDao.Load<TabDto>(path);
        }

        public void Unload(Control control)
        {
            if (control is Panel) return;
            throw new Exception("Invalid control");
        }

        public void Save(SessionDto[] dtos)
        {
            Save(path, dtos);
        }

        public void Save(string path, SessionDto[] dtos)
        {
            SessionDao.Save(path, dtos);
        }

        public Control New()
        {
            return Wrap(new TabDto
            {
                Name = SessionDao.NewName()
            });
        }

        public SessionDto Unwrap(Control obj)
        {
            var control = obj as Panel;
            return new TabDto 
            { 
                Name = control.Text 
            };
        }

        public Control Wrap(SessionDto obj)
        {
            var dto = obj as TabDto;
            return new Panel
            {
                Text = dto.Name,
            };
        }
    }
}
