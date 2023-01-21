using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
namespace döviz_xml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        public class Currency
        {
            public string Name { get; set; }
            public double Rate { get; set; }
        }
        public class Currency1
        {
            public string Name { get; set; }
            public double Rate { get; set; }
        }

        private void acces1()
        {
            string url = "https://api.exchangerate-api.com/v4/latest/USD";

            // API isteği oluştur
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            // API cevabını al
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                // JSON verisini oku
                string json = reader.ReadToEnd();

                // JSON verisini deserialize et
                dynamic data = JsonConvert.DeserializeObject(json);

                // Döviz kurlarını listeye ekle
                List<Currency> currencies = new List<Currency>();
                foreach (var rate in data.rates)
                {
                    currencies.Add(new Currency { Name = rate.Name, Rate = rate.Value });
                }

                // Listeyi DataGridView'e bağla
                dataGridView1.DataSource = currencies;

                
              
            }
        }

        private void acces2()
        {
            string url = "https://api.exchangerate-api.com/v4/latest/TRY";

            // API isteği oluştur
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            // API cevabını al
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                // JSON verisini oku
                string json = reader.ReadToEnd();

                // JSON verisini deserialize et
                dynamic data = JsonConvert.DeserializeObject(json);

                // Döviz kurlarını listeye ekle
                List<Currency1> currencies = new List<Currency1>();
                foreach (var rate in data.rates)
                {
                    currencies.Add(new Currency1 { Name = rate.Name, Rate = rate.Value });
                }

                // Listeyi DataGridView'e bağla
                dataGridView2.DataSource = currencies;



            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            acces1();
            acces2();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        bool move = false;
        int mouse_X, mouse_Y;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_X=e.X;

                mouse_Y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (WindowState==FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move=false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_X = e.X;
            mouse_Y = e.Y;


        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X-mouse_X,MousePosition.Y-mouse_Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_X, MousePosition.Y - mouse_Y);
            }
           
        }
    }
}
