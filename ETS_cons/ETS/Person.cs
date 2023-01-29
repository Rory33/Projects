using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_cons
{
    abstract class Person
    {
        string firstName;
        string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;   

        }

        public virtual string toString()
        {
            return this.firstName + " " + this.lastName;
        }


    }
}
