using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_cons
{
    internal class Prizes : CollectionBase
    {
        public void add (Prize pr)
        {
            List.Add (pr);
        }

        public Prize this[int index]
        {
            get { return (Prize)this[index]; }
            set { List[index] = value; }
        }
    }
}
