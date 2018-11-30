using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanCongViec
{
    class WorkList
    {
        List<Work> listWork;
        public WorkList()=> listWork = new List<Work>();
       

        public List<Work> ListWork
        {
            get { return listWork; }
            set { listWork = value; }
        }

        public void Input()
        {
            #region read nWork
            int nWork = 0;
           
            do
            {
                Console.WriteLine("Nhập sl công việc");
            }
            while (!int.TryParse(Console.ReadLine(), out nWork));
            #endregion

            for(int i=0;i<nWork;i++)
            { 
                int time = 0;
                do
                {
                    Console.WriteLine($"Nhập thời gian cho công việc {i + 1}");
                }
                while (!int.TryParse(Console.ReadLine(), out time));

                Work x = new Work();
                x.Index = i + 1;
                x.Time = time;
                ListWork.Add(x);
            }

        }

        public void Output()
        {
            Console.WriteLine("Xuất DS công việc và thời gian hoàn thành");
            for(int i=0;i<listWork.Count;i++)
            {
                Console.WriteLine(listWork[i].ToString());
            }


        }


        
     
        public void Sort(Func<Work,Work, int> callback)
        {
            Comparison<Work> comparison = new Comparison<Work>(callback);
            listWork.Sort(comparison);
        }

        public static int CompareByTime(Work a, Work b)
        {
            return b.Time.CompareTo(a.Time);
        }

        public int CountBy(int workerID)
        {
          return  listWork.Count(n => n.WorkerID == workerID);
        }
        
        public int LowestTimeWorker(WorkerList workerList)
        {
            double lowest = listWork.Where(n => n.WorkerID != 0).Min(n => SumTimeBy(n.WorkerID));

            return listWork.IndexOf(listWork.First(n => SumTimeBy(n.WorkerID)==lowest))+1;
        }
        public  int SumTimeBy(int workerID)
        {
            return listWork.Where(n => n.WorkerID == workerID).Sum(n => n.Time);
        }

        public void Solve(WorkerList workerList)
        {
            for(int i=0;i<listWork.Count;i++)
            {
                if (i >= 0 && i < workerList.ListWorker.Count)
                    ListWork[i].WorkerID = workerList.ListWorker[i].WorkerID;
                else
                listWork[i].WorkerID = LowestTimeWorker(workerList);

            }
        }
        public void Detail(int workerID)
        {       
           var g= listWork.FindAll(n => n.WorkerID == workerID);
            Console.WriteLine($"Máy {workerID}");
            for(int i=0;i<g.Count;i++)
                Console.Write(g[i].Time+",");

            Console.WriteLine("_________");
        }
    }
}
