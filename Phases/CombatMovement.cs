using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AxisAndAllies.Phases
{
    public class CombatMovement : Phase
    {

        public CombatMovement(Country cCountry, List<ITerritory> terrs)
        {
            currentCountry = cCountry;
            territories = terrs;
        }

        public override void run()
        {

        }

    }
}