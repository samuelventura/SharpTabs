using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SharpTabs
{
    public partial class MainForm : Form
    {
        private readonly SessionFactory factory;

        public MainForm(SessionFactory factory)
        {
            this.factory = factory;
            InitializeComponent();
        }

        private void AddTab(Control control)
        {
            control.Dock = DockStyle.Fill;
            var tabPage = new TabPage();
            tabPage.Text = control.Text; //name holder
            tabPage.Dock = DockStyle.Fill;
            tabPage.Controls.Add(control);
            tabPage.Tag = control;
            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTab = tabPage;
        }

        private Control Control(TabPage tabPage)
        {
            return tabPage.Tag as Control;
        }

        private object Dto(TabPage tabPage)
        {
            var control = Control(tabPage);
            control.Text = tabPage.Text; //name holder
            return factory.Unwrap(control);
        }

        private object[] Dtos()
        {
            var list = new List<object>();
            foreach(var item in tabControl.TabPages)
            {
                list.Add(Dto(item as TabPage));
            }
            return list.ToArray();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = factory.Title;
            Icon = factory.Icon;
            toolStripStatusLabel.Text = factory.Status;
            tabControl.TabPages.Clear();
            foreach(var dto in factory.Load())
            {
                AddTab(factory.Wrap(dto));
            }
            if (tabControl.TabPages.Count == 0)
            {
                newToolStripButton.PerformClick();
            }
            tabControl.SelectedIndex = 0;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var item in tabControl.TabPages)
            {
                var control = Control(item as TabPage);
                factory.Unload(control);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dtos = Dtos();
            #if DEBUG
            var current = JsonConvert.SerializeObject(dtos, Formatting.Indented);
            var original = JsonConvert.SerializeObject(factory.Load(), Formatting.Indented);
            File.WriteAllText("original.txt", original);
            File.WriteAllText("current.txt", current);
            #else
            var current = JsonConvert.SerializeObject(dtos);
            var original = JsonConvert.SerializeObject(factory.Load());
            #endif
            if (current != original)
            {
                var result = MessageBox.Show(this, 
                    "Save changes before closing?",
                    "Detected changes will be lost",
                    MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Warning);
                switch (result)
                {
                    case DialogResult.Yes: 
                        factory.Save(dtos);
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            AddTab(factory.New());
        }

        private void CloneToolStripButton_Click(object sender, EventArgs e)
        {
            var selected = tabControl.SelectedTab;
            if (selected == null) return;
            var dto = Dto(selected);
            AddTab(factory.Wrap(dto));
        }

        private void RenameToolStripButton_Click(object sender, EventArgs e)
        {
            var selected = tabControl.SelectedTab;
            if (selected == null) return;
            var form = new RenameForm();
            form.textBox.Text = selected.Text;
            if (DialogResult.OK == form.ShowDialog())
            {
                selected.Text = form.textBox.Text;
            }
        }

        private void RemoveToolStripButton_Click(object sender, EventArgs e)
        {
            var selected = tabControl.SelectedTab;
            if (selected == null) return;
            var control = Control(selected);
            factory.Unload(control);
            tabControl.TabPages.Remove(selected);
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            factory.Save(Dtos());
        }

        private void ShiftLeftToolStripButton_Click(object sender, EventArgs e)
        {
            var selected = tabControl.SelectedTab;
            if (selected == null) return;
            var index = tabControl.SelectedIndex;
            tabControl.TabPages.Remove(selected);
            index--;
            if (index < 0) index = tabControl.TabPages.Count;
            tabControl.TabPages.Insert(index, selected);
            tabControl.SelectedTab = selected;
        }

        private void ShiftRightToolStripButton_Click(object sender, EventArgs e)
        {
            var selected = tabControl.SelectedTab;
            if (selected == null) return;
            var index = tabControl.SelectedIndex;
            tabControl.TabPages.Remove(selected);
            index++;
            if (index > tabControl.TabPages.Count) index = 0;
            tabControl.TabPages.Insert(index, selected);
            tabControl.SelectedTab = selected;
        }

        private void ExportAllToolStripButton_Click(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Count == 0) return;
            var fd = new SaveFileDialog
            {
                Title = $"Export to {factory.Name} File",
                Filter = $"{factory.Name} Files (*.{factory.Ext})|*.{factory.Ext}",
                OverwritePrompt = true,
                RestoreDirectory = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                factory.Save(fd.FileName, Dtos());
            }
        }

        private void ExportSelectedToolStripButton_Click(object sender, EventArgs e)
        {
            var selected = tabControl.SelectedTab;
            if (selected == null) return;
            var fd = new SaveFileDialog
            {
                Title = $"Export to {factory.Name} File",
                Filter = $"{factory.Name} Files (*.{factory.Ext})|*.{factory.Ext}",
                OverwritePrompt = true,
                RestoreDirectory = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                var dto = Dto(selected);
                factory.Save(fd.FileName, new object[] {dto});
            }
        }

        private void ImportToolStripButton_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog
            {
                Title = $"Import from {factory.Name} File",
                Filter = $"{factory.Name} Files (*.{factory.Ext})|*.{factory.Ext}",
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                foreach (var dto in factory.Load(fd.FileName))
                {
                    AddTab(factory.Wrap(dto));
                }
            }
        }

        private void ToolStripStatusLabel_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(toolStripStatusLabel.Text);
        }
    }
}
