using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;


namespace AxisAndAllies.Entities {
    public class Transport : Unit
    {
        public Transport(Country unitCountry) {
            name = "TRANSPORT";
            orginalCountry = unitCountry;
            type = UnitType.Naval;
            cost = 8;
            movement = 2;
            attackCapability = 0;
            defenseCapability = 1;
        }
    }
}