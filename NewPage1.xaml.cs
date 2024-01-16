namespace MauiApp1;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}
    private async void GoBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}