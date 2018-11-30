using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACI____Difference_Position_
{
    public class KhoiList
    {
        List<Khoi> list;
        public KhoiList()
        {
            list = new List<Khoi>();
        }
        public KhoiList(List<Khoi> list)
        {
            this.list = list;
        }

        public List<Khoi> List { get => list; set => list = value; }

        public KhoiList Min_f_Values()
        {
           return new KhoiList( list.Where(n => n.F == list.Min(g => g.F)).ToList());
        }

    }
}
