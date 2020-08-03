using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;
using System.Collections.Generic;

namespace AxisAndAllies.Entities
{
    public interface ITerritory
    {
        string name { get; }
        int value { get; }
        TerritoryStatus status { get; set; }
        Dictionary<Unit,int> armies { get; }
        List<ITerritory> adjacentTerritories { get; }

        void addArmy(Unit unit,int count);
        void removeArmy(Unit unit,int count);
        void clearArmies();
        void addTerritories(List<ITerritory> t);
        string toString();
    }
}