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
    public partial class WebOpener : Form
    {
        public WebOpener()
        {
            InitializeComponent();
        }

        private void WebOpener_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Link_TextBox.Text = string.Empty;
            Hide();
        }
    }
}