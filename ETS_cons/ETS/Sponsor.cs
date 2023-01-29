using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_cons
{
    internal class Sponsor : Person
    {
        string sponsorID;
        double totalPrizeValue;

        public Sponsor (string sponsorID, double totalPrizeValue, 
            string firstName, string lastName) : base (firstName, lastName)
        {
            this.sponsorID = sponsorID;
            this.totalPrizeValue = totalPrizeValue;
        }

        public string SponsorID { get; set; }
        public double TotalPrizeValue { get; set; }

        public override string toString()
        {
            return this.sponsorID + "\n" + this.TotalPrizeValue + "\n" + base.toString();
        }

        public string GetID()
        {
            return SponsorID;
        }

        //public double AddValue(double val)
        //{
        //    return this.totalPrizeValue + val;
        //}
    }
}
