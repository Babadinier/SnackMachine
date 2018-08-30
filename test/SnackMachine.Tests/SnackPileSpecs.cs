using System;
using FluentAssertions;
using SnackMachine.Logic;
using Xunit;
using static SnackMachine.Logic.Snack;

namespace SnackMachine.Tests
{
    public class SnackPileSpecs
    {
        [Fact]
        public void Cannot_create_snackPile_with_negative_quantity()
        {
            Action action = () => { new SnackPile(Chocolate, -2, 1); };
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Cannot_create_snackPile_with_negative_price()
        {
            Action action = () => { new SnackPile(Chocolate, 1, -2); };
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Cannot_create_snackPile_with_price_with_have_more_2_decimals()
        {
            Action action = () => { new SnackPile(Chocolate, 1, 1.011m); };
            action.Should().Throw<ArgumentException>();
        }
    }
}
