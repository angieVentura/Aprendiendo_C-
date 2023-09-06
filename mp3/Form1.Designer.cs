namespace mp3
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
            this.components = new System.ComponentModel.Container();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.PlayListFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.cantidadCanciones = new System.Windows.Forms.Label();
            this.AgregarMusica = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelFondo = new System.Windows.Forms.Panel();
            this.cover = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.contenedorTitulo = new System.Windows.Forms.Panel();
            this.tituloCancion = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tiempoCancion = new System.Windows.Forms.Label();
            this.trackBarTiempo = new Ce_TrackBar();
            this.reproductorEstado = new System.Windows.Forms.TextBox();
            this.Play = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timerActualizarTiempo = new System.Windows.Forms.Timer(this.components);
            this.duracionTotal = new System.Windows.Forms.Label();
            this.siguienteCancion = new System.Windows.Forms.Button();
            this.cancionAnterior = new System.Windows.Forms.Button();
            this.aleatorio = new System.Windows.Forms.Button();
            this.bucle = new System.Windows.Forms.Button();
            this.panelSideMenu.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).BeginInit();
            this.contenedorTitulo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.Controls.Add(this.PlayListFlow);
            this.panelSideMenu.Controls.Add(this.panelInfo);
            this.panelSideMenu.Controls.Add(this.panel1);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(215, 504);
            this.panelSideMenu.TabIndex = 0;
            // 
            // PlayListFlow
            // 
            this.PlayListFlow.AutoScroll = true;
            this.PlayListFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayListFlow.Location = new System.Drawing.Point(0, 139);
            this.PlayListFlow.Name = "PlayListFlow";
            this.PlayListFlow.Size = new System.Drawing.Size(215, 365);
            this.PlayListFlow.TabIndex = 0;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panelInfo.Controls.Add(this.cantidadCanciones);
            this.panelInfo.Controls.Add(this.AgregarMusica);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 108);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.panelInfo.Size = new System.Drawing.Size(215, 31);
            this.panelInfo.TabIndex = 0;
            // 
            // cantidadCanciones
            // 
            this.cantidadCanciones.AutoSize = true;
            this.cantidadCanciones.Location = new System.Drawing.Point(11, 9);
            this.cantidadCanciones.Name = "cantidadCanciones";
            this.cantidadCanciones.Size = new System.Drawing.Size(0, 13);
            this.cantidadCanciones.TabIndex = 1;
            // 
            // AgregarMusica
            // 
            this.AgregarMusica.BackgroundImage = global::mp3.Properties.Resources.DefaultImage;
            this.AgregarMusica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AgregarMusica.Dock = System.Windows.Forms.DockStyle.Right;
            this.AgregarMusica.Location = new System.Drawing.Point(176, 0);
            this.AgregarMusica.Name = "AgregarMusica";
            this.AgregarMusica.Size = new System.Drawing.Size(31, 31);
            this.AgregarMusica.TabIndex = 0;
            this.AgregarMusica.Text = "+";
            this.AgregarMusica.UseVisualStyleBackColor = true;
            this.AgregarMusica.Click += new System.EventHandler(this.AgregarMusica_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 43);
            this.panel1.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(215, 65);
            this.panelLogo.TabIndex = 0;
            // 
            // panelFondo
            // 
            this.panelFondo.Controls.Add(this.cover);
            this.panelFondo.Controls.Add(this.panel5);
            this.panelFondo.Controls.Add(this.panel4);
            this.panelFondo.Controls.Add(this.contenedorTitulo);
            this.panelFondo.Controls.Add(this.panel3);
            this.panelFondo.Controls.Add(this.panel2);
            this.panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFondo.Location = new System.Drawing.Point(215, 0);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Size = new System.Drawing.Size(585, 504);
            this.panelFondo.TabIndex = 1;
            // 
            // cover
            // 
            this.cover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cover.ErrorImage = null;
            this.cover.Location = new System.Drawing.Point(134, 46);
            this.cover.Name = "cover";
            this.cover.Size = new System.Drawing.Size(316, 304);
            this.cover.TabIndex = 5;
            this.cover.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(450, 46);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(135, 304);
            this.panel5.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(134, 304);
            this.panel4.TabIndex = 3;
            // 
            // contenedorTitulo
            // 
            this.contenedorTitulo.Controls.Add(this.tituloCancion);
            this.contenedorTitulo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.contenedorTitulo.Location = new System.Drawing.Point(0, 350);
            this.contenedorTitulo.Name = "contenedorTitulo";
            this.contenedorTitulo.Size = new System.Drawing.Size(585, 58);
            this.contenedorTitulo.TabIndex = 2;
            // 
            // tituloCancion
            // 
            this.tituloCancion.AutoEllipsis = true;
            this.tituloCancion.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.tituloCancion.Location = new System.Drawing.Point(69, 3);
            this.tituloCancion.MinimumSize = new System.Drawing.Size(450, 0);
            this.tituloCancion.Name = "tituloCancion";
            this.tituloCancion.Size = new System.Drawing.Size(450, 52);
            this.tituloCancion.TabIndex = 0;
            this.tituloCancion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.bucle);
            this.panel3.Controls.Add(this.aleatorio);
            this.panel3.Controls.Add(this.cancionAnterior);
            this.panel3.Controls.Add(this.siguienteCancion);
            this.panel3.Controls.Add(this.duracionTotal);
            this.panel3.Controls.Add(this.tiempoCancion);
            this.panel3.Controls.Add(this.trackBarTiempo);
            this.panel3.Controls.Add(this.Play);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 408);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 96);
            this.panel3.TabIndex = 1;
            // 
            // tiempoCancion
            // 
            this.tiempoCancion.AutoSize = true;
            this.tiempoCancion.Location = new System.Drawing.Point(26, 66);
            this.tiempoCancion.Name = "tiempoCancion";
            this.tiempoCancion.Size = new System.Drawing.Size(34, 13);
            this.tiempoCancion.TabIndex = 3;
            this.tiempoCancion.Text = "00:00";
            // 
            // trackBarTiempo
            // 
            this.trackBarTiempo.AllowDrop = true;
            this.trackBarTiempo.BallColor = System.Drawing.Color.MidnightBlue;
            this.trackBarTiempo.JumpToMouse = true;
            this.trackBarTiempo.Location = new System.Drawing.Point(74, 62);
            this.trackBarTiempo.Maximum = 100;
            this.trackBarTiempo.Minimum = 0;
            this.trackBarTiempo.MinimumSize = new System.Drawing.Size(47, 22);
            this.trackBarTiempo.Name = "trackBarTiempo";
            this.trackBarTiempo.Size = new System.Drawing.Size(445, 22);
            this.trackBarTiempo.SlideColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(62)))), ((int)(((byte)(254)))));
            this.trackBarTiempo.TabIndex = 2;
            this.trackBarTiempo.Text = "ce_TrackBar1";
            this.trackBarTiempo.Value = 0;
            this.trackBarTiempo.ValueDivison = Ce_TrackBar.ValueDivisor.By100;
            this.trackBarTiempo.ValueToSet = 0F;
            this.trackBarTiempo.ValueChanged += new Ce_TrackBar.ValueChangedEventHandler(this.ce_TrackBar1_ValueChanged);
            this.trackBarTiempo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTiempo_MouseDown);
            this.trackBarTiempo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackBarTiempo_MouseMove);
            this.trackBarTiempo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarTiempo_MouseUp);
            // 
            // reproductorEstado
            // 
            this.reproductorEstado.Location = new System.Drawing.Point(0, 0);
            this.reproductorEstado.Name = "reproductorEstado";
            this.reproductorEstado.Size = new System.Drawing.Size(585, 20);
            this.reproductorEstado.TabIndex = 1;
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(278, 21);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(42, 35);
            this.Play.TabIndex = 0;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reproductorEstado);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 46);
            this.panel2.TabIndex = 0;
            // 
            // timerActualizarTiempo
            // 
            this.timerActualizarTiempo.Enabled = true;
            this.timerActualizarTiempo.Interval = 1000;
            this.timerActualizarTiempo.Tick += new System.EventHandler(this.timerActualizarTiempo_Tick);
            // 
            // duracionTotal
            // 
            this.duracionTotal.AutoSize = true;
            this.duracionTotal.Location = new System.Drawing.Point(525, 66);
            this.duracionTotal.Name = "duracionTotal";
            this.duracionTotal.Size = new System.Drawing.Size(29, 13);
            this.duracionTotal.TabIndex = 4;
            this.duracionTotal.Text = "Final";
            // 
            // siguienteCancion
            // 
            this.siguienteCancion.Location = new System.Drawing.Point(326, 26);
            this.siguienteCancion.Name = "siguienteCancion";
            this.siguienteCancion.Size = new System.Drawing.Size(26, 24);
            this.siguienteCancion.TabIndex = 5;
            this.siguienteCancion.Text = ">";
            this.siguienteCancion.UseVisualStyleBackColor = true;
            // 
            // cancionAnterior
            // 
            this.cancionAnterior.Location = new System.Drawing.Point(249, 27);
            this.cancionAnterior.Name = "cancionAnterior";
            this.cancionAnterior.Size = new System.Drawing.Size(23, 23);
            this.cancionAnterior.TabIndex = 6;
            this.cancionAnterior.Text = "<";
            this.cancionAnterior.UseVisualStyleBackColor = true;
            // 
            // aleatorio
            // 
            this.aleatorio.Location = new System.Drawing.Point(219, 27);
            this.aleatorio.Name = "aleatorio";
            this.aleatorio.Size = new System.Drawing.Size(24, 23);
            this.aleatorio.TabIndex = 7;
            this.aleatorio.Text = "x";
            this.aleatorio.UseVisualStyleBackColor = true;
            // 
            // bucle
            // 
            this.bucle.Location = new System.Drawing.Point(358, 27);
            this.bucle.Name = "bucle";
            this.bucle.Size = new System.Drawing.Size(26, 24);
            this.bucle.TabIndex = 8;
            this.bucle.Text = "O";
            this.bucle.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 504);
            this.Controls.Add(this.panelFondo);
            this.Controls.Add(this.panelSideMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cover)).EndInit();
            this.contenedorTitulo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.FlowLayoutPanel PlayListFlow;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Button AgregarMusica;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelFondo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel contenedorTitulo;
        private System.Windows.Forms.Label tituloCancion;
        private System.Windows.Forms.TextBox reproductorEstado;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Label cantidadCanciones;
        private System.Windows.Forms.PictureBox cover;
        private Ce_TrackBar trackBarTiempo;
        private System.Windows.Forms.Label tiempoCancion;
        private System.Windows.Forms.Timer timerActualizarTiempo;
        private System.Windows.Forms.Label duracionTotal;
        private System.Windows.Forms.Button bucle;
        private System.Windows.Forms.Button aleatorio;
        private System.Windows.Forms.Button cancionAnterior;
        private System.Windows.Forms.Button siguienteCancion;
    }
}

