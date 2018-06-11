/*
 * Program By : Preethi Sekar
 * Net ID :pxs163930
 * Submitted On: 02/11/2018
 * Project On: 
 * Building an efficient User Interface
 * Purpose: 
 * Understanding the Design concepts in building a User Interface 
 * which gives the user a comfortable and seamless experience which is also efficient.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2_pxs163930
{
    public partial class Form1 : Form
    {
        //Initializing the form
        public Form1()
        {
            InitializeComponent();
            Form1_Load();

        }

        //Actions performed on form load
        public void Form1_Load()
        {
            //Initialize the Date field
            this.txtDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            listView1.Items.Clear();
            //initialize the listview
            //load the data from the text file
            String line;
            if (File.Exists(@"CS6326Asg2.txt"))
            {
                using (StreamReader sw = new StreamReader(@"CS6326Asg2.txt"))
                {
                    while ((line = sw.ReadLine()) != null)
                    {
                        char[] delimiters = new char[] { '\t' };
                        string[] words = line.Split(delimiters);
                        String fn = words[0];
                        String ln = words[2];
                        String pn = words[9];

                        ListViewItem row = new ListViewItem(fn);
                        row.SubItems.Add(new ListViewItem.ListViewSubItem(row, ln));
                        row.SubItems.Add(new ListViewItem.ListViewSubItem(row, pn));
                        listView1.Items.Add(row);

                    }
                }
            }

        }
        DateTime starttime, endtime;
        double difference = 0;
        int flag = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //time the first character was entered
            if (flag == 0)
            {
                starttime = DateTime.Now;
                flag = 1;
            }

        }


        //Clear button
        private void button4_Click(object sender, EventArgs e)
        {
            clearFields(this);
        }


        //Clearing all text fields
        public void clearFields(Control control)
        {

            foreach (Control c in control.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }


            }
            //Set today's date
            this.txtDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            count = 0;
            toolStripStatusLabel1.Text = "";
            //Reset to the add functionality
            if (addButton.Enabled == false && modifyButton.Enabled == true)
            {
                addButton.Enabled = true;
                modifyButton.Enabled = false;
                deleteButton.Enabled = false;
            }
        }

        //add the form fields to the text file
        public void addtoFile()
        {
            String file = @"CS6326Asg2.txt";
            if (!File.Exists(file))
            {
                //create if there is no file
                using (StreamWriter tw = File.CreateText(file))
                {
                    tw.Write(txtFirstName.Text + "\t");
                    tw.Write(txtMiddleInitial.Text + "\t");
                    tw.Write(txtLastName.Text + "\t");
                    tw.Write(txtAddrLine1.Text + "\t");
                    tw.Write(txtAddrLine2.Text + "\t");
                    tw.Write(txtCity.Text + "\t");
                    tw.Write(txtState.Text + "\t");
                    tw.Write(txtZipCode.Text + "\t");
                    tw.Write(txtGender.Text.ToUpper() + "\t");
                    tw.Write(txtPhoneNumber.Text + "\t");
                    tw.Write(txtEmail.Text + "\t");
                    tw.Write(txtProof.Text.ToUpper() + "\t");
                    tw.Write(txtDate.Text + "\t");
                    tw.Write(starttime.ToString() + "\t");
                    tw.Write(difference.ToString() + "\t");
                    tw.Write(count.ToString() + "\n");
                    tw.Close();
                }
            }
            else
            {
                //append if file exists
                using (StreamWriter tw = File.AppendText(file))
                {
                    tw.Write(txtFirstName.Text + "\t");
                    tw.Write(txtMiddleInitial.Text + "\t");
                    tw.Write(txtLastName.Text + "\t");
                    tw.Write(txtAddrLine1.Text + "\t");
                    tw.Write(txtAddrLine2.Text + "\t");
                    tw.Write(txtCity.Text + "\t");
                    tw.Write(txtState.Text + "\t");
                    tw.Write(txtZipCode.Text + "\t");
                    tw.Write(txtGender.Text.ToUpper() + "\t");
                    tw.Write(txtPhoneNumber.Text + "\t");
                    tw.Write(txtEmail.Text + "\t");
                    tw.Write(txtProof.Text.ToUpper() + "\t");
                    tw.Write(txtDate.Text + "\t");
                    tw.Write(starttime.ToString() + "\t");
                    tw.Write(difference.ToString() + "\t");
                    tw.Write(count.ToString() + "\n");
                    tw.Close();
                }

            }
            count = 0;

        }

        //validate the email address
        private int validate_email()
        {
            if (txtEmail.Text.IndexOf('@') >= 0 && txtEmail.Text.IndexOf('.') >= 0)
            {

                return 1;

            }
            else
            {
                toolStripStatusLabel1.Text = "Incorrect format for email id";
                return 0;
            }

        }
        //validate phone number
        private int validate_pn()
        {
            int parsedValue;
            if (!int.TryParse(txtPhoneNumber.Text, out parsedValue))
            {
                toolStripStatusLabel1.Text = "Incorrect values for phone number";
                return 0;
            }
            return 1;
        }
        //validate zip code
        private int validate_zc()
        {
            int parsedValue;
            if (!int.TryParse(txtZipCode.Text, out parsedValue))
            {
                toolStripStatusLabel1.Text = "Incorrect values for zipcode";
                return 0;
            }
            return 1;
        }
        //validate gender
        private int validate_Gender()
        {
            if (txtGender.Text.IndexOf('m') >= 0 || txtGender.Text.IndexOf('M') >= 0
                || txtGender.Text.IndexOf('f') >= 0 || txtGender.Text.IndexOf('F') >= 0)
            {
                return 1;

            }
            else
            {
                toolStripStatusLabel1.Text = "Incorrect values for gender";
                return 0;
            }

        }
        //validate proof of purchase received
        private int validate_Proof()
        {
            if (txtProof.Text.IndexOf('y') >= 0 || txtProof.Text.IndexOf('Y') >= 0
                || txtProof.Text.IndexOf('n') >= 0 || txtProof.Text.IndexOf('N') >= 0)
            {
                return 1;

            }
            else
            {
                toolStripStatusLabel1.Text = "Incorrect value for proof attached";
                return 0;
            }

        }

        //validate the fields and add them to the text file
        private void addButton_Click(object sender, EventArgs e)
        {

            endtime = DateTime.Today;
            difference = (starttime - endtime).TotalSeconds;
            int a = checkMandatory();
            if (a == 0)
            {
                int b = validateAdd();
                int c = validate_email();
                int d = validate_pn();
                int f = validate_Gender();
                int g = validate_Proof();
                int h = validate_zc();
                if (b == 1)
                {
                    if (c == 1 && d == 1 && f == 1 && g == 1 && h == 1)
                    {
                        addtoFile();
                        clearFields(this);
                        toolStripStatusLabel1.Text = "Entry added";
                        Form1_Load();

                    }
                }
                else
                {
                    toolStripStatusLabel1.Text = "Duplicate Entries";

                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Enter Mandatoy Fields";

            }


        }
        //check manadatory fields
        private int checkMandatory()
        {
            if (txtFirstName.Text == "" ||
                        txtLastName.Text == "" ||
                        txtAddrLine1.Text == "" ||
                        txtCity.Text == "" ||
                        txtState.Text == "" ||
                        txtZipCode.Text == "" ||
                        txtGender.Text == "" ||
                        txtPhoneNumber.Text == "" ||
                        txtEmail.Text == "" ||
                        txtProof.Text == "" ||
                        txtDate.Text == "")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //check if the record is eligible to be added
        private int validateAdd()
        {
            String line;
            if (File.Exists(@"CS6326Asg2.txt"))
            {
                using (StreamReader sw = new StreamReader(@"CS6326Asg2.txt"))
                {
                    while ((line = sw.ReadLine()) != null)
                    {
                        char[] delimiters = new char[] { '\t' };
                        string[] words = line.Split(delimiters);
                        String fn = words[0];
                        String ln = words[2];
                        String pn = words[9];

                        if (txtFirstName.Text == fn && txtLastName.Text == ln && txtPhoneNumber.Text == pn)
                        {
                            return 0;
                        }

                    }
                }

            }
            return 1;

        }

        public String linebeforemodify;
        //Fill theform when a record is selected for modify or delete
        private void listView1_Click(object sender, EventArgs e)
        {
            addButton.Enabled = false;
            modifyButton.Enabled = true;
            deleteButton.Enabled = true;

            String fnls = listView1.SelectedItems[0].SubItems[0].Text;
            String lnls = listView1.SelectedItems[0].SubItems[1].Text;
            String pnls = listView1.SelectedItems[0].SubItems[2].Text;


            String line;
            using (StreamReader sw = new StreamReader(@"CS6326Asg2.txt"))
            {
                while ((line = sw.ReadLine()) != null)
                {
                    char[] delimiters = new char[] { '\t' };
                    string[] words = line.Split(delimiters);
                    String fn = words[0];
                    String ln = words[2];
                    String pn = words[9];

                    String st, diff, back;
                    if (fnls.Equals(fn) && lnls.Equals(ln) && pnls.Equals(pn))
                    {
                        //populate text box
                        txtFirstName.Text = words[0];
                        txtMiddleInitial.Text = words[1];
                        txtLastName.Text = words[2];
                        txtAddrLine1.Text = words[3];
                        txtAddrLine2.Text = words[4];
                        txtCity.Text = words[5];
                        txtState.Text = words[6];
                        txtZipCode.Text = words[7];
                        txtGender.Text = words[8];
                        txtPhoneNumber.Text = words[9];
                        txtEmail.Text = words[10];
                        txtProof.Text = words[11];
                        txtDate.Text = words[12];
                        st = words[13];
                        diff = words[14];
                        back = words[15];
                        linebeforemodify = txtFirstName.Text + "\t" +
                                           txtMiddleInitial.Text + "\t" +
                                           txtLastName.Text + "\t" +
                                           txtAddrLine1.Text + "\t" +
                                           txtAddrLine2.Text + "\t" +
                                           txtCity.Text + "\t" +
                                           txtState.Text + "\t" +
                                           txtZipCode.Text + "\t" +
                                           txtGender.Text + "\t" +
                                           txtPhoneNumber.Text + "\t" +
                                           txtEmail.Text + "\t" +
                                           txtProof.Text + "\t" +
                                           txtDate.Text;


                        break;
                    }
                }
            }


        }


        //validate modify the record
        private void modifyButton_Click(object sender, EventArgs e)
        {
            int a = checkMandatory();
            int d = validate_email();
            int f = validate_zc();
            int g = validate_pn();
            int h = validate_Proof();
            int i = validate_Gender();
            if (a == 0)
            {
                if (d == 1 && f == 1 && g == 1 && h == 1 && i == 1)
                {
                    //Check for changes
                    int b = isChanged();
                    if (b == 0)
                    {
                        //changes
                        //check for duplicates
                        removeLine(linebeforemodify);
                        int c = validateAdd();
                        if (c == 1)
                        {
                            addtoFile();
                            clearFields(this);
                            toolStripStatusLabel1.Text = "Entry modified";
                            Form1_Load();
                        }
                        else
                        {
                            toolStripStatusLabel1.Text = "Duplicate Entries";
                        }

                    }
                    else
                    {
                        //no changes 
                        //don't do anything
                        clearFields(this);

                    }
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Enter Mandatory Entries";
            }

        }
        //check if the field is modified
        private int isChanged()
        {
            String line;
            using (StreamReader sw = new StreamReader(@"CS6326Asg2.txt"))
            {
                while ((line = sw.ReadLine()) != null)
                {
                    char[] delimiters = new char[] { '\t' };
                    string[] words = line.Split(delimiters);

                    if (txtFirstName.Text == words[0] &&
                        txtMiddleInitial.Text == words[1] &&
                        txtLastName.Text == words[2] &&
                        txtAddrLine1.Text == words[3] &&
                        txtAddrLine2.Text == words[4] &&
                        txtCity.Text == words[5] &&
                        txtState.Text == words[6] &&
                        txtZipCode.Text == words[7] &&
                        txtGender.Text == words[8] &&
                        txtPhoneNumber.Text == words[9] &&
                        txtEmail.Text == words[10] &&
                        txtProof.Text == words[11] &&
                        txtDate.Text == words[12])
                    {
                        return 1;
                    }

                }
            }
            return 0;

        }
        //delete the record
        private void deleteButton_Click(object sender, EventArgs e)
        {
            String deleteline;
            deleteline = txtFirstName.Text + "\t" +
                         txtMiddleInitial.Text + "\t" +
                         txtLastName.Text + "\t" +
                         txtAddrLine1.Text + "\t" +
                         txtAddrLine2.Text + "\t" +
                         txtCity.Text + "\t" +
                         txtState.Text + "\t" +
                         txtZipCode.Text + "\t" +
                         txtGender.Text + "\t" +
                         txtPhoneNumber.Text + "\t" +
                         txtEmail.Text + "\t" +
                         txtProof.Text + "\t" +
                         txtDate.Text;
            removeLine(deleteline);
            clearFields(this);
            toolStripStatusLabel1.Text = "Entry deleted";
            Form1_Load();

        }
        int count = 0;
        //counting backspace
        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\b'))
            {
                count++;
            }
        }



        //actual implementation of delete
        private void removeLine(string deleteline)
        {
            StringBuilder sb = new StringBuilder("");
            String[] lines = File.ReadAllLines(@"CS6326Asg2.txt");
            foreach (String a in lines)
            {
                if (!a.Contains(deleteline))
                {
                    sb.Append(a + "\n");

                }
            }
            if (File.Exists(@"CS6326Asg2.txt"))
                File.Delete(@"CS6326Asg2.txt");


            using (FileStream fs = new FileStream(@"CS6326Asg2.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.Begin);
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
            }


        }


    }
}
