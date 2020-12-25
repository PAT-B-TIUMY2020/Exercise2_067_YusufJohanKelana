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
using System.Runtime.Serialization;
using System.Net;
using static Exercise2_067_Yusuf_Johan_Kelana.Create;

namespace Exercise2_067_Yusuf_Johan_Kelana
{
    public partial class Find : Form
    {
        public Find()
        {
            InitializeComponent();
        }

        private void Find_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tI_UMYDataSet.Mahasiswa' table. You can move, or remove it, as needed.
            this.mahasiswaTableAdapter.Fill(this.tI_UMYDataSet.Mahasiswa);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Server server = new Server();
            server.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var json = new WebClient().DownloadString("http://localhost:1907/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);

            foreach (var mahasiswa in data)
            {
                MessageBox.Show("NIM: " + mahasiswa.nim + "Nama: " + mahasiswa.nama + "Prodi: " + mahasiswa.prodi + "Angkatan: " + mahasiswa.angkatan);
            }
        }
    }
}
