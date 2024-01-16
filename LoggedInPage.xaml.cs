namespace MauiApp1;

public partial class LoggedInPage : ContentPage
{
	public LoggedInPage()
	{
		InitializeComponent();
	}

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            double res = 0;
            double num1 = double.Parse(Num1.Text);
            double num2 = double.Parse(Num2.Text);

            switch ((string)Operation.SelectedItem)
            {
                case "+":
                {
                    res = num1 + num2;
                    break;
                }
                case "-":
                {
                    res = num1 - num2;
                    break;
                }
                case "/":
                {
                    res = num1 / num2;
                    break;
                }
                case "*":
                {
                    res = num1 * num2;
                    break;
                }
            }

            Result.Text = $"Eredmény: {res}";
        }
        catch(Exception ex)
        {
            Result.Text = $"Eredmény: {ex.Message}";
        }
    }

    private void Operation_OnSelectedIndexChanged(object? sender, EventArgs e)
    {
        Operation.Unfocus();
        Num2.Focus();
    }

    private void VisualElement_OnLoaded(object? sender, EventArgs e)
    {
        Image1.IsAnimationPlaying = false;
        Image1.IsAnimationPlaying = true;
    }
}