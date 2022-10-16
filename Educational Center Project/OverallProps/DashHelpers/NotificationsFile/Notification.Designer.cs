
namespace Educational_Center_Project.OverallProps.DashHelpers.NotificationsFile
{
    partial class Notification
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.notification_name = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.go_btn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notification_name
            // 
            this.notification_name.BackColor = System.Drawing.Color.Transparent;
            this.notification_name.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.notification_name.ForeColor = System.Drawing.Color.Black;
            this.notification_name.Location = new System.Drawing.Point(16, 18);
            this.notification_name.Name = "notification_name";
            this.notification_name.Size = new System.Drawing.Size(147, 21);
            this.notification_name.TabIndex = 0;
            this.notification_name.Text = "Notification Name:\r\n";
            // 
            // go_btn
            // 
            this.go_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.go_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.go_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.go_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.go_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.go_btn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.go_btn.ForeColor = System.Drawing.Color.White;
            this.go_btn.Location = new System.Drawing.Point(804, 39);
            this.go_btn.Name = "go_btn";
            this.go_btn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.go_btn.Size = new System.Drawing.Size(63, 41);
            this.go_btn.TabIndex = 1;
            this.go_btn.Text = "Go";
            this.go_btn.Click += new System.EventHandler(this.go_btn_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Black;
            this.guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Black;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 83);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(870, 3);
            this.guna2PictureBox1.TabIndex = 11;
            this.guna2PictureBox1.TabStop = false;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.go_btn);
            this.Controls.Add(this.notification_name);
            this.Name = "Notification";
            this.Size = new System.Drawing.Size(870, 86);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel notification_name;
        private Guna.UI2.WinForms.Guna2CircleButton go_btn;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
