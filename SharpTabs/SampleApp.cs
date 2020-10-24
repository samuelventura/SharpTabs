using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharpTabs
{
    public class SampleDto
    {
        public string Name { get; set; }
    }

    public class SampleFactory : SessionFactory
    {
        private readonly string path;
        public string Name => "SampleApp";
        public string Ext => "SampleApp";
        public string Title => "Sample App";
        public string Status => path;
        public Icon Icon => Resource.SampleIcon;

        public SampleFactory(string path)
        {
            this.path = path ?? SessionDao.DefaultPath(Name);
        }

        public object[] Load()
        {
            return Load(path);
        }

        public object[] Load(string path)
        {
            return SessionDao.Load<SampleDto>(path);
        }

        public void Unload(Control control)
        {
            if (control is Panel) return;
            throw new Exception("Invalid control");
        }

        public void Save(object[] dtos)
        {
            Save(path, dtos);
        }

        public void Save(string path, object[] dtos)
        {
            SessionDao.Save(path, dtos);
        }

        public Control New()
        {
            return Wrap(new SampleDto
            {
                Name = NewName()
            });
        }

        public object Unwrap(Control obj)
        {
            var control = obj as Panel;
            return new SampleDto 
            { 
                Name = control.Text 
            };
        }

        public Control Wrap(object obj)
        {
            var dto = obj as SampleDto;
            return new Panel
            {
                Text = dto.Name,
            };
        }

        private static long count;

        public static string NewName()
        {
            count++;
            return $"Session {count}";
        }
    }
}
