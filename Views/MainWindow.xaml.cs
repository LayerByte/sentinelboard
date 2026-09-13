using System.Collections.ObjectModel;
using System.Windows;
using LayerByte.Sentinelboard.Models;
using LayerByte.Sentinelboard.Services;

namespace LayerByte.Sentinelboard.Views;

public partial class MainWindow : Window
{
    public ObservableCollection<ReportItem> Items { get; }

    public MainWindow()
    {
        InitializeComponent();
        Items = new SecurityReportService().BuildReport();
        DataContext = this;
    }
}
