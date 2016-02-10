﻿using System;
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
        

        public Form1()
        {

            
            InitializeComponent();
            TheDataTables TDT = new TheDataTables();
            filePath.AutoCompleteSource = AutoCompleteSource.FileSystem;
            filePath.AutoCompleteMode = AutoCompleteMode.Suggest;

            DTAcctLog.Columns.Add("unique_id");//, typeof(int));
            DTAcctLog.Columns.Add("repuid");//, typeof(int));
            DTAcctLog.Columns.Add("memid");//, typeof(int));
            DTAcctLog.Columns.Add("start_time");//, typeof(DateTime));
            DTAcctLog.Columns.Add("endtime");//, typeof(DateTime));
            DTAcctLog.Columns.Add("Module");//, typeof(char));
            DTAcctLog.Columns.Add("numchanged");//, typeof(int));
            DTAcctLog.Columns.Add("numchanged1");//, typeof(int));
            DTAcctLog.Columns.Add("numchanged2");//, typeof(int));
            DTAcctLog.Columns.Add("numchanged3");//, typeof(int));
            DTAcctLog.Columns.Add("numchanged4");//, typeof(int));
            DTAcctLog.Columns.Add("numchanged5");//, typeof(int));

            dataGridView1.DataSource = DTAcctLog; // initialize the datagridview so you can see that shit and make sure it's working.



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
            StreamReader csvFile = new StreamReader(filePath.Text);
            var csvData = new CsvParser(csvFile);
            //var row = csvData.Read();
            
            try
            {
                
                while (true)
                {
                   
                    var row = csvData.Read();
                    //if (row = row.Empty) //attemping to handle nulls - if I figure something out this can be deleted. 
                    //{

                    //}
                    if (row == null)
                    {
                        break;
                    }
                    
                    //resultsTest.Text = row[0] + " " + row[1] + " " + row[2] + " " + row[3];
                    //foreach (string element in row) I might want this later - I like this.
                    //{     }

                    DTAcctLog.Rows.Add(row);


                    
                   

                   //DTAcctLog.Rows.Add(row[0], row[1], row[2], row[0]);
                   //DTAcctLog.Rows.Add(row[0], row[1], row[2], row[0]); //each row add propagates the columns for the row in order. A new row add row method will start a new row.
                    dataGridView1.Refresh(); //refresh the data grid view when you grab fresh data. 
                }
                
               

            }
            catch (Exception ex)
            {
               
                MessageBoxHelper.PrepToCenterMessageBoxOnForm(this);
                MessageBox.Show("You fucked up\n" + ex.Message);
                
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
            string connectionString = connStr.Text.Trim();
            try
            {
                
                using (SAConnection conn = new SAConnection(connectionString)) //open the connection to the database with the connection string
                {
                    conn.Open();
                    SADataAdapter da = new SADataAdapter("Select * from members where memnum like '999000'", conn);
                    da.Fill(DTAcctLog);
                    dataGridView1.DataSource = DTAcctLog;
                    dataGridView1.Refresh();
                }

            }
            catch (Exception)
            {
                MessageBoxHelper.PrepToCenterMessageBoxOnForm(this);
                MessageBox.Show("Error");

            }
            
        }
    }
}
