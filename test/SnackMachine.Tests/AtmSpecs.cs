using System.Configuration;
using System.Linq;
using DDDInPractice.Logic.Atms;
using DDDInPractice.Logic.Common;
using DDDInPractice.Logic.Utils;
using FluentAssertions;
using Xunit;
using static DDDInPractice.Logic.SharedKernel.Money;

namespace DDDInPractice.Tests
{
    public class AtmSpecs
    {
        [Fact]
        public void Take_money_exchanges_money_with_comission()
        {
            var atm = new Atm();
            atm.LoadMoney(Dollar);

            atm.TakeMoney(1m);

            atm.MoneyInside.Amount.Should().Be(0);
            atm.MoneyCharged.Should().Be(1.01m);
        }

        [Fact]
        public void Comission_is_at_least_one_cent()
        {
            var atm = new Atm();
            atm.LoadMoney(Cent);

            atm.TakeMoney(0.01m);

            atm.MoneyCharged.Should().Be(0.02m);
        }

        [Fact]
        public void Comission_is_rounded_up_to_the_next_cent()
        {
            var atm = new Atm();
            atm.LoadMoney(Dollar + TenCent);

            atm.TakeMoney(1.1m);

            atm.MoneyCharged.Should().Be(1.12m);
        }

        [Fact]
        public void Take_money_raises_an_event()
        {
            var atm = new Atm();
            atm.LoadMoney(Dollar);

            atm.TakeMoney(1m);

            var balanceChangedEvent = (BalanceChangedEvent)atm.DomainEvents.SingleOrDefault(x => x.GetType() == typeof(BalanceChangedEvent));
            balanceChangedEvent.Should().NotBeNull();
            balanceChangedEvent?.Delta.Should().Be(1.01m);
        }
    }
}
