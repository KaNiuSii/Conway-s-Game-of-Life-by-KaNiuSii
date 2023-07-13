using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Drawing;

namespace ConsoleApp1
{
    class GameScreen
    { 
        private ConsoleColor altColor = ConsoleColor.Magenta;
        private ConsoleColor mainColor = ConsoleColor.White;
        private ConsoleColor cellColor = ConsoleColor.White;
        private int width, height;
        public Cell[,] cells;

        public GameScreen(int width, int height)
        {
            Width = width;
            Height = height;
            cells = new Cell[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells[i, j] = new Cell(i, j);
                }
            }
        }
        public ConsoleColor AltColor
        {
            get { return altColor; }
            set { altColor = value; }
        }
        public ConsoleColor CellColor
        {
            get { return cellColor; }
            set { cellColor = value; }
        }
        public ConsoleColor MainColor
        {
            get { return mainColor; }
            set { mainColor = value; }
        }
        public int Width
        {
            get { return width; }
            set
            {
                if (value < 1)
                    value = 1;
                width = value;
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                if (value < 1)
                    value = 1;
                height = value;
            }
        }
        public void BasicTheme()
        {
            AltColor = ConsoleColor.Magenta;
            MainColor = ConsoleColor.White;
            CellColor = ConsoleColor.White;
        }
        public void RGBTheme()
        {
            AltColor = ConsoleColor.Red;
            MainColor = ConsoleColor.Green;
            CellColor = ConsoleColor.Blue;
        }
        public void NatureTheme()
        {
            AltColor = ConsoleColor.Cyan;
            MainColor = ConsoleColor.Green;
            CellColor = ConsoleColor.Gray;
        }
        public void RoyalTheme()
        {
            AltColor = ConsoleColor.Yellow;
            MainColor = ConsoleColor.Magenta;
            CellColor = ConsoleColor.Gray;
        }
        public void ChangeCell(int y, int x)
        {
            if (cells[y, x].Alive) cells[y, x].Next = false;
            else cells[y, x].Next = true;
            cells[y, x].UpdateState();
        }
        public void AnimationScreen(int framesCount, int framesSpeed)
        {
            for(int i = 0; i < framesCount; i++)
            {
                NextFrame();
                Console.WriteLine($"\nFrame {i + 1}/{framesCount}");
                Thread.Sleep(framesSpeed);
            }
        }
        public void ShuffleScreen(int howMany)
        {
            Random rnd = new Random();
            for (int i = 0; i < howMany; i++)
            {
                int x = rnd.Next(Width);
                int y = rnd.Next(Height);
                cells[y, x].Next = true;
                cells[y, x].UpdateState();
            }
        }
        public void NextFrame()
        {
            Console.Clear();
            UpdateNext();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    cells[i, j].UpdateState();
                }
            }
            Console.Clear();
            DisplayScreen();
        }

        public void DisplayScreen()
        {
            bool colourSwitch = false;
            Console.ForegroundColor = CellColor;
            Console.Write("Y");
            Console.Write("\\");
            Console.Write("X");
            for (int j = 0; j < Width; j++)
            {
                if (colourSwitch)
                    Console.ForegroundColor = AltColor;
                else
                    Console.ForegroundColor = MainColor;
                Console.Write($"{j,2}");
                colourSwitch = !colourSwitch;
            }
            Console.Write("\n");
            colourSwitch = false;
            for (int i = 0; i < Height; i++)
            {
                if (colourSwitch)
                    Console.ForegroundColor = AltColor;
                else
                    Console.ForegroundColor = MainColor;
                Console.Write($"{i,2}|");
                for (int j = 0; j < Width; j++)
                {
                    Console.ForegroundColor = CellColor;
                    cells[i,j].DisplayItSelf();
                }
                Console.Write("\n");
                colourSwitch = !colourSwitch;
            }
        }
        public void ResetScreen()
        {
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    cells[i, j].Alive = false;
                    cells[i, j].Next = false;
                }
            }
            Console.Clear();
            DisplayScreen();
        }
        private void UpdateNext()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int neighbourCount = NeighbourSum(cells[i, j]);
                    if (neighbourCount < 2 || neighbourCount > 3)
                    {
                        cells[i, j].Next = false;
                    }
                    else if (neighbourCount == 3 && !cells[i, j].Alive)
                    {
                        cells[i, j].Next = true;
                    }
                    else
                    {
                        cells[i, j].Next = cells[i, j].Alive;
                    }
                }
            }
        }

        private int NeighbourSum(Cell mine)
        {
            int x = mine.Y, y = mine.X;
            int sum = 0;
            for (int row = y - 1; row <= y + 1; row++)
            {
                if (row < 0 || row >= Height) continue;
                for (int col = x - 1; col <= x + 1; col++)
                {
                    if (col < 0 || col >= Width) continue;
                    if (col == x && row == y) continue; // skip the current cell
                    if (cells[row, col].Alive) sum++;
                }
            }
            return sum;
        }





    }
}
