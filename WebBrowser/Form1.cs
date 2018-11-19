using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Browser_Form : Form
    {
        public Browser_Form()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CBrowser was developed by Altuğhan Özengi for users of Windows operating system");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            Navigate_to_Page();
        }

        private void Navigate_to_Page()
        {
            if (urlBox.Text.Contains(".com")){
                NavStatus.Text = "Loading: "+ urlBox.Text;
                webBrowser.Navigate(urlBox.Text);
            }
            else
            {
                string searchTerm = urlBox.Text.Replace("http://", "");
                NavStatus.Text = "Loading: " + urlBox.Text;
                webBrowser.Navigate("http://www.google.com/search?q=" + searchTerm);
            }
        }

        private void urlBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                Navigate_to_Page();
            }
        }

        private void urlBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            urlBox.Enabled = true;
           
        }
      
        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try { 
                    if (e.CurrentProgress > 0 && e.MaximumProgress > 0) {
                        ProgressBar.ProgressBar.Value = (int)((double)e.CurrentProgress * 100 / e.MaximumProgress);
                    }
                }
            catch { }
        
    }

        private void Refresher_Click(object sender, EventArgs e)
        {
            Navigate_to_Page();
        }

        private void goBck_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void goForward_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }
    }
}
