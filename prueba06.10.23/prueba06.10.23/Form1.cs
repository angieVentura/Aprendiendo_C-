using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba06._10._23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool inter = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Hola");
            listBox1.Items.Add("Chau");
            listBox1.Items.Add("React");
            listBox1.Items.Add("Navidad");
            listBox1.Items.Add("Dormir");
            listBox1.Items.Add("Facturas");
            listBox1.Items.Add("Computadoras");
            listBox1.Items.Add("Goleada");
            listBox1.Items.Add("Domingo");
            listBox1.Items.Add("Exponer");

            listBox2.Items.Add("Lunes");
            listBox2.Items.Add("Efemerides");
            listBox2.Items.Add("Cumpleaños");
            listBox2.Items.Add("Empanadas");
            listBox2.Items.Add("Matematica");
            listBox2.Items.Add("Informes");
            listBox2.Items.Add("Demanda");
            listBox2.Items.Add("Oferta");
            listBox2.Items.Add("Oferentes");
            listBox2.Items.Add("Demandantes");

        }

        private void ordenar_Click(object sender, EventArgs e)
        {
            //Cuando se presiona en el primer boton ordenar los listados

            listBox1.Sorted = true;
            listBox2.Sorted = true;

        }

        private void borrar_Click(object sender, EventArgs e)
        {
            //Con el segundo boton borran todos los nombres que tengan hasta 5 letras


            Borrar(listBox1);
            Borrar(listBox2);

        }

        private void intercambiar_Click(object sender, EventArgs e)
        {
            //Con el tercer boton intercambiar los nombres que tengan hasta 5 letras

            Intercambiar(listBox1, listBox2);

        }

        private void interPrimeroUltimo_Click(object sender, EventArgs e)
        {
            //Intercambiar el primer y ultimo elemento de ambas listas. Tienen que quedar en el primer lugar y en el ultimo

            string[] nombresPri = { listBox1.Items[0].ToString(), listBox2.Items[0].ToString()};
            string[] nombresUlt = { listBox1.Items[listBox1.Items.Count - 1].ToString(), listBox2.Items[listBox2.Items.Count - 1].ToString()};

            listBox1.Items[0] = nombresPri[1];
            listBox2.Items[0] = nombresPri[0];
            listBox1.Items[listBox1.Items.Count - 1] = nombresUlt[1];
            listBox2.Items[listBox2.Items.Count - 1] = nombresUlt[0];
        }


        public void Borrar(ListBox listBox) {
            for (int i = listBox.Items.Count - 1; i > 0; i--)
            {
                if (listBox.Items[i].ToString().Length <= 5)
                {
                    listBox.Items.RemoveAt(i);
                }
            }
        }

        public void Intercambiar(ListBox listBoxA, ListBox listBoxB)
        {
            List<string> listBoxA5 = new List<string>();
            List<string> listBoxB5 = new List<string>();

            for (int i = 0; i < listBoxA.Items.Count; i++)
            {
                if (listBoxA.Items[i].ToString().Length <= 5)
                {
                    listBoxA5.Add(listBoxA.Items[i].ToString());
                } 
            }
            for (int i = 0; i < listBoxB.Items.Count; i++)
            {
                if (listBoxB.Items[i].ToString().Length <= 5)
                {
                    listBoxB5.Add(listBoxB.Items[i].ToString());
                }
            }

            Borrar(listBoxB);
            Borrar(listBoxA);

            for (int i = 0; i < listBoxA5.Count; i++)
            {
                if (!Contiene(listBoxA5[i], listBoxB))
                    listBoxB.Items.Add(listBoxA5[i].ToString());
                                
            }

            for (int i = 0; i < listBoxB5.Count; i++)
            {
                if (!Contiene(listBoxB5[i], listBoxA))
                    listBoxA.Items.Add(listBoxB5[i].ToString());
            }

        }

        public bool Contiene(string palabra, ListBox listBox )
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                if (listBox.Items[i].ToString() == palabra)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
