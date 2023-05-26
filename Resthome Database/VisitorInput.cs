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
            try
            {
                conn.Close();
                conn.Open();
                cmmd.CommandText = "INSERT INTO Visitor (Firstname, LastName, Age, Day) VALUES ( '" + txtFirstname.Text + "', '" + txtLastName.Text + "', " + Int32.Parse(txtAge.Text) + ", '" + txtDay.Text + "');";
                cmmd.ExecuteNonQuery();
                conn.Close();
                this.Visible = false;
                FormVisitor formVisitor = new FormVisitor();
                formVisitor.ShowDialog();
                this.Close();
            }
            catch(System.FormatException FE)
            {
                MessageBox.Show("Sie haben das falsche Format eingegeben, geben Sie nächstes Mal bitte nur Zahlen ein!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Geben Sie nächstes Mal beim Datum Ihr Datum laut diesem Format ein: 00.00.0000 00:00:00 --> sprich Tag.Monat.Jahr und die Uhrzeit: Stunden:Minuten:Sekunden!");
            }
        }
    }
}
