using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Image originalImage = null;
        private int zoomPercentage = 100;
        private int cantSum = 6;
        private int cantRes = 2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAbrir_Click_2(object sender, EventArgs e)
        {

            OpenFileDialog Img = new OpenFileDialog();
            Img.Title = "Visor de imagenes";
            Img.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (Img.ShowDialog() == DialogResult.OK)
            {
                pictureImg.Size = new Size(619, 361);
                pictureImg.Location = new Point((panel1.Width - pictureImg.Width) / 2, (panel1.Height - pictureImg.Height) / 2);

                string ruta = Img.FileName;
                originalImage = Image.FromFile(ruta);

                int newWidth = originalImage.Width <= originalImage.Height ? (originalImage.Width * pictureImg.Height) / originalImage.Height : pictureImg.Width;
                int newHeight = originalImage.Width > originalImage.Height ? (originalImage.Height * pictureImg.Width) / originalImage.Width : pictureImg.Height;
                Image resizedImage = originalImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);
                pictureImg.Image = resizedImage;
                originalImage = resizedImage;
                porcentaje.Text = $"100%";
            }
        }

        private void AplicarZoom()
        {
            if (originalImage != null)
            {
                int newWidth = (originalImage.Width * zoomPercentage) / 100;
                int newHeight = (originalImage.Height * zoomPercentage) / 100;
                Image resizedImage = new Bitmap(originalImage, newWidth, newHeight);

                pictureImg.Image = resizedImage;
                pictureImg.Size = new Size(newWidth, newHeight);
                pictureImg.Location = new Point((panel1.Width - newWidth) / 2, (panel1.Height - newHeight) / 2);

                porcentaje.Text = $"{zoomPercentage}%";
            }
        }

        private void btnMas_Click_1(object sender, EventArgs e)
        {
            if ((cantSum > 0 && cantRes < 8) && originalImage != null)
            {
                zoomPercentage += 10;
                AplicarZoom();
                cantSum--;
                cantRes++;
            }
        }

        private void btnMenos_Click_1(object sender, EventArgs e)
        {

            if ((cantRes >= 2 && cantRes <= 8) && originalImage != null)
            {
                zoomPercentage -= 10;
                AplicarZoom();
                cantSum++;
                cantRes--;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (pictureImg.Image != null)
            {
                pictureImg.Image.Dispose();
                pictureImg.Image = null;
                porcentaje.Text = string.Empty;
                cantRes = 2;
                cantSum = 6;
            }
        }
    }
}
