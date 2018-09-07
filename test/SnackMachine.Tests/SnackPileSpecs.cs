using System;
using DDDInPractice.Logic.SnackMachines;
using FluentAssertions;
using Xunit;

namespace DDDInPractice.Tests
{
    public class SnackPileSpecs
    {
        [Fact]
        public void Cannot_create_snackPile_with_negative_quantity()
        {
            Action action = () => { new SnackPile(Snack.Chocolate, -2, 1); };
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Cannot_create_snackPile_with_negative_price()
        {
            Action action = () => { new SnackPile(Snack.Chocolate, 1, -2); };
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Cannot_create_snackPile_with_price_with_have_more_2_decimals()
        {
            Action action = () => { new SnackPile(Snack.Chocolate, 1, 1.011m); };
            action.Should().Throw<ArgumentException>();
        }
    }
}
