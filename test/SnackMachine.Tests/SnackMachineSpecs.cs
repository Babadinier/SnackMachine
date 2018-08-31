using System;
using DDDInPractice.Logic.SharedKernel;
using DDDInPractice.Logic.SnackMachine;
using FluentAssertions;
using Xunit;

namespace DDDInPractice.Tests
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void Return_money_empties_money_in_transaction()
        {
            var snackMachine = new DDDInPractice.Logic.SnackMachine.SnackMachine();
            snackMachine.InsertMoney(Money.Dollar);

            snackMachine.ReturnMoney();

            snackMachine.MoneyInTransaction.Should().Be(0m);
        }

        [Fact]
        public void Inserted_money_goes_to_money_in_transaction()
        {
            var snackMachine = new DDDInPractice.Logic.SnackMachine.SnackMachine();
            
            snackMachine.InsertMoney(Money.Cent);
            snackMachine.InsertMoney(Money.Dollar);

            snackMachine.MoneyInTransaction.Should().Be(1.01m);
        }

        [Fact]
        public void Cannot_insert_more_than_one_coin_or_note_at_a_time()
        {
            var snackMachine = new DDDInPractice.Logic.SnackMachine.SnackMachine();
            var twoCent = Money.Cent + Money.Cent;

            Action action = () => snackMachine.InsertMoney(twoCent);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void BuySnack_trades_inserted_money_for_a_snack()
        {
            var snackMachine = new DDDInPractice.Logic.SnackMachine.SnackMachine();
            snackMachine.LoadSnacks(1, new SnackPile(Snack.Chocolate, 10, 1m));
            snackMachine.InsertMoney(Money.Dollar);

            snackMachine.BuySnack(1);

            snackMachine.MoneyInTransaction.Should().Be(0);
            snackMachine.MoneyInside.Amount.Should().Be(1m);
            snackMachine.GetSnackPile(1).Quantity.Should().Be(9);
        }

        [Fact]
        public void Cannot_make_purchase_when_there_is_no_snacks()
        {
            var snackMachine = new DDDInPractice.Logic.SnackMachine.SnackMachine();

            Action action = () => snackMachine.BuySnack(1);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Cannot_make_purchase_if_not_enough_money_inserted()
        {
            var snackMachine = new DDDInPractice.Logic.SnackMachine.SnackMachine();
            snackMachine.LoadSnacks(1, new SnackPile(Snack.Chocolate, 1, 2m));
            snackMachine.InsertMoney(Money.Dollar);

            Action action = () => snackMachine.BuySnack(1);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Snack_machine_returns_money_with_highest_denomination_first()
        {
            var snackMachine = new DDDInPractice.Logic.SnackMachine.SnackMachine();
            snackMachine.LoadMoney(Money.Dollar);

            snackMachine.InsertMoney(Money.QuarterCent);
            snackMachine.InsertMoney(Money.QuarterCent);
            snackMachine.InsertMoney(Money.QuarterCent);
            snackMachine.InsertMoney(Money.QuarterCent);
            snackMachine.ReturnMoney();

            snackMachine.MoneyInside.QuarterCentCount.Should().Be(4);
            snackMachine.MoneyInside.OneDollarCount.Should().Be(0);
        }

        [Fact]
        public void After_purchase_change_is_returned()
        {
            var snackMachine = new DDDInPractice.Logic.SnackMachine.SnackMachine();
            snackMachine.LoadSnacks(1, new SnackPile(Snack.Chocolate, 1, 0.5m));
            snackMachine.LoadMoney(new Money(0, 10, 0, 0, 0, 0));

            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.BuySnack(1);

            snackMachine.MoneyInside.Amount.Should().Be(1.5m);
            snackMachine.MoneyInTransaction.Should().Be(0m);
        }


        [Fact]
        public void Cannot_buy_snack_if_not_enough_change()
        {
            var snackMachine = new DDDInPractice.Logic.SnackMachine.SnackMachine();
            snackMachine.LoadSnacks(1, new SnackPile(Snack.Chocolate, 1, 0.5m));

            snackMachine.InsertMoney(Money.Dollar);
            Action action = () => snackMachine.BuySnack(1);

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
