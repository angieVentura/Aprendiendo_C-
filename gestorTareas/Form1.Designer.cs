namespace gestorTareas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listTareas = new System.Windows.Forms.ListBox();
            this.tituloAgregar = new System.Windows.Forms.TextBox();
            this.agregar = new System.Windows.Forms.Button();
            this.eliminar = new System.Windows.Forms.Button();
            this.Editar = new System.Windows.Forms.Button();
            this.textAgregar = new System.Windows.Forms.TextBox();
            this.textEditar = new System.Windows.Forms.TextBox();
            this.tituloEditar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listTareas
            // 
            this.listTareas.FormattingEnabled = true;
            this.listTareas.Location = new System.Drawing.Point(12, 83);
            this.listTareas.Name = "listTareas";
            this.listTareas.Size = new System.Drawing.Size(203, 355);
            this.listTareas.TabIndex = 0;
            this.listTareas.SelectedIndexChanged += new System.EventHandler(this.listTareas_SelectedIndexChanged);
            // 
            // tituloAgregar
            // 
            this.tituloAgregar.Location = new System.Drawing.Point(230, 83);
            this.tituloAgregar.Name = "tituloAgregar";
            this.tituloAgregar.Size = new System.Drawing.Size(157, 20);
            this.tituloAgregar.TabIndex = 1;
            // 
            // agregar
            // 
            this.agregar.Location = new System.Drawing.Point(231, 415);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(75, 23);
            this.agregar.TabIndex = 2;
            this.agregar.Text = "agregar";
            this.agregar.UseVisualStyleBackColor = true;
            this.agregar.Click += new System.EventHandler(this.agregar_Click);
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(312, 415);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(75, 23);
            this.eliminar.TabIndex = 3;
            this.eliminar.Text = "Eliminar";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // Editar
            // 
            this.Editar.Location = new System.Drawing.Point(494, 415);
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(75, 23);
            this.Editar.TabIndex = 4;
            this.Editar.Text = "Editar";
            this.Editar.UseVisualStyleBackColor = true;
            // 
            // textAgregar
            // 
            this.textAgregar.Location = new System.Drawing.Point(231, 118);
            this.textAgregar.Multiline = true;
            this.textAgregar.Name = "textAgregar";
            this.textAgregar.Size = new System.Drawing.Size(157, 291);
            this.textAgregar.TabIndex = 5;
            // 
            // textEditar
            // 
            this.textEditar.Location = new System.Drawing.Point(413, 118);
            this.textEditar.Multiline = true;
            this.textEditar.Name = "textEditar";
            this.textEditar.Size = new System.Drawing.Size(157, 291);
            this.textEditar.TabIndex = 7;
            // 
            // tituloEditar
            // 
            this.tituloEditar.Location = new System.Drawing.Point(412, 83);
            this.tituloEditar.Name = "tituloEditar";
            this.tituloEditar.Size = new System.Drawing.Size(157, 20);
            this.tituloEditar.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 450);
            this.Controls.Add(this.textEditar);
            this.Controls.Add(this.tituloEditar);
            this.Controls.Add(this.textAgregar);
            this.Controls.Add(this.Editar);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.agregar);
            this.Controls.Add(this.tituloAgregar);
            this.Controls.Add(this.listTareas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listTareas;
        private System.Windows.Forms.TextBox tituloAgregar;
        private System.Windows.Forms.Button agregar;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.Button Editar;
        private System.Windows.Forms.TextBox textAgregar;
        private System.Windows.Forms.TextBox textEditar;
        private System.Windows.Forms.TextBox tituloEditar;
    }
}

