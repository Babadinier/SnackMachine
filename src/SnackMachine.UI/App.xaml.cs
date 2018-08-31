using System.Configuration;
using DDDInPractice.Logic.Utils;

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
