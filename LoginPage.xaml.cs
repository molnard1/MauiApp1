namespace MauiApp1;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
        if (Username.Text == "a" && Password.Text == "a")
        {
            await DisplayAlert("Sikeres bejelentkez�s", $"Felhaszn�l�n�v: {Username.Text}\nJelsz�: {Password.Text}",
                "OK");
            await Shell.Current.GoToAsync("LoggedInPage");
        }
        else
        {
            await DisplayAlert("Sikertelen bejelentkez�s", "�rv�nytelen felhaszn�l�n�v vagy jelsz�!",
                "OK");
        }

        Username.Text = "";
        Password.Text = "";
    }

    private void Password_OnCompleted(object? sender, EventArgs e)
    {
        Button_OnClicked(sender, e);
    }

    private void Username_OnCompleted(object? sender, EventArgs e)
    {
        Username.Unfocus();
        Password.Focus();
    }
}