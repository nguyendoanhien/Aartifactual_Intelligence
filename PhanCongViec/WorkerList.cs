using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanCongViec
{
    class WorkerList
    {
        List<Worker> listWorker = null;
        
       public WorkerList()
        {
            listWorker = new List<Worker>();
        }
        public List<Worker> ListWorker
        {
            get { return listWorker; }
            set { listWorker = value; }
        }

        public void Input()
        {
            int nWorker;
            #region read nWorker
            do
            {
                Console.Write("Hãy nhập số số lượng NV(máy): ");
            }
            while (!int.TryParse(Console.ReadLine(), out nWorker));
            #endregion

            for(int i=0;i<nWorker;i++)
            {
                listWorker.Add(new Worker(i+1));
            }
        }

        public void Output()
        {
            Console.WriteLine("Xuất DS nhân viên(máy)");
            for (int i = 0; i < listWorker.Count; i++)
            {
                Console.WriteLine(listWorker[i].ToString());
            }
        }
        public void Output_Detail(WorkList workList)
        {
            for (int i = 0; i < listWorker.Count; i++)
                workList.Detail(listWorker[i].WorkerID);
        }


        public delegate int functionDelegate(Worker a, Worker b);
        public void Sort(functionDelegate callback)
        {
            Comparison<Worker> comparison = new Comparison<Worker>(callback);
            listWorker.Sort(comparison);
        }

        public static int CompareByWorkerID(Worker a,Worker b)
        {
            return a.WorkerID.CompareTo(b.WorkerID);
        }

        public bool CheckExist(int workerID)
        {
            return listWorker.Exists(n => n.WorkerID == workerID);
        }
    }
}
