﻿namespace Admin_Login
{
    partial class PositionAndDepartments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvPosAndDept = new System.Windows.Forms.DataGridView();
            this.cb_SortBy = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_SortBy = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.AddDepPos = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosAndDept)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvPosAndDept);
            this.panel3.Location = new System.Drawing.Point(16, 71);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(827, 511);
            this.panel3.TabIndex = 28;
            // 
            // dgvPosAndDept
            // 
            this.dgvPosAndDept.AllowUserToAddRows = false;
            this.dgvPosAndDept.AllowUserToDeleteRows = false;
            this.dgvPosAndDept.AllowUserToResizeColumns = false;
            this.dgvPosAndDept.AllowUserToResizeRows = false;
            this.dgvPosAndDept.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPosAndDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPosAndDept.Location = new System.Drawing.Point(7, 3);
            this.dgvPosAndDept.Name = "dgvPosAndDept";
            this.dgvPosAndDept.Size = new System.Drawing.Size(815, 503);
            this.dgvPosAndDept.TabIndex = 4;
            // 
            // cb_SortBy
            // 
            this.cb_SortBy.AccessibleDescription = "";
            this.cb_SortBy.AccessibleName = "";
            this.cb_SortBy.BackColor = System.Drawing.Color.White;
            this.cb_SortBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_SortBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_SortBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_SortBy.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.cb_SortBy.Items.AddRange(new object[] {
            "Default",
            "Position",
            "Basic Rate",
            "Number of Employees"});
            this.cb_SortBy.Location = new System.Drawing.Point(84, 3);
            this.cb_SortBy.Margin = new System.Windows.Forms.Padding(2);
            this.cb_SortBy.Name = "cb_SortBy";
            this.cb_SortBy.Size = new System.Drawing.Size(89, 30);
            this.cb_SortBy.TabIndex = 10;
            this.cb_SortBy.Text = "Default";
            this.cb_SortBy.Click += new System.EventHandler(this.Cb_SortBy_Click);
            this.cb_SortBy.Enter += new System.EventHandler(this.Cb_SortBy_Enter);
            this.cb_SortBy.Leave += new System.EventHandler(this.Cb_SortBy_Leave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cb_SortBy);
            this.panel2.Controls.Add(this.lbl_SortBy);
            this.panel2.Location = new System.Drawing.Point(531, 19);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 37);
            this.panel2.TabIndex = 27;
            // 
            // lbl_SortBy
            // 
            this.lbl_SortBy.AutoSize = true;
            this.lbl_SortBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SortBy.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_SortBy.Location = new System.Drawing.Point(9, 6);
            this.lbl_SortBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SortBy.Name = "lbl_SortBy";
            this.lbl_SortBy.Size = new System.Drawing.Size(73, 24);
            this.lbl_SortBy.TabIndex = 11;
            this.lbl_SortBy.Text = "Sort by:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.tb_Search);
            this.panel1.Location = new System.Drawing.Point(214, 19);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 37);
            this.panel1.TabIndex = 26;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Image = global::Admin_Login.Properties.Resources.Search_Icon;
            this.pictureBox5.Location = new System.Drawing.Point(7, 4);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(19, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // tb_Search
            // 
            this.tb_Search.BackColor = System.Drawing.Color.White;
            this.tb_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Search.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tb_Search.Location = new System.Drawing.Point(36, 6);
            this.tb_Search.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(259, 21);
            this.tb_Search.TabIndex = 6;
            this.tb_Search.Text = " Search";
            this.tb_Search.Enter += new System.EventHandler(this.Tb_Search_Enter);
            this.tb_Search.Leave += new System.EventHandler(this.Tb_Search_Leave);
            // 
            // AddDepPos
            // 
            this.AddDepPos.AutoSize = true;
            this.AddDepPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.AddDepPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddDepPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDepPos.ForeColor = System.Drawing.Color.White;
            this.AddDepPos.Location = new System.Drawing.Point(20, 26);
            this.AddDepPos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddDepPos.Name = "AddDepPos";
            this.AddDepPos.Size = new System.Drawing.Size(157, 24);
            this.AddDepPos.TabIndex = 30;
            this.AddDepPos.Tag = "btn_AddNew";
            this.AddDepPos.Text = "Add Dep. / Pos.";
            this.AddDepPos.Click += new System.EventHandler(this.AddDepPos_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Admin_Login.Properties.Resources.AddPositionOrDepartment_Icon;
            this.pictureBox2.Location = new System.Drawing.Point(170, 21);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "btn_AddNew";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape;
            this.pictureBox1.Location = new System.Drawing.Point(16, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "btn_AddNew";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Green;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(729, 19);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 39);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // PositionAndDepartments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 592);
            this.ControlBox = false;
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.AddDepPos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PositionAndDepartments";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PositionAndDepartments_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosAndDept)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cb_SortBy;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_SortBy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label AddDepPos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvPosAndDept;
        public System.Windows.Forms.Button btnEdit;
    }
}