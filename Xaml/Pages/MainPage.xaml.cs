using NetMdvt.Logic;

namespace NetMdvt.Xaml.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        DownloadExampleJson();

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private async void DownloadExampleJson()
    {
        JsonLabel.Text = string.Empty;
        IsDownloading.IsRunning = true;

        var fakeDelay = 3000;
        var uri = "https://api.open-meteo.com/v1/forecast?latitude=50.06&longitude=19.94&hourly=temperature_2m";
        var downloadJsonTask = await JsonDownloader.GetJsonAsync(uri, fakeDelay);

        JsonLabel.Text = downloadJsonTask.RootElement.GetRawText();
        IsDownloading.IsRunning = false;


        //int i = 0, fakeDelay = 3000;
        //var downloadingText = new[] { ".", "..", "..." };
        //var uri = "https://api.open-meteo.com/v1/forecast?latitude=50.06&longitude=19.94&hourly=temperature_2m";
        //var downloadJsonTask = JsonDownloader.GetJsonAsync(uri, fakeDelay);

        //while (!downloadJsonTask.IsCompleted)
        //{
        //    await Task.WhenAny(downloadJsonTask, Task.Delay(100));
        //    JsonLabel.Text = downloadingText[++i % downloadingText.Length];
        //}

        //JsonLabel.Text = downloadJsonTask.Result.RootElement.GetRawText();
    }
}

