using System.Configuration;
using DDDInPractice.Logic.Management;
using DDDInPractice.Logic.SnackMachine;
using DDDInPractice.Logic.Utils;
using FluentAssertions;
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

            snackMachine.Should().NotBe(null);
        }

        [Fact]
        public void Test_DB_HeadOffice()
        {
            SessionFactory.Init(ConfigurationManager.ConnectionStrings["SnackMachine"].ConnectionString);

            var repository = new HeadOfficeRepository();
            var headOffice = repository.GetById(1);

            headOffice.Should().NotBe(null);
        }
    }
}
