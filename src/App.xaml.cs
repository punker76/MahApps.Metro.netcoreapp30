using System.Windows;

namespace MahApps.Metro.netcoreapp30
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ThemeManager.IsAutomaticWindowsAppModeSettingSyncEnabled = true;
        ThemeManager.SyncThemeWithWindowsAppModeSetting();
    }
}
}
