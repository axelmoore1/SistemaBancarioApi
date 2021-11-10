﻿using Front;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir de la aplicación?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

       
        private void ConsultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cuentas consultar = new Cuentas();
            consultar.ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoCliente nuevo = new NuevoCliente();
            nuevo.ShowDialog();

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(    "\t INTEGRANTES:\n"+
                                "\t 112746 - Moore, Axel.\n" +
                                "\t 112988 - Ramallo, Camila.\n" +
                                "\t 113021 - Retamar, Agustin.\n" +
                                "\t 113288 - Berton, Gonzalo.\n" +
                                "\t 113160 - Ramallo, Tomas.\n" 
                            );

        }


    }
}
