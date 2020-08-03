using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;

namespace AxisAndAllies.Entities {
    public class Battleship : Unit
    {
        public Battleship(Country unitCountry, ITerritory unitTerritory) {
            name = "BATTLESHIP";
            orginalCountry = unitCountry;
            type = UnitType.Naval;
            territory = unitTerritory;
            cost = 24;
            movement = 2;
            attackCapability = 4;
            defenseCapability = 4;
        }
    }
}