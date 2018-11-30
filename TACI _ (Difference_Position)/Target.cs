using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACI____Difference_Position_
{
    public class Target
    {
        int x;
        int y;

        public Target()
        {
            x = 0;
            y = 0;
        }
        public Target (Target other)
        {
            this.x = other.x;
            this.y = other.y;
        }
        public Target(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public bool Is_InsideKhoi(int n)
        {
            return (x >= 1 && x <= n && y >= 1 && y <= n);
        }

        public Target NextTarget(Direction direction)
        {
            Target next = new Target(this);
                
            switch (direction)
            {
                case Direction.m_top:
                    {
                        next.X =this.X - 1;
                        break;
                    }
                case Direction.m_right:
                    {
                        next.Y = this.Y + 1;
                        break;
                    }
                case Direction.m_bot:
                    {
                        next.X = this.X + 1;
                        break;
                    }
                case Direction.m_left:
                    {
                        next.Y = this.Y - 1;
                        break;
                    }
            }
            return next;
        }

        public static int Step (Target a,Target b)
        {
            return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
        }
    }
}
