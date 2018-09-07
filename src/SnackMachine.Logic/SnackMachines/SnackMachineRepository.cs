using System.Collections.Generic;
using System.Linq;
using DDDInPractice.Logic.Common;
using DDDInPractice.Logic.Utils;

namespace DDDInPractice.Logic.SnackMachines
{
    public class SnackMachineRepository : Repository<SnackMachine>
    {
        public IReadOnlyList<SnackMachineDto> GetSnackMachineList()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.Query<SnackMachine>()
                    .ToList() // Fetch data into memory
                    .Select(x => new SnackMachineDto(x.Id, x.MoneyInside.Amount))
                    .ToList();
            }
        }
    }
}
