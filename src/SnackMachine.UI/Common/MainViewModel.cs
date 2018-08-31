using DDDInPractice.Logic.SnackMachine;
using DDDInPractice.UI.SnackMachine;

namespace DDDInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        private readonly SnackMachineRepository _snackMachineRepository;
        public MainViewModel()
        {
            _snackMachineRepository = new SnackMachineRepository();;
            var snackMachine = _snackMachineRepository.GetById(1);
            var viewModel = new SnackMachineViewModel(snackMachine);
            _dialogService.ShowDialog(viewModel);
        }
    }
}

