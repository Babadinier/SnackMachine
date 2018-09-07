using System;
using DDDInPractice.Logic.Common;

namespace DDDInPractice.Logic.SnackMachines
{
    public sealed class SnackPile : ValueObject<SnackPile>
    {
        public static SnackPile Empty = new SnackPile(Snack.None, 0, 0);
        public Snack Snack { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public SnackPile()
        {
        }

        public SnackPile(Snack snack, int quantity, decimal price) : this()
        {
            if (quantity < 0)
            {
                throw new ArgumentException();
            }

            if (price < 0)
            {
                throw new ArgumentException();
            }

            if (price % 0.01m > 0)
            {
                throw new ArgumentException();
            }

            Snack = snack;
            Quantity = quantity;
            Price = price;
        }

        protected override bool EqualsCore(SnackPile valueObject)
        {
            return Snack == valueObject.Snack
                   && Quantity == valueObject.Quantity
                   && Price == valueObject.Price;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hashCode = Snack.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity;
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                return hashCode;
            }
        }

        public SnackPile SubstractOne()
        {
            return new SnackPile(Snack, Quantity - 1, Price);
        }
    }
}
