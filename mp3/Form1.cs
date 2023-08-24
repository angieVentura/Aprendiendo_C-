using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using TagLib;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace mp3
{

    public partial class Form1 : Form
    {
        private List<SongInfo> playlist = new List<SongInfo>();
        [DllImport("winmm.dll")]
        public static extern int mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        [DllImport("winmm.dll")]
        private static extern int mciGetErrorString(int errorCode, StringBuilder errorText, int errorTextSize);

        [DllImport("winmm.dll")]
        public static extern int waveOutGetNumDevs();

        public Form1()
        {
            InitializeComponent();
            this.Resize += Form1_Resize;
        }

        private void panelBuscador_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AgregarMusica_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de audio|*.mp3;*.mp4;*.wav;*.flac;*.ogg";
            openFileDialog.Multiselect = true;
            contenedorTitulo.Controls.Add(tituloCancion);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    TagLib.File file = TagLib.File.Create(filePath);

                    string title = Path.GetFileNameWithoutExtension(filePath);
                    string duration = FormatDuration(file.Properties.Duration);

                    byte[]? albumCover = file.Tag.Pictures.Length > 0 ? file.Tag.Pictures[0].Data.Data : null;
                    Image? coverImage = albumCover != null ? Image.FromStream(new MemoryStream(albumCover)) : Properties.Resources.DefaultImage;
                    

                    playlist.Add(new SongInfo { Title = title, Duration = duration, CoverImage = coverImage });

                    Debug.WriteLine($"Title: {title}, Duration: {duration}");
                }

                cantidadCanciones.Text = $" Canciones: {playlist.Count}";
                CrearCancionesEnPanel();

            }
        }

        private Size Proporcional(int originalWidth, int originalHeight, int maxWidth, int maxHeight)
        {
            double ratio = Math.Min((double)maxWidth / originalWidth, (double)maxHeight / originalHeight);
            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            return new Size(newWidth, newHeight);
        }

        private void CrearCancionesEnPanel()
        {
            PlayList.Controls.Clear();

            if (playlist.Count > 0)
            {
                foreach (SongInfo song in playlist)
                {
                    Size nuevo = Proporcional(song.CoverImage.Width, song.CoverImage.Height, 35, 35);

                    Panel panel = new Panel();
                    PictureBox pictureBox = new PictureBox();
                    Label label = new Label();
                    Label duracion = new Label();
                    
                    //Para le panel
                    panel.Size = new Size(192, 40);
                    panel.BackColor = Color.Red;
                    panel.Dock = DockStyle.Top;
                    panel.Padding = new Padding(0, 0, 8, 0);
                    panel.Tag = song;

                    //Agrego los elemenos al panel
                    panel.Controls.Add(pictureBox);
                    panel.Controls.Add(label);
                    panel.Controls.Add(duracion);

                    //Para la imagen
                    pictureBox.Dock = DockStyle.Left;
                    pictureBox.Size = new Size(35, 35);
                    pictureBox.Image = new Bitmap(song.CoverImage, nuevo);

                    //Para el nombre de la cancion
                    label.Size = new Size(100, 20);
                    label.Text = song.Title;
                    label.Location = new Point(38, 7);

                    //Para la duracion de la cancion

                    duracion.Text = song.Duration;
                    duracion.TextAlign = ContentAlignment.MiddleRight;
                    //duracion.Text = "78:02:02";
                    duracion.Size = new Size(50, 15);
                    duracion.Dock = DockStyle.Right;

                    PlayList.Controls.Add(panel);
                    panel.Click += panel_Click;
                }

                //Aca en el caso de que si se active el scroll
            }



        }

        private void panel_Click(object? sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                if (panel.Tag is SongInfo song)
                {
                    string? title = song.Title;
                    string? duration = song.Duration;
                    Image? imagen = song.CoverImage;

                    Size nuevo = Proporcional(imagen.Width, imagen.Height, 280, 280);
                    cover.Image = new Bitmap(imagen, nuevo);
                    tituloCancion.MaximumSize = new Size(450, int.MaxValue); 
                    tituloCancion.AutoEllipsis = true;
                    tituloCancion.Text = title;
                    tituloCancion.Location = new Point((contenedorTitulo.Width - tituloCancion.Width) / 2, (contenedorTitulo.Height - tituloCancion.Height) / 2);
                }
            }
        }

        private string FormatDuration(TimeSpan duration)
        {

            return string.Format(duration.TotalHours >= 1 ? "{0:D2}:{1:D2}:{2:D2}" : "{0:D2}:{1:D2}", duration.TotalHours >= 1 ? (int)duration.TotalHours : duration.Minutes, duration.Seconds);

        }


        private void Form1_Resize(object? sender, EventArgs e)
        {
            CrearCancionesEnPanel();
        }

        private void cantidadCanciones_Click(object sender, EventArgs e)
        {

        }

        private void contenedorTitulo_Click(object sender, EventArgs e)
        {

        }

        /*private void Play_Click(object sender, EventArgs e)
        {
            
        }
        private string MciMensajesDeError(int ErrorCode)
        {
            
        }*/
    }
    //Fuera de form
    public class SongInfo
    {
        public string? Title { get; set; }
        public string? Duration { get; set; }
        public Image? CoverImage { get; set; }
    }
}
