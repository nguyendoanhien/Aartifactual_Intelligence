using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanCongViec
{
    class Work
    {
        private int workID;
        private int time;
        private int workerID;
        
        public int Index
        {
            get { return workID; }
            set { workID = value; }
        }
        public int Time
        {
            get { return time; }
            set { time = value; }
        }
        public int WorkerID
        {
            get => workerID;
            set => workerID = value;
        }
       
        public override string ToString()
        {
            return $"Công việc {workID} thời gian là {time} người làm {workerID}";
        }


    }
}
