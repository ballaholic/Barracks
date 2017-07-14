namespace Barracks.Core.Commands
{
    using Barracks.Attributes;
    using Barracks.Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            string output;

            if (this.repository.HasThatType(unitType))
            {
                this.repository.RemoveUnit(unitType);

                output = unitType + " retired!";
            }
            else
            {
                output = "No such units in repository.";
            }

            return output;
        }
    }
}