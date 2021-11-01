using BancoLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:59453/api/Cliente";
            using (var cliente = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(new Cliente()
                {
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    dni = long.Parse(txtDni.Text),
                    FechaAlta = DateTime.Parse(txtFecha.Text)
                }) ;

                var result = await cliente.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            long dni = long.Parse(txtDni.Text);
            string url = "http://localhost:59453/api/Cliente/" + dni;
            using (var cliente = new HttpClient())

            using (var result = await cliente.DeleteAsync(url))

            {
                result.EnsureSuccessStatusCode();
                Console.WriteLine("success");
            }

        }

        private async void Consultar ()
        {
            string url = "http://localhost:59453/api/Cliente";
            using (var cliente = new HttpClient())
            {
                var result = await cliente.GetAsync(url);
                var content = await result.Content.ReadAsStringAsync();
                List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(content);
            }
        }

        private async void ConsultarPorDni()
        {
            long dni = long.Parse(txtDni.Text);
            string url = "http://localhost:59453/api/Cliente" + dni;
            using (var cliente = new HttpClient())
            {
                var result = await cliente.GetAsync(url);
                var content = await result.Content.ReadAsStringAsync();
                List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(content);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
}
