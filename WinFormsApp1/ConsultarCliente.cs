using BancoLib;
using BancoLib.Dominio;
using Front.Cliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            cboCuentas.Enabled = false;
            btnAbrir.Enabled = false;
            cargarCombo();
        }

        private async void cargarCombo()
        {
             string url = "https://localhost:44389/api/Cuenta/";
            var result = await ClienteSingleton.GetInstancia().GetAsync(url);


            List<TipoCuenta> lst = JsonConvert.DeserializeObject<List<TipoCuenta>>(result);
            cboCuentas.ValueMember = "Id";
            cboCuentas.DisplayMember = "Nombre";

            cboCuentas.DataSource = lst;
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

            url = "https://localhost:44389/api/ClienteCuenta/" + dni.ToString();
            result = await ClienteSingleton.GetInstancia().GetAsync(url);
            var lista = JsonConvert.DeserializeObject<List<ClienteCuenta>>(result);

            if (lista.Count != 0)
            {
                foreach (ClienteCuenta item in lista)
                {
                    dgvResultados.Rows.Add(new object[] {   item.Id,
                                                            item.Cbu,
                                                            item.tipoCuenta,
                                                            item.Saldo 
                                                            });
                }
            }
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            long dni = long.Parse (txtDni.Text);
            await Cargar_Cliente_Async(dni);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnAbrir.Enabled = true;
            cboCuentas.Enabled = true; 
        }

        private async void btnAbrir_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44389/api/ClienteCuenta/";
            ClienteCuenta oClienteCuenta = new ClienteCuenta();
            oClienteCuenta.Cbu = 0;
            oClienteCuenta.Saldo = 0;
            oClienteCuenta.tipoCuenta = cboCuentas.SelectedIndex;
            oClienteCuenta.Id_cliente = 4;
            string clienteJson = JsonConvert.SerializeObject(oClienteCuenta);
            var result = await ClienteSingleton.GetInstancia().PostAsync(url, clienteJson);

            if (result.IsSuccessStatusCode) //-- ver si esta bien 
            {
                MessageBox.Show("Cuenta guardada con éxito!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Error al intentar grabar la cuenta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnAbrir.Enabled = false;
            cboCuentas.Enabled = false;
            cboCuentas.SelectedIndex = -1;

        }
    }
}
