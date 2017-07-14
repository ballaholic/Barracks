namespace Barracks.Core
{
    using System;
    using Barracks.Contracts;

    public class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        private ICommandInterpreter commandInterpreter;

        public Engine(IRepository repository, IUnitFactory unitFactory, ICommandInterpreter commandInterpreter)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input.Equals("fight"))
                    {
                        Environment.Exit(0);
                    }

                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = this.commandInterpreter
                        .InterpretCommand(data, commandName)
                        .Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}