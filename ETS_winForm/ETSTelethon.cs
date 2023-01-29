using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Xml.Linq;
using ETS;
using System.IO;

namespace TelethonSystemWin
{
    public partial class ETSTelethon : Form
    {
        EtsManager etsManager = new EtsManager();

        public ETSTelethon()
        {
            InitializeComponent();
        }
        private void ClearSponsors()
        {
            foreach(Control c in sp.Controls)
            {
                if (c is RichTextBox)
                {
                    c.Text = null;
                }
            }
        }

        private void ClearDonors()
        {
            foreach (Control c in dn.Controls)
            {
                if (c is RichTextBox)
                {
                    c.Text = null;
                }
            }
        }

        //Sponsor
        private void btnAddSpn_Click(object sender, EventArgs e)
        {
            double totalPrizeValue = 
                Convert.ToDouble(prizeValTxt.Text) * Convert.ToDouble(prizeCountTxt.Text);

            etsManager.AddSponsor(sponsIDTxt.Text, totalPrizeValue, 
                sponsFnTxt.Text, sponsLnTxt.Text);
        }

        private void btnViewSpn_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            string allSpnInfos = etsManager.ListSponsors();
            MessageBox.Show(allSpnInfos, "Sponsors Info");

            richTextBox1.Text = allSpnInfos;
        }

        //Prize

        private void btnAddPrz_Click(object sender, EventArgs e)
        {
            etsManager.addPrize(prizeIDTxt.Text, descTxt.Text, Convert.ToDouble(prizeValTxt.Text),
                Convert.ToDouble(donLimitTxt.Text), 0, Convert.ToInt32(prizeCountTxt.Text), sponsIDTxt.Text);

            ClearSponsors();
        }

        private void btnViewPrz_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            string allPrzInfos = etsManager.ListPrizes();
            MessageBox.Show(allPrzInfos, "Prize Infos");

            richTextBox1.Text = allPrzInfos;
        }
        private void btnShowPrz_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            
            try
            {
                string allQualifPrzInfos = etsManager.ListQualifiedPrizes
                    (Convert.ToDouble(donAmntTxt.Text));
                MessageBox.Show(allQualifPrzInfos, "Qualified Prizes");
                
                richTextBox1.Text = allQualifPrzInfos;
            }
            catch(Exception)
            {
               MessageBox.Show("Invalid input format..", "Error!");
                richTextBox1.Text = "Invalid input format..";
            }
        }
        //Donation
        private void btnAddDonation_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            string date = DateTime.Now.ToString();
            try
            {
                int qtyAwarded = Convert.ToInt32(awrdNumTxt.Text);

                etsManager.AddDonation(donationIDTxt.Text, date, donIDTxt.Text, 
                    Convert.ToDouble(donAmntTxt.Text), awrdPrzTxt.Text, qtyAwarded);

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input format..", "Error!");
             
            }
        }
        private void btnListDonations_Click(object sender, EventArgs e)
        {
            string allDonationsInfos = etsManager.ListDonations();
            MessageBox.Show(allDonationsInfos, "Donations info");
            
            richTextBox1.Text = allDonationsInfos;
        }

        //Donor

        private void btnListDonors_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            string allDonorsInfos = etsManager.ListDonors();
            MessageBox.Show(allDonorsInfos, "Donors info");
            richTextBox1.Text = allDonorsInfos;
        }

        private void btnSaveDonor_Click(object sender, EventArgs e)
        {
            char cardType;

            if (btnVisa.Checked == true)
            {
                cardType = 'V';
            }
            else if (btnMcard.Checked == true)
            {
                cardType = 'M';
            }
            else if (btnAmex.Checked == true)
            {
                cardType = 'A';
            }
            else
            {
                MessageBox.Show("Card Type must be checked", "Error!");
                return;
            }

            Regex validatePhone = new Regex
                (@"^(?:\([2-9]\d{2}\)\ ?|[0-9]\d{2}(?:\-?|\ ?))[0-9]\d{2}[- ]?\d{4}$");

            if (validatePhone.IsMatch(donPhoneTxt.Text) == false)
            {
                MessageBox.Show("The phone number format is invalid", "Error!");
                donPhoneTxt.Focus();
                return;
            }

            Regex validateExpiry = new Regex
                (@"^((0[1-9])|(1[0-2]))[\/\.\-]*((2[2-9])|(3[1-9]))$");

            if (validateExpiry.IsMatch(cardExpTxt.Text) == false)
            {
                MessageBox.Show("The expiry date is invalid", "Error!");
                cardExpTxt.Focus();
                return;
            }

            etsManager.AddDonor(donIDTxt.Text, donAdrsTxt.Text, donPhoneTxt.Text, cardType,
                cardNumTxt.Text, cardExpTxt.Text, donFnTxt.Text, donLnTxt.Text);

            //ClearDonors();
            etsManager.WriteDonors();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchSpn_Click(object sender, EventArgs e)
        {
            string res = etsManager.FindSponsor(searchSpnTxt.Text);
            MessageBox.Show(res, "Message");

            searchSpnTxt.Clear();

            richTextBox1.Text = res;
        }

        private void searchDnr_Click(object sender, EventArgs e)
        {
            string res = etsManager.FindDonor(searchDnrTxt.Text);
            MessageBox.Show(res, "Message");

            searchDnrTxt.Clear();

            richTextBox1.Text = res;
        }

        private void deleteDnr_Click(object sender, EventArgs e)
        {
            string res = etsManager.DeleteDonor(searchDnrTxt.Text);
            MessageBox.Show(res, "Message");

            richTextBox1.Text = res;
        }


    }
}
