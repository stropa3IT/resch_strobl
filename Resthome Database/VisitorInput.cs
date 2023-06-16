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
        public static string databasen = "Resthome";
        public static SqlConnection conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB; integrated security = true; database =  " + databasen);
        public static SqlCommand cmmd = new SqlCommand("", conn);

        public VisitorInput()
        {
            InitializeComponent();
        }

        private void VisitorInput_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateVisitor_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                MessageBox.Show(DateTime.Now.ToString());
                cmmd.CommandText = "INSERT INTO Visitor (Firstname, LastName, Age, Day) VALUES ( '" + txtFirstname.Text + "', '" + txtLastName.Text + "', " + Int32.Parse(txtAge.Text) + ", '" + txtDay.Text + "');";
                cmmd.ExecuteNonQuery();
                conn.Close();
                this.Visible = false; 
            }
            catch(FormatException) 
            {
                MessageBox.Show("Sie haben das falsche Format eingegeben, geben Sie nächstes Mal das Datums Format so ein: yyyy-mm-dd (hh:mm:ss) und bei Alter (Age) dürfen sie nur Zahlen eingeben!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Etwas ist schiefgegangen, nur wissen wir nicht was!");
            }
        }
    }
}
