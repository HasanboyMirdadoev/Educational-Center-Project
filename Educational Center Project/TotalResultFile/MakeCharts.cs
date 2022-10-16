using System;
using System.Collections.Generic;
using System.Data;
using Educational_Center_Project.OverallProps;
using LiveCharts;
using LiveCharts.Wpf;

namespace Educational_Center_Project.TotalResultFile
{
    class MakeCharts
    {
        public void MakeMonthChart(LiveCharts.WinForms.CartesianChart monthChart)
        {
            List<TotalMonthDatas> monthDatas = GetMonthList();
            List<string> dates = new List<string>();
            foreach (var data in monthDatas)
            {
                dates.Add(data.Date);
            }
            monthChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Month",
                Labels = dates
            });
            monthChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Revenue",
                LabelFormatter = value => value.ToString("C")
            }); ;
            monthChart.LegendLocation = LiveCharts.LegendLocation.Right;
        }
        public void MakeMonthSeries(LiveCharts.WinForms.CartesianChart monthChart)
        {
            List<TotalMonthDatas> monthDatas = GetMonthList();

            monthChart.Series.Add(MakePureProfitSeries(monthDatas));
            monthChart.Series.Add(MakeTotalProfitSeries(monthDatas));
            monthChart.Series.Add(MakeTeacherSalarySeries(monthDatas));
        }
        private LineSeries MakePureProfitSeries(List<TotalMonthDatas> monthDatas)
        {
            List<double> pureProfits = new List<double>();
            foreach (var data in monthDatas)
            {
                pureProfits.Add(data.PureProfit);
            }
            return new LineSeries() { Title = "PureProfits", Values = new ChartValues<double>(pureProfits) };
        }
        private LineSeries MakeTotalProfitSeries(List<TotalMonthDatas> monthDatas)
        {
            List<double> totalProfits = new List<double>();
            foreach (var data in monthDatas)
            {
                totalProfits.Add(data.TotalProfit);
            }
            return new LineSeries() { Title = "TotalProfit", Values = new ChartValues<double>(totalProfits) };
        }
        private LineSeries MakeTeacherSalarySeries(List<TotalMonthDatas> monthDatas)
        {
            List<double> teacherSalaries = new List<double>();
            foreach (var data in monthDatas)
            {
                teacherSalaries.Add(data.TeachersSalary);
            }
            return new LineSeries() { Title = "TeacherSalaries", Values = new ChartValues<double>(teacherSalaries) };
        }
        private List<TotalMonthDatas> GetMonthList()
        {
            DataTable table = BaseDB.GetMonthOutcomeTable();
            List<TotalMonthDatas> monthDatas = new List<TotalMonthDatas>();
            foreach (DataRow row in table.Rows)
            {
                TotalMonthDatas monthData = new TotalMonthDatas()
                {
                    Date = row["Date"].ToString(),
                    LessonCount = Convert.ToInt32(row["LessonCount"]),
                    StudentCount = Convert.ToInt32(row["StudentCount"]),
                    GroupCount = Convert.ToInt32(row["GroupCount"]),
                    TeacherCount = Convert.ToInt32(row["TeacherCount"]),
                    TotalProfit = Convert.ToDouble(row["TotalProfit"]),
                    TeachersSalary = Convert.ToDouble(row["TotalTeacherSalary"]),
                    PureProfit = Convert.ToDouble(row["PureProfit"]),
                };
                monthDatas.Add(monthData);
            }
            return monthDatas;
        }

        public void MakeYearChart(LiveCharts.WinForms.CartesianChart yearChart)
        {
            List<TotalYearDatas> yearDates = GetYearList();
            List<string> dates = new List<string>();
            foreach (var data in yearDates)
            {
                dates.Add(data.Year.ToString());
            }
            yearChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Year",
                Labels = dates
            });
            yearChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Revenue",
                LabelFormatter = value => value.ToString("C")
            }); ;
            yearChart.LegendLocation = LiveCharts.LegendLocation.Right;
        }
        public void MakeYearSeries(LiveCharts.WinForms.CartesianChart yearChart)
        {
            List<TotalYearDatas> yearDatas = GetYearList();

            yearChart.Series.Add(MakePureProfitSeriesYear(yearDatas));
            yearChart.Series.Add(MakeTotalProfitSeriesYear(yearDatas));
            yearChart.Series.Add(MakeTeacherSalarySeriesYear(yearDatas));
        }
        private LineSeries MakePureProfitSeriesYear(List<TotalYearDatas> yearDatas)
        {
            List<double> pureProfits = new List<double>();
            foreach (var data in yearDatas)
            {
                pureProfits.Add(data.PureProfit);
            }
            return new LineSeries() { Title = "PureProfits", Values = new ChartValues<double>(pureProfits) };
        }
        private LineSeries MakeTotalProfitSeriesYear(List<TotalYearDatas> yearDatas)
        {
            List<double> totalProfits = new List<double>();
            foreach (var data in yearDatas)
            {
                totalProfits.Add(data.TotalProfit);
            }
            return new LineSeries() { Title = "TotalProfit", Values = new ChartValues<double>(totalProfits) };
        }
        private LineSeries MakeTeacherSalarySeriesYear(List<TotalYearDatas> yearDatas)
        {
            List<double> teacherSalaries = new List<double>();
            foreach (var data in yearDatas)
            {
                teacherSalaries.Add(data.TeacherSalary);
            }
            return new LineSeries() { Title = "TeacherSalaries", Values = new ChartValues<double>(teacherSalaries) };
        }
        private List<TotalYearDatas> GetYearList()
        {
            DataTable table = BaseDB.GetYearOutcomeTable();
            List<TotalYearDatas> yearDatas = new List<TotalYearDatas>();
            foreach (DataRow row in table.Rows)
            {
                TotalYearDatas yearData = new TotalYearDatas()
                {
                    Year =Convert.ToInt32(row["Year"]),
                    LessonCount = Convert.ToInt32(row["LessonCount"]),
                    TotalProfit = Convert.ToDouble(row["TotalProfit"]),
                    TeacherSalary = Convert.ToDouble(row["TeachersSalary"]),
                    PureProfit = Convert.ToDouble(row["PureProfit"]),
                };
                yearDatas.Add(yearData);
            }
            return yearDatas;
        }
    }
}
