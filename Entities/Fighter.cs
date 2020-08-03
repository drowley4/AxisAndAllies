using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;

namespace AxisAndAllies.Entities {
    public class Fighter : Unit
    {
        public Fighter(Country unitCountry) {
            name = "FIGHTER";
            orginalCountry = unitCountry;
            type = UnitType.Air;
            cost = 12;
            movement = 4;
            attackCapability = 3;
            defenseCapability = 4;
        }
    }
}