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
    public partial class Form2 : Form {
        
        SoundPlayer player = new SoundPlayer();
        WindowsMediaPlayer music = new WindowsMediaPlayer();
        Boolean isPlaying = true;
        public Form2() {

            InitializeComponent();
            music.URL = "sound\\main_menu_theme.mp3";
            music.settings.setMode("Loop", true);
            music.controls.play();

        }

        private void lbl_Jugar_Click(object sender, EventArgs e) {
            player.SoundLocation = "sound\\effects\\CURSOL_OK.wav";
            player.Play();
            music.controls.stop();
            Form1 juego = new Form1(isPlaying);
            juego.Show();

            this.Hide();
        }

        private void lbl_Version_Click(object sender, EventArgs e) {
            player.SoundLocation = "sound\\effects\\CURSOL_OK.wav";
            player.Play();
            MessageBox.Show("Ver. 1.0", "Version");
        }

        private void lbl_Salir_Click(object sender, EventArgs e) {
            player.SoundLocation = "sound\\effects\\CURSOL_OK.wav";
            player.Play();
            Environment.Exit(1);
        }

        private void lblMenu_Enter(object sender, EventArgs e) {
            Label enterLabel = sender as Label;
            player.SoundLocation = "sound\\effects\\CURSOL_SELECT.wav";
            player.Play();
            enterLabel.Font = new Font(enterLabel.Font, FontStyle.Underline);
            enterLabel.ForeColor = Color.OrangeRed;
        }

        private void lblMenu_Leave(object sender, EventArgs e) {
            Label enterLabel = sender as Label;
            enterLabel.Font = new Font(enterLabel.Font, FontStyle.Regular);
            enterLabel.ForeColor = Color.White;
            
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

        private void lbl_Instrucciones_Click(object sender, EventArgs e) {
            player.SoundLocation = "sound\\effects\\CURSOL_OK.wav";
            player.Play();

            MessageBox.Show("Juego de las parejas: \n\nEn este juego, para lograr la victoria, deberás encontrar " +
                "todas las parejas de iconos en un tablero de 6x6. \n\nPara descubrir un icono, haz click sobre un " +
                "recuadro. A continuación, haz click sobre otro recuadro para comprobar si era el mismo que el " +
                "primero que clickaste. \n\nSi eran el mismo, se eliminarán. Si no lo eran, se volverán a voltear a " +
                "su posición inicial y tendrás que intentarlo de nuevo con otra pareja. \n\n¡Descúbrelos todos para " +
                "destapar la imagen de fondo!\n", "Instrucciones");
        }

        private void lbl_hardmode_Click(object sender, EventArgs e) {
            player.SoundLocation = "sound\\effects\\CURSOL_OK.wav";
            player.Play();

            var confirmacion = MessageBox.Show("En este modo de juego se intenta mimetizar al máximo la experiencia que proporciona Dark Souls. " +
                "\n\nSe requiere de una paciencia extrema para estar a la altura del desafío. " +
                "\n\n¿Estás segur@ de que deseas continuar?", "Advertencia", MessageBoxButtons.YesNo);

            if(confirmacion == DialogResult.Yes) {
                music.controls.stop();
                Form5 instrucciones = new Form5();
                instrucciones.Show();
                Hide();

            } else {
                MessageBox.Show("Una retirada a tiempo también es una victoria");
            }

            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e) {
            Environment.Exit(1);
        }
        
    }
}
