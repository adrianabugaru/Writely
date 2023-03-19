namespace Writely;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        //MainPage = new AppShell();


        if (Preferences.ContainsKey("IsFirstLaunch"))
        {
            // App has already launched before
            MainPage = new NavigationPage(new HomePage());
        }
        else
        {
            // First launch
            MainPage = new NavigationPage(new MainPage());

            // Save the "IsFirstLaunch" flag
            Preferences.Set("IsFirstLaunch", false);
        }
    }
}

