namespace Barracks.Core.Commands
{
    using System;
    using System.Reflection;
    using Barracks.Attributes;
    using Barracks.Contracts;
    using Barracks.ExtensionMethods;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Path = "Barracks.Core.Commands.";

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.UnitFactory = unitFactory;
            this.Repository = repository;
        }

        public IUnitFactory UnitFactory { get; set; }
        public IRepository Repository { get; set; }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string fullCommandName = commandName.ToPascalCase() + "Command";
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;

            Type commandType = Type.GetType(Path + fullCommandName);

            ConstructorInfo ctor = commandType.GetConstructor(flags, null,
                new[] { typeof(string[]) }, null);

            IExecutable instance = ctor.Invoke(new object[] { data }) as IExecutable;

            FieldInfo[] fields = commandType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in fields)
            {
                bool hasInjectAttribute = field.GetCustomAttributes(typeof(InjectAttribute), false).Length > 0;

                if (hasInjectAttribute)
                {
                    string fieldTypeName = field.FieldType.Name;
                    
                    switch (fieldTypeName)
                    {
                        case "IUnitFactory":
                            field.SetValue(instance, this.UnitFactory);
                            break;
                        case "IRepository":
                            field.SetValue(instance, this.Repository);
                            break;
                    }
                }
            }
            return instance;
        }
    }
}