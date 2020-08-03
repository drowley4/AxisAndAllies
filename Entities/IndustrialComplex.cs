using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;

namespace AxisAndAllies.Entities {
    public class IndustrialComplex : Unit
    {
        public string currentCountryName { get; set; }
        public IndustrialComplex(Country unitCountry, ITerritory unitTerritory) {
            name = "INDUSTRIAL COMPLEX";
            orginalCountry = unitCountry;
            type = UnitType.Land;
            territory = unitTerritory;
            cost = 15;
            movement = 0;
            attackCapability = 0;
            defenseCapability = 0;
            currentCountryName = unitCountry.name;
        }
    }
}