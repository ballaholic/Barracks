namespace Barracks.Contracts
{
    public interface IRepository
    {
        void AddUnit(IUnit unit);
        string Statistics { get; }
        void RemoveUnit(string unitType);
        bool HasThatType(string unitType);
    }
}