using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;


namespace AxisAndAllies.Entities {
    public class AircraftCarrier : Unit
    {
        public AircraftCarrier(Country unitCountry) {
            name = "AIRCRAFT CARRIER";
            orginalCountry = unitCountry;
            type = UnitType.Naval;
            cost = 18;
            movement = 2;
            attackCapability = 1;
            defenseCapability = 3;
        }
    }
}