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
    public partial class VisitorInput : Form
    {
        public VisitorInput()
        {
            InitializeComponent();
        }

        private void VisitorInput_Load(object sender, EventArgs e)
        {

        }

        public static string databasen = "Resthome";
        public static SqlConnection conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB; integrated security = true; database =  " + databasen);
        public static SqlCommand cmmd = new SqlCommand("", conn);

        private void btnCreateVisitor_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmmd.CommandText = "INSERT INTO Visitor (Firstname, LastName, Age, Day) VALUES ( '"+ txtFirstname.Text + "', '" + txtLastName.Text + "', " + Int32.Parse(txtAge.Text) + ", '" + txtDay.Text + "');";
            cmmd.ExecuteNonQuery(); 
            conn.Close(); 
        }
    }
}
