using DddInPractice.UI.Management;

namespace DDDInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        public DashboardViewModel Dashboard { get; private set; }

        public MainViewModel()
        {
            Dashboard = new DashboardViewModel();
            _dialogService.ShowDialog(Dashboard);
        }
    }
}

