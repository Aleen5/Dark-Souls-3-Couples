
namespace WindowsFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.lbl_Salir = new System.Windows.Forms.Label();
            this.lbl_Jugar = new System.Windows.Forms.Label();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.lbl_Instrucciones = new System.Windows.Forms.Label();
            this.music_button = new System.Windows.Forms.Button();
            this.lbl_hardmode = new System.Windows.Forms.Label();
            this.panel_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Menu
            // 
            this.panel_Menu.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.select_background;
            this.panel_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Menu.Controls.Add(this.lbl_hardmode);
            this.panel_Menu.Controls.Add(this.lbl_Salir);
            this.panel_Menu.Controls.Add(this.lbl_Jugar);
            this.panel_Menu.Controls.Add(this.lbl_Version);
            this.panel_Menu.Controls.Add(this.lbl_Instrucciones);
            this.panel_Menu.Location = new System.Drawing.Point(508, 186);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(244, 273);
            this.panel_Menu.TabIndex = 1;
            // 
            // lbl_Salir
            // 
            this.lbl_Salir.AutoSize = true;
            this.lbl_Salir.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Salir.Font = new System.Drawing.Font("Palatino Linotype", 20.75F);
            this.lbl_Salir.ForeColor = System.Drawing.Color.White;
            this.lbl_Salir.Location = new System.Drawing.Point(80, 211);
            this.lbl_Salir.Name = "lbl_Salir";
            this.lbl_Salir.Size = new System.Drawing.Size(73, 37);
            this.lbl_Salir.TabIndex = 5;
            this.lbl_Salir.Text = "Salir";
            this.lbl_Salir.Click += new System.EventHandler(this.lbl_Salir_Click);
            this.lbl_Salir.MouseEnter += new System.EventHandler(this.lblMenu_Enter);
            this.lbl_Salir.MouseLeave += new System.EventHandler(this.lblMenu_Leave);
            // 
            // lbl_Jugar
            // 
            this.lbl_Jugar.AutoSize = true;
            this.lbl_Jugar.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Jugar.Font = new System.Drawing.Font("Palatino Linotype", 20.75F);
            this.lbl_Jugar.ForeColor = System.Drawing.Color.White;
            this.lbl_Jugar.Location = new System.Drawing.Point(80, 16);
            this.lbl_Jugar.Name = "lbl_Jugar";
            this.lbl_Jugar.Size = new System.Drawing.Size(84, 37);
            this.lbl_Jugar.TabIndex = 4;
            this.lbl_Jugar.Text = "Jugar";
            this.lbl_Jugar.Click += new System.EventHandler(this.lbl_Jugar_Click);
            this.lbl_Jugar.MouseEnter += new System.EventHandler(this.lblMenu_Enter);
            this.lbl_Jugar.MouseLeave += new System.EventHandler(this.lblMenu_Leave);
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Version.Font = new System.Drawing.Font("Palatino Linotype", 20.75F);
            this.lbl_Version.ForeColor = System.Drawing.Color.White;
            this.lbl_Version.Location = new System.Drawing.Point(67, 163);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(108, 37);
            this.lbl_Version.TabIndex = 2;
            this.lbl_Version.Text = "Versión";
            this.lbl_Version.Click += new System.EventHandler(this.lbl_Version_Click);
            this.lbl_Version.MouseEnter += new System.EventHandler(this.lblMenu_Enter);
            this.lbl_Version.MouseLeave += new System.EventHandler(this.lblMenu_Leave);
            // 
            // lbl_Instrucciones
            // 
            this.lbl_Instrucciones.AutoSize = true;
            this.lbl_Instrucciones.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Instrucciones.Font = new System.Drawing.Font("Palatino Linotype", 20.75F);
            this.lbl_Instrucciones.ForeColor = System.Drawing.Color.White;
            this.lbl_Instrucciones.Location = new System.Drawing.Point(36, 115);
            this.lbl_Instrucciones.Name = "lbl_Instrucciones";
            this.lbl_Instrucciones.Size = new System.Drawing.Size(179, 37);
            this.lbl_Instrucciones.TabIndex = 1;
            this.lbl_Instrucciones.Text = "Instrucciones";
            this.lbl_Instrucciones.Click += new System.EventHandler(this.lbl_Instrucciones_Click);
            this.lbl_Instrucciones.MouseEnter += new System.EventHandler(this.lblMenu_Enter);
            this.lbl_Instrucciones.MouseLeave += new System.EventHandler(this.lblMenu_Leave);
            // 
            // music_button
            // 
            this.music_button.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.sound;
            this.music_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.music_button.Location = new System.Drawing.Point(12, 429);
            this.music_button.Name = "music_button";
            this.music_button.Size = new System.Drawing.Size(30, 30);
            this.music_button.TabIndex = 2;
            this.music_button.UseVisualStyleBackColor = true;
            this.music_button.Click += new System.EventHandler(this.music_button_Click);
            // 
            // lbl_hardmode
            // 
            this.lbl_hardmode.AutoSize = true;
            this.lbl_hardmode.BackColor = System.Drawing.Color.Transparent;
            this.lbl_hardmode.Font = new System.Drawing.Font("Palatino Linotype", 17.75F);
            this.lbl_hardmode.ForeColor = System.Drawing.Color.White;
            this.lbl_hardmode.Location = new System.Drawing.Point(15, 70);
            this.lbl_hardmode.Name = "lbl_hardmode";
            this.lbl_hardmode.Size = new System.Drawing.Size(216, 32);
            this.lbl_hardmode.TabIndex = 6;
            this.lbl_hardmode.Text = "Modo Prepare2Die";
            this.lbl_hardmode.Click += new System.EventHandler(this.lbl_hardmode_Click);
            this.lbl_hardmode.MouseEnter += new System.EventHandler(this.lblMenu_Enter);
            this.lbl_hardmode.MouseLeave += new System.EventHandler(this.lblMenu_Leave);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.menu_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(764, 471);
            this.Controls.Add(this.music_button);
            this.Controls.Add(this.panel_Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(780, 510);
            this.MinimumSize = new System.Drawing.Size(780, 510);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dark Souls 3: Tiny Edition";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.panel_Menu.ResumeLayout(false);
            this.panel_Menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Label lbl_Instrucciones;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.Label lbl_Jugar;
        private System.Windows.Forms.Label lbl_Salir;
        private System.Windows.Forms.Button music_button;
        private System.Windows.Forms.Label lbl_hardmode;
    }
}