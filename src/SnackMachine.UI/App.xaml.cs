using System.Configuration;
using SnackMachine.Logic;

namespace SnackMachine.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            Initer.Init(ConfigurationManager.ConnectionStrings["SnackMachine"].ConnectionString);
        }
    }
}
