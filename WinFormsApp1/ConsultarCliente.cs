using BancoLib;
using Front.Cliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoForms
{
    public partial class ConsultarCliente : Form
    {
        Cliente oCliente = new Cliente();
        public ConsultarCliente()
        {
            InitializeComponent();

            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtFecha.Enabled = false;
        }

        private async Task Cargar_Cliente_Async(long dni)
        {

            string url = "https://localhost:44389/api/Cliente/"+ dni.ToString();
            var result = await ClienteSingleton.GetInstancia().GetAsync(url);
            this.oCliente = JsonConvert.DeserializeObject<Cliente>(result);

            if (this.oCliente == null) 
            {
                MessageBox.Show("No existe usuario", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDni.Focus();
                return;
            }

            txtNombre.Text = oCliente.nombre;
            txtApellido.Text = oCliente.apellido;
            txtFecha.Text = oCliente.FechaAlta.ToString("dd/MM/yyyy");




        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            long dni = long.Parse (txtDni.Text);
            await Cargar_Cliente_Async(dni);
        }
    }
}
