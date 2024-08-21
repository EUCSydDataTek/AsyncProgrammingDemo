using System.Net;
using System.Windows;

namespace AsyncWithThread;

public partial class MainWindow : Window
{
    private SynchronizationContext uiCtx = SynchronizationContext.Current;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnSync_Click(object sender, RoutedEventArgs e)
    {
        txtResults.Text = "Downloading...\r\n";
        new Thread(AccessTheWebAsync).Start();
    }

    void AccessTheWebAsync()
    {
        WebClient client = new WebClient();

        string getString = client.DownloadString("https://demosamples.azurewebsites.net/SlowPages/SlowPage.aspx");

        string urlContents = getString;

        uiCtx.Post(_ => txtResults.Text += string.Format($"\r\nLength: {urlContents.Length} bytes\r\n"), null);
    }
}