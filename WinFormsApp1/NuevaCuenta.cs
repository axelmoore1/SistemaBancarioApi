using BancoLib;
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

namespace Front
{
    public partial class NuevaCuenta : Form
    {
        TipoCuenta oTipoCuenta = new TipoCuenta();
        public NuevaCuenta()
        {
            InitializeComponent();
        }

        private async Task<HttpResponseMessage> Grabar_Cuenta_Async(TipoCuenta Ocuenta)
        {
            string url = "https://localhost:44389/api/Cuenta/";
            string cuentaJson = JsonConvert.SerializeObject(Ocuenta);
            var result = await ClienteSingleton.GetInstancia().PostAsync(url, cuentaJson);

            return result;

        }
        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un nombre de Cuenta", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }
            TipoCuenta cuenta = new TipoCuenta();
            cuenta.Nombre = txtNombre.Text;

            var result = await Grabar_Cuenta_Async(cuenta); //metodo post.
            if (!result.IsSuccessStatusCode) //-- ver si esta bien 
            {
                MessageBox.Show("Error al intentar grabar el tipo de Cuenta ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
                LimpiarCampos();

            }
            else
                MessageBox.Show("Tipo de Cuenta creada con éxito!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
        }

        private void NuevaCuenta_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            Consultar_NextIdCuenta_Async();
        }

        private async Task Consultar_NextIdCuenta_Async()
        {
            string url = "https://localhost:44389/api/Cuenta/CuentaID";
            var result = await ClienteSingleton.GetInstancia().GetAsync(url);
            txtId.Text = result;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar el registro?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
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
    }
}
