using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace Resthome_Database
{
    public partial class VisitorEdit : Form
    {
        public VisitorEdit()
        {
            InitializeComponent();
        }

        public static string databasen = "Resthome";
        public static SqlConnection conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB; integrated security = true; database =  " + databasen);
        public static SqlCommand cmmd = new SqlCommand("", conn);

        private void btnLoadLastIndex_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            //https://stackoverflow.com/questions/39002025/is-there-a-lastindexof-in-sql-server   
            //cmmd.CommandText = "SELECT right(db_name(), charindex('_', reverse(db_name()) + '_') -1) FROM Visitor;"; 
            cmmd.CommandText = "SELECT LEFT(db_name(), len(db_name()) - charindex('_', reverse(db_name()) + '_')) FROM Visitor";
            //cmmd.CommandText = "SELECT * FROM Visitor where ID = ;";
            cmmd.ExecuteNonQuery(); 
            SqlDataReader DR1 = cmmd.ExecuteReader();
            if (DR1.Read())
            {
                txtFirstname.Text = DR1.GetValue(0).ToString();
                txtLastName.Text = DR1.GetValue(1).ToString();
                txtAge.Text = DR1.GetValue(2).ToString();
                txtDay.Text = DR1.GetValue(3).ToString();
            }
            conn.Close();
        }
    }
}
