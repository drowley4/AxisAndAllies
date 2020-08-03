using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;

namespace AxisAndAllies.Entities {
    public class AnitAircraft : Unit
    {
        public string currentCountryName { get; set; }
        public AnitAircraft(Country unitCountry, ITerritory unitTerritory) {
            name = "ANTIAIRCRAFT";
            orginalCountry = unitCountry;
            type = UnitType.Land;
            territory = unitTerritory;
            cost = 5;
            movement = 1;
            attackCapability = 0;
            defenseCapability = 1;
            currentCountryName = unitCountry.name;
            
        }
    }
}