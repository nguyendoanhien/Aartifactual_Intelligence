using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACI____Difference_Position_
{
    public class Khoi
    {
        int n;
        string[,] mang;
        Target target;
        int f;
        int g;
        int h;
        Khoi parent;
        public Khoi()
        {
            n = 0;
            mang = new string[0, 0];
            target = new Target();
            f = 0;
            g = 0;
            h = 0;
            parent = null;
        }
        public Khoi(Khoi another)
        {
            this.n = another.n;
            this.mang = CopyMang(another);
           
            this.target = another.target;
            this.f = another.f;
            this.g = another.g;
            this.h = another.h;
            this.parent = another.parent;
        }
        public Khoi(int n, string[,] mang)
        {
            this.n = n;
            this.mang = mang;
            this.target = new Target();
            f = 0;
            g = 0;
            h = 0;
        }

        public string[,] Mang { get => mang; set => mang = value; }
        public int N { get => n; set => n = value; }
        public Target Target { get => target; set => target = value; }
        public int F { get => f; set => f = value; }
        public int G { get => g; set => g = value; }
        public int H { get => h; set => h = value; }
        public Khoi Parent { get => parent; set => parent = value; }

        public void ToNguon(Khoi dich)
        {
            HashSet<string> randomList = new HashSet<string>();
            Random rd = new Random();
            while (randomList.Count != n * n - 1)          
                randomList.Add(rd.Next(n * n - 1) + 1 + "");
            

            int row_target = rd.Next(n)+1;
            int col_target = rd.Next(n)+1;
            target.X = row_target;
            target.Y = col_target;
            mang[row_target, col_target] = " ";
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                {
                    if (mang[i, j] != " ")
                    {
                        mang[i, j] = randomList.FirstOrDefault();
                        randomList.Remove(randomList.FirstOrDefault());
                    }
                }
            Initiate(dich);

        }
        public void ToNguon_Example(Khoi dich)
        {
            target.X = 3;
            target.Y = 2;
            mang[3, 2] = " ";
            mang[1, 1] = "2";
            mang[1, 2] = "8";
            mang[1, 3] = "3";
            mang[2, 1] = "1";
            mang[2, 2] = "6";
            mang[2, 3] = "4";
            mang[3, 1] = "7";
            mang[3, 3] = "5";

            //target.X = 2;
            //target.Y = 3;
            //mang[2, 3] = " ";
            //mang[1, 1] = "2";
            //mang[1, 2] = "6";
            //mang[1, 3] = "8";
            //mang[2, 1] = "7";
            //mang[2, 2] = "5";
            //mang[3, 2] = "1";
            //mang[3, 1] = "3";
            //mang[3, 3] = "4";

            //target.X = 3;
            //target.Y = 2;
            //mang[2, 3] = "4";
            //mang[1, 1] = "2";
            //mang[1, 2] = "8";
            //mang[1, 3] = "3";
            //mang[2, 1] = "1";
            //mang[2, 2] = "6";
            //mang[3, 2] = " ";
            //mang[3, 1] = "7";
            //mang[3, 3] = "5";
            Initiate(dich);
        }
        public void Initiate(Khoi dich)
        {
            h = Cal_H(dich);
            f = g + h;
        }
        public void ToDich()
        {
            int left = 1;
            int right = n;
            int top = 1;
            int bot = n;
            int so = 0;
            while (so != n * n)
            {
                Right(ref left, ref right, ref top, ref bot, ref so);
                Bot(ref left, ref right, ref top, ref bot, ref so);
                Left(ref left, ref right, ref top, ref bot, ref so);
                Top(ref left, ref right, ref top, ref bot, ref so);
            }
        }
        void Right(ref int left, ref int right, ref int top, ref int bot, ref int so)
        {

            for (int i = left; i <= right; i++)
            {
                if (so != n * n-1) mang[top, i] = ++so + "";
                else
                { mang[top, i] = " "; so++; }
            }
            top++;
        }
        void Bot(ref int left, ref int right, ref int top, ref int bot, ref int so)
        {
            for (int i = top; i <= bot && (so != n * n); i++)
                if (so != n * n-1) mang[i, right] = ++so + "";
                else
                { mang[i, right] = " "; so++; }
            right--;
        }
        void Left(ref int left, ref int right, ref int top, ref int bot, ref int so)
        {
            for (int i = right; i >= left; i--)
                if (so != n * n-1) mang[bot, i] = ++so + "";
                else
                { mang[bot, i] = " "; so++; }
            bot--;
        }
        void Top(ref int left, ref int right, ref int top, ref int bot, ref int so)
        {
            for (int i = bot; i >= top; i--)
                if (so != n * n-1) mang[i, left] = ++so + "";
                else
                { mang[i, left] = " "; so++; }
            left++;
        }


        public void Xuat()
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                    Console.Write(String.Format("{0,5}", mang[i, j]));
                Console.WriteLine();
            }
            Console.WriteLine($"g :{g} h:{h} f{f}");
        }

        public Khoi IncreaseStep_OLD(string[,] mang, Khoi dich, Target oldTarget,Khoi parent)
        {
          
            this.Xuat();


            if (h == 0) return this;

            
            Khoi minKhoi = new Khoi(this);

            int min_h = this.MinOfChild(mang, dich, target);

            Console.WriteLine("____________________________CON_________________________");
            foreach (Direction i in (Direction[])Enum.GetValues(typeof(Direction)))
            {
                Target nextTarget = target.NextTarget(i);
                if (nextTarget.Is_InsideKhoi(n) )
                {
                    
                    

                    Khoi nextKhoi = new Khoi(this);

                    nextKhoi.Swap(nextTarget);
                    nextKhoi.g = this.g + 1;
                    nextKhoi.h = nextKhoi.Cal_H(dich);
                    nextKhoi.f = nextKhoi.h + nextKhoi.g;

                    nextKhoi.Xuat();
                    if(nextKhoi.h==0) return nextKhoi.IncreaseStep_OLD(nextKhoi.mang, dich, this.target, minKhoi);
                    if (nextTarget.X != oldTarget.X || nextTarget.Y != oldTarget.Y)
                    {
                        int minOfChild = nextKhoi.MinOfChild(nextKhoi.mang, dich, nextKhoi.target);
                            if (minOfChild <= min_h)
                            {
                                min_h = minOfChild;
                                minKhoi = nextKhoi;
                            }
                    }

                }

            }
            
            Console.WriteLine("____________________________Over_________________________");

            
            return minKhoi.IncreaseStep_OLD(minKhoi.mang, dich, this.target,minKhoi);

        }
        public int MinOfChild(string[,] mang, Khoi dich, Target oldTarget)
        {


            
            HashSet<int> min = new HashSet<int>();

            foreach (Direction i in (Direction[])Enum.GetValues(typeof(Direction)))
            {
                Target nextTarget = target.NextTarget(i);
                if (nextTarget.Is_InsideKhoi(n) )
                {
                    Khoi nextKhoi = new Khoi(this);

                    nextKhoi.Swap(nextTarget);
                    nextKhoi.g = this.g + 1;
                    nextKhoi.h = nextKhoi.Cal_H(dich);
                    nextKhoi.f = nextKhoi.h + nextKhoi.g;
                    if(nextTarget.X != oldTarget.X || nextTarget.Y != oldTarget.Y)
                    min.Add(nextKhoi.h);     
                }

            }
            return min.Min();

        }
        public Khoi IncreaseStep(string[,] mang, Khoi dich, Target oldTarget)
            {
        

           
            h = Cal_H(dich);
            f = g + h;
            this.Xuat();
            g++;
            Console.WriteLine("____________");
            if (h == 0) return this;
            int min = int.MaxValue;
            Khoi minKhoi = new Khoi(this);
            foreach (Direction i in (Direction[])Enum.GetValues(typeof(Direction)))
            {
                Target nextTarget = target.NextTarget(i);
               
                if(nextTarget.Is_InsideKhoi(n))
                {
                
                    Console.WriteLine("___CON____");
                    Khoi nextKhoi = new Khoi(this);
                    nextKhoi.Swap(nextTarget);
                    nextKhoi.target = nextTarget;
                    nextKhoi.h = nextKhoi.Cal_H(dich);
                    nextKhoi.Xuat();
                    
                    if (nextKhoi.h < min&& !(nextTarget.X == oldTarget.X && nextTarget.Y == oldTarget.Y))
                    {
                        min = nextKhoi.H;
                        minKhoi = nextKhoi;
                                                
                    }

                }
             
            }
            Console.WriteLine("---END CON ___");

            return minKhoi.IncreaseStep(minKhoi.mang, dich , this.target);

        }

        public int Cal_H_Distance(Khoi dich)
        {
            int count = 0;
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                {
                    string valueNow = mang[i, j] + "";
                    count += Target.Step(this.GetPosition(valueNow), dich.GetPosition(valueNow));
                }
            return count;
        }

        public Target GetPosition(string value)
        {
            Target target = new Target();
            bool isBreak = false;
            for (int i = 1; i <= n && !isBreak; i++)
                for (int j = 1; j <= n && !isBreak; j++)
                    if(mang[i,j]==value)
                    {
                        target.X = i;
                        target.Y = j;
                        isBreak = true;
                    }
                    return target;
        }



        public void Swap(Target target)
        {
            string temp = mang[this.target.X, this.target.Y];
            mang[this.target.X, this.target.Y] = mang[target.X, target.Y];
            mang[target.X, target.Y] = temp;
            this.target = target;
        }
        public int Cal_H(Khoi dich)
        {
            int count = 0;
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                    if (mang[i, j] != dich.mang[i, j]&&mang[i,j]!=" ")
                        count++;
            return count;
        }
        public string [,] CopyMang(Khoi another)
        {
            string[,] kq = new string[another.n+1, another.n+1];
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                    kq[i, j] = another.mang[i, j];

            return kq;
        }
    }
}
