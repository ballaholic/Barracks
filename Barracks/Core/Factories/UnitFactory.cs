namespace Barracks.Core.Factories
{
    using System;
    using System.Reflection;
    using Barracks.Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string Path = "Barracks.Models.Units.";

        public IUnit CreateUnit(string unitType)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;

            Type typeOfUnit = Type.GetType(Path + unitType, false);
            ConstructorInfo ctor = typeOfUnit.GetConstructor(flags, null, Type.EmptyTypes, null);
            IUnit unit = ctor.Invoke(null) as IUnit;
            return unit;
        }
    }
}