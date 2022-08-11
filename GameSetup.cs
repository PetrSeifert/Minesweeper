using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Projekt_Hledání_Min
{
    class GameSetup
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Mines { get; set; }
        public int Flags { get; set; }
        public bool FirstPlay { get; set; }
        public bool Gameover { get; set; }

        public bool FirstClick { get; set; }

        //Obtížnost
        public string Difficulty { get; set; }

        //Body okolo
        public int[] Dx8 {get; set; }
        public int[] Dy8 { get; set; }

        int[] dy8 = { 0, 1, 0, -1, 1, -1, 1, -1 };
        int[] dx8 = {1, 0, -1, 0, 1, -1, -1, 1}; 


        //Pozice tabulky
        public int Start_x { get; set; }
        public int Start_y { get; set; }

        //Proměnné hry
        public string Flag_value
        {
            get => "f";
        }

        //Tlačítko
        public int ButtonSize { get; set; }

        //Koeficienti pro obtížnost
        const double easyCoef = 0.1f;
        const double mediumCoef = 0.12f;
        const double hardCoef = 0.14f;
        const double expertCoef = 0.16f;

        //Čas
        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public GameSetup()
        {
            Dx8 = dx8;
            Dy8 = dy8;
            FirstPlay = true;
            FirstClick = true;
            Gameover = true;
        }
        /// <summary>
        /// Zahájí hru
        /// </summary>
        public void StartGame(Control secondsBox, Control minutesBox, Control remainingFlags, Size size)
        {
            SetupTable();
            TableMargins(size);
            Flags = Mines;
            FirstPlay = false;

            secondsBox.Text = Seconds.ToString();
            minutesBox.Text = Minutes.ToString();
            remainingFlags.Text = "VLAJKY: " + Flags;

        }


        /// <summary>
        /// Připraví vše pro novou hru
        /// </summary>
        public void ResetGame(Control.ControlCollection Controls, Button[,] btn)
        {
            for (int i = 1; i <= Height; i++)
                for (int j = 1; j <= Width; j++)
                    Controls.Remove(btn[i, j]);
            FirstClick = true;
            Seconds = 0;
            Minutes = 0;
        }

        /// <summary>
        /// Vypočítá pozici tabulky
        /// </summary>
        public void TableMargins(Size size)
        {
            Start_x = (size.Width - (Width + 2) * ButtonSize) / 2;
            Start_y = (size.Height - (Height + 2) * ButtonSize) / 2 - 20;
        }

        /// <summary>
        /// Nastaví vzhled herního pole
        /// </summary>
        public void SetupTable()
        {
            switch (Difficulty)
            {
                case "LEHKÁ":
                    Height = 15;
                    Width = 15;
                    Mines = (int)(Height * Width * easyCoef);
                    ButtonSize = 48;
                    break;

                case "STŘEDNÍ":
                    Height = 20;
                    Width = 20;
                    Mines = (int)(Height * Width * mediumCoef);
                    ButtonSize = 36;
                    break;

                case "TĚŽKÁ":
                    Height = 25;
                    Width = 25;
                    Mines = (int)(Height * Width * hardCoef);
                    ButtonSize = 28;
                    break;

                case "EXPERT":
                    Height = 30;
                    Width = 30;
                    Mines = (int)(Height * Width * expertCoef);
                    ButtonSize = 24;
                    break;
            }
        }

        /// <summary>
        /// Vytvoří hrací pole
        /// </summary>
        public Button[,] CreateButtons(Control.ControlCollection Controls, Action<object, EventArgs> OneClick, Action<object, MouseEventArgs> RightClick, string[,] btnProp, string[,] savedBtnProp)
        {
            Button[,] btn = new Button[Height + 1, Width + 1];
            for (int i = 1; i <= Height; i++)
                for (int j = 1; j <= Width; j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].SetBounds(i * ButtonSize + Start_x, j * ButtonSize + Start_y, ButtonSize, ButtonSize);
                    btn[i, j].Click += new EventHandler(OneClick);
                    btn[i, j].MouseUp += new MouseEventHandler(RightClick);
                    btnProp[i, j] = "0";
                    savedBtnProp[i, j] = "0";
                    btn[i, j].TabStop = false;
                    btn[i, j].UseVisualStyleBackColor = true;
                    btn[i, j].Anchor = AnchorStyles.None;
                    Controls.Add(btn[i, j]);
                }
            return btn;
        }

        /// <summary>
        /// Nastaví tlačítkům vlastnosti
        /// </summary>
        /// <param name="clickX"></param>
        /// <param name="clickY"></param>
        public void GenerateMap(int clickX, int clickY, string[,] btnProp, string[,] savedBtnProp)
        {
            Random rand = new Random();
            List<int> coordx = new List<int>();
            List<int> coordy = new List<int>();

            while (Mines > 0)
            {
                coordx.Clear();
                coordy.Clear();

                for (int i = 1; i <= Height; i++)
                    for (int j = 1; j <= Width; j++)
                        if (btnProp[i, j] != "9" && i != clickX && j != clickY)
                        {
                            coordx.Add(i);
                            coordy.Add(j);
                        }

                int randNum = rand.Next(0, coordx.Count);
                btnProp[coordx[randNum], coordy[randNum]] = "9";
                savedBtnProp[coordx[randNum], coordy[randNum]] = "9";
                Mines--;
            }
            SetMapNumbers(Width, Height, btnProp, savedBtnProp);
        }

        /// <summary>
        /// Nastaví tlačítku vlastnost podle počtu bomb v okolí
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetMapNumbers(int x, int y, string[,] btnProp, string[,] savedBtnProp)
        {
            for (int i = 1; i <= x; i++)
                for (int j = 1; j <= y; j++)
                    if (btnProp[i, j] != "9")
                    {
                        btnProp[i, j] = MinesAround(i, j, btnProp);
                        savedBtnProp[i, j] = MinesAround(i, j, btnProp);
                    }
        }

        /// <summary>
        /// Zjistí kolik je o kolo políčka bomb
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private string MinesAround(int x, int y, string[,] btnProp)
        {
            int score = 0;
            for (int i = 0; i < 8; i++)
            {
                int cx = x + dx8[i];
                int cy = y + dy8[i];

                if (isPointOnMap(cx, cy) == 1 && btnProp[cx, cy] == "9")
                    score++;
            }
            return score.ToString();
        }

        /// <summary>
        /// Zjistí zda se bod nachází na hracím poli
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int isPointOnMap(int x, int y)
        {
            if (x < 1 || x > Width || y < 1 || y > Height)
                return 0;
            return 1;
        }
    }
}