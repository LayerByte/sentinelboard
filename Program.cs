using System.Windows;

namespace LayerByte.Sentinelboard;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        var app = new App();
        app.Run(new Views.MainWindow());
    }
}
