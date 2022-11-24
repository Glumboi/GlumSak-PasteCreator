using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlumSak_PasteCreator.Core
{
    internal class FileSaver
    {
        public static void CreateGlumSakPaste(List<string> items, List<string> links)
        {
            var filecontent = new List<string>();

            for (int i = 0; i < items.Count; i++)
            {
                string str = items[i];
                filecontent.Add(str + "=" + links[i]);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files | *.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = "GlumSakPaste";

            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                File.WriteAllLines(saveFileDialog.FileName, filecontent);
            }
        }
    }
}