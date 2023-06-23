using System;
using System.Windows.Forms;

namespace form1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (InputDer.Text != "")
            {
                boxDer.Items.Add(InputDer.Text);
                InputDer.Clear();
            }
        }

        private void sdsfsd_TextChanged(object sender, EventArgs e)
        {

        }

        private void sdsfsd_Click(object sender, EventArgs e)
        {

        }

        private void AgregarIzq_Click(object sender, EventArgs e)
        {
            if (InputIzq.Text != "")
            {
                boxIzq.Items.Add(InputIzq.Text);
                InputIzq.Clear();
            }
        }

        private void CopiarTodoDer_Click(object sender, EventArgs e)
        {
            if (boxDer.SelectedItems.Count >= 0)
            {
                for (int i = 0; i < boxDer.Items.Count; i++)
                {
                    boxIzq.Items.Add(boxDer.Items[i]);
                }
            }
        }
    }
}
