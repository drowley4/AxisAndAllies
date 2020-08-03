using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;

namespace AxisAndAllies.Entities {
    public class Infantry : Unit
    {
        public Infantry(Country unitCountry, ITerritory unitTerritory) {
            name = "INFANTRY";
            orginalCountry = unitCountry;
            type = UnitType.Land;
            territory = unitTerritory;
            cost = 3;
            movement = 1;
            attackCapability = 1;
            defenseCapability = 2;
        }
    }
}
