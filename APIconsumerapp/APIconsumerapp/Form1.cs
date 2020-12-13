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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bt_Load_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage mess = client.GetAsync("http://localhost:49865//api/TbNews").Result;

            if(mess.IsSuccessStatusCode)
            {
                List<News> newlst= mess.Content.ReadAsAsync<List<News>>().Result;
                var lst = newlst.Select(n => new { Title = n.title, Pref = n.pref, Description = n.description, Date = n.date,Catalog=n.TbCatalog.name });

                gv_News.DataSource = lst.ToList();
            }
        }

    }
}
