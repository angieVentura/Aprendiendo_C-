namespace prueba06._10._23
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
            this.ordenar = new System.Windows.Forms.Button();
            this.borrar = new System.Windows.Forms.Button();
            this.intercambiar = new System.Windows.Forms.Button();
            this.interPrimeroUltimo = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ordenar
            // 
            this.ordenar.Location = new System.Drawing.Point(346, 118);
            this.ordenar.Name = "ordenar";
            this.ordenar.Size = new System.Drawing.Size(75, 23);
            this.ordenar.TabIndex = 0;
            this.ordenar.Text = "Ordenar";
            this.ordenar.UseVisualStyleBackColor = true;
            this.ordenar.Click += new System.EventHandler(this.ordenar_Click);
            // 
            // borrar
            // 
            this.borrar.Location = new System.Drawing.Point(346, 174);
            this.borrar.Name = "borrar";
            this.borrar.Size = new System.Drawing.Size(75, 23);
            this.borrar.TabIndex = 1;
            this.borrar.Text = "Borrar";
            this.borrar.UseVisualStyleBackColor = true;
            this.borrar.Click += new System.EventHandler(this.borrar_Click);
            // 
            // intercambiar
            // 
            this.intercambiar.Location = new System.Drawing.Point(346, 232);
            this.intercambiar.Name = "intercambiar";
            this.intercambiar.Size = new System.Drawing.Size(75, 23);
            this.intercambiar.TabIndex = 2;
            this.intercambiar.Text = "Intercambiar";
            this.intercambiar.UseVisualStyleBackColor = true;
            this.intercambiar.Click += new System.EventHandler(this.intercambiar_Click);
            // 
            // interPrimeroUltimo
            // 
            this.interPrimeroUltimo.Location = new System.Drawing.Point(346, 288);
            this.interPrimeroUltimo.Name = "interPrimeroUltimo";
            this.interPrimeroUltimo.Size = new System.Drawing.Size(75, 23);
            this.interPrimeroUltimo.TabIndex = 3;
            this.interPrimeroUltimo.Text = "Pri y ulti";
            this.interPrimeroUltimo.UseVisualStyleBackColor = true;
            this.interPrimeroUltimo.Click += new System.EventHandler(this.interPrimeroUltimo_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(61, 56);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(202, 329);
            this.listBox1.TabIndex = 4;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(513, 56);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(202, 329);
            this.listBox2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.interPrimeroUltimo);
            this.Controls.Add(this.intercambiar);
            this.Controls.Add(this.borrar);
            this.Controls.Add(this.ordenar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ordenar;
        private System.Windows.Forms.Button borrar;
        private System.Windows.Forms.Button intercambiar;
        private System.Windows.Forms.Button interPrimeroUltimo;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label1;
    }
}

