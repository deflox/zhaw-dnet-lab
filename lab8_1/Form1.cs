using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form1 : Form
    {
        private bool search = true;

        public Form1()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate("https://radar.zhaw.ch/adressbook/_Adressbook.aspx");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (search && e.Url.ToString().StartsWith("https://radar.zhaw.ch/adressbook/_Adressbook.aspx"))
            {
                HtmlElement e1 = getElementByClassName(webBrowser1.Document.All, "searchInput");
                e1.SetAttribute("value", "Karl");
                HtmlElement e2 = getElementByClassName(webBrowser1.Document.All, "go");
                e2.InvokeMember("click");
                search = false;
            }
        }

        private HtmlElement getElementByClassName(HtmlElementCollection all, string name)
        {
            foreach (HtmlElement elem in all)
            {
                if (elem.GetAttribute("className") == name)
                    return elem;
            }

            return null;
        }
    }
}
