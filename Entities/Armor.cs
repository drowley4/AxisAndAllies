using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;

namespace AxisAndAllies.Entities {
    public class Armor : Unit
    {
        public Armor(Country unitCountry, ITerritory unitTerritory) {
            name = "ARMOR";
            orginalCountry = unitCountry;
            type = UnitType.Land;
            territory = unitTerritory;
            cost = 5;
            movement = 2;
            attackCapability = 3;
            defenseCapability = 2;
        }
    }
}