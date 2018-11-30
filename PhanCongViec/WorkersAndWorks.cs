using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanCongViec
{
    class WorkersAndWorks
    {
        WorkList workList;
        WorkerList workerList;
        public WorkList WorkList
            {
            get => workList;
            set => workList = value;
            }
        public WorkerList Workerlist
        {
            get => workerList;
            set => workerList = value;
        }
        public WorkersAndWorks(WorkerList workerList, WorkList workList)
        {
            this.workerList = workerList;
            this.workList = workList;
        }
    }
}
