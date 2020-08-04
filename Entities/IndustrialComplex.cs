using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;

namespace AxisAndAllies.Entities {
    public class IndustrialComplex : Unit
    {
        public string currentCountryName { get; set; }
        public IndustrialComplex(Country unitCountry) {
            name = "INDUSTRIAL COMPLEX";
            orginalCountry = unitCountry;
            type = UnitType.Land;
            cost = 15;
            movement = 0;
            attackCapability = 0;
            defenseCapability = 0;
            currentCountryName = unitCountry.name;
        }
    }
}