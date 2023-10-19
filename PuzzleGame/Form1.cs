using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PuzzleGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


//Zmienne
        // Okno i Obrazek
        private Bitmap FullWindow = null;
        private Bitmap piecesPicture = null;


        // T�o planszy
        private Bitmap Background = null;

        // Plansza.
        private Bitmap Board = null;

        // Puzzle.
        private List<Puzzle> Puzzles = null;

        // Zmienna kt�ra pozwala zmienia� poziom trudno�ci (startuje z �atwym)
        private int TargetSize = 200;

        // Ilo�� i Wielko��: Kolumn i Wierszy
        private int NumRows, NumCols, RowHgt, ColWid;

        // Puzzel kt�rym rusza gracz
        private Puzzle MovingPiece = null;
        private Point MovingPoint;

        // True je�li gra si� sko�czy�a
        private bool GameOver = true;

        // Wyj�cie
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Otwarcie Pliku
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {

            if (ofdPicture.ShowDialog() == DialogResult.OK)
            {

                LoadPicture(ofdPicture.FileName);
            }
        }
        //Wybor z zaproponowanych zdj�� 
        private void wybierzZNaszychToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                LoadPicture(form2.AppImage);
            }
        }
        private void CenterFormOnScreen()
        {
            // Pobranie g��wnego ekranu
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

            // Obliczenie pozycji wy�rodkowania
            int centerX = screenBounds.Left + (screenBounds.Width - this.Width) / 2;
            int centerY = screenBounds.Top + (screenBounds.Height - this.Height) / 2;

            // Ustawienie pozycji Form1
            this.Location = new Point(centerX, centerY);
        }
    
        // Za�adowanie zdj�cia podanego przez u�ytkownika i ustawienie okna
        private void LoadPicture(string filename)
        {
            try
            {              
                using (Bitmap bm = new Bitmap(ofdPicture.FileName))
                {
                  
                    //Przeskalowanie okna �eby mie�ci�o sie na ekranie 
                    float scalingFactor = Math.Min((float)Screen.PrimaryScreen.WorkingArea.Width * 3 / 4 / bm.Width,
                                                   (float)Screen.PrimaryScreen.WorkingArea.Height * 5 / 6 / bm.Height);

                    FullWindow = new Bitmap((int)(bm.Width * scalingFactor), (int)(bm.Height * scalingFactor));
                    piecesPicture = new Bitmap((int)(bm.Width * scalingFactor * 3 / 4), (int)(bm.Height * scalingFactor * 3 / 4));

                    using (Graphics gr = Graphics.FromImage(FullWindow))
                    {
                        gr.DrawImage(bm, 0, 0, FullWindow.Width * 3 / 4, FullWindow.Height * 3 / 4);
                    }
                    using (Graphics gr = Graphics.FromImage(piecesPicture))
                    {
                        gr.DrawImage(bm, 0, 0, piecesPicture.Width, piecesPicture.Height);
                    }
                }
                CreateBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Za�adowanie zdj�cia z mo�liwych do wyboru
        private void LoadPicture(System.Drawing.Image AppPic)
        {
            try
            {
                using (Bitmap bm = new Bitmap(AppPic))
                {

                    //Przeskalowanie okna �eby mie�ci�o sie na ekranie 
                    float scalingFactor = Math.Min((float)Screen.PrimaryScreen.WorkingArea.Width * 3 / 4 / bm.Width,
                                                   (float)Screen.PrimaryScreen.WorkingArea.Height * 5 / 6 / bm.Height);

                    FullWindow = new Bitmap((int)(bm.Width * scalingFactor), (int)(bm.Height * scalingFactor));
                    piecesPicture = new Bitmap((int)(bm.Width * scalingFactor * 3 / 4), (int)(bm.Height * scalingFactor * 3 / 4));

                    using (Graphics gr = Graphics.FromImage(FullWindow))
                    {
                        gr.DrawImage(bm, 0, 0, FullWindow.Width * 3 / 4, FullWindow.Height * 3 / 4);
                    }
                    using (Graphics gr = Graphics.FromImage(piecesPicture))
                    {
                        gr.DrawImage(bm, 0, 0, piecesPicture.Width, piecesPicture.Height);
                    }
                }
                CreateBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Stworzenie Bitmapy: Planszy i T�a
        private void CreateBitmap()
        {
            Background = new Bitmap(FullWindow.Width, FullWindow.Height);
            Board = new Bitmap(FullWindow.Width, FullWindow.Height);
            picPuzzle.Size = FullWindow.Size;
            picPuzzle.Image = Board;
            this.ClientSize = new Size(
                picPuzzle.Right + picPuzzle.Left,
                picPuzzle.Bottom + picPuzzle.Left);

            CenterFormOnScreen();
            // Rozpoczecie gry
            StartGame();
        }
        // Wyb�r poziomu
        private void mnuOptionsLevel_Click(object sender, EventArgs e)
        {
            // Je�li w menu jest wybrana opcja to pojawia sie znaczek 
            ToolStripMenuItem mnu = sender as ToolStripMenuItem;
            mnuOptionsEasy.Checked = (mnu == mnuOptionsEasy);
            mnuOptionsMedium.Checked = (mnu == mnuOptionsMedium);
            mnuOptionsHard.Checked = (mnu == mnuOptionsHard);

            // Pozwala uzyska� wielko�� puzzli
            TargetSize = int.Parse((string)mnu.Tag);


            StartGame();
        }

        // Rozpoczecie gry
        private void StartGame()
        {
            if (FullWindow == null) return;
            GameOver = false;

            // Dostosowuje wielko�� Puzzli
            NumRows = (piecesPicture.Height / TargetSize);
            RowHgt = (piecesPicture.Height / NumRows);
            NumCols = (piecesPicture.Width / TargetSize);
            ColWid = (piecesPicture.Width / NumCols);

            // Tworzy Puzzle
            Random rand = new Random();
            Puzzles = new List<Puzzle>();
            bool pieceXY = true;

            for (int row = 0; row < NumRows; row++)
            {
                int hgt = RowHgt;
                if (row == NumRows - 1) hgt = piecesPicture.Height - row * RowHgt;
                for (int col = 0; col < NumCols; col++)
                {
                    int wid = ColWid;
                    if (col == NumCols - 1) wid = piecesPicture.Width - col * ColWid;
                    Rectangle rect = new Rectangle(col * ColWid, row * RowHgt, wid, hgt);
                    Puzzle new_piece = new Puzzle(piecesPicture, rect);

                    // Randomowo umieszcza puzzle
                    if (pieceXY)
                    {
                       new_piece.CurrentLocation = new Rectangle(
                       rand.Next(piecesPicture.Width - wid / 2, FullWindow.Width - wid / 2),
                       rand.Next(0, piecesPicture.Height - hgt / 2),
                       wid, hgt);

                        pieceXY = false;
                    }
                    else
                    {
                       new_piece.CurrentLocation = new Rectangle(
                       rand.Next(0, FullWindow.Width - wid / 2),
                       rand.Next(piecesPicture.Height - hgt / 2, FullWindow.Height - hgt / 2),
                       wid, hgt);

                        pieceXY = true;
                    }

                    // Dodaje Puzzle do kolekcji
                    Puzzles.Add(new_piece);

                }
            }

            // Tworzy T�o
            MakeBackground();

            // Tworzy Plansze
            DrawBoard();
        }

        // Tworzenie t�a
        private void MakeBackground()
        {
            using (Graphics gr = Graphics.FromImage(Background))
            {
                gr.Clear(picPuzzle.BackColor);


                // Ustawia przezroczysto�� zdj�cia kt�re s�u�y nam jak� pomoc w uk�adaniu (zdj�cie w tle)
                ImageAttributes imageAttributes = new ImageAttributes();
                float[][] colorMatrixElements = {
            new float[] {1, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, 0.5f, 0},
            new float[] {0, 0, 0, 0, 1}};
                ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
                imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // Rysuje zdj�cie w t�e
                gr.DrawImage(FullWindow, new Rectangle(0, 0, picPuzzle.Width, picPuzzle.Height), 0, 0, FullWindow.Width, FullWindow.Height, GraphicsUnit.Pixel, imageAttributes);

                // Rysuje siatke na tle
                DrawGrid(gr);

                // Tworzy Puzzle
                DrawPieces(gr);
            }

            picPuzzle.Visible = true;
            picPuzzle.Refresh();
        }
        // Rysuje siatke na tle
        private void DrawGrid(Graphics gr)
        {
            using (Pen thick_pen = new Pen(Color.DarkGray, 4))
            {
                for (int y = 0; y <= piecesPicture.Height; y += RowHgt)
                {
                    gr.DrawLine(thick_pen, 0, y, piecesPicture.Width, y);
                }
                gr.DrawLine(thick_pen, 0, piecesPicture.Height, piecesPicture.Width, piecesPicture.Height);

                for (int x = 0; x <= piecesPicture.Width; x += ColWid)
                {
                    gr.DrawLine(thick_pen, x, 0, x, piecesPicture.Height);
                }
                gr.DrawLine(thick_pen, piecesPicture.Width, 0, piecesPicture.Width, piecesPicture.Height);
            }
        }

        // Tworzy Puzzle
        private void DrawPieces(Graphics gr)
        {

            using (Pen white_pen = new Pen(Color.White, 3))
            {
                using (Pen black_pen = new Pen(Color.Black, 3))
                {
                    foreach (Puzzle piece in Puzzles)
                    {
                        //Je�li ruszamy puzzlem to nie rysuje go w tle
                        if (piece != MovingPiece)
                        {
                            gr.DrawImage(piecesPicture,
                                piece.CurrentLocation,
                                piece.HomeLocation,
                                GraphicsUnit.Pixel);
                            if (!GameOver)
                            {
                                if (piece.IsHome())
                                {
                                   
                                    // Rysuje zablokowane Puzzle z bia�ym obramowaniem
                                    gr.DrawRectangle(white_pen, piece.CurrentLocation);
                                }
                                else
                                {
                                   
                                    // Rysuje Puzzle z czarnym obramowaniem
                                    gr.DrawRectangle(black_pen, piece.CurrentLocation);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Rysuje plansze
        private void DrawBoard()
        {
            using (Graphics gr = Graphics.FromImage(Board))
            {


                //jak zmienimy poziom trudno�ci to pozwala zresetowa� t�o
                gr.DrawImage(Background, 0, 0, Background.Width, Background.Height);

                // Rysuje ruszaj�cego si� Puzzla
                if (MovingPiece != null)
                {
                    gr.DrawImage(FullWindow,
                        MovingPiece.CurrentLocation,
                        MovingPiece.HomeLocation,
                        GraphicsUnit.Pixel);

                    using (Pen blue_pen = new Pen(Color.Blue, 4))
                    {
                        gr.DrawRectangle(blue_pen, MovingPiece.CurrentLocation);
                    }
                }
            }

            picPuzzle.Visible = true;
            picPuzzle.Refresh();
        }


        // Pocz�tek ruszania puzzlem
        private void picPuzzle_MouseDown(object sender, MouseEventArgs e)
        {
            // Sprawdza kt�ry puzzel zawiera punkt myszy, pomija zablokowane puzzle 
            MovingPiece = null;
            foreach (Puzzle piece in Puzzles)
            {
                if (!piece.IsHome() && piece.Contains(e.Location))
                    MovingPiece = piece;
            }
            if (MovingPiece == null) return;

            // Zapis miejsca
            MovingPoint = e.Location;

            // Bierze puzzla nad inne
            Puzzles.Remove(MovingPiece);
            Puzzles.Add(MovingPiece);

            
            MakeBackground();
            DrawBoard();
        }

        // Ruch wybranego puzzla
        private void picPuzzle_MouseMove(object sender, MouseEventArgs e)
        {
            if (MovingPiece == null) return;
   
            // Ruch
            int dx = e.X - MovingPoint.X;
            int dy = e.Y - MovingPoint.Y;
            MovingPiece.CurrentLocation.X += dx;
            MovingPiece.CurrentLocation.Y += dy;

            //Blokada przed wyj�ciem lewa �ciana
            if (MovingPiece.CurrentLocation.X < 0)
            {
                MovingPiece.CurrentLocation.X = 0;
            }
            //Blokada przed wyj�ciem prawo
            if (MovingPiece.CurrentLocation.X >=  FullWindow.Width - ColWid)
            {
                MovingPiece.CurrentLocation.X = FullWindow.Width - ColWid;
            }
            //Blokada przed wyj�ciem g�ra
            if (MovingPiece.CurrentLocation.Y < 0)
            {
                MovingPiece.CurrentLocation.Y = 0;
            }
            //Blokada przed wyj�ciem d�
            if (MovingPiece.CurrentLocation.Y > FullWindow.Height - RowHgt)
            {
                MovingPiece.CurrentLocation.Y = FullWindow.Height - RowHgt;
            }
            // Zapis nowego miejsca myszy
            MovingPoint = e.Location;
            
            DrawBoard();
        }

        // Zatrzymuje Puzzla i sprawdza czy pasuje w dane miejsce
        private void picPuzzle_MouseUp(object sender, MouseEventArgs e)
        {
            if (MovingPiece == null) return;

            // Sprawdza czy puzzel jest w odpowiednim miejscu
            if (MovingPiece.SnapToHome())
            {
                // Przesuwa puzzla na d�
                Puzzles.Remove(MovingPiece);
                Puzzles.Reverse();
                Puzzles.Add(MovingPiece);
                Puzzles.Reverse();

                // Sprawdza czy u�o�y�e� wszystkie puzzle
                GameOver = true;
                foreach (Puzzle piece in Puzzles)
                {
                    if (!piece.IsHome())
                    {
                        GameOver = false;
                        break;
                    }
                }
            }

            // Zatrzymuje ruch puzzla
            MovingPiece = null;

            MakeBackground();
            DrawBoard();
        }
    }
}