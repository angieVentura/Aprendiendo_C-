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
            panelSideMenu = new Panel();
            PlayList = new FlowLayoutPanel();
            panelInfo = new Panel();
            cantidadCanciones = new Label();
            AgregarMusica = new FontAwesome.Sharp.IconButton();
            panelBuscador = new Panel();
            panelLogo = new Panel();
            panel1 = new Panel();
            panelFondo = new Panel();
            panelSideMenu.SuspendLayout();
            panelInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelSideMenu
            // 
            panelSideMenu.BackColor = Color.Transparent;
            panelSideMenu.Controls.Add(PlayList);
            panelSideMenu.Controls.Add(panelInfo);
            panelSideMenu.Controls.Add(panelBuscador);
            panelSideMenu.Controls.Add(panelLogo);
            panelSideMenu.Dock = DockStyle.Left;
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(200, 461);
            panelSideMenu.TabIndex = 0;
            // 
            // PlayList
            // 
            PlayList.CausesValidation = false;
            PlayList.Dock = DockStyle.Top;
            PlayList.Location = new Point(0, 91);
            PlayList.Name = "PlayList";
            PlayList.Size = new Size(200, 367);
            PlayList.TabIndex = 1;
            // 
            // panelInfo
            // 
            panelInfo.BackColor = SystemColors.ActiveCaptionText;
            panelInfo.Controls.Add(cantidadCanciones);
            panelInfo.Controls.Add(AgregarMusica);
            panelInfo.Dock = DockStyle.Top;
            panelInfo.Location = new Point(0, 64);
            panelInfo.Name = "panelInfo";
            panelInfo.Padding = new Padding(8, 0, 8, 0);
            panelInfo.Size = new Size(200, 27);
            panelInfo.TabIndex = 2;
            // 
            // cantidadCanciones
            // 
            cantidadCanciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cantidadCanciones.AutoSize = true;
            cantidadCanciones.ForeColor = SystemColors.Control;
            cantidadCanciones.Location = new Point(7, 6);
            cantidadCanciones.Name = "cantidadCanciones";
            cantidadCanciones.Size = new Size(0, 15);
            cantidadCanciones.TabIndex = 1;
            cantidadCanciones.TextAlign = ContentAlignment.MiddleCenter;
            cantidadCanciones.Click += cantidadCanciones_Click;
            // 
            // AgregarMusica
            // 
            AgregarMusica.Dock = DockStyle.Right;
            AgregarMusica.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            AgregarMusica.IconColor = Color.Black;
            AgregarMusica.IconFont = FontAwesome.Sharp.IconFont.Auto;
            AgregarMusica.IconSize = 24;
            AgregarMusica.Location = new Point(165, 0);
            AgregarMusica.Name = "AgregarMusica";
            AgregarMusica.Size = new Size(27, 27);
            AgregarMusica.TabIndex = 0;
            AgregarMusica.UseVisualStyleBackColor = true;
            AgregarMusica.Click += AgregarMusica_Click;
            // 
            // panelBuscador
            // 
            panelBuscador.BackColor = SystemColors.ControlDark;
            panelBuscador.Dock = DockStyle.Top;
            panelBuscador.Location = new Point(0, 30);
            panelBuscador.Name = "panelBuscador";
            panelBuscador.Size = new Size(200, 34);
            panelBuscador.TabIndex = 1;
            panelBuscador.Paint += panelBuscador_Paint;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = SystemColors.ControlDarkDark;
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(200, 30);
            panelLogo.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(200, 361);
            panel1.Name = "panel1";
            panel1.Size = new Size(584, 100);
            panel1.TabIndex = 1;
            // 
            // panelFondo
            // 
            panelFondo.BackColor = SystemColors.ActiveCaption;
            panelFondo.Dock = DockStyle.Fill;
            panelFondo.Location = new Point(200, 0);
            panelFondo.Name = "panelFondo";
            panelFondo.Size = new Size(584, 361);
            panelFondo.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(panelFondo);
            Controls.Add(panel1);
            Controls.Add(panelSideMenu);
            Name = "Form1";
            Text = "Form1";
            panelSideMenu.ResumeLayout(false);
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSideMenu;
        private FlowLayoutPanel PlayList;
        private Panel panelInfo;
        private Panel panelBuscador;
        private Panel panelLogo;
        private Panel panel1;
        private Panel panelFondo;
        private FontAwesome.Sharp.IconButton AgregarMusica;
        private Label cantidadCanciones;
    }
}