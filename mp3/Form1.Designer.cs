namespace mp3
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
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.PlayList = new System.Windows.Forms.FlowLayoutPanel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.AgregarMusica = new FontAwesome.Sharp.IconButton();
            this.cantidadCanciones = new System.Windows.Forms.Label();
            this.panelBuscador = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelFondo = new System.Windows.Forms.Panel();
            this.tituloCancion = new System.Windows.Forms.Label();
            this.cover = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.contenedorTitulo = new System.Windows.Forms.PictureBox();
            this.Play = new FontAwesome.Sharp.IconButton();
            this.panelSideMenu.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contenedorTitulo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelSideMenu.Controls.Add(this.PlayList);
            this.panelSideMenu.Controls.Add(this.panelInfo);
            this.panelSideMenu.Controls.Add(this.panelBuscador);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(215, 461);
            this.panelSideMenu.TabIndex = 0;
            // 
            // PlayList
            // 
            this.PlayList.AutoScroll = true;
            this.PlayList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayList.Location = new System.Drawing.Point(0, 92);
            this.PlayList.Name = "PlayList";
            this.PlayList.Size = new System.Drawing.Size(215, 369);
            this.PlayList.TabIndex = 0;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelInfo.Controls.Add(this.AgregarMusica);
            this.panelInfo.Controls.Add(this.cantidadCanciones);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 64);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.panelInfo.Size = new System.Drawing.Size(215, 28);
            this.panelInfo.TabIndex = 2;
            // 
            // AgregarMusica
            // 
            this.AgregarMusica.Dock = System.Windows.Forms.DockStyle.Right;
            this.AgregarMusica.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.AgregarMusica.IconColor = System.Drawing.Color.Black;
            this.AgregarMusica.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.AgregarMusica.IconSize = 24;
            this.AgregarMusica.Location = new System.Drawing.Point(180, 0);
            this.AgregarMusica.Name = "AgregarMusica";
            this.AgregarMusica.Size = new System.Drawing.Size(27, 28);
            this.AgregarMusica.TabIndex = 2;
            this.AgregarMusica.UseVisualStyleBackColor = true;
            this.AgregarMusica.Click += new System.EventHandler(this.AgregarMusica_Click_1);
            // 
            // cantidadCanciones
            // 
            this.cantidadCanciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cantidadCanciones.AutoSize = true;
            this.cantidadCanciones.ForeColor = System.Drawing.SystemColors.Control;
            this.cantidadCanciones.Location = new System.Drawing.Point(7, 6);
            this.cantidadCanciones.Name = "cantidadCanciones";
            this.cantidadCanciones.Size = new System.Drawing.Size(0, 15);
            this.cantidadCanciones.TabIndex = 1;
            this.cantidadCanciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBuscador
            // 
            this.panelBuscador.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelBuscador.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBuscador.Location = new System.Drawing.Point(0, 30);
            this.panelBuscador.Name = "panelBuscador";
            this.panelBuscador.Size = new System.Drawing.Size(215, 34);
            this.panelBuscador.TabIndex = 1;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(215, 30);
            this.panelLogo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.Play);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(215, 365);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 96);
            this.panel1.TabIndex = 1;
            // 
            // panelFondo
            // 
            this.panelFondo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelFondo.Controls.Add(this.tituloCancion);
            this.panelFondo.Controls.Add(this.cover);
            this.panelFondo.Controls.Add(this.pictureBox3);
            this.panelFondo.Controls.Add(this.pictureBox4);
            this.panelFondo.Controls.Add(this.pictureBox2);
            this.panelFondo.Controls.Add(this.contenedorTitulo);
            this.panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFondo.Location = new System.Drawing.Point(215, 0);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Size = new System.Drawing.Size(569, 365);
            this.panelFondo.TabIndex = 2;
            // 
            // tituloCancion
            // 
            this.tituloCancion.AutoEllipsis = true;
            this.tituloCancion.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tituloCancion.ForeColor = System.Drawing.Color.White;
            this.tituloCancion.Location = new System.Drawing.Point(60, 322);
            this.tituloCancion.MaximumSize = new System.Drawing.Size(450, 0);
            this.tituloCancion.Name = "tituloCancion";
            this.tituloCancion.Size = new System.Drawing.Size(450, 29);
            this.tituloCancion.TabIndex = 7;
            this.tituloCancion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cover
            // 
            this.cover.BackColor = System.Drawing.Color.Red;
            this.cover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cover.Location = new System.Drawing.Point(144, 30);
            this.cover.MaximumSize = new System.Drawing.Size(480, 480);
            this.cover.MinimumSize = new System.Drawing.Size(280, 280);
            this.cover.Name = "cover";
            this.cover.Size = new System.Drawing.Size(280, 280);
            this.cover.TabIndex = 6;
            this.cover.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox3.Location = new System.Drawing.Point(0, 30);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(144, 280);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox4.Location = new System.Drawing.Point(424, 30);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(145, 280);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(569, 30);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // contenedorTitulo
            // 
            this.contenedorTitulo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.contenedorTitulo.Location = new System.Drawing.Point(0, 310);
            this.contenedorTitulo.MaximumSize = new System.Drawing.Size(0, 58);
            this.contenedorTitulo.MinimumSize = new System.Drawing.Size(569, 10);
            this.contenedorTitulo.Name = "contenedorTitulo";
            this.contenedorTitulo.Size = new System.Drawing.Size(569, 55);
            this.contenedorTitulo.TabIndex = 0;
            this.contenedorTitulo.TabStop = false;
            // 
            // Play
            // 
            this.Play.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Play.IconColor = System.Drawing.Color.Black;
            this.Play.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Play.Location = new System.Drawing.Point(236, 32);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(75, 23);
            this.Play.TabIndex = 0;
            this.Play.Text = "play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panelFondo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSideMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelSideMenu.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contenedorTitulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelSideMenu;
        private Panel panelInfo;
        private Panel panelBuscador;
        private Panel panelLogo;
        private Panel panel1;
        private Panel panelFondo;
        private Label cantidadCanciones;
        private FlowLayoutPanel PlayList;
        private FontAwesome.Sharp.IconButton AgregarMusica;
        private PictureBox pictureBox4;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox cover;
        private PictureBox contenedorTitulo;
        private Label tituloCancion;
        private FontAwesome.Sharp.IconButton Play;
    }
}