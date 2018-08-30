using System.Configuration;
using SnackMachine.Logic;
using Xunit;

namespace SnackMachine.Tests
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
