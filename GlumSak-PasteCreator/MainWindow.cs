using Glumboi.UI;
using GlumSak_PasteCreator.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GlumSak_PasteCreator
{
    public partial class MainWindow : Form
    {
        private WebOpener webOpener = new WebOpener();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.Menu = new MainMenu();
            MenuItem item = new MenuItem("File");
            this.Menu.MenuItems.Add(item);
            item.MenuItems.Add("Save", new EventHandler(Save_Click));
            item.MenuItems.Add("Open", new EventHandler(Open_Click));
            item.MenuItems.Add("Open from web", new EventHandler(OpenWeb_Click));
            this.Menu.MenuItems.Add(item);
        }

        private void OpenWeb_Click(object sender, EventArgs e)
        {
            webOpener.OpenLink_Button.Click += OpenLink_Button_Click;
            webOpener.Show();
        }

        private void OpenLink_Button_Click(object sender, EventArgs e)
        {
            //Link_TextBox
            LoadPaste(true, webOpener.Link_TextBox.Text);
            webOpener.Close();
        }

        private void ClearLists()
        {
            Items_ListBox.Items.Clear();
            Links_ListBox.Items.Clear();
        }

        private void RemoveDuplicates()
        {
            var prev = string.Empty;

            for (int i = Items_ListBox.Items.Count - 1; i >= 0; i--)
            {
                string str = (string)Items_ListBox.Items[i];
                if (str == prev)
                {
                    RemovItemByIndex(i);
                }
                prev = str;
            }
        }

        private void LoadPaste(bool web = false, string url = "")
        {
            //Open a text file
            var fileContent = new List<string>();
            if (!web)
            {
                fileContent = FileOpener.OpenGlumSakPaste();
            }
            else
            {
                WebClient client = new WebClient();
                System.IO.Stream stream = client.OpenRead(url);
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                {
                    string text;
                    while ((text = reader.ReadLine()) != null)
                    {
                        fileContent.Add(text);
                    }
                }
            }

            ClearLists();

            var prev = string.Empty;

            if (fileContent == null) return;

            foreach (string str in fileContent)
            {
                var value = str;
                if (!str.Contains("="))
                {
                    value = prev + str;

                    var splitted2 = value.Split('=');
                    Items_ListBox.Items.Add(splitted2[0]);
                    Links_ListBox.Items.Add(splitted2[1]);
                }
                else
                {
                    prev = str;
                    var splitted = value.Split('=');
                    Items_ListBox.Items.Add(splitted[0]);

                    Links_ListBox.Items.Add(splitted[1]);
                }
            }

            RemoveDuplicates();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            LoadPaste();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //Save the file as glumsak paste
            FileSaver.CreateGlumSakPaste(Items_ListBox.Items.OfType<string>().ToList(),
                Links_ListBox.Items.OfType<string>().ToList());
        }

        private void AddItem_Button_Click(object sender, EventArgs e)
        {
            Items_ListBox.Items.Add(Item_TextBox.Text);
        }

        private void AddLink_Button_Click(object sender, EventArgs e)
        {
            Links_ListBox.Items.Add(Link_TextBox.Text);
        }

        private void RemovItemByIndex(int index)
        {
            Items_ListBox.Items.Remove(Items_ListBox.Items[index]);
            Links_ListBox.Items.Remove(Links_ListBox.Items[index]);
        }

        private void RemoveSelected(ListBox list)
        {
            try
            {
                list.Items.Remove(list.Items[list.SelectedIndex]);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void ItemsRemove_Button_Click(object sender, EventArgs e)
        {
            RemoveSelected(Items_ListBox);
        }

        private void LinksRemove_Button_Click(object sender, EventArgs e)
        {
            RemoveSelected(Links_ListBox);
        }

        private void Links_ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(Links_ListBox.SelectedItem.ToString());
        }

        private void Items_ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(Items_ListBox.SelectedItem.ToString());
        }
    }
}