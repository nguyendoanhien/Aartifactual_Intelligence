using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TACI____Difference_Position_
{
    class Program
    {
        static int n;
        static Khoi nguon;
        static Khoi dich;

        class Animal { }
        class Dog : Animal { }

        void PrintTypes(Animal a)
        {
            Console.WriteLine(a.GetType() == typeof(Animal)); // false 
            Console.WriteLine(a is Animal);                   // true 
            Console.WriteLine(a.GetType() == typeof(Dog));    // true
            Console.WriteLine(a is Dog);                      // true 
        }
        static void Main(string[] args)
        {
            object a = method1(null, 2);
            int b = method2<int>("123", 1);
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Input();
            //Console.WriteLine("----Nguồn----");
            //nguon.Xuat();
            //Console.WriteLine("----Đích----");
            //dich.Xuat();
            //Console.WriteLine("-----Bắt đầu-----");
            //nguon.IncreaseStep_OLD(nguon.Mang,dich,nguon.Target,nguon);
            //Console.WriteLine("----Solved----");
            //nguon.Xuat();
            Console.ReadLine();

        }

        static dynamic method1(object input, int type)
        {
            switch(type)
            {
                case 1: { return "123";  }
                case 2: { return int.Parse("123"); }
            }
            
            return input;
            
        }
        static T method2<T> (string name,int type)
        {
            T b = (T)Convert.ChangeType(name, typeof(T));
          

            return b;
        }

        static void Input()
        {     
            n = int.Parse(Console.ReadLine()); // Nhập n
            nguon = new Khoi(n,new string [n+1,n+1]); // (bỏ 0) và đi 1=>n
            dich = new Khoi(n,new string [n+1,n+1]);
             
            dich.ToDich();
            //nguon.ToNguon(dich);
            nguon.ToNguon_Example(dich);

        }
       
       

 


        
    }
}
