using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Image> originalImages = new List<Image>();
        private int zoomPercentage;
        private int cantSum;
        private int cantRes;
        private int imgId;
        private int rote = 0; 


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
            Img.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            Img.Multiselect = true;
            if (Img.ShowDialog() == DialogResult.OK)
            {

                foreach (string ruta in Img.FileNames)
                {
                    Image image = Image.FromFile(ruta);

                    Size nuevo = Proporcional(image.Width, image.Height, 554, 348);

                    originalImages.Add(new Bitmap(image, nuevo));
                }
                CrearPictureBoxEnPanel();

                porcentaje.Text = $"100%";
            }
        }
        private Size Proporcional(int originalWidth, int originalHeight, int maxWidth, int maxHeight)
        {
            double widthRatio = (double)maxWidth / originalWidth;
            double heightRatio = (double)maxHeight / originalHeight;
            double ratio = Math.Min(widthRatio, heightRatio);

            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            return new Size(newWidth, newHeight);
        }


        private void CrearPictureBoxEnPanel()
        {
            flowLayoutPanel1.Controls.Clear();
            if (originalImages.Count > 0)
            {
                foreach (Image img in originalImages)
                {
                    PictureBox pictureBox = new PictureBox();

                    pictureBox.Size = new Size(100, 100); 
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.BackColor = Color.FromArgb(100, 100, 100);
                    pictureBox.Image = img;

                    flowLayoutPanel1.Controls.Add(pictureBox);

                    pictureBox.Click += PictureBox_Click;
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Verificar que el objeto que generó el evento es un PictureBox
            if (sender is PictureBox pictureBox)
            {
                porcentaje.Text = $"100%";
                rote = 0;
                pictureImg.Size = new Size(554, 348);
                pictureImg.Location = new Point((panel1.Width - pictureImg.Width) / 2, (panel1.Height - pictureImg.Height) / 2);
                zoomPercentage = 100;
                cantSum = 6;
                cantRes = 2;
                int newWidth = pictureBox.Image.Width <= pictureBox.Image.Height ? (pictureBox.Image.Width * pictureImg.Height) / pictureBox.Image.Height : pictureImg.Width;
                int newHeight = pictureBox.Image.Width > pictureBox.Image.Height ? (pictureBox.Image.Height * pictureImg.Width) / pictureBox.Image.Width : pictureImg.Height;
                Image resizedImage = pictureBox.Image.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);
                pictureImg.Image = resizedImage;

                imgId = flowLayoutPanel1.Controls.GetChildIndex(pictureBox);
            }
        }

        private void AplicarZoom()
        {
            if (originalImages.Count > 0)
            {
                int newWidth = (originalImages[imgId].Width * zoomPercentage) / 100;
                int newHeight = (originalImages[imgId].Height * zoomPercentage) / 100;
                Image resizedImage = new Bitmap(originalImages[imgId], newWidth, newHeight);

                pictureImg.Image = resizedImage;
                pictureImg.Size = new Size(newWidth, newHeight);
                //pictureImg.Location = new Point((panel1.Width - newWidth) / 2, (panel1.Height - newHeight) / 2);
                porcentaje.Text = $"{zoomPercentage}%";
            }
        }

        private void btnMas_Click_1(object sender, EventArgs e)
        {
            if ((cantSum > 0 && cantRes < 8) && originalImages.Count > 0)
            {
                zoomPercentage += 10;
                AplicarZoom();
                cantSum--;
                cantRes++;
            }
        }

        private void btnMenos_Click_1(object sender, EventArgs e)
        {

            if ((cantRes >= 2 && cantRes <= 8) && originalImages.Count > 0)
            {
                zoomPercentage -= 10;
                AplicarZoom();
                cantSum++;
                cantRes--;
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (pictureImg.Image != null && originalImages.Count > 0)
            {
                originalImages.RemoveAt(imgId);
                CrearPictureBoxEnPanel();
                pictureImg.Image.Dispose();
                pictureImg.Image = null;
                porcentaje.Text = string.Empty;
            }
        }

        private void rotar_Click(object sender, EventArgs e)
        {
            if (pictureImg.Image != null)
            {
                rote++;
                int newWidth = (originalImages[imgId].Width * zoomPercentage) / 100;
                int newHeight = (originalImages[imgId].Height * zoomPercentage) / 100;

                if (rote % 2 == 0)
                    pictureImg.Size = new Size(newWidth, newHeight);
                else
                {
                    pictureImg.Size = new Size(newHeight, newWidth);
                }

                Image Image = pictureImg.Image;

                Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                pictureImg.Image = Image;
            }
        }

        private void pictureImg_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureImg_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
