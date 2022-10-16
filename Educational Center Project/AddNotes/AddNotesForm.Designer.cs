
namespace Educational_Center_Project.AddNotes
{
    partial class AddNotesForm
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
            this.components = new System.ComponentModel.Container();
            this.guna2ShadowDashboard = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.note_txb = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.addDates_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.skip_weekends = new Guna.UI2.WinForms.Guna2CheckBox();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.recur_comb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.addDates_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ShadowDashboard
            // 
            this.guna2ShadowDashboard.TargetForm = this;
            // 
            // note_txb
            // 
            this.note_txb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.note_txb.DefaultText = "";
            this.note_txb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.note_txb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.note_txb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.note_txb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.note_txb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.note_txb.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.note_txb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.note_txb.Location = new System.Drawing.Point(4, 44);
            this.note_txb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.note_txb.Name = "note_txb";
            this.note_txb.PasswordChar = '\0';
            this.note_txb.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.note_txb.PlaceholderText = "Task Name:";
            this.note_txb.SelectedText = "";
            this.note_txb.Size = new System.Drawing.Size(430, 48);
            this.note_txb.TabIndex = 8;
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button1.Location = new System.Drawing.Point(4, 95);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(430, 45);
            this.guna2Button1.TabIndex = 9;
            this.guna2Button1.Text = "Add Date";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // exit_button
            // 
            this.exit_button.FlatAppearance.BorderSize = 0;
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_button.Image = global::Educational_Center_Project.Properties.Resources.icons8_close_24;
            this.exit_button.Location = new System.Drawing.Point(402, 2);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(35, 35);
            this.exit_button.TabIndex = 7;
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            this.exit_button.MouseLeave += new System.EventHandler(this.exit_button_MouseLeave);
            this.exit_button.MouseHover += new System.EventHandler(this.exit_button_MouseHover);
            // 
            // addDates_panel
            // 
            this.addDates_panel.Controls.Add(this.skip_weekends);
            this.addDates_panel.Controls.Add(this.start_date);
            this.addDates_panel.Controls.Add(this.recur_comb);
            this.addDates_panel.Controls.Add(this.label1);
            this.addDates_panel.ForeColor = System.Drawing.Color.Purple;
            this.addDates_panel.Location = new System.Drawing.Point(4, 143);
            this.addDates_panel.Name = "addDates_panel";
            this.addDates_panel.Size = new System.Drawing.Size(430, 229);
            this.addDates_panel.TabIndex = 11;
            // 
            // skip_weekends
            // 
            this.skip_weekends.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.skip_weekends.CheckedState.BorderRadius = 0;
            this.skip_weekends.CheckedState.BorderThickness = 0;
            this.skip_weekends.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.skip_weekends.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.skip_weekends.Location = new System.Drawing.Point(127, 116);
            this.skip_weekends.Name = "skip_weekends";
            this.skip_weekends.Size = new System.Drawing.Size(161, 27);
            this.skip_weekends.TabIndex = 0;
            this.skip_weekends.Text = "Skip weekends";
            this.skip_weekends.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.skip_weekends.UncheckedState.BorderRadius = 0;
            this.skip_weekends.UncheckedState.BorderThickness = 0;
            this.skip_weekends.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // start_date
            // 
            this.start_date.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_date.CalendarMonthBackground = System.Drawing.Color.White;
            this.start_date.CalendarTitleBackColor = System.Drawing.Color.White;
            this.start_date.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.start_date.Location = new System.Drawing.Point(8, 25);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(162, 25);
            this.start_date.TabIndex = 4;
            // 
            // recur_comb
            // 
            this.recur_comb.BackColor = System.Drawing.Color.Transparent;
            this.recur_comb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.recur_comb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recur_comb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.recur_comb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.recur_comb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.recur_comb.ForeColor = System.Drawing.Color.Purple;
            this.recur_comb.ItemHeight = 30;
            this.recur_comb.Items.AddRange(new object[] {
            "Daily",
            "Weekly ",
            "Monthly",
            "Never"});
            this.recur_comb.Location = new System.Drawing.Point(239, 22);
            this.recur_comb.Name = "recur_comb";
            this.recur_comb.Size = new System.Drawing.Size(176, 36);
            this.recur_comb.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(188, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recur:";
            // 
            // guna2Button2
            // 
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(4, 427);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(430, 45);
            this.guna2Button2.TabIndex = 12;
            this.guna2Button2.Text = "Add";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // AddNotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(441, 535);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.addDates_panel);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.note_txb);
            this.Controls.Add(this.exit_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddNotesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNotesForm";
            this.addDates_panel.ResumeLayout(false);
            this.addDates_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowDashboard;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox note_txb;
        private System.Windows.Forms.Button exit_button;
        private Guna.UI2.WinForms.Guna2Panel addDates_panel;
        private Guna.UI2.WinForms.Guna2ComboBox recur_comb;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.DateTimePicker start_date;
        private Guna.UI2.WinForms.Guna2CheckBox skip_weekends;
    }
}