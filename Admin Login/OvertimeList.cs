﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Admin_Login
{
    public partial class OvertimeList : Form
    {
        Login login = new Login();

        string selectedOtId = "", selected = "", selected_date = "";
        bool historyEnabled = false;

        public OvertimeList()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Schedule Overtime";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void UpdateTable()
        {
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT " +
                    "OvertimeDates.OvertimeID, " +
                    "EmployeeInfo.EmployeeFullName," +
                    "OvertimeDates.Date FROM OvertimeDates " +
                    "INNER JOIN EmployeeInfo " +
                    "ON OvertimeDates.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Date='" + date + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvEmployees.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvEmployees.DataSource = data;
                dgvEmployees.Columns["OvertimeID"].Visible = false;
            }
        }

        private void OvertimeList_Load(object sender, EventArgs e)
        {
            dtp_Date.MinDate = DateTime.Now.Date;

            UpdateTable();
        }

        private void dtp_Date_ValueChanged(object sender, EventArgs e)
        {
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT " +
                    "OvertimeDates.OvertimeID, " +
                    "EmployeeInfo.EmployeeFullName," +
                    "OvertimeDates.Date FROM OvertimeDates " +
                    "INNER JOIN EmployeeInfo " +
                    "ON OvertimeDates.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Date='" + date + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvEmployees.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvEmployees.DataSource = data;
                dgvEmployees.Columns["OvertimeID"].Visible = false;
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedOtId = dgvEmployees.Rows[e.RowIndex].Cells[0].Value.ToString();
                selected = dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
                selected_date = dgvEmployees.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                // Do nothing
                // Columan header click catcher
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "DELETE FROM OvertimeDates WHERE OvertimeID=" + selectedOtId;


                DialogResult dialogResult = MessageBox.Show(
                        " Are you sure you want to remove the overtime schedule? ", "Delete Overtime Schedule", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                );

                SqlCommand cmd = new SqlCommand(query, connection);

                if (dialogResult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Overtime Schedule Removed", "Overtime Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AuditTrail audit = new AuditTrail();
                    audit.AuditRemoveOverTime(selected, selected_date, selected_date);
                }

                UpdateTable();
            }
        }

        private void ViewHistoryClick(object sender, EventArgs e)
        {
            pbCancel.Visible = false;
            lblCancel.Visible = false;
            pbOvalCancel.Visible = false;

            pbHistory.Visible = false;
            lblHistory.Visible = false;
            pbOvalHistory.Visible = false;

            pbCurrent.Visible = true;
            lblCurrent.Visible = true;
            pbOvalCurrent.Visible = true;

            panel1.Size = new Size(443, 37);

            dtp_Date.Enabled = false;

            string query =
                "SELECT " +
                    "OvertimeDates.OvertimeID, " +
                    "EmployeeInfo.EmployeeFullName," +
                    "OvertimeDates.Date FROM OvertimeDates " +
                    "INNER JOIN EmployeeInfo " +
                    "ON OvertimeDates.EmployeeID = EmployeeInfo.EmployeeID";

            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dgvEmployees.DataSource = dt;

            historyEnabled = true;
        }

        private void ViewCurrentClick(object sender, EventArgs e)
        {
            pbCancel.Visible = true;
            lblCancel.Visible = true;
            pbOvalCancel.Visible = true;

            pbHistory.Visible = true;
            lblHistory.Visible = true;
            pbOvalHistory.Visible = true;

            pbCurrent.Visible = false;
            lblCurrent.Visible = false;
            pbOvalCurrent.Visible = false;

            panel1.Size = new Size(292, 37);

            dtp_Date.Enabled = true;

            historyEnabled = false;

            UpdateTable();
        }

        private void tb_Search_Click(object sender, EventArgs e)
        {
            tb_Search.Text = "";
        }

        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                if (string.IsNullOrEmpty(tb_Search.Text))
                {
                    if (historyEnabled == true)
                    {
                        string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

                        string query =
                        "SELECT " +
                        "OvertimeDates.OvertimeID, " +
                        "EmployeeInfo.EmployeeFullName," +
                        "OvertimeDates.Date FROM OvertimeDates " +
                        "INNER JOIN EmployeeInfo " +
                        "ON OvertimeDates.EmployeeID = EmployeeInfo.EmployeeID ";
                        
                        SqlCommand cmd2 = new SqlCommand(query, connection);
                        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        sqlDataAdapter2.Fill(dt2);
                        dgvEmployees.DataSource = dt2;
                    }
                    else
                    {
                        string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

                        string query =
                        "SELECT " +
                        "OvertimeDates.OvertimeID, " +
                        "EmployeeInfo.EmployeeFullName," +
                        "OvertimeDates.Date FROM OvertimeDates " +
                        "INNER JOIN EmployeeInfo " +
                        "ON OvertimeDates.EmployeeID = EmployeeInfo.EmployeeID " +
                        "WHERE Date='" + date + "'";

                        SqlCommand cmd2 = new SqlCommand(query, connection);
                        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        sqlDataAdapter2.Fill(dt2);
                        dgvEmployees.DataSource = dt2;
                    }
                }
                else if (tb_Search.Focused)
                {
                    if (historyEnabled == true)
                    {
                        string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

                        string query =
                        "SELECT " +
                        "OvertimeDates.OvertimeID, " +
                        "EmployeeInfo.EmployeeFullName," +
                        "OvertimeDates.Date FROM OvertimeDates " +
                        "INNER JOIN EmployeeInfo " +
                        "ON OvertimeDates.EmployeeID = EmployeeInfo.EmployeeID " +
                        "WHERE " +
                        "EmployeeFullName like '%" + tb_Search.Text + "%'";

                        SqlCommand cmd = new SqlCommand(query, connection);
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sqlDataAdapter.Fill(dt);
                        dgvEmployees.DataSource = dt;
                    }
                    else
                    {
                        string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

                        string query =
                        "SELECT " +
                        "OvertimeDates.OvertimeID, " +
                        "EmployeeInfo.EmployeeFullName," +
                        "OvertimeDates.Date FROM OvertimeDates " +
                        "INNER JOIN EmployeeInfo " +
                        "ON OvertimeDates.EmployeeID = EmployeeInfo.EmployeeID " +
                        "WHERE Date='" + date + "' AND " +
                        "EmployeeFullName like '%" + tb_Search.Text + "%'";

                        SqlCommand cmd = new SqlCommand(query, connection);
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sqlDataAdapter.Fill(dt);
                        dgvEmployees.DataSource = dt;
                    }
                }
            }
        }
    }
}
