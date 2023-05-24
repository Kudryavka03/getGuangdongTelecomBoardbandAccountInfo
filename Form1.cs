using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace getGuangdongTelecomBoardbandAccountInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            webBrowser1.Navigate("https://10000.gd.cn/getAccountServer.php");
        }
        public void main01(string s)
        {
            try
            {
                if (!(s == null || s.Length == 0 || s.Contains("false")))
                {
                    textBox1.Text = s.Split('_')[6];
                    textBox3.Text = "下行：" + s.Split('_')[1] + " 上行：" + s.Split('_')[2];
                    textBox2.Text = s.Split('_')[3];
                    textBox4.Text = s.Split('_')[5];
                    var a = (JObject)JsonConvert.DeserializeObject(s.Split('_')[4]);
                    textBox5.Text = a["loginTime"].ToString();
                    textBox6.Text = a["multiSessionId"].ToString();
                }
            }
            catch { }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string htmlString = webBrowser1.Document.Body.InnerHtml;
            main01(htmlString);
        }
    }
}
