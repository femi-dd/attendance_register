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
using System.IO;

namespace Attendance_Register
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectDB();
            setDate();
        }

        private void getData()
        {
            firstname = textBox1.Text.Trim();
            middlename = textBox2.Text.Trim();
            lastname = textBox3.Text.Trim();
            college = comboBox1.Text.Trim();
            department = comboBox5.Text.Trim();
            course = comboBox2.Text.Trim();
            level = comboBox3.Text.Trim();
            regno = textBox8.Text.Trim();
            gender = comboBox4.Text.Trim();
            id = textBox10.Text.Trim();
            matric = textBox11.Text.Trim();
            phone = textBox4.Text.Trim();
            time = textBox5.Text;
            picloc = piclocation;
        }

        private string firstname;
        private string middlename;
        private string lastname;
        private string college;
        private string department;
        private string course;
        private string level;
        private string regno;
        private string gender;
        private string id;
        private string matric;
        private string phone;
        private string picloc;
        private string piclocation;
        private string time;

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

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            button1.Enabled = false;
            try
            {
                string sql = "INSERT INTO student_details(FIRSTNAME, MIDDLENAME, LASTNAME, COLLEGE, DEPARTMENT, COURSE, LEVEL, REGISTRATION_NO, GENDER,STUDENT_RFID, MATRIC_NO, PHONE_NO, PICTURE, TIME) VALUES (@fname, @mname, @lname, @coleg, @dept, @curs, @lvl, @regno, @sex, @stdid, @mtrno, @phone, @pics, @time)";
                MySqlCommand cmd = new MySqlCommand(sql, connectDB());
                getData();
                cmd.Parameters.AddWithValue("@fname", firstname);
                cmd.Parameters.AddWithValue("@mname", middlename);
                cmd.Parameters.AddWithValue("@lname", lastname);
                cmd.Parameters.AddWithValue("@coleg", college);
                cmd.Parameters.AddWithValue("@dept", department);
                cmd.Parameters.AddWithValue("@curs", course);
                cmd.Parameters.AddWithValue("@lvl", level);
                cmd.Parameters.AddWithValue("@regno", regno);
                cmd.Parameters.AddWithValue("@sex", gender);
                cmd.Parameters.AddWithValue("@stdid", id);
                cmd.Parameters.AddWithValue("@mtrno", matric);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@pics", picloc);
                cmd.Parameters.AddWithValue("@time", time);
                cmd.ExecuteNonQuery();
                MessageBox.Show(firstname + " Added Successfully");
                button1.Cursor = Cursors.Arrow;
            }
            catch (MySqlException) { connectDB().Close(); button1.Cursor = Cursors.Default; MessageBox.Show("Error Adding Student"); }
            finally { connectDB(); Cursor = Cursors.Default; button1.Enabled = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            button2.Enabled = false;
            try
            {
                string sql = "SELECT * FROM student_details WHERE STUDENT_RFID = " + textBox10.Text;
                MySqlCommand cmd = new MySqlCommand(sql, connectDB());
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    textBox1.Text = dt["FIRSTNAME"].ToString();
                    textBox2.Text = dt["MIDDLENAME"].ToString();
                    textBox3.Text = dt["LASTNAME"].ToString();
                    comboBox1.Text = dt["COLLEGE"].ToString();
                    comboBox5.Text = dt["DEPARTMENT"].ToString();
                    comboBox2.Text = dt["COURSE"].ToString();
                    comboBox3.Text = dt["LEVEL"].ToString();
                    textBox8.Text = dt["REGISTRATION_NO"].ToString();
                    comboBox4.Text = dt["GENDER"].ToString();
                    textBox10.Text = dt["STUDENT_RFID"].ToString();
                    textBox11.Text = dt["MATRIC_NO"].ToString();
                    textBox4.Text = dt["PHONE_NO"].ToString();
                    try
                    {
                        pictureBox1.ImageLocation = dt["PICTURE"].ToString();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cannot load image!");
                    }
                    textBox5.Text = dt["TIMES"].ToString();
                    connectDB().Dispose();
                    connectDB().Close();
                }
                Cursor = Cursors.Default;
            }
            catch (MySqlException) { connectDB().Dispose(); }
            finally { connectDB(); Cursor = Cursors.Default; button2.Enabled = true; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            button3.Enabled = false;
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
            catch (Exception) { Cursor = Cursors.Default; pictureBox1.Text = "File could not be uploaded."; }
            finally { Cursor = Cursors.Default; button3.Enabled = true; }
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            button4.Enabled = false;
            AdminReg newadminreg = new AdminReg();
            newadminreg.Show();
            button4.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        void setDate()
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString();
            textBox5.Text = date;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == null || textBox5.Text.ToString() == "")
            {
                MessageBox.Show("StudentID is reuired!");
            }
            else
            {
                try {
                    string stdid = textBox10.Text.ToString();
                    string time = textBox5.Text.ToString();
                    string sql = "INSERT INTO ATTENDANCE (ID, ATTENDANCE_TIME) VALUES (@id, @time)";
                    MySqlCommand cmd = new MySqlCommand(sql, connectDB());
                    cmd.Parameters.AddWithValue("@id", stdid);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success!");
                    button1.Cursor = Cursors.Arrow;
                }
                catch (MySqlException) { connectDB().Close(); button5.Cursor = Cursors.Default; MessageBox.Show("Error taking attendance"); }
                finally { connectDB(); Cursor = Cursors.Default; button5.Enabled = true; }
            }
        }
    }
}