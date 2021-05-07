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
    public partial class Form4 : Form
    {
        Random random = new Random();
        Random random2 = new Random();
        SoundPlayer player = new SoundPlayer();
        WindowsMediaPlayer music = new WindowsMediaPlayer();
        Boolean isPlaying = true;

        List<Image> deck = new List<Image> {
                                            Resources.ascua, Resources.espada, Resources.frasco_estus, Resources.gesto,
                                            Resources.guardiana_de_fuego, Resources.hoguera,
                                            Resources.pacto_centinelas_azules, Resources.pacto_dedos_rosaria, Resources.pacto_farron,
                                            Resources.pacto_luna_oscura, Resources.pacto_luz_solar, Resources.señal_oscura,
                                            Resources.ascua, Resources.espada, Resources.frasco_estus, Resources.gesto,
                                            Resources.guardiana_de_fuego, Resources.hoguera,
                                            Resources.pacto_centinelas_azules, Resources.pacto_dedos_rosaria, Resources.pacto_farron,
                                            Resources.pacto_luna_oscura, Resources.pacto_luz_solar, Resources.señal_oscura
                                            };

        List<int> imageIndex = new List<int> {

            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
        };

        List<Image> bg = new List<Image> { Resources.faraam, Resources.irithyll, Resources.lothric_lorian, Resources.sulyvahn1, Resources.wolnir, Resources.soul_of_cinder };

        String[] sources = {"sound\\abyss_watchers.mp3", "sound\\gwyn.mp3", "sound\\lothric_lorian.mp3", "sound\\ornstein_smough.mp3",
                                    "sound\\soul_of_cinder.mp3", "sound\\sulyvahn.mp3", "sound\\vordt.mp3" };

        PictureBox firstClicked = null;
        PictureBox secondClicked = null;
        private void AssignImagesToSquares() {

            foreach (Control control in tableLayoutPanel1.Controls) {
                PictureBox boxImage = control as PictureBox;

                if (boxImage != null)
                {

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

        public Form4(Boolean isPlaying) {                                   // Recibe la variable booleana de la música en el constructor del Form
            InitializeComponent();
            AssignImagesToSquares();
            AssignMusic();
            AssignBackground();
        }

        private void pictureBox_Click(object sender, EventArgs e) {

            if (timer1.Enabled == true)
                return;

            PictureBox clickedPicture = sender as PictureBox;

            if (clickedPicture != null) {                                   // Comprueba si la imagen de delante está puesta       

                if (clickedPicture.Image == null)
                    return;
                player.SoundLocation = "sound\\effects\\CURSOL_MOVE.wav";
                player.Play();                                              // Reproduce el sonido al hacer click

                if (firstClicked == null) {                                 // Comprueba si es el primer click

                    firstClicked = clickedPicture;
                    firstClicked.Image = null;
                    return;
                }

                secondClicked = clickedPicture;
                secondClicked.Image = secondClicked.Tag as Image;

                CheckForWinner();

                if (secondClicked.Tag.Equals(firstClicked.Tag)) {            // Comprueba si el tag de los picturebox clickados son iguales

                    if (firstClicked.Tag.Equals(3)) {

                        Curacion("estus");
                        firstClicked.Hide();
                        secondClicked.Hide();
                        firstClicked = null;
                        secondClicked = null;
                        return;

                    } else if (firstClicked.Tag.Equals(1)) {

                        Curacion("ascua");
                        firstClicked.Hide();
                        secondClicked.Hide();
                        firstClicked = null;
                        secondClicked = null;
                        return;

                    } else {
                        Curacion("robo");
                        firstClicked.Hide();
                        secondClicked.Hide();
                        firstClicked = null;
                        secondClicked = null;
                        return;
                    }
                }
                else { CheckForLoser(); }
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

        private void Curacion(String tipo) {
            int contador = 0;

            if (tipo == "robo")
                contador = 1;

            if (tipo == "estus") {
                player.SoundLocation = "sound\\effects\\estus_heal.wav";
                player.Play();
                MessageBox.Show("Curado por Frasco Estus (+ 3 HP)");
                contador = 3;
            }

            if (tipo == "ascua") {
                player.SoundLocation = "sound\\effects\\ember_heal.wav";
                player.Play();
                MessageBox.Show("Curado por Ascua (Vida al máximo)");
                contador = 8;
            }

            //contador = 8;                                                 // Descomenta esto para inmortalidad en el modo Prepare2Die (no recomendado)

                while (contador > 0) {

                    if (pb_lifebar2.BackColor == Color.Transparent && contador > 0) {
                        pb_lifebar2.BackColor = Color.DarkRed;
                        contador--;
                    }

                    if (pb_lifebar3.BackColor == Color.Transparent && contador > 0) {
                        pb_lifebar3.BackColor = Color.DarkRed;
                        contador--;
                    }
                    
                    if (pb_lifebar4.BackColor == Color.Transparent && contador > 0) {
                        pb_lifebar4.BackColor = Color.DarkRed;
                        contador--;
                    }

                    if(pb_lifebar5.BackColor == Color.Transparent && contador > 0) {
                        pb_lifebar5.BackColor = Color.DarkRed;
                        contador--;
                    }

                    if(pb_lifebar6.BackColor == Color.Transparent && contador > 0) {
                        pb_lifebar6.BackColor = Color.DarkRed;
                        contador--;
                    }

                    if (pb_lifebar7.BackColor == Color.Transparent && contador > 0) {
                        pb_lifebar7.BackColor = Color.DarkRed;
                        contador--;
                    }

                    if (pb_lifebar8.BackColor == Color.Transparent && contador > 0) {
                        pb_lifebar8.BackColor = Color.DarkRed;
                        contador--;
                    }

                return;
            }
        }
        

        private void CheckForWinner() {

            foreach (Control control in tableLayoutPanel1.Controls) {

                PictureBox boxImage = control as PictureBox;
                if (boxImage.Image != null) {
                    return;
                }
            }

            player.SoundLocation = "sound\\effects\\bossout.wav";
            player.Play();
            MessageBox.Show("You've defeated the heir of fire", "Congratulations");

        }
        private void CheckForLoser() {

            foreach (Control control in lifebar_Panel.Controls) {

                PictureBox lifebar = control as PictureBox;
                if (lifebar.BackColor == Color.DarkRed) {
                    lifebar.BackColor = Color.Transparent;

                    if (pb_lifebar1.BackColor == Color.Transparent) {

                        player.SoundLocation = "sound\\effects\\died.wav";
                        player.Play();
                        MessageBox.Show("YOU DIED");
                        Form2 menu = new Form2();
                        music.close();
                        menu.Show();
                        this.Hide();
                    }
                    return;
                }
            }

            
        }

        private void music_button_Click(object sender, EventArgs e) {
            if (isPlaying) {

                music.controls.pause();
                music_button.BackgroundImage = Resources.mute;
                isPlaying = false;

            } else {

                music.controls.play();
                music_button.BackgroundImage = Resources.sound;
                isPlaying = true;
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e) {
            var result = MessageBox.Show("¿Desea salir de la partida? Perderás tu progreso", "¿Salir?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                e.Cancel = false;
                Form2 menu = new Form2();
                menu.Show();
                music.close();
                this.Hide();
                

            } else { e.Cancel = true; }
        }
    }
}
