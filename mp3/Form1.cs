using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using TagLib;

namespace mp3
{

    public partial class Form1 : Form
    {
        private List<SongInfo> playlist = new List<SongInfo>();

        public Form1()
        {
            InitializeComponent();
        }

        private void panelBuscador_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AgregarMusica_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de audio|*.mp3;*.mp4;*.wav;*.flac;*.ogg";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    TagLib.File file = TagLib.File.Create(filePath);

                    string title = filePath;
                    TimeSpan duration = file.Properties.Duration;

                    byte[]? albumCover = file.Tag.Pictures.Length > 0 ? file.Tag.Pictures[0].Data.Data : null;
                    Image? coverImage = albumCover != null ? Image.FromStream(new MemoryStream(albumCover)) : null;

                    playlist.Add(new SongInfo { Title = title, Duration = duration, CoverImage = coverImage });

                    Debug.WriteLine($"Title: {title}, Duration: {duration}");
                }
            }
        }
    }

    public class SongInfo
    {
        public string? Title { get; set; }
        public TimeSpan Duration { get; set; }
        public Image? CoverImage { get; set; }
    }
}
