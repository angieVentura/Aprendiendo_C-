using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestorTareas
{
    public partial class Form1 : Form
    {
        List<Tarea> tareas = new List<Tarea>();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void agregar_Click(object sender, EventArgs e)
        {
            if (textAgregar.Text != "" && tituloAgregar.Text != "")
            {
                listTareas.Items.Add(tituloAgregar.Text);

                tareas.Add(new Tarea(tituloAgregar.Text, textAgregar.Text));
            }
        }

        private void listTareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTareas.Items.Count > 0)
            {
                textEditar.Text = tareas[listTareas.SelectedIndex].text;
                tituloEditar.Text = tareas[listTareas.SelectedIndex].titulo;
            }
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            listTareas.Items.Remove(listTareas.SelectedItem);
        }
    }

    class Tarea
    {
        public string titulo;
        public string text;

        public Tarea(string titulo, string text)
        {
            this.text = text;
            this.titulo = titulo;
        }
    }
}
