using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace mp3
{
    public partial class Form1 : Form
    {
        private List<SongInfo> playlist = new List<SongInfo>();

        [DllImport("winmm.dll")]
        public static extern int mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLengh, int hwndCallback);

        [DllImport("winmm.dll")]
        public static extern int mciGetErrorString(int fwdError, StringBuilder lpszErrorText, int cchErrorText);

        [DllImport("winmm.dll")]
        public static extern int waveOutGetNumDevs();

        [DllImport("kernel32.dll")]
        public static extern int GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, int cchBuffer);

        [DllImport("kernel32.dll")]
        public static extern int GetLongPathName(string lpszShortPath, StringBuilder lpszLongPath, int cchBuffer);


        const int MAX_PATH = 260;
        const string Tipo = "MPEGVIDEO";
        const string sAlias = "ArchivoDeSonido";
        private string fileName;
        SongInfo songActual;
        private bool usuarioMoviendoTrackBar = false;
        
        public Form1()
        {
            InitializeComponent();
            this.Resize += Form1_Resize;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AgregarMusica_Click(object sender, EventArgs e)
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

                    byte[] albumCover = file.Tag.Pictures.Length > 0 ? file.Tag.Pictures[0].Data.Data : null;
                    Image coverImage = albumCover != null ? Image.FromStream(new MemoryStream(albumCover)) : Properties.Resources.DefaultImage;


                    playlist.Add(new SongInfo { Title = title, FilePath = filePath, Duration = duration, CoverImage = coverImage });

                    Debug.WriteLine($"Title: {title}, Duration: {duration}");

                }

                cantidadCanciones.Text = $" Canciones: {playlist.Count}";
                CrearCancionesEnPanel();
            }
        }
        private Color botonBackColor;
        private ImageLayout botonBackgroundImageLayout;
        private FlatStyle botonFlatStyle;
        private void Play_Config(System.Drawing.Image img)
        {
            // Guarda las configuraciones originales
            botonBackColor = Play.BackColor;
            botonBackgroundImageLayout = Play.BackgroundImageLayout;
            botonFlatStyle = Play.FlatStyle;

            // Aplica las nuevas configuraciones
            Play.Image = new Bitmap(img, new Size(39, 39));
            Play.BackgroundImageLayout = ImageLayout.Center;
            Play.FlatStyle = FlatStyle.Flat;
        }

        private void Play_Click_1(object sender, EventArgs e)
        {
            if (songActual != null)
            {
                if (EstadoPausado()) {
                    Continuar();
                    Play_Config(Properties.Resources.Diseño_sin_título__56_);
                } else { 
                    Pausar();

                    Play_Config(Properties.Resources.Diseño_sin_título__55_);
                }
            }
        }

        private void CrearCancionesEnPanel()
        {
            PlayListFlow.Controls.Clear();

            if (playlist.Count > 0)
            {
                foreach (SongInfo song in playlist)
                {
                    Size nuevo = Proporcional(song.CoverImage.Width, song.CoverImage.Height, 35, 35);

                    Panel panel = new Panel();
                    PictureBox pictureBox = new PictureBox();
                    Label label = new Label();
                    Label duracion = new Label();

                    //Para el panel
                    panel.Size = new Size(236, 45);
                    panel.BackColor = Color.FromArgb(09,21,52);
                    //panel.BackColor = Color.Red;
                    panel.Dock = DockStyle.Top;
                    panel.Padding = new Padding(0, 0, 8, 0);
                    panel.Tag = song;

                    //Agrego los elemenos al panel
                    panel.Controls.Add(pictureBox);
                    panel.Controls.Add(label);
                    panel.Controls.Add(duracion);

                    //Para la imagen
                    //pictureBox.Dock = DockStyle.Left;
                    pictureBox.Location = new Point(9,5);
                    pictureBox.Size = new Size(35, 35);
                    pictureBox.Image = new Bitmap(song.CoverImage, nuevo);
                    pictureBox.Tag = song;

                    //Para el nombre de la cancion
                    label.Size = new Size(130, 20);
                    label.Text = song.Title;
                    label.Tag = song;
                    label.Location = new Point(49,7);
                    label.ForeColor = Color.White;

                    //Para la duracion de la cancion
                    duracion.Text = song.Duration;
                    duracion.TextAlign = ContentAlignment.MiddleRight;
                    duracion.Size = new Size(50, 15);
                    //duracion.Dock = DockStyle.Right;
                    duracion.Location = new Point(164,16);
                    duracion.Tag = song;
                    duracion.ForeColor = Color.White;

                    PlayListFlow.Controls.Add(panel);
                    panel.Click += panel_Click;
                    pictureBox.Click += panel_Click;
                    label.Click += panel_Click;
                    duracion.Click += panel_Click;
                }

                //Aca en el caso de que si se active el scroll
            }

        }

        private void panel_Click(object sender, EventArgs e)
        {
            reproductorEstado.Text = "Se dio click";
            if (sender is Control control)
            {
                if (control.Tag is SongInfo song)
                {
                    Image imagen = song.CoverImage;

                    Size nuevo = Proporcional(imagen.Width, imagen.Height, 300, 300);
                    cover.Image = new Bitmap(imagen, nuevo);
                    tituloCancion.MaximumSize = new Size(450, int.MaxValue);
                    tituloCancion.AutoEllipsis = true;
                    tituloCancion.Text = song.Title;
                    tituloCancion.Location = new Point((contenedorTitulo.Width - tituloCancion.Width) / 2, (contenedorTitulo.Height - tituloCancion.Height) / 2);
                    songActual = song;
                    fileName = songActual.FilePath;
                    Cerrar();
                    Reproducir();
                    trackBarTiempo.Maximum = DuracionCancion(songActual);
                    duracionTotal.Text = song.Duration;
                    Play_Config(Properties.Resources.Diseño_sin_título__56_);
                }
            }
        }

        private string NombreCorto(string NombreLargo)
        {
            StringBuilder sBuffer = new StringBuilder(MAX_PATH);
            return GetShortPathName(NombreLargo, sBuffer, MAX_PATH) > 0 ? sBuffer.ToString() : "";
        }

        private string MciMensajesDeError(int ErrorCode)
        {
            StringBuilder sbBuffer = new StringBuilder(MAX_PATH);
            return mciGetErrorString(ErrorCode, sbBuffer, MAX_PATH) != 0 ? sbBuffer.ToString() : "";
        }

        public int DispositivosDeSonido()
        {
            return waveOutGetNumDevs();
        }

        private bool Abrir()
        {
            if (!System.IO.File.Exists(fileName)) return false;
            //Esto no va a hacer falta porque almacenamos el nombre la clase songInfo
            string nombreCorto = NombreCorto(fileName);

            return mciSendString("open " + nombreCorto + " type " + Tipo + " alias " + sAlias, null, 0, 0) == 0 ? true : false;
        }

        public void Reproducir()
        {
            // Nos cersioramos que hay un archivo que reproducir.
            if (fileName != "")
            {
                // intentamos iniciar la reproducción.
                if (Abrir())
                {
                    int mciResul = mciSendString("play " + sAlias, null, 0, 0);
                    if (mciResul == 0)
                        // si se ha tenido éxito, devolvemos el mensaje adecuado,
                        reproductorEstado.Text = "Ok";
                    else // en caso contrario, la cadena de mensaje de error.
                        reproductorEstado.Text = MciMensajesDeError(mciResul);
                }
                else // sí el archivo no ha sido abierto, indicamos el mensaje de error.
                    reproductorEstado.Text = "No se ha logrado abrir el archivo especificado";
            }
            else // si no hay archivo especificado, devolvemos la cadena indicando
                 // el evento.
                reproductorEstado.Text = "No se ha especificado ningún nombre de archivo";
        }

        public void ReproducirDesde(long Desde)
        {
            int mciResul = mciSendString("play " + sAlias + " from " + (Desde * 1000).ToString(), null, 0, 0);

            reproductorEstado.Text = mciResul == 0 ? "Nueva Posición: " + Desde.ToString() : MciMensajesDeError(mciResul);

        }

        public void Velocidad(int Tramas)
        {
            int mciResul = mciSendString("set " + sAlias + " tempo " + Tramas.ToString(), null, 0, 0);

            reproductorEstado.Text = mciResul == 0 ? "Velocidad modificada." : MciMensajesDeError(mciResul);
        }

        public void Reposicionar(int NuevaPosicion)
        {
            int mciResul = mciSendString("seek " + sAlias + " to " + (NuevaPosicion * 1000).ToString(), null, 0, 0);

            reproductorEstado.Text = mciResul == 0 ? "Nueva Posición: " + NuevaPosicion.ToString() : MciMensajesDeError(mciResul);
        }

        public void Principio()
        {
            int mciResul = mciSendString("seek " + sAlias + " to start", null, 0, 0);

            reproductorEstado.Text = mciResul == 0 ? "Inicio de" + Path.GetFileNameWithoutExtension(fileName) : MciMensajesDeError(mciResul);
        }

        public void Final()
        {
            int mciResul = mciSendString("seek " + sAlias + " to end", null, 0, 0);

            reproductorEstado.Text = mciResul == 0 ? "Final de" + Path.GetFileNameWithoutExtension(fileName) : MciMensajesDeError(mciResul);

        }

        public void Pausar()
        {
            int mciResul = mciSendString("pause " + sAlias, null, 0, 0);

            reproductorEstado.Text = mciResul == 0 ? "Pausada" : MciMensajesDeError(mciResul);
        }

        public void Continuar()
        {
            int mciResul = mciSendString("resume " + sAlias, null, 0, 0);

            reproductorEstado.Text = mciResul == 0 ? "Continuar" : MciMensajesDeError(mciResul);
        }

        public void Cerrar()
        {
            mciSendString("stop " + sAlias, null, 0, 0);
            mciSendString("close " + sAlias, null, 0, 0);
        }

        public void Detener()
        {
            mciSendString("stop " + sAlias, null, 0, 0);
        }

        public string Estado()
        {
            StringBuilder sbBuffer = new StringBuilder(MAX_PATH);

            mciSendString("status " + sAlias + " mode", sbBuffer, MAX_PATH, 0);

            return sbBuffer.ToString();
        }

        public bool EstadoReproduciendo()
        {
            return Estado() == "playing" ? true : false;
        }

        public bool EstadoPausado()
        {
            return Estado() == "paused" ? true : false;
        }

        public bool EstadoDetenido()
        {
            return Estado() == "stopped" ? true : false;
        }

        public bool EstadoAbierto()
        {
            return Estado() == "open" ? true : false;
        }

        public long CalcularPosicion()
        {
            StringBuilder sbBuffer = new StringBuilder(MAX_PATH);
            // Establecemos el formato de tiempo.
            mciSendString("set " + sAlias + " time format milliseconds", null, 0, 0);
            // Enviamos el comando para conocer la posición del apuntador.
            mciSendString("status " + sAlias + " position", sbBuffer, MAX_PATH, 0);

            // Sí hay información en el buffer,
            if (sbBuffer.ToString() != "")
                // la devolvemos, eliminando el formato de milisegundos
                // y formateando la salida a entero largo;
                return long.Parse(sbBuffer.ToString()) / 1000;
            else // si no, devolvemos cero.
                return 0L;
        }

        public string Posicion()
        {
            // obtenemos los segundos.
            long sec = CalcularPosicion();
            long mins;

            // Si la cantidad de segundos es menor que 60 (1 minuto),
            if (sec < 60)
                // devolvemos la cadena formateada a 0:Segundos.
                return "0:" + String.Format("{0:D2}", sec);
            // Si los segundos son mayores que 59 (60 o más),
            else if (sec > 59)
            {
                // calculamos la cantidad de minutos,
                mins = (int)(sec / 60);
                // restamos los segundos de la cantida de minutos obtenida,
                sec = sec - (mins * 60);
                // devolvemos la cadena formateada a Minustos:Segundos.
                return String.Format("{0:D2}", mins) + ":" + String.Format("{0:D2}", sec);
            }
            else // en caso de obtener un valor menos a 0, devolvemos una cadena vacía.
                return "";
        }

        public long CalcularTamaño()
        {
            StringBuilder sbBuffer = new StringBuilder(MAX_PATH);
            mciSendString("set " + sAlias + " time format milliseconds", null, 0, 0);
            // Obtenemos el largo del archivo, en millisegundos.
            mciSendString("status " + sAlias + " length", sbBuffer, MAX_PATH, 0);

            // Sí el buffer contiene información,
            if (sbBuffer.ToString() != "")
                // la devolvemos, formateando la salida a entero largo;
                return long.Parse(sbBuffer.ToString()) / 1000;
            else // si no, devolvemos cero.
                return 0L;
        }

        public string Tamaño()
        {
            long sec = CalcularTamaño();
            long mins;

            // Si la cantidad de segundos es menor que 60 (1 minuto),
            if (sec < 60)
                // devolvemos la cadena formateada a 0:Segundos.
                return "0:" + String.Format("{0:D2}", sec);
            // Si los segundos son mayores que 59 (60 o más),
            else if (sec > 59)
            {
                mins = (int)(sec / 60);
                sec = sec - (mins * 60);
                // devolvemos la cadena formateada a Minustos:Segundos.
                return String.Format("{0:D2}", mins) + ":" + String.Format("{0:D2}", sec);
            }
            else
                return "";
        }

        private Size Proporcional(int originalWidth, int originalHeight, int maxWidth, int maxHeight)
        {
            double ratio = Math.Min((double)maxWidth / originalWidth, (double)maxHeight / originalHeight);
            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            return new Size(newWidth, newHeight);
        }

        private string FormatDuration(TimeSpan duration)
        {

            return string.Format(duration.TotalHours >= 1 ? "{0:D2}:{1:D2}:{2:D2}" : "{0:D2}:{1:D2}", duration.TotalHours >= 1 ? (int)duration.TotalHours : duration.Minutes, duration.Seconds);

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CrearCancionesEnPanel();
        }

        private int DuracionCancion(SongInfo song)
        {

            try
            {
                string[] partes = song.Duration.Split(':');

                if (partes.Length == 2)
                {

                    int minutos = int.Parse(partes[0]);
                    int segundos = int.Parse(partes[1]);

                    int duracionSegundos = (minutos * 60) + segundos;

                    return duracionSegundos;
                }
            }
            catch (Exception ex)
            {
                reproductorEstado.Text = "Error al obtener la duración en segundos: " + ex.Message;
            }

            return 0;
        }

        private string FormatearTiempo(int segundos)
        {

            int minutos = segundos / 60;
            segundos %= 60;

            string tiempoFormateado = $"{minutos:D2}:{segundos:D2}";

            return tiempoFormateado;
        }

        private void timerActualizarTiempo_Tick(object sender, EventArgs e)
        {

            if (!usuarioMoviendoTrackBar)
            {
                long tiempoReproduccion = CalcularPosicion();
                trackBarTiempo.Value = (int)tiempoReproduccion;
            }

            reproductorEstado.Text = $"{trackBarTiempo.Value}";
        }

        private void ce_TrackBar1_ValueChanged()
        {
            tiempoCancion.Text = FormatearTiempo(trackBarTiempo.Value);
        }

        private void trackBarTiempo_MouseUp(object sender, MouseEventArgs e)
        {
            Reposicionar(trackBarTiempo.Value);
            ReproducirDesde(trackBarTiempo.Value);
            usuarioMoviendoTrackBar = false;
            trackBarTiempo.Capture = false;
        }

        private void trackBarTiempo_MouseDown(object sender, MouseEventArgs e)
        {
            usuarioMoviendoTrackBar = true;
            trackBarTiempo.Capture = true;
        }

        private void trackBarTiempo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int mouseX = e.X - trackBarTiempo.Left;
                int trackBarWidth = trackBarTiempo.Width;

                double ratio = (double)mouseX / trackBarWidth;
                int newPosition = (int)(ratio * (trackBarTiempo.Maximum - trackBarTiempo.Minimum)) + trackBarTiempo.Minimum;

                int mousePreciso = (int)Math.Round((double)(17 * trackBarTiempo.Maximum) / 100);

                if (newPosition >= trackBarTiempo.Minimum - mousePreciso && newPosition <= trackBarTiempo.Maximum + mousePreciso)
                {
                    trackBarTiempo.Value = newPosition + mousePreciso;
                }
            }

        }

        private void volumen_ValueChanged()
        {
            int Volumen = volumen.Value; // Obtén el valor del control de volumen

            // Asegúrate de que el valor esté dentro del rango de 0 a 1000
            Volumen = Math.Max(0, Math.Min(Volumen, 1000));

            // Construye el comando MCI para establecer el volumen
            string command = $"setaudio {sAlias} volume to {Volumen}";

            // Llama a mciSendString para ajustar el volumen
            int result = mciSendString(command, null, 0, 0);

            if (result != 0)
            {
                // Maneja cualquier error que pueda ocurrir al ajustar el volumen
                string errorMessage = MciMensajesDeError(result);
                MessageBox.Show($"Error al ajustar el volumen: {errorMessage}");
            }
        }

    }
    //Fuera de form
    public class SongInfo
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string Duration { get; set; }

        public Image CoverImage { get; set; }
    }
}
