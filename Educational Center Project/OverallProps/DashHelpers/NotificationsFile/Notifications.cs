using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Educational_Center_Project.OverallProps.DashHelpers.NotificationsFile
{
    public partial class Notifications : Form
    {
        public Notifications()
        {
            InitializeComponent();
            AddPaymentTotalNotification();
            AddGroupMessages();
        }
        private void AddGroupMessages()
        {
            DataTable table = BaseDB.GetMessagesTable();
            foreach (DataRow row in table.Rows)
            {
                Notification notification = new Notification(row[1].ToString(), 2, this);
                notifications_panel.Controls.Add(notification);
                notification.Dock = DockStyle.Top;
            }
        }
        private void AddPaymentTotalNotification()
        {
            DataTable table = BaseDB.GetMonthOutcomeTable();
            if (table.Rows.Count != 0)
            {
                string lastMonth = table.Rows[table.Rows.Count - 1]["Date"].ToString();
                string currentMonth = $"{DateTime.Now.Month}.{DateTime.Now.Year}";

                if (DateTime.Now.Day >= 25 && lastMonth != currentMonth)
                {
                    Notification notification = new Notification("The date is over 25, we have to make PaymentTotal for this month", 1, this);
                    notifications_panel.Controls.Add(notification);
                    notification.Dock = DockStyle.Top;
                }
            }
            else
            {
                Notification notification = new Notification("The date is over 25, we have to make PaymentTotal for this month", 1, this);
                notifications_panel.Controls.Add(notification);
                notification.Dock = DockStyle.Top;
            }
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard form1 = new Dashboard();
            form1.Show();
        }
        private void exit_button_MouseHover(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.Red;
        }
        private void exit_button_MouseLeave(object sender, EventArgs e)
        {
            exit_button.BackColor = Color.White;

        }
    }
}
