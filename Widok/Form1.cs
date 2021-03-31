using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using ZajeciaGra;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Widok
{
    public partial class Form1 : Form
    {
        private Gra _gra = null;
        private Keys _klawisz = Keys.None;
        private uint _ticki = 0;
        private bool _wDol = false;
        private readonly SolidBrush _brush = new SolidBrush(Color.Red);
        private readonly PictureBox[,] _kratki = new PictureBox[12, 10];
        private readonly PictureBox[,] _klocek = new PictureBox[5, 5];

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            GeneratePictureBoxes();
            GeneratePictureBoxNextKloc();
            LabelStyl();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _gra = new Gra();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!_gra.Zyje)
            {
                timer1.Enabled = false;
                KoniecGry();
            }
            _wDol = false;
            _ticki++;
            if (_ticki > 9)
            {
                _ticki = 0;
                _wDol = true;
                
            }
            _gra.Klatka(_klawisz, _wDol);
            AktualizujLabelPunktow();
            Odswiez();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _klawisz = e.KeyCode;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _klawisz = Keys.None;
        }

        private void GeneratePictureBoxes()
        {
            var size = 30;
            for (int i = 0; i < _kratki.GetLength(0); i++)
            {
                for (int j = 0; j < _kratki.GetLength(1); j++)
                {
                    var pb = new PictureBox()
                    {
                        Size = new Size(size, size),
                        Location = new Point(size + j * size, size + i * size),
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    _kratki[i, j] = pb;
                    Controls.Add(pb);
                }
            }
        }

        private void GeneratePictureBoxNextKloc()
        {
            var size = 30;
            for (int i = 0; i < _klocek.GetLength(0); i++)
            {
                for (int j = 0; j < _klocek.GetLength(1); j++)
                {
                    var pb1 = new PictureBox()
                    {
                        Size = new Size(size, size),
                        Location = new Point(size + j * size + nextKloc.Location.X, size + i * size + nextKloc.Location.Y),
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    _klocek[i, j] = pb1;
                    Controls.Add(pb1);
                }
            }
        }

        private void Odswiez()
        {
            for (int i = 0; i < _gra.Plansza1.Wymiary.GetLength(0); i++)
            {
                for (int j = 0; j < _gra.Plansza1.Wymiary.GetLength(1); j++)
                {
                    if (_gra.Plansza1.Wymiary[i, j] != 0)
                    {
                        _kratki[i, j].BackColor = Color.Red;
                    }
                    else
                    {
                        _kratki[i, j].BackColor = Color.White;
                    }
                }
            }
            for (int i = 0; i < _klocek.GetLength(0); i++)
            {
                for (int j = 0; j < _klocek.GetLength(1); j++)
                {
                    if (i < _gra.nastepnyKlocek.Width && j < _gra.nastepnyKlocek.Height && _gra.nastepnyKlocek.shape[i, j] != 0)
                    {
                        _klocek[i, j].BackColor = Color.Red;
                    }
                    else
                    {
                        _klocek[i, j].BackColor = Color.White;
                    }
                }
            }
        }

        private void LabelStyl()
        {
            labelMan.BackColor = Color.White;
            labelMan.ForeColor = Color.Black;
            labelMan.Text = "Instrukcja";
            labelMan.Font = new Font("Georgia", 14);
            labelMan.Location = new Point(390, 35);
            labelMan.BorderStyle = BorderStyle.FixedSingle;

            manual.BackColor = Color.White;
            manual.ForeColor = Color.Black;
            manual.Text = "strzałka do góry - obrót klocka o 90 stopni w lewo\nstrzałka na dół - obrót klocka o 90 stopni w prawo\nstrzałka w lewo - przesunięcie klocka o jedno miejsce w lewo\nstrzałka w prawo - przesunięcie o jedno miejsce w prawo\n";
            manual.Font = new Font("Georgia", 8);
            manual.Location = new Point(390, 70);
            manual.BorderStyle = BorderStyle.FixedSingle;

            labelPunkty.BackColor = Color.White;
            labelPunkty.ForeColor = Color.Black;
            labelPunkty.Text = "Punkty";
            labelPunkty.Font = new Font("Georgia", 14);
            labelPunkty.Location = new Point(390, 140);
            labelPunkty.BorderStyle = BorderStyle.FixedSingle;

            punktyLabel.BackColor = Color.White;
            punktyLabel.ForeColor = Color.Black;
            punktyLabel.Font = new Font("Georgia", 10);
            punktyLabel.BorderStyle = BorderStyle.FixedSingle;

            klocLabel.BackColor = Color.White;
            klocLabel.ForeColor = Color.Black;
            klocLabel.Text = "Następny klocek";
            klocLabel.Font = new Font("Georgia", 14);
            klocLabel.Location = new Point(390, 205);
            klocLabel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void AktualizujLabelPunktow()
        {
            punktyLabel.Text = $@"{_gra.Wynik}";
        }

        private void KoniecGry()
        {
            MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Twój wynik to "+_gra.Wynik+"\n Czy chciałbyś zagrać jeszcze?", "Koniec gry", (MessageBoxButtons)MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _gra.RestartGry();
                    timer1.Enabled = true;
                    break;
                case MessageBoxResult.No:
                    this.Close();
                    break;
                case MessageBoxResult.Cancel:
                    this.Close();
                    break;
            }
        }

       
    }
}