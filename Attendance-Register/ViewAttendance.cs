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
    public partial class ViewAttendance : Form
    {
        public ViewAttendance()
        {
            InitializeComponent();
        }

        private void ViewAttendance_Load(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
			
			/*builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "babafemiadedayo";
            builder.Database = "attendancedb";*/

			builder.Server = "md";
			builder.UserID = "root";
			builder.Password = "kole";
			builder.Database = "world"
				;
			MySqlConnection connection = new MySqlConnection(builder.ToString());
            connection.Open();
            string sql = "SELECT * FROM attendance";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dt = cmd.ExecuteReader();
            DataTable obj = new DataTable();
            obj.Load(dt);
            dataGridView1.DataSource = obj;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
