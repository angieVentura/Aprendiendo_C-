using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Image> originalImages = new List<Image>();
        private List<String> nombreImg = new List<String>();
        private Image imagenAct;
        private int zoomPercentage, cantSum, cantRes, imgId;

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
                    nombreImg.Add(ruta.Substring(ruta.LastIndexOf('\\') + 1));
                }
                CrearPictureBoxEnPanel();
                PictureBox_Click(flowLayoutPanel1.Controls[0], EventArgs.Empty);
            }           
        }

        private Size Proporcional(int originalWidth, int originalHeight, int maxWidth, int maxHeight)
        {
            double ratio = Math.Min((double)maxWidth / originalWidth, (double)maxHeight / originalHeight);
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

                    pictureBox.MouseEnter += (sender, e) => { pictureBox.Cursor = Cursors.Hand; };

                    pictureBox.MouseLeave += (sender, e) => { pictureBox.Cursor = Cursors.Default; };

                    flowLayoutPanel1.Controls.Add(pictureBox);
                    pictureBox.Click += PictureBox_Click;
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                porcentaje.Text = $"100%";
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
                label1.Text = nombreImg[imgId];
                label1.Location = new Point((panel2.Width - label1.Width) / 2, (panel2.Height - label1.Height) / 2);
                imagenAct = (Image)originalImages[imgId].Clone();
            }
        }

        private void AplicarZoom()
        {
            if (originalImages.Count > 0)
            {
                int newWidth = (imagenAct.Width * zoomPercentage) / 100;
                int newHeight = (imagenAct.Height * zoomPercentage) / 100;
                Image resizedImage = new Bitmap(imagenAct, newWidth, newHeight);

                pictureImg.Image = resizedImage;
                pictureImg.Size = new Size(newWidth, newHeight);
                porcentaje.Text = $"{zoomPercentage}%";
            }
        }

        private void rotar_Click(object sender, EventArgs e)
        {
            if (pictureImg.Image != null)
            {
                imagenAct.RotateFlip(RotateFlipType.Rotate90FlipNone);
                int newWidth = (imagenAct.Width * zoomPercentage) / 100;
                int newHeight = (imagenAct.Height * zoomPercentage) / 100;
                pictureImg.Size = new Size(newWidth, newHeight);
                pictureImg.Image = new Bitmap(imagenAct, newWidth, newHeight);
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

                label1.Text = "";
                originalImages.RemoveAt(imgId);
                nombreImg.RemoveAt(imgId);

                CrearPictureBoxEnPanel();
                pictureImg.Image.Dispose();
                pictureImg.Image = null;
                porcentaje.Text = string.Empty;

                if (originalImages.Count > 0) PictureBox_Click(flowLayoutPanel1.Controls[imgId >= originalImages.Count ? originalImages.Count - 1 : imgId], EventArgs.Empty);
            }
        }

        private void reflejarHor_Click(object sender, EventArgs e)
        {
            if (imagenAct != null)
            {
                imagenAct.RotateFlip(RotateFlipType.RotateNoneFlipX);
                AplicarZoom();
            }
        }

        private void reflejarVert_Click(object sender, EventArgs e)
        {
            if (imagenAct != null)
            {
                imagenAct.RotateFlip(RotateFlipType.RotateNoneFlipY);
                AplicarZoom();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
