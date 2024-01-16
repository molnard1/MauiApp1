namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage1", typeof(MainPage));
            Routing.RegisterRoute("NewPage1", typeof(NewPage1));
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("LoggedInPage", typeof(LoggedInPage));
            MainPage = new AppShell();
        }
    }
}
