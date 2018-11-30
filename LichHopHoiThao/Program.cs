using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections;
namespace ConAp
{

    class Program
    {
        static int nPart;
        static List<List<string>> violateSetCollections = new List<List<string>>();
        static List<Vertical> verticalCollections = new List<Vertical>();
        static List<List<int>> solutions = new List<List<int>>();
        static List<Vertical> verticalList = null;

        static int CompareLength(List<string> a, List<string> b)
        {
            //int maxLength = MaxLength(a.Count, b.Count);
            int minLength = MinLength(a.Count, b.Count);
            for (int i = 0; i < minLength; i++)
            {
                if (a[i] == b[i]) continue;

                return a[i].CompareTo(b[i]);
            }
            return b.Count.CompareTo(a.Count);
        }

        static int CompareDegree(Vertical a, Vertical b)
        {
            return b.Degree.CompareTo(a.Degree);
        }

        static int MaxLength(int a, int b)
        {
            return a > b ? a : b;
        }

        static int MinLength(int a, int b)
        {
            return a < b ? a : b;
        }


        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ReadN();
            ReadViolateSet();
            ReadVerticalCollections(violateSetCollections, verticalCollections);
            RemoveUnEssentialSet(violateSetCollections);
            SortCollections(violateSetCollections);
            RemoveAbundanSetCollections(violateSetCollections);
            ReadVerticalList(violateSetCollections);
            SortVerticalList(verticalList);
            PrintVerticalList(verticalList);
            PrintViolateSetCollections(violateSetCollections);
            PrintSolution(verticalList);
            PrintSolution(solutions);
            Console.WriteLine("Finished!!");
            Console.ReadLine();
        }
        #region Print
        private static void PrintViolateSet(List<string> set)
        {
            foreach (string i in set)
            {
                Console.Write($" {i}");
            }

        }
        private static void PrintViolateSetCollections(List<List<string>> collections)
        {
            for (int i = 0; i < collections.Count; i++)
            {
                Console.Write("Set " + (i + 1) + ": ");
                for (int j = 0; j < collections[i].Count; j++)
                {

                    Console.Write(collections[i][j] + " ");
                }
                Console.WriteLine();
            }

        }
        public static void PrintVerticalList(List<Vertical> verticalList)
        {
            for (int i = 1; i <= nPart; i++)
            {
                Console.WriteLine("Vertical " + verticalList[i - 1].VerticalIndex);
                Console.WriteLine("RelativeVertical " + i + " : " + verticalList[i - 1].ToString());
                Console.WriteLine("Degree " + i + " : " + verticalList[i - 1].Degree);
                Console.WriteLine("___________________________");
            }
        }
        public static void PrintSolution(List<List<int>> solutions)
        {
            for (int i = 0; i < solutions.Count; i++)
            {
                Console.WriteLine("Day " + (i + 1));
                for (int j = 0; j < solutions[i].Count; j++)
                {
                    Console.Write(solutions[i][j] + ",");

                }
                Console.WriteLine();
                Console.WriteLine("_______________");
            }
        }
        public static void PrintSolution(List<Vertical> verticalList)
        {

            while (verticalList.Count != 0)
            {
                List<int> sub = new List<int>();
                List<int> removeIndex = new List<int>();
                sub.Add(verticalList[0].VerticalIndex);
                removeIndex.Add(verticalList[0].VerticalIndex);
                string bannedVertical = String.Join(",", verticalList[0].RelativeVerticals);
                foreach (var i in verticalList)
                {



                    if (bannedVertical.IndexOf(i.VerticalIndex.ToString()) != -1)
                    {
                        i.RelativeVerticals.RemoveWhere(n => sub.Contains(n));
                        i.Degree--;
                    }
                    else
                    {
                        sub.Add(i.VerticalIndex);
                        bannedVertical += "," + String.Join(",", i.RelativeVerticals);
                        removeIndex.Add(i.VerticalIndex);
                    }

                }
                verticalList.RemoveAll(n => removeIndex.Contains(n.VerticalIndex));
                sub.Sort();
                solutions.Add(sub);
            }

        }
        #endregion
        #region Read
        private static void ReadN()
        {
            do
                Console.Write("Hãy nhập số buổi cần họp (số): ");
            while (!int.TryParse(Console.ReadLine(), out nPart));


        }
        private static void ReadViolateSet()
        {
            string violateSet = "";
            do
            {
                Console.WriteLine("Hãy nhập các buổi ko đc tổ chức trong 1 ngày (Ngăn cách bởi dấu phẩy)");
                violateSet = Console.ReadLine();
                if (violateSet != "")
                {
                    List<string> ListViolateSet = violateSet.Split(',').ToList();
                    RemoveDupplicateValues(ref ListViolateSet);
                    if (SumCheckValidSet(ListViolateSet))
                        violateSetCollections.Add(ListViolateSet);
                }

            }
            while (violateSet != "");
        }
        private static void ReadVerticalCollections(List<List<string>> collections, List<Vertical> verticalCollections)
        {
            for (int i = 1; i <= nPart; i++)
            {
                verticalCollections.Add(new Vertical(i, null, 0));

            }

            for (int i = 0; i < collections.Count; i++)
            {

                for (int j = 0; j < collections[i].Count; j++)
                {
                    ReadRelativeVertical(int.Parse(collections[i][j]), collections[i]);
                }

            }

        }
        public static void ReadRelativeVertical(int index, List<string> set)
        {
            Vertical z = verticalCollections.Single(n => n.VerticalIndex == index);

        }
        public static void ReadVerticalList(List<List<string>> collections)
        {
            verticalList = new List<Vertical>();
            for (int i = 1; i <= nPart; i++)
            {
                verticalList.Add(new Vertical(i, new HashSet<int>() { i }, 0));
            }
            List<int> a = new List<int>();

            for (int i = 0; i < collections.Count; i++)
            {
                for (int j = 0; j < collections[i].Count; j++)
                {

                    verticalList[int.Parse(collections[i][j]) - 1].UpdateRelativeVertical(collections[i]);
                }
            }
        }
        #endregion
        #region Check
        private static bool SumCheckValidSet(List<string> set)
        {
            if (!CheckSetFormat(set)) { Console.WriteLine("Sai định dạng"); return false; }
            else if (!CheckValidValueSet(set)) { Console.WriteLine("Số buổi phải >= 1 && <= " + nPart); return false; }
            else if (CheckExistSetInCollection(set)) { Console.WriteLine("Đã tồn tại"); return false; };
            return true;
        }
        private static bool CheckExistSetInCollection(List<string> set)
        {
            set.Sort();
            //return violateSetCollections.Any(n => n.SequenceEqual(set));
            return violateSetCollections.Any(n => n.Intersect(set).Count() == set.Count());

        }
        private static bool CheckSetFormat(List<string> set)
        {
            return set.All(n => int.TryParse(n, out int result));
        }
        private static bool CheckValidValueSet(List<string> set)
        {
            return set.All(n => int.Parse(n) >= 1 && int.Parse(n) <= nPart);
        }
        #endregion
        #region Remove
        private static void RemoveDupplicateValues(ref List<string> set)
        {
            set = set.Distinct().ToList();
        }
        public static void RemoveUnEssentialSet(List<List<string>> collections)
        {
            //foreach (List<string> i in collections)
            //{
            //    collections.Remove(collections.Single(n => n.Intersect(i).Count()==i.Count()));
            //}
        }
        public static void RemoveAbundanSetCollections(List<List<string>> collections)
        {
            for (int i = collections.Count - 1; i > 0; i--)
            {
                if (collections[i - 1].Intersect(collections[i]).Count() == collections[i].Count())
                {

                    collections.RemoveAt(i);
                }
            }
        }
        #endregion
        #region Sort
        public static void SortCollections(List<List<string>> collections)
        {
            Comparison<List<string>> comparison = new Comparison<List<string>>(CompareLength);
            collections.Sort(comparison);


        }
        public static void SortVerticalList(List<Vertical> verticalList)
        {
            Comparison<Vertical> comparison = new Comparison<Vertical>(CompareDegree);
            verticalList.Sort(comparison);
        }
        #endregion






    }

}
