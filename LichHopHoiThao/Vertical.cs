using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAp
{
    class Vertical
    {
        int verticalIndex;
        HashSet<int> relativeVerticals;
        int degree;
      
       
        public Vertical()
        {
            verticalIndex = 0;
            relativeVerticals = new HashSet<int>();
            degree = 0;
        }
        public Vertical(int verticalIndex, HashSet<int> relativeVerticals,int degree)
        {
            this.verticalIndex = verticalIndex;
            this.relativeVerticals = relativeVerticals;
            this.degree = degree;
            
        }
        public Vertical(Vertical another)
        {
            this.verticalIndex = another.verticalIndex;
            this.relativeVerticals = another.relativeVerticals;
            this.degree = another.degree;
        }

        public int VerticalIndex
        {
            get { return verticalIndex; }
            set { verticalIndex = value; }
        }
        public HashSet<int> RelativeVerticals
        {
            set { relativeVerticals = value;
                
                }
            get { return relativeVerticals; }
        }

        public int Degree
        {
            get { return degree; }
            set { degree = value; }
        }
        public override string ToString()
        {

            return relativeVerticals==null?"0": String.Join(",",relativeVerticals);
        }
        public void UpdateRelativeVertical(List<string> relativeVerticalsInput)
        {
            relativeVerticals.UnionWith(relativeVerticalsInput.Select(n => int.Parse(n)));
            CalculateDegree();
        }
        public void CalculateDegree()
        {
            degree = relativeVerticals==null?degree:relativeVerticals.Count()-1;
        }

    }
}
