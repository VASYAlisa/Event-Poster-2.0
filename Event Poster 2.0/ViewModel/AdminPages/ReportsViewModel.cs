using CsvHelper;
using CsvHelper.Configuration;
using Event_Poster_2._0.Model.DTOs;
using Event_Poster_2._0.Model.Repositories;
using Event_Poster_2._0.Utilities;
using Event_Poster_2._0.View.AdminPages;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Event_Poster_2._0.Model.DTOs.ReportDto;

namespace Event_Poster_2._0.ViewModel.AdminPages
{
    public class ReportsViewModel: ViewModelBase
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private ReportDto _dataTable;
        public DateTime StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(nameof(StartDate)); } }
        public DateTime EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(nameof(EndDate)); } }
        public ReportDto DataTable { get => _dataTable; set { _dataTable = value; OnPropertyChanged(nameof(DataTable)); } }

        public ICommand UpdateReportDataTableCommand { get; set; }
        public ICommand DownloadReportDataTableCommand { get; set; }

        private DbRepos context;
        public ReportsViewModel()
        {
            context = new DbRepos();
            StartDate = DateTime.Now.AddMonths(-1);
            EndDate = DateTime.Now;


            DataTable = new ReportDto();
            DataTable.StartData = StartDate; DataTable.EndData = EndDate;
            DataTable.Participations = new ObservableCollection<ParticipationsByDate>(context.Reports.ParticipationsByDate(StartDate, EndDate));

            DownloadReportDataTableCommand = new RelayCommand(DownloadReportDataTable);
            UpdateReportDataTableCommand = new RelayCommand(UpdateReportDataTable);
        }

        private void UpdateReportDataTable(object obj)
        {
            DataTable.Participations = new ObservableCollection<ParticipationsByDate>(context.Reports.ParticipationsByDate(StartDate, EndDate));
        }

        private string filePath;
        private void DownloadReportDataTable(object obj)
        {
            filePath = OpenFolderDialog();

            if (!string.IsNullOrEmpty(filePath))
            {
                GenerateCsvReport(DataTable.Participations, filePath);
            }
        }

        public string OpenFolderDialog()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Title = "Выберите папку",
                Filter = "CSV file (.csv)|.csv",
                OverwritePrompt = false,
                FileName = "Отчёт." + StartDate.ToShortDateString() + "-" + EndDate.ToShortDateString(),
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }

            return null;
        }

        public static void GenerateCsvReport(ObservableCollection<ParticipationsByDate> data, string filePath)
        {
            using (var writer = new StreamWriter(filePath, false, Encoding.GetEncoding("windows-1251")))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(new CultureInfo("ru-RU"))))
            {
                csv.WriteRecords(data.Select(item => new { Дата = item.Date, Время = item.Time, События = item.Events, Участник = item.Participant, Стоимость_заказа = item.Price }));
            }
        }

    }
}
