using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIconsumerapp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage mess= client.GetAsync("http://localhost:49865//api/TbCatalogs").Result;
            if(mess.IsSuccessStatusCode)
            {
               List<Catalog> ctlst= mess.Content.ReadAsAsync<List<Catalog>>().Result;
             
                foreach (var item in ctlst)
                {

                    cmb_catalog.Items.Add(item.name);

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Catalog c = new Catalog();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49865/");
            HttpResponseMessage respons = client.GetAsync($"api/TbCatalogs?name={cmb_catalog.SelectedItem.ToString()}").Result;
            if (respons.IsSuccessStatusCode)
            {
               c= respons.Content.ReadAsAsync<Catalog>().Result;
            }

            News n = new News() {
                title = txt_title.Text,
                pref = txt_pref.Text,
                description = txt_desc.Text,
                date = DateTime.Parse(txt_date.Text),
                Catalog_id = c.id
            };
           
            HttpResponseMessage mess = client.PostAsJsonAsync("http://localhost:49865//api/TbNews", n).Result;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }
    }
}
