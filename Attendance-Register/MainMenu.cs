using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_Register
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminReg obj = new AdminReg();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewAttendance obj1 = new ViewAttendance();
            obj1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin obj2 = new Admin();
            obj2.Show();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
