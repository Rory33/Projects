using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ETS_cons
{
    internal class Sponsors : CollectionBase
    {
        public void add(Sponsor spn)
        {
            List.Add(spn);
        }

        public Sponsor this[int index]
        {
            get { return (Sponsor)this[index]; }
            set { List[index] = value; }
        }
    }
}
