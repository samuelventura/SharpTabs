﻿using System;
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
        public bool HasSetup => true;

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
            SessionDao.Retype(path, 1, typeof(TabDto));
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
