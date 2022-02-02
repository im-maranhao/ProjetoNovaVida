using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class KabumDemo : Form
    {
        public KabumDemo()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wc = new WebClient();
            string pagina = wc.DownloadString("https://www.giraffas.com.br/cardapio");

            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(pagina);

            dataGridView1.Rows.Clear();

            string id = string.Empty;
            string nome = string.Empty;
            string descrição = string.Empty;
            string quantidade = string.Empty;
            string link = string.Empty;
            
            foreach (HtmlNode node in htmlDocument.GetElementbyId("main-content").ChildNodes)
            {
                if(node.Attributes.Count > 0)
                {
                    //id = node.Attributes["__next"].Value;
                    link = "https://www.giraffas.com.br/cardapio/diamante-negro";
                    nome = node.Descendants().First(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("c-highlight-box__title")).InnerText;
                    //descrição = node.Descendants().First(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("overflow-wrap: break-word")).InnerText;
                    //c-highlight-box__title
                    if (!string.IsNullOrEmpty(nome))                
                        dataGridView1.Rows.Add(nome, descrição, quantidade, link);
                }

            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
       
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        { 

        }
    }
}
