using BancoLib;
using BancoLib.Servicios.Interfaces;
using Front.Cliente;
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
    public enum Accion
    {
        CREATE,
        READ,
        UPDATE,
        DELETE
    }
    public partial class NuevoCliente : Form
    {
        //private IService service;
        private Accion accion = Accion.CREATE; 

        Cliente oCliente = new Cliente();  
        Cuenta oCuenta = new Cuenta();  
        public NuevoCliente()
        {
            InitializeComponent();
           // service = new ServiceFactory().CrearService();
            
            
            if (accion == Accion.READ)
            {
                gbDatosCliente.Enabled = false;
                btnAceptar.Enabled = false;
                this.Text = "CLIENTE";
            }
        }

        private async Task Cargar_Cliente_Async(int dni)
        {
            
            string url = "https://localhost:44373/api/Presupuestos/" + dni.ToString();
            var result = await ClienteSingleton.GetInstancia().GetAsync(url);
            this.oCliente = JsonConvert.DeserializeObject<Cliente>(result);

            txtNombre.Text = oCliente.nombre;
            txtApellido.Text = oCliente.apellido;
            txtDni.Text = (oCliente.dni).ToString();
            txtFecha.Text = oCliente.FechaAlta.ToString("dd/MM/yyyy");
            

            //dgvDetalles.Rows.Clear();
            //foreach (Cuenta oDetalle in oCliente.Cuentas) //----------------> ver esto
            //{
            //    dgvDetalles.Rows.Add(new object[] { "", //oDetalle.Cuenta.cb, }); ; ---> 
            //}
            
        }

        private async Task<HttpResponseMessage> Grabar_Cliente_Async(Cliente oCliente) 
        {
            string url = "https://localhost:44389/api/Cliente/";
            string clienteJson = JsonConvert.SerializeObject(oCliente);
            var result = await ClienteSingleton.GetInstancia().PostAsync(url, clienteJson);

            return result;

        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el nombre del cliente", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }
            if (txtDni.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el DNI", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDni.Focus();
                return;
            }
            if (txtApellido.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el Apellido", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return;
            }
            //pasar datos al objeto 
            Cliente cliente = new Cliente();
            cliente.apellido = txtApellido.Text;
            cliente.nombre = txtNombre.Text;
            cliente.dni = long.Parse(txtDni.Text);
            cliente.FechaAlta = Convert.ToDateTime (txtFecha.Text);


            var result = await Grabar_Cliente_Async(cliente);
            if (result.IsSuccessStatusCode) //-- ver si esta bien 
            {
                MessageBox.Show("Cliente guardado con éxito!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Error al intentar grabar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (accion == Accion.CREATE)
            {
                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                CargarCombo();
            }
        }

        private async void CargarCombo()
        {
            string url = "https://localhost:44389/api/Cuenta/";
            var result = await ClienteSingleton.GetInstancia().GetAsync(url);


            List<TipoCuenta2> lst = JsonConvert.DeserializeObject<List<TipoCuenta2>>(result);
            cboCuentas.ValueMember = "Id";
            cboCuentas.DisplayMember = "Nombre";

            cboCuentas.DataSource = lst;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar el registro?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

       
        private bool ExisteProductoEnGrilla(string text)
        {
            //foreach (DataGridViewRow fila in dgvDetalles.Rows)
            //{
            //    if (fila.Cells[""].Value.Equals(text)) // ----> verlo en donde esta "" 
            //        return true;
            //}
            return false;
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvDetalles.CurrentCell.ColumnIndex == 6)
            //{
            //    //oCliente.QuitarDetalle(dgvDetalles.CurrentRow.Index); //--- > ver esto
            //    dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow); //---> ver esto
               
            //}
        }

        private void gbDatosCliente_Enter(object sender, EventArgs e)
        {

        }
    }
}
