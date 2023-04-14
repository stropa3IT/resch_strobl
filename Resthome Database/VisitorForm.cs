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
    public partial class FormVisitor : Form
    {
        public static string databasen = "Resthome";
        public static SqlConnection conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB; integrated security = true;");
        public static SqlCommand cmmd = new SqlCommand("", conn);
        DataTable dataTable;

        public FormVisitor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (CheckForDatabase(conn, databasen))
            {
                cbTables.Items.Add("Pensioner");
                cbTables.Items.Add("Personal");
                cbTables.Items.Add("Visitor");
            }
            else
            {
                CreateDabase(conn, cmmd, databasen);
                CreateTable(conn, cmmd, databasen);
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
            SqlCommand comm = new SqlCommand($"SELECT db_id('{db}')", conn);
            conn.Open();
            return comm.ExecuteScalar() != DBNull.Value;
        }

        static void CreateDabase(SqlConnection conn, SqlCommand cmmd, string databasen)
        {
            try
            {
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
        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTables.SelectedItem.Equals("Personal"))
                {
                    string Query;
                    //string chtable = (string)cbTables.SelectedItem;
                    Query = "SELECT * FROM Personal" /*chtable*/;
                    cmmd.CommandText = Query;//here I could do it with the index (dr[0]) for example! btn.name.ToString(); instead of ID
                    conn.Close();
                    conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Integrated Security = true; Database = " + databasen;
                    conn.Open();
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
                    string Query;
                    //string chtable = (string)cbTables.SelectedItem;
                    Query = "SELECT * FROM Pensioner" /*chtable*/;
                    cmmd.CommandText = Query;//here I could do it with the index (dr[0]) for example! btn.name.ToString(); instead of ID
                    conn.Close();
                    conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Integrated Security = true; Database = " + databasen;
                    conn.Open();
                    cmmd = new SqlCommand(Query, conn);
                    SqlDataReader dataReader = cmmd.ExecuteReader();
                    dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    dgvShowData.DataSource = dataTable;
                    dgvShowData.ReadOnly = true;
                    conn.Close();
                }
                else if (cbTables.SelectedItem.Equals("Visitor"))
                {
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
                    //DataGridViewRow row = new DataGridViewRow();
                    //row.CreateCells(dgvShowData);
                    //row.Cells[0].Value = "";
                    //row.Cells[1].Value = "";
                    //dgvShowData.Rows.Add(row);
                    dgvShowData.DataSource = dataTable;
                    DataGridViewRow row = (DataGridViewRow)dgvShowData.Rows[0].Clone();
                    //row.Cells[0].Value = "";
                    //row.Cells[1].Value = "";
                    //row.Cells[2].Value = "";
                    //row.Cells[3].Value = ""; 
                    //dgvShowData.Rows.Add(row);
                    //dgvShowData.VirtualMode = true; 
                    //dgvShowData.NewRowNeeded += 1;
                    if (dgvShowData.IsCurrentCellInEditMode)
                    {
                        dgvShowData.ReadOnly = false;
                    }
                    else
                    {
                        dgvShowData.ReadOnly = true; 
                    }
              
                    //foreach (DataGridViewRow rowe in dgvShowData.Rows)
                    //{
                    //    if (!rowe.IsNewRow)
                    //    {
                    //        rowe.ReadOnly = true;
                    //    }
                    //}
                    conn.Close();
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("one");
                    DataRow dr = dt.NewRow();
                    dr["one"] = "not editable";
                    dt.Rows.Add(dr);
                    DataRow dr1 = dt.NewRow();
                    dr1["one"] = "editable";
                    dt.Rows.Add(dr1);
                    dgvShowData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Something went wrong, please try something else");
                MessageBox.Show(ex.ToString());
            }
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

        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvShowData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //sfdg
        }

        //private void dgvShowData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dgvShowData["one", e.RowIndex].Value == "not editable")
        //        dgvShowData.Rows[e.RowIndex].ReadOnly = true;
        //    else
        //        dgvShowData.Rows[e.RowIndex].ReadOnly = false;
        //}

        //private void dgvShowData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //foreach (DataGridViewRow row in dgvShowData.Rows)
        //{
        //    if (!row.IsNewRow)
        //    {
        //        row.ReadOnly = true;
        //    }
        //}
        //}

        //void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)

        //{

        //    if (dataGridView1.NewRowIndex == e.RowIndex)

        //    {

        //        dataGridView1.Rows[e.RowIndex].ReadOnly = false;

        //    }

        //    else

        //    {

        //        dataGridView1.Rows[e.RowIndex].ReadOnly = true;

        //    }

        //} 
        //private void dgvShowData_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dgvShowData["one", e.RowIndex].Value == "not editable")
        //        dgvShowData.Rows[e.RowIndex].ReadOnly = true;
        //    else
        //        dgvShowData.Rows[e.RowIndex].ReadOnly = false;
        //}

        //private void myDataGridview_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{

        //    myDataGridview.Rows[e.RowIndex].ReadOnly = false;
        //    myDataGridview.FirstDisplayedScrollingRowIndex = e.RowIndex;

        //}
    }
}

       