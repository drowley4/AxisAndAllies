using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;
using System.Collections.Generic;
using System.Text;
using System;

namespace AxisAndAllies.Entities
{
    public class NavalTerritory : ITerritory 
    {
        public string name { get; }

        public int value { get; }
        public TerritoryStatus status { get; set; }
        public Dictionary<Unit,int> armies { get; }
        public List<ITerritory> adjacentTerritories { get; }

        public NavalTerritory(string tName, TerritoryStatus tStatus)
        {
            name = tName;
            status = tStatus;
            armies = new Dictionary<Unit, int>();
            adjacentTerritories = new List<ITerritory>();
        }

        public void addArmy(Unit unit, int count)
        {
            if(unit.type == UnitType.Naval)
            {
                int result;
                armies.TryGetValue(unit,out result);
                armies[unit] = result + count;
            }
            else if(unit.name.Equals("FIGHTER"))
            {
                int numCarriers = 0;
                int numFighters = 0;
                foreach (var item in armies)
                {
                    if(item.Key.name.Equals("AIRCRAFT CARRIER"))
                    {
                        numCarriers = item.Value;
                    }
                    if(item.Key.name.Equals("FIGHTER"))
                    {
                        numFighters = item.Value;
                    }
                }
                if(2*numCarriers >= numFighters+count)
                {
                    int result;
                    armies.TryGetValue(unit,out result);
                    armies[unit] = result + count;
                }
                else 
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine("CAN ONLY ADD AIR UNITS TO CARRIER NAVAL TERRITORIES");
                    Console.WriteLine("-------------------");
                }
            }
            else
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("CAN ONLY ADD NAVAL UNITS TO NAVAL TERRITORIES");
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
            sb.AppendLine($"Naval Territory Name: {name}");
            sb.AppendLine($"Naval Territory Status: {status}");
            sb.AppendLine($"Naval Territory Armies: ");
            foreach (var u in armies)
            {
                sb.Append($"{u.Key.name}: {u.Value}, ");
            }
            sb.Remove(sb.Length-2,2);
            sb.AppendLine();
            sb.AppendLine($"Naval Territory Adjacent Territories: ");
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