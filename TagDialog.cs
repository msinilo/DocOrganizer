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
    public partial class TagDialog : Form
    {
        public TagDialog()
        {
            InitializeComponent();
        }

        public string TagText
        {
            get { return textTag.Text; }
        }
    }
}
