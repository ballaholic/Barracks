namespace Barracks
{
    using Barracks.Data;
    using Barracks.Core;
    using Barracks.Contracts;
    using Barracks.Core.Factories;
    using Barracks.Core.Commands;

    public static class BarracksEntryPoint
    {
        public static void Start()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(repository, unitFactory);
            IRunnable engine = new Engine(repository, unitFactory, commandInterpreter);
            engine.Run();
        }
    }
}