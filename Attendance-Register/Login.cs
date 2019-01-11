using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Attendance_Register
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            button1.Enabled = false;
            try
            {
                string uname = textBox1.Text.Trim();
                string pword = textBox2.Text.Trim();
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                //builder.Server = "localhost";
                //builder.UserID = "root";
                //builder.Password = "babafemiadedayo";
                //builder.Database = "attendancedb";

				builder.Server = "md";
				builder.UserID = "root";
				builder.Password = "kole";
				builder.Database = "world";
				MySqlConnection connection = new MySqlConnection(builder.ToString());
                connection.Open();
                string sql = "SELECT * FROM admin_details";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader dt = cmd.ExecuteReader();
                string un, pa;
                while (dt.Read())
                {
                    un = dt["USERNAME"].ToString();
                    pa = dt["PASSWORD"].ToString();

                    if (un.Equals(textBox1.Text) && pa.Equals(textBox2.Text))
                    {
                        button1.Cursor = Cursors.Default;
                        openmainwindow();
                        connection.Dispose();
                        connection.Close();
                        button1.Enabled = true;
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("Value(s) Incorrect!");
                        button1.Enabled = true;
                    }
                    break;
                }
            }
            catch (Exception)
            {
                Cursor = Cursors.Default;
                button1.Enabled = true;
                MessageBox.Show("Error in Login");
            }
        }

        private void openmainwindow()
        {
            Cursor = Cursors.WaitCursor;
            this.Hide();
            MainMenu mn = new MainMenu();
            mn.Show();
            Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}