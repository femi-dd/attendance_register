using MySql.Data.MySqlClient;
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
    public partial class AdminReg : Form
    {
        public AdminReg()
        {
            InitializeComponent();
        }

        MySqlConnection connectDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "md";
            builder.UserID = "root";
            builder.Password = "kole";
            builder.Database = "world";

            MySqlConnection connection = new MySqlConnection(builder.ToString());
            connection.Open();
            return connection;
        }
        private void getData()
        {
            name = textBox1.Text.Trim();
            username = textBox2.Text.Trim();
            password = textBox3.Text.Trim();
            college = comboBox1.Text.Trim();
            department = comboBox2.Text.Trim();
            course = comboBox3.Text.Trim();
            gender = comboBox4.Text.Trim();
            id = textBox5.Text.Trim();
            phone = textBox4.Text.Trim();
            picloc = piclocation;
        }

        private string name;
        private string username;
        private string password;
        private string college;
        private string department;
        private string course;
        private string gender;
        private string phone;
        private string id;
        private string picloc;
        private string piclocation;

        private void AdminReg_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            button1.Enabled = false;
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(open.FileName);
                    piclocation = open.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception) { Cursor = Cursors.Default; pictureBox1.Text = "Image File could not be uploaded!"; }
            finally { Cursor = Cursors.Default; button1.Enabled = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            button2.Enabled = false;
            try
            {
                string sql = "INSERT INTO admin_details(NAME, USERNAME, PASSWORD, COLLEGE, DEPARTMENT, COURSE, GENDER, PHONE_NO, ADMIN_RFID, PICTURE) VALUES (@fname, @mname, @lname, @coleg, @dept, @curs, @sex, @phone, @admid, @pics)";
                MySqlCommand cmd = new MySqlCommand(sql, connectDB());
                getData();
                cmd.Parameters.AddWithValue("@fname", name);
                cmd.Parameters.AddWithValue("@mname", username);
                cmd.Parameters.AddWithValue("@lname", password);
                cmd.Parameters.AddWithValue("@coleg", college);
                cmd.Parameters.AddWithValue("@dept", department);
                cmd.Parameters.AddWithValue("@curs", course);
                cmd.Parameters.AddWithValue("@sex", gender);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@admid", id);
                cmd.Parameters.AddWithValue("@pics", picloc);
                cmd.ExecuteNonQuery();
                MessageBox.Show(name + " Added Successfully");
                button2.Cursor = Cursors.Arrow;
            }
            catch (MySqlException) { connectDB().Close(); button2.Cursor = Cursors.Default; MessageBox.Show("Error Adding Admin"); }
            finally { connectDB(); Cursor = Cursors.Default; button2.Enabled = true; }
        }

        private void AdminReg_Load(object sender, EventArgs e)
        {

        }
    }
}