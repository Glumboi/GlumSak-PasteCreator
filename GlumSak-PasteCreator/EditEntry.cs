using Glumboi.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlumSak_PasteCreator
{
    public partial class EditEntry : Form
    {
        private Core.Entry entry;

        public EditEntry()
        {
            InitializeComponent();
        }

        public void Init(Core.Entry ent)
        {
            entry = ent;
            Value_TextBox.Text = entry.Value;
        }

        private void SaveValue_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Value_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }
    }
}