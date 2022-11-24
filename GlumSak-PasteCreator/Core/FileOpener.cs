using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlumSak_PasteCreator.Core
{
    internal class FileOpener
    {
        public static List<string> OpenGlumSakPaste()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                var fileContent = File.ReadAllLines(openFileDialog.FileName);
                return fileContent.ToList();
            }
            return null;
        }
    }
}