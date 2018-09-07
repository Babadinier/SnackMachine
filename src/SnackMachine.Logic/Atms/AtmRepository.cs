using System.Collections.Generic;
using System.Linq;
using DDDInPractice.Logic.Common;
using DDDInPractice.Logic.Utils;

namespace DDDInPractice.Logic.Atms
{
    public class AtmRepository : Repository<Atm>
    {
        public IReadOnlyList<AtmDto> GetAtmList()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.Query<Atm>()
                    .ToList()
                    .Select(x => new AtmDto(x.Id, x.MoneyInside.Amount))
                    .ToList();
            }
        }
    }
}
