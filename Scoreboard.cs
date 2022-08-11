using System;
using System.IO;
using System.Windows.Forms;

namespace Projekt_Hledání_Min
{
    public partial class Scoreboard : Form
    {
        string text;

        //Cesta k souborům
        string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "SeifertsMinesweeper");

        public Scoreboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Vratí okno s hrou
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToGame_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Načte nejlepší výsledky
        /// </summary>
        void LoadBestTimes()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(savePath, "scoreboard.txt")))
                {
                    while ((text = sr.ReadLine()) != null)
                    {
                        string[] rozdeleno = text.Split(';');
                        string difficultyOfBestTime = rozdeleno[0];
                        int bestMinutes = int.Parse(rozdeleno[1]);
                        int bestSeconds = int.Parse(rozdeleno[2]);
                        int wins = int.Parse(rozdeleno[3]);
                        switch (difficultyOfBestTime)
                        {
                            case "LEHKÁ":
                                lblLehka.Text = difficultyOfBestTime + " - " + bestMinutes + ":" + bestSeconds +
                                                "  Výhry:" + wins;
                                break;

                            case "STŘEDNÍ":
                                lblStredni.Text = difficultyOfBestTime + " - " + bestMinutes + ":" + bestSeconds +
                                                  "  Výhry:" + wins;
                                break;

                            case "TĚŽKÁ":
                                lblTezka.Text = difficultyOfBestTime + " - " + bestMinutes + ":" + bestSeconds +
                                                "  Výhry:" + wins;
                                break;

                            case "EXPERT":
                                lblExpert.Text = difficultyOfBestTime + " - " + bestMinutes + ":" + bestSeconds +
                                                 "  Výhry:" + wins;
                                break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Něco se pokazilo!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Scoreboard_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
                using (StreamWriter sw = File.CreateText(Path.Combine(savePath, "scoreboard.txt"))) { };
            }
            LoadBestTimes();
        }

        /// <summary>
        /// Zjistí zda chcete smazat výsledky
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteScore_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Opravdu chcete vymazat skoré?", "Upozornění",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
                DeleteScore();
        }

        /// <summary>
        /// Smaže výsledky
        /// </summary>
        private void DeleteScore()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(savePath, "scoreboard.txt")))
                {
                    sw.WriteLine("LEHKÁ;999;99;0");
                    sw.WriteLine("STŘEDNÍ;999;99;0");
                    sw.WriteLine("TĚŽKÁ;999;99;0");
                    sw.WriteLine("EXPERT;999;99;0");
                    sw.Flush();
                }

                LoadBestTimes();
            }
            catch (Exception)
            {
                MessageBox.Show("Něco se pokazilo!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
}
}
