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
using WinFormsApp1;

namespace BancoForms
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            txtpassword.PasswordChar = '*';
        }

     

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtDni.Text == "User" || string.IsNullOrEmpty(txtDni.Text))
            {
                Limpiar2(txtDni);
            }


        }
        public void Limpiar2(TextBox tbx)
        {
            if (tbx.Name == "User" || tbx.Name == "")
            {
                tbx.ForeColor = Color.Black;
                tbx.Text = "";
                tbx.TextAlign = HorizontalAlignment.Left;
            }
            else
            {
                tbx.ForeColor = Color.Black;
                tbx.Text = "";
                tbx.TextAlign = HorizontalAlignment.Left;
            }

        }
        private void TCtaBN_Leave(object sender, EventArgs e)
        {

            FormatoTbx(txtDni, txtpassword.Text);

        }
        public void FormatoTbx(TextBox tbx, string campo)
        {

            if (string.IsNullOrEmpty(campo) || campo == "?" || campo == "<no puesta>" || campo == "?    " || campo == "ND" || campo == "<falta poner>")
            {
                tbx.ForeColor = Color.Red;
                tbx.Text = "ND";
                tbx.TextAlign = HorizontalAlignment.Left;
            }
            else
            {

                tbx.ForeColor = Color.Black;
                tbx.TextAlign = HorizontalAlignment.Left;
                if (tbx.Name == "User" || tbx.Name == "")
                {
                    tbx.ForeColor = Color.Black;
                    tbx.TextAlign = HorizontalAlignment.Left;
                }
            }

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (txtDni.Text == "" ) 
            {
                MessageBox.Show("Ingrese dni", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDni.Focus();
                return;
            }

            if (txtpassword.Text == "") 
            {
                MessageBox.Show("Ingrese Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpassword.Focus();
                return;
            }


            long dni = long.Parse(txtDni.Text);

            Cliente cliente = await Consultar_Cliente_Async(dni);
            if (cliente == null) 
            {
                MessageBox.Show("Usuario incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDni.Focus();
                return;
            }

            string password = txtpassword.Text;
            

            if (!password.Equals(cliente.password)) 
            {
                MessageBox.Show("Contraseña incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }
            Menu menu = new Menu();
            menu.ShowDialog();
            

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            {
                txtDni.Clear();
                txtpassword.Clear();
                txtDni.Focus();
            }
        }

        private async Task<Cliente> Consultar_Cliente_Async(long dni)
        {
            string url = "https://localhost:44389/api/Cliente/" + dni.ToString();
            var result = await ClienteSingleton.GetInstancia().GetAsync(url);
            return JsonConvert.DeserializeObject<Cliente>(result);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            NuevoCliente nuevo = new NuevoCliente();
            nuevo.ShowDialog();
        }
    }
}
