using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;

namespace AxisAndAllies.Entities {
    public class Bomber : Unit
    {
        public Bomber(Country unitCountry, ITerritory unitTerritory) {
            name = "BOMBER";
            orginalCountry = unitCountry;
            type = UnitType.Air;
            territory = unitTerritory;
            cost = 15;
            movement = 6;
            attackCapability = 4;
            defenseCapability = 1;
        }
    }
}