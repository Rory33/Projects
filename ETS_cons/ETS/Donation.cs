using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_cons
{
    class Donation
    {
        string donationID;
        string donationDate;
        string donorID;
        double donationAmount;
        string prizeID;

        public Donation(string donationID, string donationDate,
            string donorID, double donationAmount, string prizeID)
        {
            this.donationID = donationID;
            this.donationDate = donationDate;
            this.donorID = donorID;
            this.donationAmount = donationAmount;
            this.prizeID = prizeID;
        }

        public string DonationID { get; set; }
        public string DonationDate { get; set; }
        public string DonorID { get; set; }
        public double DonationAmount { get; set; }
        public string PrizeID { get; set; }

        public string toString()
        {
            return donationID + "\n" + donationDate + "\n" + donorID + 
                "\n" + donationAmount + " " + prizeID;
        }

        public string GetID()
        {
            return DonationID;
        }

    }
}
