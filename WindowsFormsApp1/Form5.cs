using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form5 : Form {
        public Form5() {
            InitializeComponent();
        }

        private void btn_Adelante_Click(object sender, EventArgs e) {
            Form4 juego = new Form4(true);
            juego.Show();
            this.Hide();
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e) {
            Form2 menu = new Form2();
            menu.Show();
            this.Hide();
        }
    }
}
