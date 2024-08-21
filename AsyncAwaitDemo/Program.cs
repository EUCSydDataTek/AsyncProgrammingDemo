// Demo af async og await.
// Først vises kald af GetUrlContentLengthAsync(), hvor DoIndependentWork() først kaldes efter GetStringAsync() er færdig pga. await.
// Derefter vises kald af etUrlContentLengthDoMoreAsync(), hvor DoIndependentWork() kaldes før GetStringAsync() er færdig pga. await først køres efter DoIndependentWork() er færdig.

public class Program
{
    private static async Task Main()
    {
        Console.WriteLine("Starting");

        //int stringlength = await GetUrlContentLengthAsync();            // DoIndependentWork() will be called after GetStringAsync() is completed

        int stringlength = await GetUrlContentLengthDoMoreAsync();      // DoIndependentWork() will be called before GetStringAsync() is completed

        Console.WriteLine($"String length: {stringlength}");
    }

    public static async Task<int> GetUrlContentLengthAsync()
    {
        using var client = new HttpClient();

        string contents = await client.GetStringAsync("https://demosamples.azurewebsites.net/SlowPages/SlowPage.aspx");

        DoIndependentWork();

        return contents.Length;
    }

    public static async Task<int> GetUrlContentLengthDoMoreAsync()
    {
        using var client = new HttpClient();

        Task<string> getStringTask = client.GetStringAsync("https://demosamples.azurewebsites.net/SlowPages/SlowPage.aspx");

        DoIndependentWork();

        string contents = await getStringTask;

        return contents.Length;
    }




    static void DoIndependentWork()
    {
        Console.WriteLine("Hello from DoIndependentWork...");
    }
}