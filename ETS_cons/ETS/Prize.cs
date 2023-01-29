using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_cons
{
    internal class Prize
    {
        string prizeID;
        string description;
        double value;
        double donationLimit;
        int originalAvailable;
        int currentAvailable;
        string sponsorID;

        public Prize(string prizeID, string desc, double val,
            double donationLimit, int originalAvail, int currentAvail, string sponsorID)
        {
            this.prizeID = prizeID;
            this.description = desc;
            this.value = val;
            this.donationLimit = donationLimit;
            this.originalAvailable = originalAvail;
            this.currentAvailable = currentAvail;
            this.sponsorID = sponsorID;
        }

        public string PrizeID { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public double DonationLimit { get; set; }
        public int OriginalAvailable { get; set; }
        public int CurrentAvailable { get; set; }
        public string SponsorID { get; set; }

        public string toString()
        {
            return prizeID + " " + description + " " + value + " " + sponsorID;
        }

        public string GetPrizeID()
        {
            return PrizeID;
        }
        public void Decrease(int val)
        {

        }
        public void OnChangePrize()
        {

        }
        public void ClearPrize()
        {

        }
    }

}
