using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanCongViec
{
    class Worker
    {
        int workerID;
        
        public int WorkerID
        {
            get { return workerID; }
            set { workerID = value; }
        }

       
        public Worker()
        {
            workerID = 0;
        }

        public Worker(int workerID)
        {
            this.workerID = workerID;
        }

        public override string ToString()
        {
            return $"Nhân viên thứ {workerID}";
        }
    }
}
