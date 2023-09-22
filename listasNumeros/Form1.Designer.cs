namespace listasNumeros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBoxIzq = new System.Windows.Forms.ListBox();
            this.listBoxDer = new System.Windows.Forms.ListBox();
            this.textBoxDer = new System.Windows.Forms.TextBox();
            this.textBoxIzq = new System.Windows.Forms.TextBox();
            this.buttonIzq = new System.Windows.Forms.Button();
            this.btnDer = new System.Windows.Forms.Button();
            this.unoDer = new System.Windows.Forms.Button();
            this.todoDer = new System.Windows.Forms.Button();
            this.todoIzq = new System.Windows.Forms.Button();
            this.unoIzq = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxIzq
            // 
            this.listBoxIzq.FormattingEnabled = true;
            this.listBoxIzq.Location = new System.Drawing.Point(132, 55);
            this.listBoxIzq.Name = "listBoxIzq";
            this.listBoxIzq.Size = new System.Drawing.Size(167, 355);
            this.listBoxIzq.TabIndex = 0;
            // 
            // listBoxDer
            // 
            this.listBoxDer.FormattingEnabled = true;
            this.listBoxDer.Location = new System.Drawing.Point(515, 55);
            this.listBoxDer.Name = "listBoxDer";
            this.listBoxDer.Size = new System.Drawing.Size(167, 355);
            this.listBoxDer.TabIndex = 1;
            // 
            // textBoxDer
            // 
            this.textBoxDer.Location = new System.Drawing.Point(516, 419);
            this.textBoxDer.Name = "textBoxDer";
            this.textBoxDer.Size = new System.Drawing.Size(124, 20);
            this.textBoxDer.TabIndex = 2;
            // 
            // textBoxIzq
            // 
            this.textBoxIzq.Location = new System.Drawing.Point(132, 419);
            this.textBoxIzq.Name = "textBoxIzq";
            this.textBoxIzq.Size = new System.Drawing.Size(124, 20);
            this.textBoxIzq.TabIndex = 3;
            // 
            // buttonIzq
            // 
            this.buttonIzq.Location = new System.Drawing.Point(262, 417);
            this.buttonIzq.Name = "buttonIzq";
            this.buttonIzq.Size = new System.Drawing.Size(36, 23);
            this.buttonIzq.TabIndex = 4;
            this.buttonIzq.Text = "+";
            this.buttonIzq.UseVisualStyleBackColor = true;
            this.buttonIzq.Click += new System.EventHandler(this.buttonIzq_Click);
            // 
            // btnDer
            // 
            this.btnDer.Location = new System.Drawing.Point(646, 417);
            this.btnDer.Name = "btnDer";
            this.btnDer.Size = new System.Drawing.Size(36, 23);
            this.btnDer.TabIndex = 5;
            this.btnDer.Text = "+";
            this.btnDer.UseVisualStyleBackColor = true;
            this.btnDer.Click += new System.EventHandler(this.btnDer_Click);
            // 
            // unoDer
            // 
            this.unoDer.Location = new System.Drawing.Point(359, 73);
            this.unoDer.Name = "unoDer";
            this.unoDer.Size = new System.Drawing.Size(90, 35);
            this.unoDer.TabIndex = 6;
            this.unoDer.Text = ">";
            this.unoDer.UseVisualStyleBackColor = true;
            this.unoDer.Click += new System.EventHandler(this.unoDer_Click);
            // 
            // todoDer
            // 
            this.todoDer.Location = new System.Drawing.Point(359, 130);
            this.todoDer.Name = "todoDer";
            this.todoDer.Size = new System.Drawing.Size(90, 35);
            this.todoDer.TabIndex = 7;
            this.todoDer.Text = ">>";
            this.todoDer.UseVisualStyleBackColor = true;
            this.todoDer.Click += new System.EventHandler(this.todoDer_Click);
            // 
            // todoIzq
            // 
            this.todoIzq.Location = new System.Drawing.Point(359, 375);
            this.todoIzq.Name = "todoIzq";
            this.todoIzq.Size = new System.Drawing.Size(90, 35);
            this.todoIzq.TabIndex = 8;
            this.todoIzq.Text = "<<";
            this.todoIzq.UseVisualStyleBackColor = true;
            this.todoIzq.Click += new System.EventHandler(this.todoIzq_Click);
            // 
            // unoIzq
            // 
            this.unoIzq.Location = new System.Drawing.Point(359, 319);
            this.unoIzq.Name = "unoIzq";
            this.unoIzq.Size = new System.Drawing.Size(90, 35);
            this.unoIzq.TabIndex = 9;
            this.unoIzq.Text = "<";
            this.unoIzq.UseVisualStyleBackColor = true;
            this.unoIzq.Click += new System.EventHandler(this.unoIzq_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.unoIzq);
            this.Controls.Add(this.todoIzq);
            this.Controls.Add(this.todoDer);
            this.Controls.Add(this.unoDer);
            this.Controls.Add(this.btnDer);
            this.Controls.Add(this.buttonIzq);
            this.Controls.Add(this.textBoxIzq);
            this.Controls.Add(this.textBoxDer);
            this.Controls.Add(this.listBoxDer);
            this.Controls.Add(this.listBoxIzq);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxIzq;
        private System.Windows.Forms.ListBox listBoxDer;
        private System.Windows.Forms.TextBox textBoxDer;
        private System.Windows.Forms.TextBox textBoxIzq;
        private System.Windows.Forms.Button buttonIzq;
        private System.Windows.Forms.Button btnDer;
        private System.Windows.Forms.Button unoDer;
        private System.Windows.Forms.Button todoDer;
        private System.Windows.Forms.Button todoIzq;
        private System.Windows.Forms.Button unoIzq;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
    }
}

