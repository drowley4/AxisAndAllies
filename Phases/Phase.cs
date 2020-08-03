using AxisAndAllies.Entities;
using System.Collections.Generic;

namespace AxisAndAllies.Phases
{
    public abstract class Phase
    {
        public Country currentCountry { get; set; }
        public List<ITerritory> territories { get; set; }

        public abstract void run();

    }
}