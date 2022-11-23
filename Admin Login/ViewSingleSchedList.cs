﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Admin_Login
{
    public partial class ViewSingleSchedList : Form
    {
        Login login = new Login();
        string selectedSingleSchedID = " ";

        public ViewSingleSchedList()
        {
            InitializeComponent();
        }

        private void btn_back(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Single Schedule";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void ViewSingleSchedList_Load(object sender, EventArgs e)
        {
            updateTable();
        }

        private void dtp_Date_ValueChanged(object sender, EventArgs e)
        {
            updateTable();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedSingleSchedID = dgvEmployees.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void remove_single_sched(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "DELETE FROM SingleSchedule WHERE SingleScheduleID=" + selectedSingleSchedID;


                DialogResult dialogResult = MessageBox.Show(
                        " Are you sure you want to remove the single schedule?, ", "Delete Department", MessageBoxButtons.YesNo
                );

                SqlCommand cmd = new SqlCommand(query, connection);

                if (dialogResult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Single Schedule Removed");
                    updateTable();
                }
            }
        }

        public void updateTable()
        {
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT " +
                    "SingleSchedule.SingleScheduleID, " +
                    "EmployeeInfo.EmployeeFullName, " +
                    "SingleSchedule.ScheduleIn, " +
                    "SingleSchedule.ScheduleOut, " +
                    "SingleSchedule.Date FROM SingleSchedule " +
                    "INNER JOIN EmployeeInfo " +
                    "ON SingleSchedule.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Date='" + date + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvEmployees.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvEmployees.DataSource = data;
                dgvEmployees.Columns["SingleScheduleID"].Visible = false;
            }
        }
    }
}