using Educational_Center_Project.OverallProps;
using Educational_Center_Project.RegisterCenter;
using System;
using System.Data;
using System.Windows.Forms;

namespace Educational_Center_Project
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataTable table = BaseDB.GetTable("Select * From [dbo].[EduCenterProps]");
            if (table.Rows.Count == 0)
            {
                Application.Run(new RegisterFirstWindow());
            }
            else
                Application.Run(new Dashboard());
        }
    }
}
