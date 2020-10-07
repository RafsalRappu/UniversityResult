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

namespace UniversityResult
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetResult_Click(object sender, EventArgs e)
        {
            


            {
                 panelGetResult.Show();
                SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-F842VI4\SQLEXPRESS; Database = University;Trusted_Connection = True");
                con.Open();
                // MessageBox.Show("Success");

                SqlCommand cmd = new SqlCommand("StudentsGetId", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentsID", txtRollNo.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    lblName.Text = reader["Name"].ToString();
                    lblMalayalam.Text = reader["Malayalam"].ToString();
                    lblEnglish.Text = reader["English"].ToString();
                    lblHindi1.Text = reader["Hindi"].ToString();
                    lblPlace.Text = reader["Place"].ToString();

                }
                else
                {
                    MessageBox.Show("Enter a Roll No", "Calicut University", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                //Malayalam Result
                if (Convert.ToInt32(lblMalayalam.Text) > 50)
                {
                    lblMalayalamPass.Text = " P ";
                    lblMalayalamPass.ForeColor = Color.Green;
                }
                else
                {
                    lblMalayalam.Text = " F ";
                    lblMalayalamPass.ForeColor = Color.Red;
                }
                //English Result
                if (Convert.ToInt32(lblEnglish.Text) > 50)
                {
                    lblEnglishPass.Text = " P ";
                    lblEnglishPass.ForeColor = Color.Green;
                }
                else
                {
                    lblEnglishPass.Text = " F ";
                    lblEnglishPass.ForeColor = Color.Red;
                }
                //Hindi Result
                if (Convert.ToInt32(lblHindi1.Text) > 50)
                {
                    lblHindiPass1.Text = " P ";
                    lblHindiPass1.ForeColor = Color.Green;
                }
                else
                {
                    lblHindiPass1.Text = " F ";
                    lblHindiPass1.ForeColor = Color.Red;
                }
                con.Close();
            }

            //Percentage
            {
                SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-F842VI4\SQLEXPRESS; Database = University;Trusted_Connection = True");
                con.Open();

                SqlCommand cmd = new SqlCommand("PercentageMarks", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentsID", txtRollNo.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    blTotalPercentage1.Text = reader["PercentageMarks"].ToString();

                }
                else
                {
                    MessageBox.Show("No Valid Data");
                }
                con.Close();
            }
            //Total
            {
                SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-F842VI4\SQLEXPRESS; Database = University;Trusted_Connection = True");
                con.Open();

                SqlCommand cmd = new SqlCommand("Total", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentsID", txtRollNo.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    lblTotal1.Text = reader["Total"].ToString();
                    if (Convert.ToInt32(lblTotal1.Text) <= 150)
                    {
                        lblTotal1.Text = "//";
                        lblDebar.Text = "DEBAR";
                        // lblDebar.ForeColor = Color.Red;
                        lblDebar.ForeColor = Color.Red;
                        lblDebar.Show();
                    }
                    else
                    {
                        lblPass.Text = "Pass";
                        //lblPass.ForeColor = Color.Green;
                        lblPass.ForeColor = Color.Green;
                        lblPass.Show();
                    }

                }
                else
                {
                    MessageBox.Show("No Valid Data");
                }
            }

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void lblMalayalamPass_Click(object sender, EventArgs e)
        {

        }

        private void btnNewResult_Click(object sender, EventArgs e)
        {
           

            txtRollNo.Text = lblMalayalamPass.Text = lblMalayalam.Text = lblEnglish.Text = lblEnglishPass.Text = lblHindi.Text = lblHindiPass.Text = lblTotal.Text = lblPercentage.Text = "";
            lblDebar.BackColor = lblPass.BackColor = Color.White;
            panelGetResult.Hide();
            panelEnter.Show();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }


    
        }

    }

