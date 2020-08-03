using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;
using System.Collections.Generic;
using System.Text;
using System;

namespace AxisAndAllies.Entities
{
    public class LandTerritory : ITerritory
    {
        public int value { get; }
        public bool capital { get; }
        public TerritoryStatus originalCountry { get; }
        public string name { get; }
        public TerritoryStatus status { get; set; }
        public Dictionary<Unit,int> armies { get; }
        public List<ITerritory> adjacentTerritories { get; }

        public LandTerritory(string tName, int tValue, bool tCapital, TerritoryStatus tStatus)
        {
            name = tName;
            value = tValue;
            capital = tCapital;
            status = tStatus;
            originalCountry = tStatus;
            armies = new Dictionary<Unit, int>();
            adjacentTerritories = new List<ITerritory>();
        }

        public void addArmy(Unit unit, int count)
        {
            if(unit.type != UnitType.Naval)
            {
                int result;
                armies.TryGetValue(unit,out result);
                armies[unit] = result + count;
            }
            else{
                Console.WriteLine("-------------------");
                Console.WriteLine("CAN ONLY ADD LAND AND AIR UNITS TO LAND TERRITORIES");
                Console.WriteLine("-------------------");
            }
        }

        public void removeArmy(Unit unit, int count)
        {
            int result;
            armies.TryGetValue(unit,out result);
            if(result > 0)
            {
                armies[unit] = result - count;
            }
        }

        public void clearArmies()
        {
            armies.Clear();
        }

        public void addTerritories(List<ITerritory> t)
        {
            adjacentTerritories.AddRange(t);
        }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Land Territory Name: {name}");
            sb.AppendLine($"Land Territory Value: {value}");
            sb.AppendLine($"Land Territory Capital: {capital}");
            sb.AppendLine($"Land Territory Origin Status: {originalCountry}");
            sb.AppendLine($"Land Territory Status: {status}");
            sb.AppendLine($"Land Territory Armies: ");
            foreach (var u in armies)
            {
                sb.Append($"{u.Key.name}: {u.Value}, ");
            }
            sb.Remove(sb.Length-2,2);
            sb.AppendLine();
            sb.AppendLine($"Land Territory Adjacent Territories: ");
            foreach (var t in adjacentTerritories)
            {
                sb.Append($"{t.name}, ");
            }
            sb.Remove(sb.Length-2,2);
            sb.AppendLine();
            return sb.ToString();
        }
    }
}