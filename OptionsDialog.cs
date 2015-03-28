using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocOrganizer
{
    public partial class OptionsDialog : Form
    {
        public OptionsDialog(List<string> extensions)
        {
            InitializeComponent();
            foreach (string ext in extensions)
            {
                AddExtension(ext);
            }
        }

        public List<string> GetExtensions()
        {
            List<string> extensions = new List<string>();
            foreach (Object o in listExtensions.Items)
            {
                extensions.Add(o as string);
            }
            return extensions;
        }

        void AddNewExtension()
        {
            string newExt = textNewExt.Text;
            if (newExt[0] != '*')
                newExt = "*." + newExt;

            AddExtension(newExt);
            textNewExt.Text = "";
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            AddNewExtension();
        }
        void AddExtension(string ext)
        {
            if (listExtensions.Items.IndexOf(ext) < 0)
                listExtensions.Items.Add(ext);
        }

        private void textNewExt_TextChanged(object sender, EventArgs e)
        {
            bAdd.Enabled = textNewExt.Text.Length != 0;
        }

        private void textNewExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                AddNewExtension();
        }

        private void listExtensions_SelectedIndexChanged(object sender, EventArgs e)
        {
            bRemove.Enabled = listExtensions.SelectedIndex >= 0;
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            listExtensions.Items.RemoveAt(listExtensions.SelectedIndex);
        }
    }
}
