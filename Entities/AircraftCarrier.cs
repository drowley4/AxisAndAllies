using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;


namespace AxisAndAllies.Entities {
    public class AircraftCarrier : Unit
    {
        public AircraftCarrier(Country unitCountry, ITerritory unitTerritory) {
            name = "AIRCRAFT CARRIER";
            orginalCountry = unitCountry;
            type = UnitType.Naval;
            territory = unitTerritory;
            cost = 18;
            movement = 2;
            attackCapability = 1;
            defenseCapability = 3;
        }
    }
}