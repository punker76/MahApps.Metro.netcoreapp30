using System.Diagnostics;
using System.Reflection;
using System.Windows;
using MahApps.Metro.Controls;

namespace MahApps.Metro.netcoreapp30
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var reader = new AssemblyTextFileReader(Assembly.GetExecutingAssembly());
            var readme = await reader.ReadFileAsync("README.md");
            this.Viewer.Markdown = readme;
        }

        private void OpenHyperlink(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Process.Start("explorer.exe", e.Parameter.ToString());
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}