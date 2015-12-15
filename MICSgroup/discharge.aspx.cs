using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;

namespace MICSgroup
{
    public partial class dispatch : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["cs_MicsHospital"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            int patientID = Convert.ToInt32(txtPatientId.Text);
            
            string query = "SELECT patient_Id, patient_Fname, patient_Lname, patient_Gender, patient_Age, doctor_Fname, doctor_Lname, CONVERT(varchar,patient_BirthDate,101) as patient_BirthDate, CONVERT(varchar,admitDate,101) as admitDate, admitTime, dischargeDate, dischargeTime FROM Patients p JOIN Doctors d ON p.doctor_id = d.doctor_id WHERE patient_Id = @patient_Id;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@patient_Id", patientID);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())                    
                {
                    txtPatientFirstName.Text = reader["patient_Fname"].ToString();
                    txtPatientLastName.Text = reader["patient_Lname"].ToString();
                    txtPatientGender.Text = reader["patient_Gender"].ToString();
                    txtPatientBirthday.Text = reader["patient_BirthDate"].ToString();
                    txtPatientAge.Text = reader["patient_Age"].ToString();
                    txtPatientDoctorName.Text = "Dr. " + reader["doctor_Fname"].ToString() + " " + reader["doctor_Lname"].ToString(); ;
                    txtPatientAdmitTime.Text = reader["admitTime"].ToString();
                    txtPatientAdmitDate.Text = reader["admitDate"].ToString();
                    txtPatientDischargeTime.Text = DateTime.Now.ToString("HH:mm:ss");
                    txtPatientDischargeDate.Text = DateTime.Now.ToString("dd'/'MM'/'yyyy");

                    lblMessage.Text = "Patient with ID = " + patientID + " is ready to discharge.";
                    lblMessage.ForeColor = Color.Green;

                    btnUpdate.Visible = true;
                    btnConfirm.Visible = false;

                    /*txtDischargeDate.Enabled = true;
                    ImgBtnCalendar.Visible = true;  */
                }
                else
                {
                    lblMessage.Text = "Patient with ID = " + patientID + " was not found. Please try again";
                    lblMessage.ForeColor = Color.Red;

                    txtPatientFirstName.Text = "";
                    txtPatientLastName.Text = "";
                    txtPatientGender.Text = "";
                    txtPatientBirthday.Text = "";
                    txtPatientAge.Text = "";
                    txtPatientDoctorName.Text = "";
                    txtPatientAdmitTime.Text = "";
                    txtPatientAdmitDate.Text = "";
                    txtPatientDischargeTime.Text = "";
                    txtPatientDischargeDate.Text = "";

                    ImgBtnCalendar.Visible = false;

                    btnUpdate.Visible = false;
                    btnConfirm.Visible = false;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            txtPatientDischargeTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblMessage.Text = "Please double check all info before discharge patient.";
            lblMessage.ForeColor = Color.Red;

            btnUpdate.Visible = false;
            btnConfirm.Visible = true;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int patientID = Convert.ToInt32(txtPatientId.Text);
            string firstName = txtPatientFirstName.Text;
            string lastName = txtPatientLastName.Text;
            string gender = txtPatientGender.Text;
            string birthday = txtPatientBirthday.Text;
            string age = txtPatientAge.Text;
            string doctorName = txtPatientDoctorName.Text;
            string admitTime = txtPatientAdmitTime.Text;
            string admitDate = txtPatientAdmitDate.Text;
            string dischargeTime = txtPatientDischargeTime.Text;
            string dischargeDate = txtPatientDischargeDate.Text;

            string query = "UPDATE Patients SET dischargeTime = @dischargeTime, dischargeDate = @dischargeDate WHERE patient_Id = @patient_Id; ";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
        
                cmd.Parameters.AddWithValue("@patient_Id", patientID);
                cmd.Parameters.AddWithValue("@dischargeTime", dischargeTime);
                cmd.Parameters.AddWithValue("@dischargeDate", dischargeDate);

                conn.Open();
                int rowsUpdated = cmd.ExecuteNonQuery();

                if (rowsUpdated == 1)
                {
                    lblMessage.Text = "Patient with ID = " + patientID + " discharged info are now updated to the database";
                    lblMessage.ForeColor = Color.Green;

                    btnUpdate.Visible = false;
                    btnConfirm.Visible = false;
                }
                else
                {
                    lblMessage.Text = "Patient with ID = " + patientID + " discharged info was not updated to the database";
                    lblMessage.ForeColor = Color.Red;
                }

            }
        }
        
        protected void CalDischarge_SelectionChanged(object sender, EventArgs e)
        {
            txtPatientDischargeDate.Text = tblCalendar.SelectedDate.ToLongDateString();

            tblCalendar.Visible = false;
        }

        protected void ImgBtnCalendar_Click(object sender, ImageClickEventArgs e)
        {
            tblCalendar.Visible = true;
        }
    }
}