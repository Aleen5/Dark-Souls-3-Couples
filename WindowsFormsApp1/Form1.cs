using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using System.Media;
using WMPLib;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {

        Random random = new Random();
        Random random2 = new Random();
        static int contador = 0;
        SoundPlayer player = new SoundPlayer();
        WindowsMediaPlayer music = new WindowsMediaPlayer();
        Boolean isPlaying = true;

        List<Image> deck = new List<Image> {
                                            Resources.anillos, Resources.ascua, Resources.espada, Resources.frasco_estus, Resources.gemas, Resources.gesto,
                                            Resources.guardiana_de_fuego, Resources.hoguera, Resources.milagro, Resources.pacto_apiladores_2,
                                            Resources.pacto_centinelas_azules, Resources.pacto_dedos_rosaria, Resources.pacto_farron, Resources.pacto_fiel_aldrich,
                                            Resources.pacto_luna_oscura, Resources.pacto_luz_solar, Resources.señal_oscura, Resources.sulyvahn,
                                            Resources.anillos, Resources.ascua, Resources.espada, Resources.frasco_estus, Resources.gemas, Resources.gesto,
                                            Resources.guardiana_de_fuego, Resources.hoguera, Resources.milagro, Resources.pacto_apiladores_2,
                                            Resources.pacto_centinelas_azules, Resources.pacto_dedos_rosaria, Resources.pacto_farron, Resources.pacto_fiel_aldrich,
                                            Resources.pacto_luna_oscura, Resources.pacto_luz_solar, Resources.señal_oscura, Resources.sulyvahn
                                            };

        List<int> imageIndex = new List<int> {

            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18,
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18
        };

        List<Image> bg = new List<Image> { Resources.faraam, Resources.irithyll, Resources.lothric_lorian, Resources.sulyvahn1, Resources.wolnir, Resources.soul_of_cinder };

        String[] sources = {"sound\\abyss_watchers.mp3", "sound\\gwyn.mp3", "sound\\lothric_lorian.mp3", "sound\\ornstein_smough.mp3",
                                    "sound\\soul_of_cinder.mp3", "sound\\sulyvahn.mp3", "sound\\vordt.mp3" };

        PictureBox firstClicked = null;
        PictureBox secondClicked = null;
        private void AssignImagesToSquares() {

            foreach (Control control in tableLayoutPanel1.Controls) {
                PictureBox boxImage = control as PictureBox;

                if (boxImage != null) {

                    int randomNumber = random.Next(deck.Count);
                    boxImage.BackgroundImage = deck[randomNumber];
                    boxImage.Tag = imageIndex[randomNumber];
                    deck.RemoveAt(randomNumber);
                    imageIndex.RemoveAt(randomNumber);
                }
            }
        }

        private void AssignMusic() {

            if (isPlaying) {                                                // Comprueba si la música estaba activada en el anterior formulario

                int randomNumber = random.Next(sources.Length);

                music.URL = sources[randomNumber];                          // Establece una canción aleatoria de la lista proporcionada
                music.settings.setMode("Loop", true);                       // Establece el modo de reproducción
                music.controls.play();
            }
        }

        private void AssignBackground() {
            int randomNumber = random.Next(bg.Count);
            tableLayoutPanel1.BackgroundImage = bg[randomNumber];
        }
        
        public Form1(Boolean isPlaying) {                                   // Recibe la variable booleana de la música en el constructor del Form
            InitializeComponent();
            AssignImagesToSquares();
            AssignMusic();
            AssignBackground();
            player.SoundLocation = "sound\\effects\\CURSOL_MOVE.wav";       // Establece la ruta del sonido al clickar

            
        }

        private void pictureBox_Click(object sender, EventArgs e) {

            if (timer1.Enabled == true)
                return;

            PictureBox clickedPicture = sender as PictureBox;

            if (clickedPicture != null) {                             // Comprueba si la imagen de delante está puesta       

                if (clickedPicture.Image == null)                
                    return;

                player.Play();                                              // Reproduce el sonido al hacer click

                if (firstClicked == null) {                                 // Comprueba si es el primer click

                    firstClicked = clickedPicture;
                    firstClicked.Image = null;
                    return;
                }

                secondClicked = clickedPicture;
                secondClicked.Image = secondClicked.Tag as Image;

                CheckForWinner();

                if(secondClicked.Tag.Equals(firstClicked.Tag)) {            // Comprueba si el tag de los picturebox clickados son iguales
                    firstClicked.Hide();
                    secondClicked.Hide();
                    firstClicked = null;
                    secondClicked = null;
                    contador = contador + 1;
                    return;
                }
                timer1.Start();
            }   
        }

        private void timer1_Tick(object sender, EventArgs e) {
            timer1.Stop();

            firstClicked.Image = Resources.dark_sun;                        // Devuelve las imágenes a su valor inicial
            secondClicked.Image = Resources.dark_sun;

            firstClicked = null;                                            // Devuelve las variables de referencia a null para volver a intentarlo
            secondClicked = null;
        }

        private void CheckForWinner() {

            foreach (Control control in tableLayoutPanel1.Controls) {

                PictureBox boxImage = control as PictureBox;
                if (boxImage.Image != null) {
                    return;
                }
            }
            MessageBox.Show("You matched all the icons!", "Congratulations");
        }

        private void music_button_Click(object sender, EventArgs e) {
            if (isPlaying) {
                music.controls.pause();
                music_button.BackgroundImage = Resources.mute;
                isPlaying = false;
            }
            else {
                music.controls.play();
                music_button.BackgroundImage = Resources.sound;
                isPlaying = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            var result = MessageBox.Show("¿Desea salir de la partida? Perderás tu progreso", "¿Salir?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                e.Cancel = false;
                Form2 menu = new Form2();
                menu.Show();
                music.close();
                this.Hide();

            } else { e.Cancel = true; }
        }

        // Método para comparar imágenes (en desuso)

        /*
        public static bool CompareBitmapsLazy(Bitmap bmp1, Bitmap bmp2) {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (object.Equals(bmp1, bmp2))
                return true;
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            for (int column = 0; column < bmp1.Width; column++)
            {
                for (int row = 0; row < bmp1.Height; row++)
                {
                    if (!bmp1.GetPixel(column, row).Equals(bmp2.GetPixel(column, row)))
                        return false;
                }
            }
            return true;
        }*/
    }
}