using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Projekt_Hledání_Min
{
    public partial class mainForm : Form
    {
        Scoreboard scoreboard = new Scoreboard();
        GameSetup gameSetup = new GameSetup();

        Button[,] btn = new Button[41, 41];
        
        //Vlastnosti tlačítek
        string[,] btnProp = new string[41, 41];
        string[,] savedBtnProp = new string[41, 41];
        Point coord;

        //Cesta k souborům
        string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "SeifertsMinesweeper");

        //Skoré
        int time;
        int bestMinutes;
        int bestSeconds;
        int wins;

        bool isNewHighScore;

        public mainForm()
        {
            InitializeComponent();
            difficultyBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Uloží rozehranou hru do textového souboru
        /// </summary>
        void SaveGame()
        {
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(savePath, "gameSave.txt")))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(gameSetup.Difficulty);
                    sb.AppendLine(gameSetup.Minutes.ToString());
                    sb.AppendLine(gameSetup.Seconds.ToString());

                    for (int i = 1; i <= gameSetup.Width; i++)
                    {
                        sb.AppendLine();
                        for (int j = 1; j <= gameSetup.Height; j++)
                            sb.Append(btnProp[j, i].ToString());
                    }

                    sb.AppendLine();

                    for (int i = 1; i <= gameSetup.Width; i++)
                    {
                        sb.AppendLine();
                        for (int j = 1; j <= gameSetup.Height; j++)
                            sb.Append(savedBtnProp[j, i].ToString());
                    }

                    sb.AppendLine();

                    for (int i = 1; i <= gameSetup.Height; i++)
                    {
                        sb.AppendLine();
                        for (int j = 1; j <= gameSetup.Width; j++)
                            if (btn[j, i].Enabled == true)
                                sb.Append("1");
                            else
                                sb.Append("0");
                    }
                    sw.Write(sb);
                    sw.Flush();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hru se nepodařilo uložit!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Načte rozehranou hru z textového souboru
        /// </summary>
        void LoadSavedGame()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(savePath, "gameSave.txt")))
                {
                    gameSetup.Difficulty = sr.ReadLine();
                    gameSetup.Minutes = int.Parse(sr.ReadLine());
                    gameSetup.Seconds = int.Parse(sr.ReadLine());

                    gameSetup.StartGame(secondsBox, minutesBox, remainingFlags, Size);
                    btn = gameSetup.CreateButtons(Controls, OneClick, RightClick, btnProp, savedBtnProp);
                    
                    for (int i = 1; i <= gameSetup.Width; i++)
                    {
                        sr.ReadLine();
                        for (int j = 1; j <= gameSetup.Height; j++)
                        {
                            btnProp[j, i] = Convert.ToChar(sr.Read()).ToString();
                            if (btnProp[j, i] == gameSetup.Flag_value)
                            {
                                btn[j, i].BackgroundImageLayout = ImageLayout.Stretch;
                                btn[j, i].BackgroundImage = Properties.Resources.flag;
                                gameSetup.Flags--;
                            }
                        }
                    }

                    sr.ReadLine();

                    for (int i = 1; i <= gameSetup.Width; i++)
                    {
                        sr.ReadLine();
                        for (int j = 1; j <= gameSetup.Height; j++)
                            savedBtnProp[j, i] = Convert.ToChar(sr.Read()).ToString();
                    }

                    sr.ReadLine();

                    for (int i = 1; i <= gameSetup.Height; i++)
                    {
                        sr.ReadLine();
                        for (int j = 1; j <= gameSetup.Width; j++)
                        {
                            if (sr.Read() == 48)
                                btn[j, i].Enabled = false;
                            else
                                btn[j, i].Enabled = true;

                            if (!btn[j, i].Enabled)
                            {
                                set_ButtonImage(j, i);
                            }
                        }
                    }
                }
                gameSetup.FirstClick = false;
                gameSetup.Gameover = false;
                minutesBox.Text = gameSetup.Minutes.ToString();
                secondsBox.Text = gameSetup.Seconds.ToString();
                timer.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Hru se nepodařilo načíst!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nastaví tlačítku obrázek
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void set_ButtonImage(int x, int y)
        {
            btn[x, y].Enabled = false;
            btn[x, y].BackgroundImageLayout = ImageLayout.Stretch;

            if (gameSetup.Gameover && btnProp[x, y] == gameSetup.Flag_value)
                btnProp[x, y] = savedBtnProp[x, y];

            if (gameSetup.Gameover)
                timer.Stop();

            switch (btnProp[x, y])
            {
                case "0":
                    btn[x, y].BackgroundImage = Properties.Resources.blank;
                    EmptySpace(x, y);
                    break;

                case "1":
                    btn[x, y].BackgroundImage = Properties.Resources._1;
                    break;

                case "2":
                    btn[x, y].BackgroundImage = Properties.Resources._2;
                    break;

                case "3":
                    btn[x, y].BackgroundImage = Properties.Resources._3;
                    break;

                case "4":
                    btn[x, y].BackgroundImage = Properties.Resources._4;
                    break;

                case "5":
                    btn[x, y].BackgroundImage = Properties.Resources._5;
                    break;

                case "6":
                    btn[x, y].BackgroundImage = Properties.Resources._6;
                    break;

                case "7":
                    btn[x, y].BackgroundImage = Properties.Resources._7;
                    break;

                case "8":
                    btn[x, y].BackgroundImage = Properties.Resources._8;
                    break;

                case "9":
                    btn[x, y].BackgroundImage = Properties.Resources.bmb;
                    if (!gameSetup.Gameover)
                        GameOver();
                    break;
            }
        }

        /// <summary>
        /// Zjistí zda jsou okolo prázdná tlačítka
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void EmptySpace(int x, int y)
        {
            if (btnProp[x, y] == "0")
                for (int i = 0; i < 8; i++)
                {
                    int cx = x + gameSetup.Dx8[i];
                    int cy = y + gameSetup.Dy8[i];

                    if (gameSetup.isPointOnMap(cx, cy) == 1)
                        if (btn[cx, cy].Enabled == true && btnProp[cx, cy] != "9" && !gameSetup.Gameover)
                        {
                            if (btnProp[cx, cy] == gameSetup.Flag_value)
                            {
                                btnProp[cx, cy] = savedBtnProp[cx, cy];
                                btn[cx, cy].Image = null;
                                gameSetup.Flags++;
                            }
                            set_ButtonImage(cx, cy);
                        }
                }
            remainingFlags.Text = "VLAJKY: " + gameSetup.Flags;
        }

        /// <summary>
        /// Odkryje hrací pole
        /// </summary>
        void Discover_Map()
        {
            for (int i = 1; i <= gameSetup.Width; i++)
                for (int j = 1; j <= gameSetup.Height; j++)
                    if (btn[i, j].Enabled == true)
                        set_ButtonImage(i, j);
        }

        /// <summary>
        /// Ukončí hru prohrou
        /// </summary>
        void GameOver()
        {
            gameSetup.Gameover = true;
            Discover_Map();
            MessageBox.Show("Prohrál jsi !");
        }

        /// <summary>
        /// Ukončí hru výhrou
        /// </summary>
        void WinGame()
        {
            gameSetup.Gameover = true;
            Discover_Map();
            time = gameSetup.Minutes * 60 + gameSetup.Seconds;
            remainingFlags.Text = "VLAJKY: 0";
            SaveWin();
            MessageBox.Show("Vyhrál jsi !");
        }

        /// <summary>
        /// Zjistí zda dolšlo k výhře
        /// </summary>
        void Check_ClickWin()
        {
            bool win = true;
            int buttonsEnabled = 0;
            for (int i = 1; i <= gameSetup.Width; i++)
                for (int j = 1; j <= gameSetup.Height; j++)
                    if (btn[i, j].Enabled == true)
                        buttonsEnabled++;
            if (buttonsEnabled != gameSetup.Mines)
                win = false;

            if (win)
                WinGame();
        }

        /// <summary>
        /// Provede se po stisknutí levého tlačítka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OneClick(object sender, EventArgs e)
        {
            coord = ((Button)sender).Location;
            int x = (coord.X - gameSetup.Start_x) / gameSetup.ButtonSize;
            int y = (coord.Y - gameSetup.Start_y) / gameSetup.ButtonSize;

            if (gameSetup.FirstClick)
            {
                gameSetup.FirstClick = false;
                gameSetup.Gameover = false;
                gameSetup.GenerateMap(x, y, btnProp, savedBtnProp);
                gameSetup.Mines = gameSetup.Flags;
                timer.Start();
            }

            if (btnProp[x, y] != gameSetup.Flag_value)
            {
                ((Button)sender).Enabled = false;
                ((Button)sender).Text = "";

                ((Button)sender).BackgroundImageLayout = ImageLayout.Stretch;

                set_ButtonImage(x, y);

                if (btnProp[x, y] != "9" && !gameSetup.Gameover)
                    Check_ClickWin();
            }
        }

        /// <summary>
        /// Po stisknutí, tlačítku nastaví a nebo zruší vlajku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                coord = ((Button)sender).Location;
                int x = (coord.X - gameSetup.Start_x) / gameSetup.ButtonSize;
                int y = (coord.Y - gameSetup.Start_y) / gameSetup.ButtonSize;

                if (btnProp[x, y] != gameSetup.Flag_value && gameSetup.Flags > 0)
                {
                    btn[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    btn[x, y].BackgroundImage = Properties.Resources.flag;
                    btnProp[x, y] = gameSetup.Flag_value;
                    gameSetup.Flags--;
                }
                else if (btnProp[x, y] == gameSetup.Flag_value)
                {
                    btnProp[x, y] = savedBtnProp[x, y];
                    btn[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    btn[x, y].BackgroundImage = null;
                    gameSetup.Flags++;
                }
                remainingFlags.Text = "VLAJKY: " + gameSetup.Flags;
            }
        }

        /// <summary>
        /// Zjistí zda došlo k novému nejlepšímu výsledku
        /// </summary>
        /// <returns></returns>
        bool IsNewHighScore()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(savePath, "scoreboard.txt")))
                {
                    while (true)
                    {
                        string text;
                        text = sr.ReadLine();
                        if (text != null)
                        {
                            string[] rozdeleno = text.Split(';');
                            string difficultyOfBestTime = rozdeleno[0];
                            bestMinutes = int.Parse(rozdeleno[1]);
                            bestSeconds = int.Parse(rozdeleno[2]);
                            wins = int.Parse(rozdeleno[3]);
                            if (gameSetup.Difficulty == difficultyOfBestTime && time < bestMinutes * 60 + bestSeconds)
                                return true;
                            else if (gameSetup.Difficulty == difficultyOfBestTime)
                                return false;
                        }
                        else
                            return true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Chyba při kontrole!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        /// <summary>
        /// Uloží nový nejlepší výsledek
        /// </summary>
        void SaveWin()
        {
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            if (!File.Exists(Path.Combine(savePath, "scoreboard.txt")))
                isNewHighScore = true;
            else
            {
                isNewHighScore = IsNewHighScore();

                var tempFile = Path.GetTempFileName();
                var linesToKeep = File.ReadLines(Path.Combine(savePath, "scoreboard.txt")).Where(l => l.Contains(gameSetup.Difficulty) == false);
                File.WriteAllLines(tempFile, linesToKeep);
                File.Delete(Path.Combine(savePath, "scoreboard.txt"));
                File.Move(tempFile, Path.Combine(savePath, "scoreboard.txt"));
            }

            if (isNewHighScore)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(Path.Combine(savePath, "scoreboard.txt"), true))
                    {
                        sw.WriteLine(gameSetup.Difficulty + @";" + gameSetup.Minutes + @";" + gameSetup.Seconds + @";" + ++wins);
                        sw.Flush();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Chyba při zápisu!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(Path.Combine(savePath, "scoreboard.txt"), true))
                    {
                        sw.WriteLine(gameSetup.Difficulty + @";" + bestMinutes + @";" + bestSeconds + @";" + ++wins);
                        sw.Flush();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Chyba při zápisu!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Otevře okno s nejlepšími výsledky
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Scoreboard_Click(object sender, EventArgs e)
        {
            scoreboard.ShowDialog();
        }

        /// <summary>
        /// Zjistí zda chce uživatel načíst rozehranou hru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult load = DialogResult.No;
            if (File.Exists(Path.Combine(savePath, "gameSave.txt")))
                load = MessageBox.Show("Chcete načíst uloženou hru?", "Načíst hru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (load == DialogResult.Yes)
                LoadSavedGame();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult save = DialogResult.No;
            if (!gameSetup.Gameover)
                save = MessageBox.Show("Chcete uložit rozehranou hru?", "Uložení hry", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (save == DialogResult.Yes)
            {
                time = gameSetup.Minutes * 60 + gameSetup.Seconds;
                SaveGame();
            }
        }

        /// <summary>
        /// Spustí hru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Play_Click(object sender, EventArgs e)
        {
            gameSetup.Difficulty = difficultyBox.Text;
            if (!gameSetup.FirstPlay)
                gameSetup.ResetGame(Controls, btn);
            gameSetup.StartGame(secondsBox, minutesBox, remainingFlags, Size);
            btn = gameSetup.CreateButtons(Controls, OneClick, RightClick, btnProp, savedBtnProp);
        }

        /// <summary>
        /// Počítá čas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            gameSetup.Seconds++;

            if (gameSetup.Seconds == 60)
            {
                gameSetup.Minutes++;
                gameSetup.Seconds = 0;
            }

            secondsBox.Text = gameSetup.Seconds.ToString();
            minutesBox.Text = gameSetup.Minutes.ToString();
        }
    }
}