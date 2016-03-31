using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CsvHelper;
using System.Diagnostics;
using iAnywhere.Data.SQLAnywhere;

namespace CSV_Reader_for_Database
{
    public partial class Form1 : Form
    {
        DataTable DTAcctLog = new DataTable("AcctLog");
        DataSet dSet = new DataSet();
        
        public Form1()
        {
            
            InitializeComponent();
            ToolTip toolTip1 = new ToolTip();
            //toolTip1.AutoPopDelay = 500;
            toolTip1.InitialDelay = 5;
            //toolTip1.ReshowDelay = 5;
            toolTip1.SetToolTip(this.connStr, "Format:  eng=Database Name;uid=clubuser;pwd=Password;links=tcp");
            toolTip1.ShowAlways = true;

            TheDataTables TDT = new TheDataTables();
            filePath.AutoCompleteSource = AutoCompleteSource.FileSystem;
            filePath.AutoCompleteMode = AutoCompleteMode.Suggest;
            #region TABLES
            //HEY - This is stupid. You did bad here. It's easier to query the DB to get the table schema, and then update the DataTable that you dump that query in to.

            //DTAcctLog.Columns.Add("unique_id");//, typeof(int));
            //DTAcctLog.Columns.Add("repuid");//, typeof(int));
            //DTAcctLog.Columns.Add("memid");//, typeof(int));
            //DTAcctLog.Columns.Add("start_time");//, typeof(DateTime));
            //DTAcctLog.Columns.Add("endtime");//, typeof(DateTime));
            //DTAcctLog.Columns.Add("Module");//, typeof(char));
            //DTAcctLog.Columns.Add("numchanged");//, typeof(int)); //this is the last column the test CSV needs.
            //DTAcctLog.Columns.Add("numchanged1");//, typeof(int));
            //DTAcctLog.Columns.Add("numchanged2");//, typeof(int));
            //DTAcctLog.Columns.Add("numchanged3");//, typeof(int));
            //DTAcctLog.Columns.Add("numchanged4");//, typeof(int));
            //DTAcctLog.Columns.Add("numchanged5");//, typeof(int));
            #endregion
            // initialize the datagridview so you can see that shit and make sure it's working.



        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
       { 
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string path = openFileDialog1.FileName;
                filePath.Text = path;
            }
           
        }

        private void button2_Click(object sender, EventArgs e) //assign elements button
        {
           /*Need to add some sort of for each loop incorporating the CSV file that'll add a column for 
            each element of data. 
            */
            int i = 0;
            
            try
            {
                StreamReader csvFile = new StreamReader(filePath.Text);
                var csvData = new CsvParser(csvFile);
                csvData.Configuration.Quote = '\'';
                //var row = csvData.Read();
                dataGridView1.DataSource = DTAcctLog;
                while (true)
                {
                  
                    
                    var row = csvData.Read();
                    
                    if (row == null)
                    {
                        break;
                    }

                    
                   while (i < row.Length)
                    {
                        DTAcctLog.Columns.Add(String.Format("Array Element {0}", (i))); //fancy way of doing it.
                        //DTAcctLog.Columns.Add("Column " + (i+1)); //what I did originally and still works fine for this application
                        i++;
                    }

                    DTAcctLog.Rows.Add(row);

                    dataGridView1.Refresh(); //refresh the data grid view when you grab fresh data. 
                    
                }
                
               

            }
            catch (Exception ex)
            {
               
                MessageBoxHelper.PrepToCenterMessageBoxOnForm(this);
                MessageBox.Show("You fucked up\n" + ex.Message);
                
            }
            finally
            {
                button2.Show();
            }
            //DTAcctLog.Rows.Add(1, 2);
            //git test
            //dataGridView1.Refresh(); //refresh the data grid view when you grab fresh data. 



        }
        

        private void filePath_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void resultsTest_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void convertCSV_Click(object sender, EventArgs e)
        {
            previewCSV pCSV = new previewCSV();
            pCSV.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            



        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            DTAcctLog.Clear();
            
            
            //Debug.WriteLine(potato);
            //foreach (int value in dataGridView1.Columns.GetColumnCount)
            {
                dataGridView1.Columns.Clear();
            }
            string connectionString = connStr.Text.Trim();
            try
            {
               using (SAConnection conn = new SAConnection(connectionString)) //DataSet tester
                {
                    conn.Open(); //open connection from using block
                    SADataAdapter da = new SADataAdapter(); //create a new data adapter. I don't know what's special about this. 
                    da.SelectCommand = new SACommand("Select top 1 * from AcctLog where 1=2", conn);
                    dataGridView1.DataSource = DTAcctLog;
                    SACommandBuilder cb = new SACommandBuilder(da);
                    da.Fill(DTAcctLog);
                }

            }
            catch (Exception ex)
            {
                MessageBoxHelper.PrepToCenterMessageBoxOnForm(this);
                MessageBox.Show("Error\n" + ex.Message); 

            }
            finally
            {
                dataGridView1.Refresh();
            }

            
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            string connectionString = connStr.Text.Trim();
            try
            {

                using (SAConnection conn = new SAConnection(connectionString)) //DataSet tester
                {
                    DTAcctLog.Clear(); //doesn't affect the update.
                    conn.Open(); //open connection from using block
                    SADataAdapter da = new SADataAdapter("Select * from acctlog", conn); //create a new data adapter. I don't know what's special about this. 
                    SACommandBuilder cb = new SACommandBuilder(da);
                    cb.ConflictOption = ConflictOption.OverwriteChanges; //cheaty bullshit for just overpowering the conflict changes negating the concurrency violation.
                    da.Fill(DTAcctLog); //you have to fill it to update it. 
                    //DTAcctLog.Rows[0]["unique_id"] = 1;
                    //DTAcctLog.Rows[0]["repuid"] = 2000001; 
                    //DTAcctLog.Rows[3]["repuid"] = 2000004; The value of the array (Rows[3]) will indicate which row to update. Starts at 0.

                    da.UpdateCommand = cb.GetUpdateCommand();
                    da.Update(DTAcctLog);
                    DTAcctLog.AcceptChanges();
                    dataGridView1.DataSource = DTAcctLog;
                    //da.Fill(DTAcctLog);
                    
                    
                }

            }
            catch (Exception ex)
            {
                MessageBoxHelper.PrepToCenterMessageBoxOnForm(this);
                MessageBox.Show("Error\n" + ex.Message + "\n\n" + ex.ToString() );

            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolTip1_Popup_1(object sender, PopupEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = DTAcctLog.ToString();
        }
    }
}
