using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelethonSystemWin
{
    public partial class Login : Form
    {
        int passwordCount = 0;  
        public Login()
        {
            InitializeComponent();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\Admin\Desktop\Lasalle\Courses\Semester_3\Multi-Tier\Projects\ETS_winForm\ETS_winForm\bin\Debug\Login.txt", true))
            {
                string file = sr.ReadLine();
                string[] fileArr;

                fileArr = file.Split(' ');
                ETSTelethon ETSTelethon = new ETSTelethon();

                if (fileArr[0] == userTxt.Text && fileArr[1] == passwordTxt.Text)
                {
                    ETSTelethon.Visible = true;
                    ETSTelethon.Activate();
                }
                else
                {
                    MessageBox.Show("Wrong Login!");
                    passwordCount++;

                    if (passwordCount == 3)
                    {
                        MessageBox.Show("Maximum tries reached!");
                        Application.Exit();
                    }
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
