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

namespace Exercise2_067_Yusuf_Johan_Kelana
{
    public partial class Create : Form
    {
        [DataContract]
        public class Mahasiswa
        {
            private string _nama, _nim, _prodi, _angkatan;

            [DataMember]
            public string nama
            {
                get { return _nama; }
                set { _nama = value; }
            }

            [DataMember]
            public string nim
            {
                get { return _nim; }
                set { _nim = value; }
            }

            [DataMember]
            public string prodi
            {
                get { return _prodi; }
                set { _prodi = value; }
            }

            [DataMember]
            public string angkatan
            {
                get { return _angkatan; }
                set { _angkatan = value; }
            }

        }

        string baseUrl = "http://localhost:1907/";

        public Create()
        {
            InitializeComponent();
        }

        private void Create_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNim_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Mahasiswa mahasiswa = new Mahasiswa();
            mahasiswa.nim = textBoxNim.Text;
            mahasiswa.nama = textBoxNama.Text;
            mahasiswa.prodi = textBoxProdi.Text;
            mahasiswa.angkatan = textBoxAngkatan.Text;

            var data = JsonConvert.SerializeObject(mahasiswa);
            var postdata = new WebClient();
            postdata.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string response = postdata.UploadString(baseUrl + "Mahasiswa", data);
            Console.WriteLine(response);

            if (textBoxNim.Text.Equals("") && textBoxNama.Text.Equals("") && textBoxProdi.Text.Equals("") 
                && textBoxAngkatan.Text.Equals(""))
            {
                MessageBox.Show("Data yang Diisi Belum Lengkap!");
            }
            else
            {
                MessageBox.Show("Data Berhasil Dibuat!");
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void server_Click(object sender, EventArgs e)
        {
            this.Hide();
            Server server = new Server();
            server.Show();
        }
    }
}
