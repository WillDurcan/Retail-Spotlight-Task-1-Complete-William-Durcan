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
using System.Globalization;
using System.Text.RegularExpressions;

namespace tasks_for_work
{
    public partial class Form1 : Form
    {
        //DataTable = new

        string[] Collumheaders;
        public Form1()
        {
            InitializeComponent();
            createtable();
        }

        private bool Isrowcomplete(String[] list)
        {
            int a = 0;
            string failedcell = "";
            int indexfailed;
            foreach (string cell in list)
            {
                if (cell.Equals("") == true)
                {
                    a = 1;
                    // indexfailed = list[]

                }
            }
            if (a == 1)
            {
              //  Console.WriteLine("Row contains a empty elemement");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool isquanitityaint(string cell)
        {
            int a = 0;
            int quantity;
            bool success = Int32.TryParse(cell, out quantity);
            if (success == true)
            {
              //  Console.WriteLine("Quanity is equal to valid int value");
                return true;
            }
            else
            {
              //  Console.WriteLine("Quanity is NOT equal to valid int value");
                return false;
            }
        }


        public void createtable()
        {
            
                string csv = System.IO.File.ReadAllText("test_cases.csv");
            
           

            string erroroutput;

            csv = csv.Replace("£", "");

            csv = csv.Replace("'", "");        

            string pattern = ("\"\r\n\""); // only repalces if its a quote folled by the \r then \n 

            string result = Regex.Replace(csv, pattern, "\n", RegexOptions.None);

            string result2 = result.Replace("\r\n", ""); // repalces the carangae return

            string pattern2 = ("\",\"");

            string result3 = Regex.Replace(result2, pattern2, "\n", RegexOptions.None);


            result3 = result3.Replace(",", "");

            result3 = result3.Replace("\"", "");

            result3 = result3.Replace("\"\"", "");



            Console.WriteLine(result3);
           
        

            string[] headers = result3.Split('\n').Skip(0).Take(7).ToArray();
            string[] row1 = result3.Split('\n').Skip(7).Take(7).ToArray();
            string[] row2 = result3.Split('\n').Skip(14).Take(7).ToArray();
            string[] row3 = result3.Split('\n').Skip(21).Take(7).ToArray();
            string[] row4 = result3.Split('\n').Skip(28).Take(7).ToArray();
            string[] row5 = result3.Split('\n').Skip(35).Take(7).ToArray();
            string[] row6 = result3.Split('\n').Skip(42).Take(7).ToArray();
            string[] row7 = result3.Split('\n').Skip(49).Take(7).ToArray();
            string[] row8 = result3.Split('\n').Skip(56).Take(7).ToArray();
            string[] row9 = result3.Split('\n').Skip(63).Take(7).ToArray();
            string[] row10 = result3.Split('\n').Skip(70).Take(7).ToArray();
            string[] row11 = result3.Split('\n').Skip(77).Take(7).ToArray();

            DataTable DataTable = new DataTable();

            

            Console.WriteLine("***************");

            string[] Fields = result3.Split('\n');

            string errorlog;

           
            Console.WriteLine("***************");

            foreach (string headerWord in headers)
            {
                // Regex.Replace(headerWord, @"[^0-9a-zA-Z]+", "");
              
                DataTable.Columns.Add(new DataColumn(headerWord));
               
            }
            DataRow dr = DataTable.NewRow();
            DataRow dr2 = DataTable.NewRow();
            DataRow dr3 = DataTable.NewRow();
            DataRow dr4 = DataTable.NewRow();
            DataRow dr5 = DataTable.NewRow();
            DataRow dr6 = DataTable.NewRow();
            DataRow dr7 = DataTable.NewRow();
            DataRow dr8 = DataTable.NewRow();
            DataRow dr9 = DataTable.NewRow();
            DataRow dr10 = DataTable.NewRow();

            string[] dataWords;
            int columnIndex = 0;
            int columnIndex2 = 0;
            int columnIndex3 = 0;
            int columnIndex4 = 0;
            int columnIndex5 = 0;
            int columnIndex6 = 0;
            int columnIndex7 = 0;
            int columnIndex8 = 0;
            int columnIndex9 = 0;
            int columnIndex10 = 0;

            
            /// Row 1 adding 


            Console.WriteLine("\n *************************************************************** \n");

            Console.WriteLine("\n ****************** Error Log ************************ \n");

            if (Isrowcomplete(row1) == true)
            {
                //DataRow dr = DataTable.NewRow();
                int deletethisrow = 0;

                foreach (string headerWord in headers)
                {
                    int index =0;
                    int validrow = 0;

                    if (headerWord.Equals("quantity"))
                    {
                        string quantity = row1[columnIndex].ToString();

                        if (isquanitityaint(quantity) == false)
                        {
                            Console.WriteLine("Row 1 - Cannot add row as Quantity is not a valid int");
                            dr.Delete();
                            validrow = 1;
                            deletethisrow = 1;

                        }
                    }

                    if (validrow == 0)
                    {
                        dr[headerWord] = row1[columnIndex++];
                    }
                }
                //DataTable.Rows.InsertAt(dr, 0);
                DataTable.Rows.Add(dr);
                //DataTable.NewRow();


                if (deletethisrow == 1)
                {
                    DataTable.Rows.Clear();
                }
            }
            else if (Isrowcomplete(row1) == false)
            {
                Console.WriteLine("Row 1 - Error row contains blank elememts and cannot be added");
            }

            /// Row 2 adding 


            if (Isrowcomplete(row2) == true)
            {
                int deletethisrow = 0;

                foreach (string headerWord in headers)
                {
                    
                    int validrow = 0;

                    if (headerWord.Equals("quantity"))
                    {
                        string quantity = row2[columnIndex2].ToString();

                        if (isquanitityaint(quantity) == false)
                        {
                            Console.WriteLine("Cannot add row as Quantity is not a valid int");
                            dr2.Delete();
                            validrow = 1;
                            deletethisrow = 1;

                        }
                    }

                    if (validrow == 0)
                    {
                        dr2[headerWord] = row2[columnIndex2++];
                    }
                }

                DataTable.Rows.Add(dr2);

                if (deletethisrow == 1)
                {
                    DataTable.Rows.Remove(dr2);
                }
            }
            else if (Isrowcomplete(row2) == false)
            {
                Console.WriteLine("Row 3 - Error row contains blank elememts and cannot be added");
            }
            
            

            /// Row 3 adding

            if (Isrowcomplete(row3) == true)
            {
                int deletethisrow = 0;

                foreach (string headerWord in headers)
                {
                    int index = columnIndex3;
                    int validrow = 0;

                    if (headerWord.Equals("quantity"))
                    {
                        string quantity = row3[columnIndex3].ToString();

                        if (isquanitityaint(quantity) == false)
                        {
                            Console.WriteLine("Cannot add row as Quantity is not a valid int");
                            dr3.Delete();
                            validrow = 1;
                            deletethisrow = 1;

                        }
                    }

                    if (validrow == 0)
                    {
                        dr3[headerWord] = row3[columnIndex3++];
                    }
                }

                DataTable.Rows.Add(dr3);
                //DataTable.ImportRow(dr3);

                if (deletethisrow == 1)
                {
                    DataTable.Rows.Remove(dr3);
                }
            }
            else if (Isrowcomplete(row3) == false)
            {
                Console.WriteLine("Row 3 - Error row contains blank elememts and cannot be added");
            }
            

            /// Row 4 adding

            if (Isrowcomplete(row4) == true)
            {
                int deletethisrow = 0;

                foreach (string headerWord in headers)
                {
                    int index = columnIndex2;
                    int validrow = 0;

                    if (headerWord.Equals("quantity"))
                    {
                        string quantity = row4[columnIndex4].ToString();

                        if (isquanitityaint(quantity) == false)
                        {
                            Console.WriteLine("Row 4 - Cannot add row as Quantity is not a valid int");
                            dr4.Delete();
                            validrow = 1;
                            deletethisrow = 1;

                        }
                    }

                    if (validrow == 0)
                    {
                        dr4[headerWord] = row4[columnIndex4++];
                    }

                    
                }
                DataTable.Rows.Add(dr4);
                if (deletethisrow == 1)
                {
                    DataTable.Rows.Remove(dr4);
                }
            }
            else if (Isrowcomplete(row4) == false)
            {
                Console.WriteLine("Row 4 - Error row contains blank elememts and cannot be added");
            }

            

            /// Row 5 adding
            if (Isrowcomplete(row5) == true)
            {
                int deletethisrow = 0;

                foreach (string headerWord in headers)
                {
                    int index = columnIndex2;
                    int validrow = 0;

                    if (headerWord.Equals("quantity"))
                    {
                        string quantity = row4[columnIndex5].ToString();

                        if (isquanitityaint(quantity) == false)
                        {
                            Console.WriteLine("Row 5 - Cannot add row as Quantity is not a valid int");
                            dr5.Delete();
                            validrow = 1;
                            deletethisrow = 1;

                        }
                    }

                    if (validrow == 0)
                    {
                        dr5[headerWord] = row5[columnIndex5++];
                    }
                }

                DataTable.Rows.Add(dr5);

                if (deletethisrow == 1)
                {
                    DataTable.Rows.Remove(dr5);
                }
            }
            else if (Isrowcomplete(row5) == false)
            {
                Console.WriteLine("Row 5 - Error row contains blank elememts and cannot be added");
            }

            /// Row 6 adding
            if (Isrowcomplete(row6) == true)
            {
                int deletethisrow = 0;

                foreach (string headerWord in headers)
                {
                    int index = columnIndex2;
                    int validrow = 0;

                    if (headerWord.Equals("quantity"))
                    {
                        string quantity = row6[columnIndex6].ToString();

                        if (isquanitityaint(quantity) == false)
                        {
                            Console.WriteLine("Row 6 - Cannot add row as Quantity is not a valid int");
                            dr6.Delete();
                            validrow = 1;
                            deletethisrow = 1;

                        }
                    }

                    if (validrow == 0)
                    {
                        dr6[headerWord] = row6[columnIndex6++];
                    }
                }

                DataTable.Rows.Add(dr6);

                if (deletethisrow == 1)
                {
                    DataTable.Rows.Remove(dr6);
                }
            }
            else if (Isrowcomplete(row6) == false)
            {
                Console.WriteLine("Row 6 - Error row contains blank elememts and cannot be added");
            }

            /// Row 7 adding
            if (Isrowcomplete(row7) == true)
            {
                int deletethisrow = 0;

                foreach (string headerWord in headers)
                {
                    int index = columnIndex2;
                    int validrow = 0;

                    if (headerWord.Equals("quantity"))
                    {
                        string quantity = row7[columnIndex7].ToString();

                        if (isquanitityaint(quantity) == false)
                        {
                            Console.WriteLine("Row 7 - Cannot add row as Quantity is not a valid int");
                            dr7.Delete();
                            validrow = 1;
                            deletethisrow = 1;

                        }
                    }

                    if (validrow == 0)
                    {
                        dr7[headerWord] = row7[columnIndex7++];
                    }
                }

                DataTable.Rows.Add(dr7);

                if (deletethisrow == 1)
                {
                    DataTable.Rows.Remove(dr7);
                }
            }
            else if (Isrowcomplete(row7) == false)
            {
                Console.WriteLine("Row 7 - Error row contains blank elememts and cannot be added");
            }

            /// Row 8 adding
            if (Isrowcomplete(row8) == true)
            {
                int deletethisrow = 0;

                foreach (string headerWord in headers)
                {
                    int index = columnIndex2;
                    int validrow = 0;

                    if (headerWord.Equals("quantity"))
                    {
                        string quantity = row8[columnIndex8].ToString();

                        if (isquanitityaint(quantity) == false)
                        {
                            Console.WriteLine("Row 8 - Cannot add row as Quantity is not a valid int");
                            dr8.Delete();
                            validrow = 1;
                            deletethisrow = 1;

                        }
                    }

                    if (validrow == 0)
                    {
                        dr8[headerWord] = row8[columnIndex8++];
                    }
                }

                DataTable.Rows.Add(dr8);

                if (deletethisrow == 1)
                {
                    DataTable.Rows.Remove(dr8);
                }
            }
            else if (Isrowcomplete(row8) == false)
            {
                Console.WriteLine("Row 8 -Error row contains blank elememts and cannot be added");
            }


            /// Row 9 adding
            if (Isrowcomplete(row9) == true)
            {
                int deletethisrow = 0;

                foreach (string headerWord in headers)
                {
                    int index = columnIndex2;
                    int validrow = 0;

                    if (headerWord.Equals("quantity"))
                    {
                        string quantity = row9[columnIndex9].ToString();

                        if (isquanitityaint(quantity) == false)
                        {
                            Console.WriteLine("Row 9 - Cannot add row as Quantity is not a valid int");
                            dr9.Delete();
                            validrow = 1;
                            deletethisrow = 1;

                        }
                    }

                    if (validrow == 0)
                    {
                        dr9[headerWord] = row9[columnIndex9++];
                    }
                }

                DataTable.Rows.Add(dr9);

                if (deletethisrow == 1)
                {
                    DataTable.Rows.Remove(dr9);
                }
            }
            else if (Isrowcomplete(row9) == false)
            {
                Console.WriteLine("Row 9 - Error row contains blank elememts and cannot be added");
            }


            /// Row 10 adding 
            if (Isrowcomplete(row10) == true)
            {
                int deletethisrow = 0;

                foreach (string headerWord in headers)
                {
                    int index = columnIndex2;
                    int validrow = 0;

                    if (headerWord.Equals("quantity"))
                    {
                        string quantity = row10[columnIndex10].ToString();

                        if (isquanitityaint(quantity) == false)
                        {
                            Console.WriteLine("Row 10 - Cannot add row as Quantity is not a valid int");
                            dr10.Delete();
                            validrow = 1;
                            deletethisrow = 1;

                        }
                    }

                    if (validrow == 0)
                    {
                        dr10[headerWord] = row10[columnIndex10++];
                    }
                }

                DataTable.Rows.Add(dr10);

                if (deletethisrow == 1)
                {
                    DataTable.Rows.Remove(dr10);
                }
            }
            else if (Isrowcomplete(row10) == false)
            {
                Console.WriteLine("Row 10 - Error row contains blank elememts and cannot be added");
            }
         

            DataGrid.DataSource = DataTable;

            Console.WriteLine("\n *************************************************************** \n");



        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

    }
}

