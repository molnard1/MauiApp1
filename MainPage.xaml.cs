using Timer = System.Timers.Timer;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            Timer t = new Timer
            {
                AutoReset = true,
                Enabled = true,
                Interval = 200
            };
            t.Elapsed += (sender, args) =>
            {
                bool van = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
                Label.Text = van ? "Van internet!" : "Nincs internet!";
            };
            t.Start();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void GoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NewPage1");
        }

        private async void GoLoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("LoginPage");
        }
    }

}
