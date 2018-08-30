using System.ComponentModel;
using System.Runtime.CompilerServices;
using SnackMachine.UI.Utils;

namespace SnackMachine.UI.Common
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected static readonly DialogService _dialogService = new DialogService();

        private bool? _dialogResult;
        public bool? DialogResult
        {
            get => _dialogResult;
            protected set
            {
                _dialogResult = value;
                Notify();
            }
        }

        protected void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
