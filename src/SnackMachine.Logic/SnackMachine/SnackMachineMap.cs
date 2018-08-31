﻿using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace DDDInPractice.Logic.SnackMachine
{
    public class SnackMachineMap : ClassMap<DDDInPractice.Logic.SnackMachine.SnackMachine>
    {
        public SnackMachineMap()
        {
            Id(x => x.Id);

            Component(x => x.MoneyInside, y =>
            {
                y.Map(x => x.OneCentCount);
                y.Map(x => x.TenCentCount);
                y.Map(x => x.QuarterCentCount);
                y.Map(x => x.OneDollarCount);
                y.Map(x => x.FiveDollarCount);
                y.Map(x => x.TwentyDollarCount);
            });

            HasMany<Slot>(Reveal.Member<DDDInPractice.Logic.SnackMachine.SnackMachine>("Slots")).Cascade.SaveUpdate().Not.LazyLoad();
        }
    }
}