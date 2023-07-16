namespace WindowsFormsApp1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.porcentaje = new System.Windows.Forms.Label();
            this.Eliminar = new System.Windows.Forms.Button();
            this.btnMenos = new System.Windows.Forms.Button();
            this.btnMas = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rotar = new System.Windows.Forms.Button();
            this.pictureImg = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureImg);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 409);
            this.panel1.TabIndex = 22;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(28, 12);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(75, 23);
            this.btnAbrir.TabIndex = 26;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click_2);
            // 
            // porcentaje
            // 
            this.porcentaje.AutoSize = true;
            this.porcentaje.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.porcentaje.Location = new System.Drawing.Point(747, 17);
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.Size = new System.Drawing.Size(0, 13);
            this.porcentaje.TabIndex = 25;
            // 
            // Eliminar
            // 
            this.Eliminar.BackColor = System.Drawing.Color.Transparent;
            this.Eliminar.Location = new System.Drawing.Point(109, 12);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(75, 23);
            this.Eliminar.TabIndex = 22;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = false;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // btnMenos
            // 
            this.btnMenos.Location = new System.Drawing.Point(716, 12);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(25, 23);
            this.btnMenos.TabIndex = 24;
            this.btnMenos.Text = "-";
            this.btnMenos.UseVisualStyleBackColor = true;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click_1);
            // 
            // btnMas
            // 
            this.btnMas.Location = new System.Drawing.Point(685, 12);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(25, 23);
            this.btnMas.TabIndex = 23;
            this.btnMas.Text = "+";
            this.btnMas.UseVisualStyleBackColor = true;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(658, 41);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(132, 377);
            this.flowLayoutPanel1.TabIndex = 28;
            // 
            // rotar
            // 
            this.rotar.BackColor = System.Drawing.Color.Transparent;
            this.rotar.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.pngwing_com__1_;
            this.rotar.Image = global::WindowsFormsApp1.Properties.Resources.pngwing1;
            this.rotar.Location = new System.Drawing.Point(654, 12);
            this.rotar.Name = "rotar";
            this.rotar.Size = new System.Drawing.Size(25, 23);
            this.rotar.TabIndex = 29;
            this.rotar.Text = "⟲";
            this.rotar.UseVisualStyleBackColor = false;
            this.rotar.Click += new System.EventHandler(this.rotar_Click);
            // 
            // pictureImg
            // 
            this.pictureImg.BackColor = System.Drawing.Color.Transparent;
            this.pictureImg.Location = new System.Drawing.Point(34, 29);
            this.pictureImg.Name = "pictureImg";
            this.pictureImg.Size = new System.Drawing.Size(554, 348);
            this.pictureImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureImg.TabIndex = 28;
            this.pictureImg.TabStop = false;
            this.pictureImg.Click += new System.EventHandler(this.pictureImg_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rotar);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.porcentaje);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnMas);
            this.Controls.Add(this.btnMenos);
            this.Controls.Add(this.Eliminar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Label porcentaje;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.Button btnMas;
        private System.Windows.Forms.PictureBox pictureImg;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button rotar;
    }
}

