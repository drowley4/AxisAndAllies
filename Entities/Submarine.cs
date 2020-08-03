using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;

namespace AxisAndAllies.Entities {
    public class Submarine : Unit
    {
        public Submarine(Country unitCountry) {
            name = "SUBMARINE";
            orginalCountry = unitCountry;
            type = UnitType.Naval;
            cost = 8;
            movement = 2;
            attackCapability = 2;
            defenseCapability = 2;
        }
    }
}