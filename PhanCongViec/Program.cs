using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanCongViec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            WorkerList workerList = new WorkerList();
            WorkList workList = new WorkList();
            workerList.Input();
            workerList.Output();
            workList.Input();
            workList.Sort(WorkList.CompareByTime);
            workList.Output();
            workList.Solve(workerList);
            workList.Output();
            workerList.Output_Detail(workList);
            Console.ReadLine();
        }
      
    }
}
