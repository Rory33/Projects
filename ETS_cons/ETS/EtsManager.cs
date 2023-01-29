using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ETS_cons
{
    internal class EtsManager
    {
        public EtsManager() { }

        Sponsors mySponsors = new Sponsors();
        public bool checkSponsorID(string sponsorID)
        {
            bool flag = false;
            foreach (Sponsor sponsor in myDonations)
            {
                if (sponsor.GetID() == sponsorID)
                {
                    flag = true;
                }
            }
            return flag;
        }
        public void AddSponsor(string sponsorID, double totalPrizeValue,
            string fName, string lName)
        {
            Sponsor sponsor = new Sponsor(sponsorID, totalPrizeValue, fName, lName);
            mySponsors.add(sponsor);
        }

        Donations myDonations = new Donations();

        public bool checkDonationID(string donationID)
        {
            bool flag = false;
            foreach (Donation donation in myDonations)
            {
                if (donation.GetID() == donationID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public string AddDonation(string donationID, string date,
            string donorID, double donationAmount, string prizeID)
        {
            string message = "";

            if (donationID.Length != 4)
            {
                return message = "The Donation ID must be 4 chars.";
            }

            if (checkDonationID(donationID) == true)
            {
                return message = "This ID exists already..";
            }

            if (date.Length != 7)
            {
                return message = "The date format should be 01/2021 ";
            }

            if (donorID.Length != 4)
            {
                return message = "The Donor ID must be 4 chars.";
            }
            if (checkDonorID(donorID) == true)
            {
                return message = "This ID exists already..";
            }

            if (donationAmount < 5)
            {
                return message = "Donations have to be min. $5";
            }
            if (donationAmount > 99999999)
            {
                return message = "Donations cannot exceed $999,999.99";
            }

            if (prizeID.Length != 4)
            {
                return message = "The Prize ID must be 4 chars.";
            }

            Donation donation = new Donation(donationID, date, donorID, donationAmount, prizeID);
            myDonations.add(donation);
            return message = "Donation added successfully!";
        }

        //public void AddDonation()
        //{
        //    Console.WriteLine("Please enter the Donation ID: ");
        //    string donationID = Console.ReadLine();

        //    if (donationID.Length != 4)
        //    {
        //        Console.WriteLine("The Donation ID must be 4 chars.");
        //        return;
        //    }
        //    if (checkDonationID(donationID) == true)
        //    {
        //        Console.WriteLine("This ID exists already..");
        //        return;
        //    }

        //    Console.WriteLine("Please enter the date of the donation (mm/yyyy): ");
        //    string date = Console.ReadLine();

        //    if (date.Length != 7)
        //    {
        //        Console.WriteLine("The date format should be 01/2021 ");
        //        return;
        //    }

        //    Console.WriteLine("Please enter the Donor ID: ");
        //    string donorID = Console.ReadLine();

        //    if (donorID.Length != 4)
        //    {
        //        Console.WriteLine("The Donor ID must be 4 chars.");
        //        return;
        //    }
        //    if (checkDonorID(donorID) == true)
        //    {
        //        Console.WriteLine("This ID exists already..");
        //        return;
        //    }

        //    Console.WriteLine("Please enter the Donation amount: ");
        //    double donAmnt = Convert.ToDouble(Console.ReadLine());

        //    if (donAmnt < 5)
        //    {
        //        Console.WriteLine("Donations have to be min. $5");
        //        return;
        //    }
        //    if (donAmnt > 99999999)
        //    {
        //        Console.WriteLine("Donations cannot exceed $999,999.99");
        //        return;
        //    }

        //    Console.WriteLine("Please enter the Prize ID: ");
        //    string prizeID = Console.ReadLine();

        //    if (prizeID.Length != 4)
        //    {
        //        Console.WriteLine("The Prize ID must be 4 chars.");
        //        return;
        //    }

        //    Donation donation = new Donation(donationID, date, donorID, donAmnt, prizeID);
        //    myDonations.add(donation);
        //    Console.WriteLine("Donation added successfully!");    

        //}

        Donors myDonors = new Donors();
        public bool checkDonorID(string donID)
        {
            bool flag = false;
            foreach (Donor donor in myDonors)
            {
                if(donor.GetID() == donID)
                {
                    flag = true;    
                }
            }
            return flag;
        }

        //public void AddDonor(string donorID, string address,
        //    string phone, char cardType, string cardNum,
        //    string cardEx, string fname, string lname)
        //{
        //    //string message = "";

        //    if (donorID.Length != 4)
        //    {
        //        message = "This ID exists already..";  
        //    }

        //    if (checkDonorID(donorID) == true)
        //    {
        //        return message = "This ID exists already..";
        //    }

        //    if (fname.Length > 15)
        //    {
        //        return message = "Names cannot exceed 15 chars.";
        //    }

        //    if (lname.Length > 15)
        //    {
        //        return message = "Names cannot exceed 15 chars.";
        //    }

        //    if (address.Length > 40)
        //    {
        //        return message = "Address cannot exceed 40 chars.";
        //    }

        //    Regex validatePhone = new Regex
        //        (@"^\(? ([0 - 9]{ 3 })\)?[-. ]?([0 - 9]{ 3})[-. ]?([0 - 9]{ 4})$");

        //    if (!validatePhone.IsMatch(phone))
        //    {
        //        return message = "Phone numbers cannot exceed 10 digits";
        //    }

        //    if (cardNum.Length > 16)
        //    {
        //        return message = "Credit card numbers must be 16 digits";
        //    }

        //    Donor donor = new Donor(donorID, address, phone, 
        //        cardType, cardNum, cardEx, fname, lname);
        //    myDonors.add(donor);
        //    return message = "The donor was successfully added to the list..";

        //}


        //public void AddDonor()
        //{
        //    string donorID;

        //    while (true)
        //    {
        //        Console.WriteLine("Please enter the Donor ID: ");
        //        donorID = Console.ReadLine();

        //        if (donorID.Length == 4)
        //        {
        //            break;
        //        } else {
        //            Console.WriteLine("The Donor ID must be 4 chars.");
        //        }
        //    }

        //    if(checkDonorID(donorID) == true)
        //    {
        //        Console.WriteLine("This ID exists already..");
        //        return;
        //    }
        //    Console.WriteLine("Please enter the Donor's firstname: ");
        //    string firstname = Console.ReadLine();

        //    if(firstname.Length > 15)
        //    {
        //        Console.WriteLine("Names cannot exceed 15 chars.");
        //        return;
        //    }

        //    Console.WriteLine("Please enter the Donor's last name: ");
        //    string lastname = Console.ReadLine();

        //    if (lastname.Length > 15)
        //    {
        //        Console.WriteLine("Names cannot exceed 15 chars.");
        //        return;
        //    }

        //    Console.WriteLine("Please enter the Donor's last address: ");
        //    string address = Console.ReadLine();

        //    if (address.Length > 40)
        //    {
        //        Console.WriteLine("Address cannot exceed 40 chars.");
        //        return;
        //    }

        //    Console.WriteLine("Please enter the Donor's phone number: ");
        //    string phone = Console.ReadLine();

        //    if (phone.Length != 11)
        //    {
        //        Console.WriteLine("Phone numbers cannot exceed 10 digits");
        //        return;
        //    }

        //    Console.WriteLine("Please enter the credit card type: ");
        //    char ccType = Convert.ToChar(Console.ReadLine());

        //    //Add verif.

        //    Console.WriteLine("Please enter the credit card type: ");
        //    string cc = Console.ReadLine();

        //    if (cc.Length > 16)
        //    {
        //        Console.WriteLine("Credit card numbers must be 16 digits");
        //        return;
        //    }

        //    Console.WriteLine("Please enter the credit card's expiry date: ");
        //    string ccExpiry = Console.ReadLine();

        //    Donor donor = new Donor(donorID, address, phone,
        //    cardType, cardNum, cardEx, fname, lname);
        //    myDonors.add(donor);
        //    Console.Writeline("The donor was successfully added to the list..");
        //}

        Prizes myPrizes = new Prizes();
        //public void addPrize() {

        //}

        public string listDonations()
        {
            string info = "";
            foreach (Donation donation in myDonations)
            {
                info += donation.toString();
                info += Environment.NewLine;
            }
            return info;
        }
        public string listDonors()
        {
            string info = "";
            foreach (Donor donor in myDonors)
            {
                info += donor.toString();
                info += Environment.NewLine;
            }
            return info;
        }

        public string listPrizes()
        {
            string info = "";
            foreach (Prize prize in myPrizes)
            {
                info += prize.toString();
                info += Environment.NewLine;
            }
            return info;
        }


    }
}
