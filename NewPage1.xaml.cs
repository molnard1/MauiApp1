using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace MauiApp1;

public partial class NewPage1 : ContentPage
{
    private DataTemplate dataTemplate = new(() =>
    {
        Label label = new();
        label.SetBinding(Label.TextProperty, ".");

        ViewCell viewCell = new()
        {
            View = label
        };

        MenuItem menuItem = new()
        {
            Text = "Törlés"
        };

        menuItem.Clicked += (s, e) =>
        {
            MenuItem m = s as MenuItem;

            if (m.BindingContext is string ctxItem)
            {
                Items.Remove(ctxItem);
            }
        };
        viewCell.ContextActions.Add(menuItem);
        return viewCell;
    });

    public static ObservableCollection<string> Items = new();
	public NewPage1()
	{
		InitializeComponent();
        LSzam.Text = MainPage.Count.ToString();
        LwAdatok.ItemTemplate = dataTemplate;
        LwAdatok.ItemsSource = Items;
    }
    private async void GoBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void GoAddClicked(object sender, EventArgs e)
    {
        Items.Add(EtrBe.Text);
        
    }

    async void SaveMauiAsset()
    {
        var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);

        await File.WriteAllLinesAsync($"{docsDirectory?.AbsoluteFile.Path}/adat.txt", Items);
    }

    async void LoadMauiAsset()
    {
        var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);
        Items.Clear();
        var f = await File.ReadAllLinesAsync($"{docsDirectory?.AbsoluteFile.Path}/adat.txt");
        foreach (var s in f)
        {
            Items.Add(s);
        }
    }

    private void BtnSave_OnClicked(object sender, EventArgs e)
    {
        SaveMauiAsset();
    }

    private void BtnLoad_OnClicked(object? sender, EventArgs e)
    {
        LoadMauiAsset();
    }

    private void BtnClear_OnClicked(object sender, EventArgs e)
    {
        Items.Clear();
    }

    private void BtnInsert_OnClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(EtrIn.Text)) return;
        var at = Convert.ToInt32(EtrIn.Text);
        Items.Insert(at, EtrBe.Text);
    }
}