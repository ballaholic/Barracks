﻿namespace Barracks.Data
{
    using System.Text;
    using System.Collections.Generic;
    using Barracks.Contracts;

    public class UnitRepository : IRepository
    {
        private readonly IDictionary<string, int> amountOfUnits;

        public UnitRepository()
        {
            this.amountOfUnits = new SortedDictionary<string, int>();
        }

        public string Statistics
        {
            get
            {
                StringBuilder statBuilder = new StringBuilder();
                foreach (var entry in amountOfUnits)
                {
                    string formatedEntry =
                            string.Format("{0} -> {1}", entry.Key, entry.Value);
                    statBuilder.AppendLine(formatedEntry);
                }

                return statBuilder.ToString().Trim();
            }
        }

        public void AddUnit(IUnit unit)
        {
            string unitType = unit.GetType().Name;
            if (!this.amountOfUnits.ContainsKey(unitType))
            {
                this.amountOfUnits.Add(unitType, 0);
            }

            this.amountOfUnits[unitType]++;
        }

        public void RemoveUnit(string unitType)
        {
            this.amountOfUnits[unitType]--;
        }

        public bool HasThatType(string unitType)
        {
            if (this.amountOfUnits.ContainsKey(unitType) && this.amountOfUnits[unitType] > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}