using FluentNHibernate.Mapping;

namespace DDDInPractice.Logic.SnackMachine
{
    public class SnackMap : ClassMap<Snack>
    {
        public SnackMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
