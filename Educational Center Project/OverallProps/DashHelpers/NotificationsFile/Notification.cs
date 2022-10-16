using Educational_Center_Project.Groups;
using Educational_Center_Project.OverallProps.DashHelpers.StudentExamScoreFile;
using System;
using System.Windows.Forms;

namespace Educational_Center_Project.OverallProps.DashHelpers.NotificationsFile
{
    public partial class Notification : UserControl
    {
        int key;
        Notifications notifications;
        string notif;
        public Notification(string notif, int key, Notifications notifications)
        {
            InitializeComponent();
            notification_name.Text = notif;
            this.key = key;
            this.notifications = notifications;
            this.notif = notif;
        }
        private void go_btn_Click(object sender, EventArgs e)
        {
            if (key == 1)
            {
                notifications.Hide();
                StudentExamScores scores = new StudentExamScores();
                scores.Show();
            }
            else
            {
                notifications.Hide();
                GroupForm groupForm = new GroupForm(notif);
                groupForm.Show();
            }
        }
    }
}
