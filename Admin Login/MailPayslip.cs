﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Http;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Admin_Login
{
    public partial class MailPayslip : Form
    {
        readonly Login login = new Login();
        public MailPayslip()
        {
            InitializeComponent();
        }
        private void MailPayslip_Load(object sender, EventArgs e)
        {
            //txt_From.Text = "fionasfarmmagalang@gmail.com";
            //txt_From.ForeColor = Color.Silver;
            //txt_Password.Text = " password";
            //txt_Password.PasswordChar = '\0';
            //txt_Password.ForeColor = Color.Silver;
            //cb_To.Text = " sample@gmail.com";
            //cb_To.ForeColor = Color.Silver;
            //txt_Subject.Text = " (no subject)";
            //txt_Subject.ForeColor = Color.Silver;
            //txt_Body.Text = "";
            //lbl_FileLocation.Text = "";
        }
        private void txt_From_Enter(object sender, EventArgs e)
        {
            //if (txt_From.Text == "fionasfarmmagalang@gmail.com")
            //{
            //    txt_From.Text = "";
            //    txt_From.ForeColor = Color.Black;
            //}
        }
        private void txt_From_Leave(object sender, EventArgs e)
        {
            //if (txt_From.Text == "")
            //{
            //    txt_From.Text = "fionasfarmmagalang@gmail.com";
            //    txt_From.ForeColor = Color.Silver;
            //}
        }
        private void txt_Password_Enter(object sender, EventArgs e)
        {
            //txt_Password.PasswordChar = '*';
            //if (txt_Password.Text == " password")
            //{
            //    txt_Password.Text = "";
            //    txt_Password.ForeColor = Color.Black;
            //}
        }
        private void txt_Password_Leave(object sender, EventArgs e)
        {
            //if (txt_Password.Text == "")
            //{
            //    txt_Password.PasswordChar = '\0';
            //    txt_Password.Text = " password";
            //    txt_Password.ForeColor = Color.Silver;
            //}
        }
        private void txt_Subject_Enter(object sender, EventArgs e)
        {
            //if (txt_Subject.Text == " (no subject)")
            //{
            //    txt_Subject.Text = "";
            //    txt_Subject.ForeColor = Color.Black;
            //}
        }
        private void txt_Subject_Leave(object sender, EventArgs e)
        {
            //if (txt_Subject.Text == "")
            //{
            //    txt_Subject.Text = " (no subject)";
            //    txt_Subject.ForeColor = Color.Silver;
            //}
        }
        private void cb_To_Enter(object sender, EventArgs e)
        {
            //if (cb_To.Text == " sample@gmail.com")
            //{
            //    cb_To.Text = "";
            //    cb_To.ForeColor = Color.Black;
            //}
            //try
            //{
            //    SqlConnection connection = new SqlConnection(login.connectionString);
            //    connection.Open();
            //    SqlCommand cmd = new SqlCommand("select Email from EmployeeInfo", connection);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    DataTable dt_Email = new DataTable();
            //    dt_Email.Columns.Add("Email", typeof(string));
            //    dt_Email.Load(reader);
            //    cb_To.ValueMember = "Email";
            //    cb_To.DataSource = dt_Email;
            //    connection.Close();
            //}
            //catch (Exception) { }
        }
        private void btn_Send_Click(object sender, EventArgs e)
        {
            //txt_From_Leave(sender, e);
            //txt_Password_Leave(sender, e);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(txt_From.Text);
                mail.To.Add(textBox1.Text);
                mail.Subject = txt_Subject.Text;
                mail.Body = txt_Body.Text;
                Attachment attachment = new Attachment(lbl_FileLocation.Text);
                mail.Attachments.Add(attachment);
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(txt_From.Text, txt_Password.Text);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Send(mail);
                MessageBox.Show("Mail has been successfully sent!", "Email sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //if(txt_Password.Text.Equals(" password")) MessageBox.Show("Wrong password.");
                //else if (cb_To.Text.Equals(" sample@gmail.com")) MessageBox.Show("A recipient must be specified.");
                //else if (lbl_FileLocation.Text.Equals("")) MessageBox.Show("File attachment cannot be empty.");
                //else
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //MailPayslip_Load(sender, e);
        }
        private void ll_AttachFile_Click(object sender, EventArgs e)
        {
            ofd_File.ShowDialog();
            lbl_FileLocation.Text = ofd_File.FileName;
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            //Menu menu = (Menu)Application.OpenForms["Menu"];
            //menu.Text = "Fiona's Farm and Resort - Payroll Report";
            //menu.Menu_Load(menu, EventArgs.Empty);
        }
    }
}