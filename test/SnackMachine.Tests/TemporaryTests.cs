using System.Configuration;
using DDDInPractice.Logic.SharedKernel;
using DDDInPractice.Logic.SnackMachine;
using DDDInPractice.Logic.Utils;
using Xunit;

namespace DDDInPractice.Tests
{
    public class TemporaryTests
    {
        [Fact]
        public void Test()
        {
            SessionFactory.Init(ConfigurationManager.ConnectionStrings["SnackMachine"].ConnectionString);
            
            var repository = new SnackMachineRepository();
            var snackMachine = repository.GetById(1);
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.BuySnack(1);
            repository.Save(snackMachine);
        }
    }
}
