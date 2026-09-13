using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using LayerByte.Sentinelboard.Models;

namespace LayerByte.Sentinelboard.Services;

public sealed class SecurityReportService
{
    public ObservableCollection<ReportItem> BuildReport()
    {
        var items = new ObservableCollection<ReportItem>
        {
            new("Project", "Sentinelboard"),
            new("Focus", "GUI security monitoring dashboard."),
            new("Machine", Environment.MachineName),
            new("OS", Environment.OSVersion.ToString()),
            new("Processes", Process.GetProcesses().Length.ToString())
        };
        return items;
    }

    public string HashFile(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
        {
            throw new FileNotFoundException("Choose a readable local file.", path);
        }
        using var stream = File.OpenRead(path);
        return Convert.ToHexString(SHA256.HashData(stream)).ToLowerInvariant();
    }
}
