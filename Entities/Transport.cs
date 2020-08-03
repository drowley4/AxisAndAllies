using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;


namespace AxisAndAllies.Entities {
    public class Transport : Unit
    {
        public Transport(Country unitCountry, ITerritory unitTerritory) {
            name = "TRANSPORT";
            orginalCountry = unitCountry;
            type = UnitType.Naval;
            territory = unitTerritory;
            cost = 8;
            movement = 2;
            attackCapability = 0;
            defenseCapability = 1;
        }
    }
}