using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Educational_Center_Project.TimeTables
{
    class TimeTableMaker
    {
        Dictionary<int, string> days = new Dictionary<int, string>();
        Dictionary<int, string> classes = new Dictionary<int, string>();
        int counter = 0;

        public TimeTableMaker()
        {
            days.Add(0, "Saturday");
            days.Add(1, "Friday");
            days.Add(2, "Thursday");
            days.Add(3, "Wednesday");
            days.Add(4, "Tuesday");
            days.Add(5, "Monday");

            classes.Add(4, "Mars");
            classes.Add(3, "Jupiter");
            classes.Add(2, "Saturn");
            classes.Add(1, "Mercury");
            classes.Add(0, "Neptune");

        }
        public TabPage MakePages(string name)
        {
            TabPage page = new TabPage();
            page.BackColor = Color.White;
            page.Text = name;

            return page;
        }
        public object[,] MakePanels(string name, ref TabPage page)
        {

            object[,] panels = new object[5, 7];
            for (int i = 0; i < 6; i++)
            {
                Panel mainPanel = new Panel();
                mainPanel.Dock = DockStyle.Bottom;
                mainPanel.BackColor = Color.White;
                mainPanel.Height = 105;
                page.Controls.Add(mainPanel);
                for (int j = 0; j < 7; j++)
                {
                    Panel panel = new Panel();
                    PictureBox leftLine = new PictureBox();
                    PictureBox bottomLine = new PictureBox();

                    if (j == 0)
                    {
                        PictureBox rightLine = new PictureBox();
                        rightLine.Dock = DockStyle.Right;
                        rightLine.Width = 1;
                        rightLine.BackColor = Color.Black;
                        panel.Controls.Add(rightLine);
                    }

                    panel.Controls.Add(leftLine);
                    panel.Controls.Add(bottomLine);
                    mainPanel.Controls.Add(panel);

                    leftLine.Dock = DockStyle.Left;
                    leftLine.Width = 1;
                    leftLine.BackColor = Color.Black;

                    bottomLine.Dock = DockStyle.Bottom;
                    bottomLine.Height = 1;
                    bottomLine.BackColor = Color.Black;

                    panel.BackColor = Color.White;
                    panel.Dock = DockStyle.Left;
                    panel.Width = 180;

                    if (i > 0 && j < 6)
                    {
                        panels[i - 1, j] = panel;
                    }

                    if (i == 0 && j < 6)
                    {
                        string text = days[j];
                        Label lbl = new Label();
                        lbl.Font = new Font("Century Gothic", 18, FontStyle.Bold);
                        lbl.Text = text;
                        ColorTables(lbl);
                        lbl.BackColor = Color.White;
                        panel.Controls.Add(lbl);
                        lbl.Left = panel.Left + 25;
                        lbl.Top = panel.Top + 30;
                        lbl.Width = 200;
                        lbl.Height = 70;

                        PictureBox topline = new PictureBox();
                        topline.Dock = DockStyle.Top;
                        topline.Height = 1;
                        topline.BackColor = Color.Black;

                        panel.Controls.Add(topline);
                    }
                    else if (i == 0 && j == 6)
                    {
                        PictureBox topline = new PictureBox();
                        topline.Dock = DockStyle.Top;
                        topline.Height = 1;
                        topline.BackColor = Color.Black;

                        panel.Controls.Add(topline);
                    }

                    if (i != 0 && j == 6)
                    {
                        string text = classes[i - 1];
                        Label lbl = new Label();
                        lbl.Font = new Font("Century Gothic", 18, FontStyle.Bold);
                        lbl.Text = text;
                        ColorTables(lbl);
                        lbl.BackColor = Color.White;
                        panel.Controls.Add(lbl);
                        lbl.Left = panel.Left + 35;
                        lbl.Top = panel.Top + 40;
                        lbl.Width = 200;
                        lbl.Height = 70;
                    }
                }
            }
            return panels;
        }
        void ColorTables(Label lbl)
        {
            switch (counter % 4)
            {
                case 0:
                    lbl.ForeColor = Color.Red;
                    break;
                case 1:
                    lbl.ForeColor = Color.FromArgb(0, 192, 0);
                    break;
                case 2:
                    lbl.ForeColor = Color.FromArgb(0, 192, 192);
                    break;
                case 3:
                    lbl.ForeColor = Color.Fuchsia;
                    break;
            }
            counter++;
        }
    }
}
