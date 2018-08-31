using System;
using DDDInPractice.Logic.Common;

namespace DDDInPractice.Logic.SharedKernel
{
    public sealed class Money : ValueObject<Money>
    {
        public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);
        public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);
        public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
        public static readonly Money QuarterCent = new Money(0, 0, 1, 0, 0, 0);
        public static readonly Money Dollar = new Money(0, 0, 0, 1, 0, 0);
        public static readonly Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);
        public static readonly Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);
        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuarterCentCount { get; }
        public int OneDollarCount { get; }
        public int FiveDollarCount { get; }
        public int TwentyDollarCount { get; }

        public decimal Amount => OneCentCount * 0.01m +
                                 TenCentCount * 0.1m +
                                 QuarterCentCount * 0.25m +
                                 OneDollarCount +
                                 FiveDollarCount * 5 +
                                 TwentyDollarCount * 20;

        private Money()
        {

        }

        public Money(int oneCentCount, int tenCentCount, int quarterCentCount, int oneDollarCount, int fiveDollarCount,
            int twentyDollarCount) : this()
        {
            if(oneCentCount < 0)
                throw new ArgumentException();
            if (tenCentCount < 0)
                throw new ArgumentException();
            if (quarterCentCount < 0)
                throw new ArgumentException();
            if (oneDollarCount < 0)
                throw new ArgumentException();
            if (fiveDollarCount < 0)
                throw new ArgumentException();
            if (twentyDollarCount < 0)
                throw new ArgumentException();

            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuarterCentCount = quarterCentCount;
            OneDollarCount = oneDollarCount;
            FiveDollarCount = fiveDollarCount;
            TwentyDollarCount = twentyDollarCount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            var sum = new Money(
                money1.OneCentCount + money2.OneCentCount,
                money1.TenCentCount + money2.TenCentCount,
                money1.QuarterCentCount + money2.QuarterCentCount,
                money1.OneDollarCount + money2.OneDollarCount,
                money1.FiveDollarCount + money2.FiveDollarCount,
                money1.TwentyDollarCount + money2.TwentyDollarCount
            );

            return sum;
        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
                money1.OneCentCount - money2.OneCentCount,
                money1.TenCentCount - money2.TenCentCount,
                money1.QuarterCentCount - money2.QuarterCentCount,
                money1.OneDollarCount - money2.OneDollarCount,
                money1.FiveDollarCount - money2.FiveDollarCount,
                money1.TwentyDollarCount - money2.TwentyDollarCount);
        }

        protected override bool EqualsCore(Money valueObject)
        {
            return OneCentCount == valueObject.OneCentCount
                   && TenCentCount == valueObject.TenCentCount
                   && QuarterCentCount == valueObject.QuarterCentCount
                   && OneDollarCount == valueObject.OneDollarCount
                   && FiveDollarCount == valueObject.FiveDollarCount
                   && TwentyDollarCount == valueObject.TwentyDollarCount;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = OneCentCount;
                hashCode = (hashCode * 397) ^ TenCentCount;
                hashCode = (hashCode * 397) ^ QuarterCentCount;
                hashCode = (hashCode * 397) ^ OneDollarCount;
                hashCode = (hashCode * 397) ^ FiveDollarCount;
                hashCode = (hashCode * 397) ^ TwentyDollarCount;
                return hashCode;
            }
        }

        public override string ToString()
        {
            if (Amount < 1)
                return "¢" + (Amount * 100).ToString("0");

            return "$" + Amount.ToString("0.00");
        }

        public bool CanAllocate(decimal amount)
        {
            var money = AllocateCore(amount);
            return money.Amount == amount;
        }

        public Money Allocate(decimal amount)
        {
            if(!CanAllocate(amount))
                throw new InvalidOperationException();

            return AllocateCore(amount);
        }

        public Money AllocateCore(decimal amount)
        {
            var twentyDollarCount = Math.Min((int) (amount / 20), TwentyDollarCount);
            amount = amount - twentyDollarCount * 20;

            var fiveDollarCount = Math.Min((int)(amount / 5), FiveDollarCount);
            amount = amount - fiveDollarCount * 5;

            var oneDollarCount = Math.Min((int)amount, OneDollarCount);
            amount = amount - oneDollarCount;

            var quarterCentCount = Math.Min((int)(amount / 0.25m), QuarterCentCount);
            amount = amount - quarterCentCount * 0.25m;

            var tenCentCount = Math.Min((int)(amount / 0.1m), TenCentCount);
            amount = amount - tenCentCount * 0.1m;

            var oneCentCount = Math.Min((int)(amount / 0.01m), OneCentCount);
            amount = amount - oneCentCount * 0.01m;

            return new Money(oneCentCount, tenCentCount, quarterCentCount, oneDollarCount, fiveDollarCount,
                twentyDollarCount);
        }
    }
}