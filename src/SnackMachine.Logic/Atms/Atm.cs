using DDDInPractice.Logic.Common;
using DDDInPractice.Logic.SharedKernel;
using static DDDInPractice.Logic.SharedKernel.Money;

namespace DDDInPractice.Logic.Atms
{
    public class Atm : AggregateRoot
    {
        private const decimal ComissionRate = 0.01m;
        public virtual Money MoneyInside { get; protected set; } = None;
        public virtual decimal MoneyCharged { get; protected set; }

        public virtual string CanTakeMoney(decimal amount)
        {
            if (amount <= 0)
            {
                return "Invalid amount";
            }

            if (MoneyInside.Amount < amount)
            {
                return "Not enough money";
            }

            if (!MoneyInside.CanAllocate(amount))
            {
                return "Not enough change";
            }

            return string.Empty;
        }

        public virtual void TakeMoney(decimal amount)
        {
            var output = MoneyInside.Allocate(amount);
            MoneyInside -= output;

            var amountWithCommission = CalculateAmountWithComission(amount);
            MoneyCharged += amountWithCommission;
        }

        private decimal CalculateAmountWithComission(decimal amount)
        {
            var comission = amount * ComissionRate;
            var lessThanCent = comission % 0.01m;

            if (lessThanCent > 0)
            {
                comission = comission - lessThanCent + 0.01m;
            }

            return amount + comission;
        }

        public virtual void LoadMoney(Money money)
        {
            MoneyInside += money;
        }
    }
}
