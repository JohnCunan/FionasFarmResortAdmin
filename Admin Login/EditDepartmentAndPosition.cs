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
using System.Collections;

namespace Admin_Login
{
    public partial class EditDepartmentAndPosition : Form
    {
        Login login = new Login();

        string selectedDept = "", selectedPos = "";
        string selectedDeptName = "", selectedPosName = "", selectedRate = "";

        SqlDataAdapter DsqlDataAdapter = new SqlDataAdapter();
        BindingSource DbindingSource = new BindingSource();
        SqlCommandBuilder Dcmbl;

        SqlDataAdapter PsqlDataAdapter = new SqlDataAdapter();
        BindingSource PbindingSource = new BindingSource();
        SqlCommandBuilder Pcmbl;

        public EditDepartmentAndPosition()
        {
            InitializeComponent();
        }

        //DROP SHADOW
        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }

        private void EditDepartmentPosition_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = 
                    "SELECT * FROM Department";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                // Column font
                this.dgvDeparments.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dgvDeparments.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvDeparments.DataSource = data;
                dgvDeparments.Columns["DepartmentID"].Visible = false;
            }

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query2 = 
                    "SELECT * FROM Position WHERE Custom=0";
                SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
                DataTable data2 = new DataTable();
                adapter2.Fill(data2);

                // Column font
                this.dgvPositions.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dgvPositions.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvPositions.DataSource = data2;
                dgvPositions.Columns["PositionID"].Visible = false;
                dgvPositions.Columns["DepartmentID"].Visible = false;
                dgvPositions.Columns["PreviousPosID"].Visible = false;
                dgvPositions.Columns["Custom"].Visible = false;
            }
        }

        private void btn_SaveDepartmentChanges_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                if (dgvDeparments.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgvDeparments.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvDeparments.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["DepartmentID"].Value);

                    connection.Open();
                    string query = 
                        "UPDATE Department " +
                        "SET DepartmentName='" + txtEditDepartmentName.Text + "'" +
                        "WHERE DepartmentID=" + cellValue;

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    AuditTrail audit = new AuditTrail();
                    audit.AuditEditDepartment(selectedDeptName, txtEditDepartmentName.Text.ToString());

                    MessageBox.Show("Department Successfully Updated", "Department Edited",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEditDepartmentName.Clear();
                    loadDgvDept();
                }
            }
        }

        private int CheckManegerial()
        {
            if (cbManegerial.Checked == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void btn_SavePositionChanges_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                if (dgvPositions.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgvPositions.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvPositions.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["PositionID"].Value);

                    connection.Open();

                    string query = "";

                    if (CheckManegerial() == 0)
                    {
                         query =
                        "UPDATE Position " +
                        "SET " +
                        "PositionName='" + txtEditPositionName.Text + "', " +
                        "BasicRate=" + txtEditBasicRate.Text + ", " +
                        "Manegerial= 0" +
                        "WHERE PositionID=" + cellValue;
                    }
                    else
                    {
                         query =
                        "UPDATE Position " +
                        "SET " +
                        "PositionName='" + txtEditPositionName.Text + "', " +
                        "BasicRate=" + txtEditBasicRate.Text + ", " +
                        "Manegerial= 1" +
                        "WHERE PositionID=" + cellValue;
                    }

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    AuditTrail audit = new AuditTrail();
                    audit.AuditEditPosition(selectedPosName, selectedRate, txtEditPositionName.Text.ToString(), txtEditBasicRate.Text.ToString());

                    MessageBox.Show("Position Successfully Updated", "Position Edited",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtEditPositionName.Clear();
                    txtEditBasicRate.Clear();
                    loadDgvPos();
                }
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Department and Position";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }

        private void dgvDeparments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Department WHERE DepartmentID=" + dgvDeparments.Rows[e.RowIndex].Cells[0].Value;

                    SqlCommand cmd = new SqlCommand(query, connection);
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    txtEditDepartmentName.Text = dt.Rows[0][1].ToString();

                    selectedDept = dt.Rows[0][0].ToString();
                    selectedDeptName = dt.Rows[0][1].ToString();
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                // Do nothing
                // Catcher for column header sort
            }
        }

        private void dgvPositions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Position WHERE PositionID=" + dgvPositions.Rows[e.RowIndex].Cells[0].Value;

                    SqlCommand cmd = new SqlCommand(query, connection);
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    txtEditPositionName.Text = dt.Rows[0][1].ToString();
                    txtEditBasicRate.Text = dt.Rows[0][3].ToString();

                    selectedPos = dt.Rows[0][0].ToString();

                    selectedPosName = dt.Rows[0][1].ToString();
                    selectedRate = dt.Rows[0][3].ToString();

                    if (dt.Rows[0][6].ToString() == "True")
                    {
                        cbManegerial.Checked= true;
                    }
                    else
                    {
                        cbManegerial.Checked = false;
                    }
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                // Do nothing
                // Catcher for column header sort
            }
        }

        public void loadDgvDept()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT * FROM Department";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvDeparments.DataSource = data;
                dgvDeparments.Columns["DepartmentID"].Visible = false;
            }
        }

        public void loadDgvPos()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query2 =
                    "SELECT * FROM Position WHERE Custom= 0";
                SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
                DataTable data2 = new DataTable();
                adapter2.Fill(data2);
                dgvPositions.DataSource = data2;
                dgvPositions.Columns["PositionID"].Visible = false;
                dgvPositions.Columns["DepartmentID"].Visible = false;
            }
        }

        private void delete_dept_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "DELETE FROM Position WHERE DepartmentID=" + selectedDept +
                    " DELETE FROM Department WHERE DepartmentID=" + selectedDept;


                DialogResult dialogResult = MessageBox.Show(
                        " Are you sure you want to Delete the Department?, " +
                        "Positions under the department will also be deleted","Delete Department", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                );

                SqlCommand cmd = new SqlCommand(query, connection);

                if (dialogResult == DialogResult.Yes)
                {
                    selectedPos = "";
                    txtEditBasicRate.Text = "";
                    txtEditPositionName.Text = "";

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Department Deleted", "Delete Department", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDgvDept();
                        loadDgvPos();
                        txtEditDepartmentName.Text = " ";

                        AuditTrail audit = new AuditTrail();
                        audit.AuditDeleteDepartment(selectedDeptName);
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("Department can not be deleted because it contains position(s)" +
                            " that are assigned to employee(s)",
                            "Department Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void delete_pos_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Position WHERE PositionID=" + selectedPos;

                DialogResult dialogResult = MessageBox.Show(
                        " Are you sure you want to Delete the Position?, ", "Delete Position", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                );

                SqlCommand cmd = new SqlCommand(query, connection);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Position Deleted", "Delete Position", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDgvPos();
                        txtEditPositionName.Text = " ";
                        txtEditBasicRate.Text = " ";
                        AuditTrail audit = new AuditTrail();
                        audit.AuditDeletePosition(selectedPosName);
                    }
                    catch(System.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("Position can not be deleted because it is assigned to employee(s)",
                            "Position Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}