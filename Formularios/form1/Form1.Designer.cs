namespace form1_
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.CopiarTodoDer = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.boxIzq = new System.Windows.Forms.ListBox();
            this.boxDer = new System.Windows.Forms.ListBox();
            this.InputIzq = new System.Windows.Forms.TextBox();
            this.InputDer = new System.Windows.Forms.TextBox();
            this.AgregarIzq = new System.Windows.Forms.Button();
            this.AgregarDer = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(330, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "PasarDer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(330, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "CopiarTodoIzq";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(330, 195);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 39);
            this.button3.TabIndex = 2;
            this.button3.Text = "PasarIzq";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // CopiarTodoDer
            // 
            this.CopiarTodoDer.Location = new System.Drawing.Point(330, 50);
            this.CopiarTodoDer.Name = "CopiarTodoDer";
            this.CopiarTodoDer.Size = new System.Drawing.Size(146, 39);
            this.CopiarTodoDer.TabIndex = 3;
            this.CopiarTodoDer.Text = "CopiarTodoDer";
            this.CopiarTodoDer.UseVisualStyleBackColor = true;
            this.CopiarTodoDer.Click += new System.EventHandler(this.CopiarTodoDer_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // boxIzq
            // 
            this.boxIzq.FormattingEnabled = true;
            this.boxIzq.Location = new System.Drawing.Point(75, 26);
            this.boxIzq.Name = "boxIzq";
            this.boxIzq.Size = new System.Drawing.Size(183, 277);
            this.boxIzq.TabIndex = 5;
            this.boxIzq.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // boxDer
            // 
            this.boxDer.FormattingEnabled = true;
            this.boxDer.Location = new System.Drawing.Point(545, 26);
            this.boxDer.Name = "boxDer";
            this.boxDer.Size = new System.Drawing.Size(183, 277);
            this.boxDer.TabIndex = 6;
            this.boxDer.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // InputIzq
            // 
            this.InputIzq.Location = new System.Drawing.Point(75, 315);
            this.InputIzq.Name = "InputIzq";
            this.InputIzq.Size = new System.Drawing.Size(183, 20);
            this.InputIzq.TabIndex = 7;
            this.InputIzq.Click += new System.EventHandler(this.sdsfsd_Click);
            this.InputIzq.TextChanged += new System.EventHandler(this.sdsfsd_TextChanged);
            // 
            // InputDer
            // 
            this.InputDer.Location = new System.Drawing.Point(545, 315);
            this.InputDer.Name = "InputDer";
            this.InputDer.Size = new System.Drawing.Size(183, 20);
            this.InputDer.TabIndex = 8;
            // 
            // AgregarIzq
            // 
            this.AgregarIzq.Location = new System.Drawing.Point(75, 350);
            this.AgregarIzq.Name = "AgregarIzq";
            this.AgregarIzq.Size = new System.Drawing.Size(183, 44);
            this.AgregarIzq.TabIndex = 9;
            this.AgregarIzq.Text = "Agregar";
            this.AgregarIzq.UseVisualStyleBackColor = true;
            this.AgregarIzq.Click += new System.EventHandler(this.AgregarIzq_Click);
            // 
            // AgregarDer
            // 
            this.AgregarDer.Location = new System.Drawing.Point(545, 350);
            this.AgregarDer.Name = "AgregarDer";
            this.AgregarDer.Size = new System.Drawing.Size(183, 44);
            this.AgregarDer.TabIndex = 10;
            this.AgregarDer.Text = "Agregar";
            this.AgregarDer.UseVisualStyleBackColor = true;
            this.AgregarDer.Click += new System.EventHandler(this.button6_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AgregarDer);
            this.Controls.Add(this.AgregarIzq);
            this.Controls.Add(this.InputDer);
            this.Controls.Add(this.InputIzq);
            this.Controls.Add(this.boxDer);
            this.Controls.Add(this.boxIzq);
            this.Controls.Add(this.CopiarTodoDer);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button CopiarTodoDer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ListBox boxIzq;
        private System.Windows.Forms.ListBox boxDer;
        private System.Windows.Forms.TextBox InputIzq;
        private System.Windows.Forms.TextBox InputDer;
        private System.Windows.Forms.Button AgregarIzq;
        private System.Windows.Forms.Button AgregarDer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}

