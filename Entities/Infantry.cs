using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;

namespace AxisAndAllies.Entities {
    public class Infantry : Unit
    {
        public Infantry(Country unitCountry) {
            name = "INFANTRY";
            orginalCountry = unitCountry;
            type = UnitType.Land;
            cost = 3;
            movement = 1;
            attackCapability = 1;
            defenseCapability = 2;
        }
    }
}
