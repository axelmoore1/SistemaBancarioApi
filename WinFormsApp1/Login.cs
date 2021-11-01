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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

     

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text == "User" || string.IsNullOrEmpty(txtUserName.Text))
            {
                Limpiar2(txtUserName);
            }
        }
        public void Limpiar2(TextBox tbx)
        {
            if (tbx.Name == "User" || tbx.Name == "Password")
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

            FormatoTbx(txtUserName, txtpassword.Text);

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
                if (tbx.Name == "User" || tbx.Name == "Password")
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtUserName.Text == "demo" && txtpassword.Text == "1234")
            {
                new Inicio().Show();
                this.Hide();

            }

            else
            {
                MessageBox.Show("The User name or password you entered is incorrect, try again");
                txtUserName.Clear();
                txtpassword.Clear();
                txtUserName.Focus();
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            {
                txtUserName.Clear();
                txtpassword.Clear();
                txtUserName.Focus();
            }
        }
    }
}
