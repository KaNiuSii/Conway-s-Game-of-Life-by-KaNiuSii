using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Cell
    {
        private int x, y;
        private bool alive;
        private bool next;
        public Cell(int x, int y) 
        {
            X = x;
            Y = y;
            Alive = alive;
            Next = next;
            Alive = false;
            Next = false;
            
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }
        public bool Next
        {
            get { return next; }
            set { next = value; }
        }
        public void DisplayItSelf()
        {
            Console.Write(this.Alive ? "██" : "  ");
        }

        public void UpdateState()
        {
            if(Next)
            {
                Alive = true; 
                Next = false;
            }
            else
            {
                Alive = false;
                Next = false;
            }
        }

    }
}
