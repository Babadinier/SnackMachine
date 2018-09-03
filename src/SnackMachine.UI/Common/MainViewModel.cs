using DDDInPractice.Logic.Atms;
using DDDInPractice.Logic.SnackMachine;
using DDDInPractice.UI.Atms;

namespace DDDInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        private readonly SnackMachineRepository _snackMachineRepository;
        private readonly AtmRepository _atmRepository;

        public MainViewModel()
        {
            //_snackMachineRepository = new SnackMachineRepository();;
            //var snackMachine = _snackMachineRepository.GetById(1);
            //var viewModel = new SnackMachineViewModel(snackMachine);
            _atmRepository = new AtmRepository();
            var atm = _atmRepository.GetById(1);
            var viewModel = new AtmViewModel(atm);
            _dialogService.ShowDialog(viewModel);
        }
    }
}

