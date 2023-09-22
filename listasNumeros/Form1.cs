using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listasNumeros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonIzq_Click(object sender, EventArgs e)
        {
            if (textBoxIzq.Text != "")
            {
            listBoxIzq.Items.Add(textBoxIzq.Text);
            textBoxIzq.Text = "";
            }
        }

        private void btnDer_Click(object sender, EventArgs e)
        {
            if (textBoxDer.Text != "")
            {
            listBoxDer.Items.Add(textBoxDer.Text);
            textBoxDer.Text = "";
            }
  
        }

        private void unoDer_Click(object sender, EventArgs e)
        {
            if (listBoxIzq.Items.Count > 0)
            {
                string text = listBoxIzq.Items[0].ToString();
                listBoxIzq.Items.RemoveAt(0);
                listBoxDer.Items.Add(text);
                DialogResult r = MessageBox.Show("Se paso un numero a la derecha", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            
        }

        private void unoIzq_Click(object sender, EventArgs e)
        {
            if (listBoxDer.Items.Count > 0)
            {
                string text = listBoxDer.Items[0].ToString();
                listBoxDer.Items.RemoveAt(0);
                listBoxIzq.Items.Add(text);
                DialogResult r = MessageBox.Show("Se paso un numero", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }

        private void todoDer_Click(object sender, EventArgs e)
        {
            if (listBoxIzq.Items.Count > 0)
            {
                int numL = listBoxIzq.Items.Count;
                for (int i = 0; i < numL ; i++)
                {
                    string text = listBoxIzq.Items[0].ToString();
                    listBoxIzq.Items.RemoveAt(0);
                    listBoxDer.Items.Add(text);
                }
            }
        }

        private void todoIzq_Click(object sender, EventArgs e)
        {
            if (listBoxDer.Items.Count > 0)
            {
                int numL = listBoxDer.Items.Count;
                for (int i = 0; i < numL; i++)
                {
                    string text = listBoxDer.Items[0].ToString();
                    listBoxDer.Items.RemoveAt(0);
                    listBoxIzq.Items.Add(text);
                }
            }
        }
    }
}
