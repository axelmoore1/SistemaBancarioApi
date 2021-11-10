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

namespace Front
{
    public enum Accion
    {
        CREATE,
        READ,
        UPDATE,
        DELETE
    }
    public partial class Cuentas : Form
    {
        private IService servicio;
        private Accion accion = Accion.CREATE;
        TipoCuenta oTipoCuenta = new TipoCuenta();
        public Cuentas()
        {
            InitializeComponent();
            if (accion == Accion.READ)
            {
                gbCuentas.Enabled = false;
                btnCrearCuenta.Enabled = false;
            }
        }

        private void Cuentas_Load(object sender, EventArgs e)
        {
        }

        private async Task<HttpResponseMessage> Grabar_Cuenta_Async(TipoCuenta Ocuenta)
        {
            string url = "https://localhost:44389/api/Cuenta/";
            string cuentaJson = JsonConvert.SerializeObject(Ocuenta);
            var result = await ClienteSingleton.GetInstancia().PostAsync(url, cuentaJson);
            return result;

        }

        private async void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            NuevaCuenta nuevo = new NuevaCuenta();
            nuevo.ShowDialog();
        }

        private async Task Consultar_TipoCuenta_Async(string nombre)
        {

            string url = "https://localhost:44389/api/Cuenta/" + nombre.ToString();
            var result = await ClienteSingleton.GetInstancia().GetAsync(url);
            var cuenta = JsonConvert.DeserializeObject<TipoCuenta>(result);

            if (this.oTipoCuenta == null)
            {
                MessageBox.Show("No existe tipo de cuenta", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }

            dgvResultados.Rows.Add(new object[] {   cuenta.Id,
                                                        cuenta.Nombre
                                                            });

        }
        private async Task Consultar_TipoCuentas_Async()
        {
            string url = "https://localhost:44389/api/Cuenta/";
            string result = await ClienteSingleton.GetInstancia().GetAsync(url);
            var lista = JsonConvert.DeserializeObject<List<TipoCuenta>>(result);

            if (lista.Count != 0)
            {
                foreach (TipoCuenta item in lista)
                {
                    dgvResultados.Rows.Add(new object[] {   item.Id,
                                                            item.Nombre
                                                            });
                }
            }
        }
        private async void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            string nombre = (txtNombre.Text);

            if (nombre == "")
            {
                limpiarGrilla();
                await Consultar_TipoCuentas_Async();
            }
            else
            {
                limpiarGrilla();
                await Consultar_TipoCuenta_Async(nombre);
            }


        }

        private void limpiarGrilla()
        {
            dgvResultados.Rows.Clear();

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

        private async void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResultados.CurrentCell.ColumnIndex == 2)
            {

                dgvResultados.Rows.Remove(dgvResultados.CurrentRow);
                await Eliminar_TipoCuenta_Async((string)dgvResultados.CurrentRow.Cells[1].Value);
            }
        }

        private async Task Eliminar_TipoCuenta_Async(string nombre)
        {
            string url = "https://localhost:44389/api/ClienteCuenta/" + nombre.ToString();
            var result = await ClienteSingleton.GetInstancia().DeleteAsync(url);

        }
    }
        
}
