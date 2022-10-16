
namespace Educational_Center_Project.HistoryFolder
{
    partial class HistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.student_list = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.search_txb = new Guna.UI2.WinForms.Guna2TextBox();
            this.choose_search = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.exit_button = new System.Windows.Forms.Button();
            this.studentSelectedPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.payments_list = new Guna.UI2.WinForms.Guna2DataGridView();
            this.surname = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.phoneNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.studentName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.student_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.studentSelectedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payments_list)).BeginInit();
            this.SuspendLayout();
            // 
            // student_list
            // 
            this.student_list.AllowUserToAddRows = false;
            this.student_list.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.student_list.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.student_list.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.student_list.ColumnHeadersHeight = 21;
            this.student_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.student_list.DefaultCellStyle = dataGridViewCellStyle3;
            this.student_list.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.student_list.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.student_list.Location = new System.Drawing.Point(0, 54);
            this.student_list.Name = "student_list";
            this.student_list.RowHeadersVisible = false;
            this.student_list.Size = new System.Drawing.Size(1259, 612);
            this.student_list.TabIndex = 70;
            this.student_list.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.student_list.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.student_list.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.student_list.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.student_list.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.student_list.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.student_list.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.student_list.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.student_list.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.student_list.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.student_list.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.student_list.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.student_list.ThemeStyle.HeaderStyle.Height = 21;
            this.student_list.ThemeStyle.ReadOnly = false;
            this.student_list.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.student_list.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.student_list.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.student_list.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.student_list.ThemeStyle.RowsStyle.Height = 22;
            this.student_list.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.student_list.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.student_list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.student_list_CellContentClick);
            this.student_list.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.student_list_CellFormatting);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Fuchsia;
            this.pictureBox8.Location = new System.Drawing.Point(12, 34);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(315, 3);
            this.pictureBox8.TabIndex = 74;
            this.pictureBox8.TabStop = false;
            // 
            // search_txb
            // 
            this.search_txb.BorderColor = System.Drawing.Color.White;
            this.search_txb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search_txb.DefaultText = "";
            this.search_txb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search_txb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search_txb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search_txb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search_txb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search_txb.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search_txb.ForeColor = System.Drawing.Color.Magenta;
            this.search_txb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search_txb.IconLeftSize = new System.Drawing.Size(30, 30);
            this.search_txb.IconRightSize = new System.Drawing.Size(30, 30);
            this.search_txb.Location = new System.Drawing.Point(12, 2);
            this.search_txb.Name = "search_txb";
            this.search_txb.PasswordChar = '\0';
            this.search_txb.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.search_txb.PlaceholderText = "type here for searching...";
            this.search_txb.SelectedText = "";
            this.search_txb.Size = new System.Drawing.Size(315, 30);
            this.search_txb.TabIndex = 73;
            // 
            // choose_search
            // 
            this.choose_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choose_search.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.choose_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.choose_search.FormattingEnabled = true;
            this.choose_search.Items.AddRange(new object[] {
            "Teacher Name",
            "Group Name",
            "Student Name"});
            this.choose_search.Location = new System.Drawing.Point(460, 6);
            this.choose_search.Name = "choose_search";
            this.choose_search.Size = new System.Drawing.Size(127, 26);
            this.choose_search.TabIndex = 72;
            this.choose_search.Text = "Group Name";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label23.Location = new System.Drawing.Point(345, 6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(108, 23);
            this.label23.TabIndex = 71;
            this.label23.Text = "Search by:";
            // 
            // exit_button
            // 
            this.exit_button.FlatAppearance.BorderSize = 0;
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_button.Image = global::Educational_Center_Project.Properties.Resources.icons8_close_24;
            this.exit_button.Location = new System.Drawing.Point(1222, 2);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(35, 35);
            this.exit_button.TabIndex = 76;
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click_1);
            this.exit_button.MouseLeave += new System.EventHandler(this.exit_button_MouseLeave_1);
            this.exit_button.MouseHover += new System.EventHandler(this.exit_button_MouseHover_1);
            // 
            // studentSelectedPanel
            // 
            this.studentSelectedPanel.Controls.Add(this.button1);
            this.studentSelectedPanel.Controls.Add(this.payments_list);
            this.studentSelectedPanel.Controls.Add(this.surname);
            this.studentSelectedPanel.Controls.Add(this.phoneNumber);
            this.studentSelectedPanel.Controls.Add(this.studentName);
            this.studentSelectedPanel.Location = new System.Drawing.Point(1, 2);
            this.studentSelectedPanel.Name = "studentSelectedPanel";
            this.studentSelectedPanel.Size = new System.Drawing.Size(1256, 663);
            this.studentSelectedPanel.TabIndex = 77;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Educational_Center_Project.Properties.Resources.icons8_close_24;
            this.button1.Location = new System.Drawing.Point(1219, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 76;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // payments_list
            // 
            this.payments_list.AllowUserToAddRows = false;
            this.payments_list.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.payments_list.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.payments_list.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.payments_list.ColumnHeadersHeight = 21;
            this.payments_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.payments_list.DefaultCellStyle = dataGridViewCellStyle6;
            this.payments_list.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.payments_list.Location = new System.Drawing.Point(375, 35);
            this.payments_list.Name = "payments_list";
            this.payments_list.RowHeadersVisible = false;
            this.payments_list.Size = new System.Drawing.Size(811, 594);
            this.payments_list.TabIndex = 75;
            this.payments_list.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.payments_list.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.payments_list.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.payments_list.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.payments_list.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.payments_list.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.payments_list.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.payments_list.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.payments_list.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.payments_list.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.payments_list.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.payments_list.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.payments_list.ThemeStyle.HeaderStyle.Height = 21;
            this.payments_list.ThemeStyle.ReadOnly = false;
            this.payments_list.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.payments_list.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.payments_list.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.payments_list.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.payments_list.ThemeStyle.RowsStyle.Height = 22;
            this.payments_list.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.payments_list.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // surname
            // 
            this.surname.BackColor = System.Drawing.Color.Transparent;
            this.surname.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.surname.Location = new System.Drawing.Point(23, 108);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(119, 39);
            this.surname.TabIndex = 74;
            this.surname.Text = "Surname:";
            // 
            // phoneNumber
            // 
            this.phoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.phoneNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneNumber.Location = new System.Drawing.Point(23, 184);
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(138, 27);
            this.phoneNumber.TabIndex = 73;
            this.phoneNumber.Text = "Phone Number:";
            // 
            // studentName
            // 
            this.studentName.BackColor = System.Drawing.Color.Transparent;
            this.studentName.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.studentName.Location = new System.Drawing.Point(23, 35);
            this.studentName.Name = "studentName";
            this.studentName.Size = new System.Drawing.Size(318, 67);
            this.studentName.TabIndex = 72;
            this.studentName.Text = "Student Name";
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1259, 666);
            this.Controls.Add(this.studentSelectedPanel);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.search_txb);
            this.Controls.Add(this.choose_search);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.student_list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.student_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.studentSelectedPanel.ResumeLayout(false);
            this.studentSelectedPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payments_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView student_list;
        private System.Windows.Forms.PictureBox pictureBox8;
        private Guna.UI2.WinForms.Guna2TextBox search_txb;
        private System.Windows.Forms.ComboBox choose_search;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button exit_button;
        private Guna.UI2.WinForms.Guna2Panel studentSelectedPanel;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2DataGridView payments_list;
        private Guna.UI2.WinForms.Guna2HtmlLabel surname;
        private Guna.UI2.WinForms.Guna2HtmlLabel phoneNumber;
        private Guna.UI2.WinForms.Guna2HtmlLabel studentName;
    }
}