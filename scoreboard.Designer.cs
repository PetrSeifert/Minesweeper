namespace Projekt_Hledání_Min
{
    partial class Scoreboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scoreboard));
            this.backToGame = new System.Windows.Forms.Button();
            this.lblLehka = new System.Windows.Forms.Label();
            this.lblStredni = new System.Windows.Forms.Label();
            this.lblTezka = new System.Windows.Forms.Label();
            this.lblExpert = new System.Windows.Forms.Label();
            this.deleteScore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backToGame
            // 
            this.backToGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.backToGame.Location = new System.Drawing.Point(3, 12);
            this.backToGame.Name = "backToGame";
            this.backToGame.Size = new System.Drawing.Size(160, 50);
            this.backToGame.TabIndex = 13;
            this.backToGame.Text = "ZPÁTKY DO HRY";
            this.backToGame.UseVisualStyleBackColor = true;
            this.backToGame.Click += new System.EventHandler(this.BackToGame_Click);
            // 
            // lblLehka
            // 
            this.lblLehka.AutoSize = true;
            this.lblLehka.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLehka.ForeColor = System.Drawing.Color.Black;
            this.lblLehka.Location = new System.Drawing.Point(12, 91);
            this.lblLehka.Name = "lblLehka";
            this.lblLehka.Size = new System.Drawing.Size(209, 20);
            this.lblLehka.TabIndex = 14;
            this.lblLehka.Text = "LEHKÁ - 999:99  Výher:0";
            // 
            // lblStredni
            // 
            this.lblStredni.AutoSize = true;
            this.lblStredni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStredni.Location = new System.Drawing.Point(12, 150);
            this.lblStredni.Name = "lblStredni";
            this.lblStredni.Size = new System.Drawing.Size(229, 20);
            this.lblStredni.TabIndex = 14;
            this.lblStredni.Text = "STŘEDNÍ - 999:99  Výher:0";
            // 
            // lblTezka
            // 
            this.lblTezka.AutoSize = true;
            this.lblTezka.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTezka.Location = new System.Drawing.Point(12, 206);
            this.lblTezka.Name = "lblTezka";
            this.lblTezka.Size = new System.Drawing.Size(207, 20);
            this.lblTezka.TabIndex = 14;
            this.lblTezka.Text = "TĚŽKÁ - 999:99  Výher:0";
            // 
            // lblExpert
            // 
            this.lblExpert.AutoSize = true;
            this.lblExpert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblExpert.Location = new System.Drawing.Point(12, 263);
            this.lblExpert.Name = "lblExpert";
            this.lblExpert.Size = new System.Drawing.Size(221, 20);
            this.lblExpert.TabIndex = 14;
            this.lblExpert.Text = "EXPERT - 999:99  Výher:0";
            // 
            // deleteScore
            // 
            this.deleteScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteScore.Location = new System.Drawing.Point(3, 328);
            this.deleteScore.Name = "deleteScore";
            this.deleteScore.Size = new System.Drawing.Size(160, 50);
            this.deleteScore.TabIndex = 13;
            this.deleteScore.Text = "VYMAZAT VÝSLEDKY";
            this.deleteScore.UseVisualStyleBackColor = true;
            this.deleteScore.Click += new System.EventHandler(this.DeleteScore_Click);
            // 
            // Scoreboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1346, 725);
            this.Controls.Add(this.lblExpert);
            this.Controls.Add(this.lblTezka);
            this.Controls.Add(this.lblStredni);
            this.Controls.Add(this.lblLehka);
            this.Controls.Add(this.deleteScore);
            this.Controls.Add(this.backToGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Scoreboard";
            this.Text = "scoreboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Scoreboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button backToGame;
        private System.Windows.Forms.Label lblLehka;
        private System.Windows.Forms.Label lblStredni;
        private System.Windows.Forms.Label lblTezka;
        private System.Windows.Forms.Label lblExpert;
        private System.Windows.Forms.Button deleteScore;
    }
}