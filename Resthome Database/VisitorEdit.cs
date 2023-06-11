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

            //https://stackoverflow.com/questions/39002025/is-there-a-lastindexof-in-sql-server   
            //cmmd.CommandText = "SELECT right(db_name(), charindex('_', reverse(db_name()) + '_') -1) FROM Visitor;"; 
            //cmmd.CommandText = "SELECT LEFT(db_name(), len(db_name()) - charindex('_', reverse(db_name()) + '_')) FROM Visitor";

            conn.Open();
            string data = "SELECT * FROM Visitor";
            SqlCommand cm = new SqlCommand(data, conn);
            SqlDataReader dr = cm.ExecuteReader();
            //cmmd.CommandText = "SELECT * FROM Visitor where ID = " + dr[0] + "";
            while (dr.Read()) //you can also use for I guess
            {
                txtID.Text = dr[0].ToString();
                txtFirstname.Text = dr[1].ToString();
                txtLastName.Text = dr[2].ToString();
                txtAge.Text = dr[3].ToString();
                txtDay.Text = dr[4].ToString();
            }
            dr.Close();
            conn.Close();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            cmmd.CommandText = "UPDATE Visitor SET Firstname = '" + txtFirstname.Text + "', LastName = '" + txtLastName.Text + "', Age = " + Int32.Parse(txtAge.Text) + ", Day = '" + txtDay.Text + "' WHERE ID = " + txtID.Text + ";";
            cmmd.ExecuteNonQuery();
            conn.Close();
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmmd.CommandText = "DELETE FROM Visitor WHERE ID = " + txtID.Text + ";";
            cmmd.ExecuteNonQuery();
            btnEdit.Enabled = false;
            btnLoadLastIndex.Enabled = false;
            txtDelete.Enabled = false;
            conn.Close();
            this.Visible = false;
            FormVisitor formVisitor = new FormVisitor();
            formVisitor.ShowDialog();
            this.Close();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormVisitor formVisitor = new FormVisitor();
            formVisitor.ShowDialog();
            this.Close();
        }
    }
}
