using DDDInPractice.UI.Common;
using SnackMachine.UI.Common;

namespace DDDInPractice.UI.Utils
{
    public class DialogService
    {
        public bool? ShowDialog(ViewModel viewModel)
        {
            var window = new CustomWindow(viewModel);
            return window.ShowDialog();
        }
    }
}
