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
            {
                Cliente cliente = await Consultar_Cliente_Async(long.Parse(txtDni.Text));

                string url = "https://localhost:44389/api/ClienteCuenta/";
                ClienteCuenta oClienteCuenta = new ClienteCuenta();
                oClienteCuenta.Cbu = ClienteCuenta.GenerarCbu();
                oClienteCuenta.Saldo = 0;
                oClienteCuenta.tipoCuenta = Convert.ToInt32(cboCuentas.SelectedValue);
                oClienteCuenta.Id_cliente = cliente.Id;
                string clienteJson = JsonConvert.SerializeObject(oClienteCuenta);
                var result = await ClienteSingleton.GetInstancia().PostAsync(url, clienteJson);

                //if (result.IsSuccessStatusCode)
                //{
                //    MessageBox.Show("Cuenta guardada con éxito!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
                //else
                //{
                //    MessageBox.Show("Error al intentar grabar la cuenta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                url = "https://localhost:44389/api/ClienteCuenta/" + cliente.dni.ToString();
                var result2 = await ClienteSingleton.GetInstancia().GetAsync(url);
                var lista = JsonConvert.DeserializeObject<List<ClienteCuenta>>(result2);

                dgvResultados.Rows.Clear();
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

                btnAbrir.Enabled = false;
                cboCuentas.Enabled = false;
                cboCuentas.SelectedIndex = -1;

                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cuenta guardada con éxito!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error al intentar grabar la cuenta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task<Cliente> Consultar_Cliente_Async(long dni)
        {
            string url = "https://localhost:44389/api/Cliente/" + dni.ToString();
            var result = await ClienteSingleton.GetInstancia().GetAsync(url);
            return JsonConvert.DeserializeObject<Cliente>(result);
        }

        private async Task Cargar_Cliente_Async(long dni)
        {

            string url = "https://localhost:44389/api/Cliente/" + dni.ToString();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
         DialogResult resultado = MessageBox.Show("Esta seguro que desea salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (resultado == DialogResult.Yes)
            {
                this.Dispose();
            }
            else { return; }
         
        }


    

        private async Task Eliminar_CuentaCliente_Async(long cbu)
        {
            string url = "https://localhost:44389/api/ClienteCuenta/" + cbu.ToString();
            var result = await ClienteSingleton.GetInstancia().DeleteAsync(url);
           
        }

        private async void dgvResultados_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResultados.CurrentCell.ColumnIndex == 4)
            {
                oCliente.QuitarCuenta(dgvResultados.CurrentRow.Index);
                dgvResultados.Rows.Remove(dgvResultados.CurrentRow);
                await Eliminar_CuentaCliente_Async((long)dgvResultados.CurrentRow.Cells[1].Value);
            }

        }
    }
}
