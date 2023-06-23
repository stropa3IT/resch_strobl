using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resthome_Database
{
    public partial class PersonalForm : Form
    {

        public static string databasen = "Resthome";
        public static SqlConnection conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB; integrated security = true;");
        public static SqlCommand cmmd = new SqlCommand("", conn);
        DataTable dataTable;
        
        public PersonalForm()
        {
            InitializeComponent();
            //settings to put the windows forms window into the middle of the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //With SqlBulk you can add, edit, delete ... data from your datagridview and it copies the items to your datatable
                string chhtable = (string)cbTables.SelectedItem;
                cmmd.CommandText = "Truncate table Visitor";
                conn.Close();
                conn.Open();
                cmmd.ExecuteNonQuery();
                SqlBulkCopy copy = new SqlBulkCopy(conn);
                copy.DestinationTableName = chhtable;
                copy.WriteToServer(dataTable);
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong, please try something else");
            }
        }

        private void Connect()
        {

            string connectionString = @"Data Source=MyServerName;Initial Catalog=MyDbName; User ID=Admin; Password=Root";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            connection.Close();

        }

        public static bool CheckForDatabase(SqlConnection conn, string db)
        {
            //Checking again if the database does already exist, we look at the table db_id where all databases are included too. And if there is our database it will return us the id.
            SqlCommand comm = new SqlCommand($"SELECT db_id('{db}')", conn);
            conn.Open();
            return comm.ExecuteScalar() != DBNull.Value;
        }

        static void CreateDatabase(SqlConnection conn, SqlCommand cmmd, string databasen)
        {
            try
            {
                //here we create the database, with the normal creation statement
                Console.WriteLine("Database does not exist");
                conn.Close();
                conn.Open();
                cmmd.CommandText = "CREATE DATABASE " + databasen;
                cmmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong, please try something else");
            }
        }
        static void CreateTable(SqlConnection conn, SqlCommand cmmd, string databasen)
        {
            try
            {
                //here we create the tables 'Pensioner', 'Personal' and 'Visitor' with the normal creation statement
                conn.Close();
                conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Integrated Security = true; Database = " + databasen;
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("", conn);
                sqlCommand.CommandText = "CREATE TABLE Pensioner([ID] INT NOT NULL PRIMARY KEY IDENTITY, [Firstname] VARCHAR(50) NULL, [LastName] VARCHAR(50) NULL, [Age] INT NOT NULL, [Roomnumber] NVARCHAR(100) NULL, [Carelevel] INT)";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = "CREATE TABLE Personal([ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), [Firstname] VARCHAR(50) NULL, [LastName] NVARCHAR(50) NULL, [Age] INT)";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = "CREATE TABLE Visitor([ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), [Firstname] VARCHAR(50) NULL, [LastName] VARCHAR(50) NULL, [Age] INT NOT NULL, [Day] DATETIME)";
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Something went wrong, please try something else");
            }
        }

        private void PersonalForm_Load(object sender, EventArgs e)
        {
            if (CheckForDatabase(conn, databasen))
            {
                //here we check if the database does already exist, and then we adding the differen table names to our combobx
                //then we just insert an clear row to our data, so that it looks nicer at the dgv. If the database doesn't exist we
                //are creating a new one plus new tables
                conn.Close();
                conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Integrated Security = true; Database = " + databasen;
                conn.Open();
                cbTables.Items.Add("Pensioner");
                cbTables.Items.Add("Personal");
                cbTables.Items.Add("Visitor");
                cmmd.CommandText = "INSERT INTO Visitor (Firstname, LastName, Age, Day) VALUES ('','','','')";
                cmmd.ExecuteNonQuery();
                cmmd.CommandText = "INSERT INTO Pensioner (Firstname, LastName, Age, Roomnumber, Carelevel) VALUES ('','','', '','')";
                cmmd.ExecuteNonQuery();
            }
            else
            {
                CreateDatabase(conn, cmmd, databasen);
                CreateTable(conn, cmmd, databasen);
            }
        }

        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTables.SelectedItem.Equals("Personal"))
                {
                    //here we firstly select everything from the personal table and then we just get a reader and read every data
                    //then we put it to our dgv with the datasource method, readonly is true because the personal shouldn't be able to edit themselves
                    string Query;
                    //string chtable = (string)cbTables.SelectedItem;
                    Query = "SELECT * FROM Personal" /*chtable*/;
                    conn.Close();
                    conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Integrated Security = true; Database = " + databasen;
                    conn.Open();
                    cmmd.CommandText = Query;//here I could do it with the index (dr[0]) for example! btn.name.ToString(); instead of ID
                    cmmd = new SqlCommand(Query, conn);
                    SqlDataReader dataReader = cmmd.ExecuteReader();
                    dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    dgvShowData.DataSource = dataTable;
                    dgvShowData.ReadOnly = true;
                    conn.Close();
                }
                else if (cbTables.SelectedItem.Equals("Pensioner"))
                {
                    //here we firstly select everything from the personal table and then we just get a reader and read every data
                    //then we put it to our dgv with the datasource method, readonly is false because the personal should be able to change the pensioners data if they need to
                    string Query;
                    //string chtable = (string)cbTables.SelectedItem;
                    Query = "SELECT * FROM Pensioner" /*chtable*/;
                    conn.Close();
                    conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Integrated Security = true; Database = " + databasen;
                    conn.Open();
                    cmmd = new SqlCommand(Query, conn);
                    SqlDataReader dataReader = cmmd.ExecuteReader();
                    dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    dgvShowData.DataSource = dataTable;
                    dgvShowData.ReadOnly = false;
                    conn.Close();
                }
                else if (cbTables.SelectedItem.Equals("Visitor"))
                {
                    //here we firstly select everything from the personal table and then we just get a reader and read every data
                    //then we put it to our dgv with the datasource method, readonly is false because the personal should be able to change the visitors data if they need to
                    string Query;
                    //string chtable = (string)cbTables.SelectedItem;
                    Query = "SELECT * FROM Visitor" /*chtable*/;
                    cmmd.CommandText = Query;//here I could do it with the index (dr[0]) for example! btn.name.ToString(); instead of ID
                    conn.Close();
                    conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Integrated Security = true; Database = " + databasen;
                    conn.Open();
                    cmmd = new SqlCommand(Query, conn);
                    SqlDataReader dataReader = cmmd.ExecuteReader();
                    dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    dgvShowData.DataSource = dataTable;
                    dgvShowData.ReadOnly = false;
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong, please try something else");
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong, please try something else");
            }
        }
    }
}
