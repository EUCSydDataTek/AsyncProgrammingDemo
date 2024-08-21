using System.Net;
using System.Windows;

namespace SynchronousProblemDemo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnSync_Click(object sender, RoutedEventArgs e)
    {
        txtResults.Text = "Downloading...\r\n";

        int contentLength = AccessTheWebSync();

        txtResults.Text += string.Format($"\r\nLength: {contentLength} bytes\r\n");
    }

    int AccessTheWebSync()
    {
        WebClient client = new WebClient();

        string getString = client.DownloadString("https://demosamples.azurewebsites.net/SlowPages/SlowPage.aspx");

        string urlContents = getString;

        return urlContents.Length;
    }
}