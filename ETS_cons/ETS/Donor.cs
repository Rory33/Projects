using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_cons
{
    internal class Donor: Person 
    {
        string donorID;
        string address;
        string phone;
        char cardType;
        string cardNumber;
        string cardExpiry;

        public Donor (string donorID, string address,
            string phone, char cardType, string cardNumber, 
            string cardExpiry, string firstName, string lastName) : base (firstName, lastName)
        {
            this.donorID = donorID;
            this.address = address;
            this.phone = phone;
            this.cardType = cardType;
            this.cardNumber = cardNumber;
            this.cardExpiry = cardExpiry;
        }

        public string DonorID
        {
            get { return donorID; } 
            set { donorID = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Phone
        {
            get { return phone; }
            set {phone = value; }
        }
        public char CardType { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiry { get; set; }

        public override string toString()
        {
            return this.donorID + "\n" + 
                address + "\n" + phone + "\n" + cardType + "\n" + cardNumber +
                "\n" + cardExpiry + "\n" + base.toString();
        }

        public string GetID()
        {
            return DonorID;
        }
    }
}
