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
            this.panelSideMenu.SuspendLayout();
            this.panelInfo.SuspendLayout();
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
            this.panelSideMenu.Size = new System.Drawing.Size(211, 461);
            this.panelSideMenu.TabIndex = 0;
            // 
            // PlayList
            // 
            this.PlayList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayList.AutoScroll = true;
            this.PlayList.Location = new System.Drawing.Point(0, 92);
            this.PlayList.Name = "PlayList";
            this.PlayList.Size = new System.Drawing.Size(211, 369);
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
            this.panelInfo.Size = new System.Drawing.Size(211, 28);
            this.panelInfo.TabIndex = 2;
            // 
            // AgregarMusica
            // 
            this.AgregarMusica.Dock = System.Windows.Forms.DockStyle.Right;
            this.AgregarMusica.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.AgregarMusica.IconColor = System.Drawing.Color.Black;
            this.AgregarMusica.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.AgregarMusica.IconSize = 24;
            this.AgregarMusica.Location = new System.Drawing.Point(176, 0);
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
            this.panelBuscador.Size = new System.Drawing.Size(211, 34);
            this.panelBuscador.TabIndex = 1;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(211, 30);
            this.panelLogo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(211, 361);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 100);
            this.panel1.TabIndex = 1;
            // 
            // panelFondo
            // 
            this.panelFondo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFondo.Location = new System.Drawing.Point(211, 0);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Size = new System.Drawing.Size(573, 361);
            this.panelFondo.TabIndex = 2;
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
    }
}