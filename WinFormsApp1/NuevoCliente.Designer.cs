
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbDatosPresupuesto = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.cboCuentas = new System.Windows.Forms.ComboBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbDatosPresupuesto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(198, 383);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 28);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar ";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(609, 382);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 28);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gbDatosPresupuesto
            // 
            this.gbDatosPresupuesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.gbDatosPresupuesto.Controls.Add(this.label5);
            this.gbDatosPresupuesto.Controls.Add(this.label4);
            this.gbDatosPresupuesto.Controls.Add(this.label3);
            this.gbDatosPresupuesto.Controls.Add(this.label2);
            this.gbDatosPresupuesto.Controls.Add(this.label1);
            this.gbDatosPresupuesto.Controls.Add(this.txtNombre);
            this.gbDatosPresupuesto.Controls.Add(this.dgvDetalles);
            this.gbDatosPresupuesto.Controls.Add(this.button1);
            this.gbDatosPresupuesto.Controls.Add(this.cboCuentas);
            this.gbDatosPresupuesto.Controls.Add(this.txtFecha);
            this.gbDatosPresupuesto.Controls.Add(this.txtDni);
            this.gbDatosPresupuesto.Controls.Add(this.txtApellido);
            this.gbDatosPresupuesto.Location = new System.Drawing.Point(2, 3);
            this.gbDatosPresupuesto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbDatosPresupuesto.Name = "gbDatosPresupuesto";
            this.gbDatosPresupuesto.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbDatosPresupuesto.Size = new System.Drawing.Size(694, 379);
            this.gbDatosPresupuesto.TabIndex = 18;
            this.gbDatosPresupuesto.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "Tipo Cuenta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "DNI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(196, 19);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(159, 23);
            this.txtNombre.TabIndex = 24;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.Gray;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detalle,
            this.Nombre,
            this.Apellido,
            this.DNI,
            this.Fecha,
            this.acciones});
            this.dgvDetalles.GridColor = System.Drawing.Color.White;
            this.dgvDetalles.Location = new System.Drawing.Point(15, 201);
            this.dgvDetalles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersWidth = 51;
            this.dgvDetalles.Size = new System.Drawing.Size(679, 173);
            this.dgvDetalles.TabIndex = 23;
            // 
            // detalle
            // 
            this.detalle.HeaderText = "Column1";
            this.detalle.MinimumWidth = 6;
            this.detalle.Name = "detalle";
            this.detalle.ReadOnly = true;
            this.detalle.Visible = false;
            this.detalle.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 125;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MinimumWidth = 6;
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 125;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.MinimumWidth = 6;
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            this.DNI.Width = 125;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 125;
            // 
            // acciones
            // 
            this.acciones.HeaderText = "Acciones";
            this.acciones.MinimumWidth = 6;
            this.acciones.Name = "acciones";
            this.acciones.ReadOnly = true;
            this.acciones.Text = "Quitar";
            this.acciones.UseColumnTextForButtonValue = true;
            this.acciones.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(462, 158);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 27);
            this.button1.TabIndex = 22;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cboCuentas
            // 
            this.cboCuentas.FormattingEnabled = true;
            this.cboCuentas.Location = new System.Drawing.Point(196, 158);
            this.cboCuentas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboCuentas.Name = "cboCuentas";
            this.cboCuentas.Size = new System.Drawing.Size(248, 23);
            this.cboCuentas.TabIndex = 21;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(196, 108);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(159, 23);
            this.txtFecha.TabIndex = 20;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(196, 78);
            this.txtDni.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(361, 23);
            this.txtDni.TabIndex = 18;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(196, 48);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(159, 23);
            this.txtApellido.TabIndex = 16;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(358, 383);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 27);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(700, 422);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbDatosPresupuesto);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAgregar);
            this.Name = "Form1";
            this.Text = "Nuevo Cliente";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbDatosPresupuesto.ResumeLayout(false);
            this.gbDatosPresupuesto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbDatosPresupuesto;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboCuentas;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewButtonColumn acciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}

