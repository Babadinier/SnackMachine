using DDDInPractice.Logic.Common;

namespace DDDInPractice.Logic.SnackMachine
{
    public class Slot : Entity
    {
        public virtual SnackPile SnackPile { get; set; }
        public virtual global::DDDInPractice.Logic.SnackMachine.SnackMachine SnackMachine { get; protected set; }
        public virtual int Position { get; protected set; }

        protected Slot()
        {
        }

        public Slot(global::DDDInPractice.Logic.SnackMachine.SnackMachine snackMachine, int position) : this()
        {
            SnackMachine = snackMachine;
            Position = position;
            SnackPile = SnackPile.Empty;
        }
    }
}
