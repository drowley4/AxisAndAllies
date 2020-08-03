using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;
using System.Collections.Generic;
using System.Text;

namespace AxisAndAllies.Entities
{
    public  class Country 
    {
        public string name { get; }
        public Weapon[] weapons { get;}
        public int currentIPC { get; set; }
        public int nextIPC { get; set; }
        public List<ITerritory> controlledTerritories { get; }
        public List<ITerritory> occupiedTerritories { get; }

        public Country(string cName, int cCurrentIPC, int cNextIPC) 
        {
            name = cName;
            currentIPC = cCurrentIPC;
            nextIPC = 0;
            weapons = new Weapon[6];
            controlledTerritories = new List<ITerritory>();
            occupiedTerritories = new List<ITerritory>();
        }

        private void calulateIPC()
        {
            int total = 0;
            foreach (var t in controlledTerritories)
            {
                if(t is LandTerritory)
                {
                    total += t.value;
                }
            }
            nextIPC = total;
        }
        public void addControlledTerritory(ITerritory territory)
        {
            controlledTerritories.Add(territory);
            calulateIPC();
        }
        public void removeControlledTerritory(ITerritory territory)
        {
            controlledTerritories.Remove(territory);
            calulateIPC();
        }
        public void addOccupiedTerritory(ITerritory territory)
        {
            occupiedTerritories.Add(territory);
        }
        public void removeOccupiedTerritory(ITerritory territory)
        {
            occupiedTerritories.Remove(territory);
        }
        
        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Country Name: {name}");
            sb.AppendLine($"Country Total IPC: {currentIPC}");
            sb.AppendLine($"Country Next IPC: {nextIPC}");
            sb.AppendLine("Controlled Territories: ");
            foreach (var t in controlledTerritories)
            {
                sb.Append($"{t.name}, ");
            }
            sb.Remove(sb.Length-2,2);
            sb.AppendLine();

            return sb.ToString();
        }
    }
}