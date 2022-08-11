namespace Projekt_Hledání_Min
{
    partial class mainForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.remainingFlags = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.minutesBox = new System.Windows.Forms.TextBox();
            this.secondsBox = new System.Windows.Forms.TextBox();
            this.difficultyBox = new System.Windows.Forms.ComboBox();
            this.Play = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Scoreboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // remainingFlags
            // 
            this.remainingFlags.AutoSize = true;
            this.remainingFlags.BackColor = System.Drawing.Color.PaleTurquoise;
            this.remainingFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.remainingFlags.Location = new System.Drawing.Point(12, 9);
            this.remainingFlags.Name = "remainingFlags";
            this.remainingFlags.Size = new System.Drawing.Size(80, 20);
            this.remainingFlags.TabIndex = 0;
            this.remainingFlags.Text = "VLAJKY:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.PaleTurquoise;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTime.Location = new System.Drawing.Point(187, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(45, 20);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "ČAS";
            // 
            // minutesBox
            // 
            this.minutesBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.minutesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minutesBox.Enabled = false;
            this.minutesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.minutesBox.ForeColor = System.Drawing.Color.Red;
            this.minutesBox.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.minutesBox.Location = new System.Drawing.Point(158, 39);
            this.minutesBox.Name = "minutesBox";
            this.minutesBox.ReadOnly = true;
            this.minutesBox.Size = new System.Drawing.Size(38, 22);
            this.minutesBox.TabIndex = 2;
            this.minutesBox.Text = "0";
            this.minutesBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // secondsBox
            // 
            this.secondsBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.secondsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondsBox.Enabled = false;
            this.secondsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.secondsBox.ForeColor = System.Drawing.Color.Red;
            this.secondsBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.secondsBox.Location = new System.Drawing.Point(226, 39);
            this.secondsBox.Name = "secondsBox";
            this.secondsBox.ReadOnly = true;
            this.secondsBox.Size = new System.Drawing.Size(38, 22);
            this.secondsBox.TabIndex = 3;
            this.secondsBox.Text = "0";
            this.secondsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // difficultyBox
            // 
            this.difficultyBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.difficultyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficultyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.difficultyBox.FormattingEnabled = true;
            this.difficultyBox.Items.AddRange(new object[] {
            "LEHKÁ",
            "STŘEDNÍ",
            "TĚŽKÁ",
            "EXPERT"});
            this.difficultyBox.Location = new System.Drawing.Point(1213, 12);
            this.difficultyBox.Name = "difficultyBox";
            this.difficultyBox.Size = new System.Drawing.Size(121, 24);
            this.difficultyBox.TabIndex = 4;
            // 
            // Play
            // 
            this.Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Play.Location = new System.Drawing.Point(1212, 42);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(121, 38);
            this.Play.TabIndex = 6;
            this.Play.Text = "HRÁT";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(202, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(1094, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "OBTÍŽNOST:";
            // 
            // Scoreboard
            // 
            this.Scoreboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Scoreboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Scoreboard.Location = new System.Drawing.Point(1212, 86);
            this.Scoreboard.Name = "Scoreboard";
            this.Scoreboard.Size = new System.Drawing.Size(120, 50);
            this.Scoreboard.TabIndex = 12;
            this.Scoreboard.Text = "NEJLEPŠÍ VÝSLEDKY";
            this.Scoreboard.UseVisualStyleBackColor = true;
            this.Scoreboard.Click += new System.EventHandler(this.Scoreboard_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1346, 725);
            this.Controls.Add(this.Scoreboard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.difficultyBox);
            this.Controls.Add(this.secondsBox);
            this.Controls.Add(this.minutesBox);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.remainingFlags);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1920, 0);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hledání min";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label remainingFlags;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TextBox minutesBox;
        private System.Windows.Forms.TextBox secondsBox;
        private System.Windows.Forms.ComboBox difficultyBox;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Scoreboard;
        public System.Windows.Forms.Timer timer;
    }
}

