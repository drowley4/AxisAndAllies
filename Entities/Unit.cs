using AxisAndAllies.Entities.Enums;
using AxisAndAllies.Entities;
using System;

namespace AxisAndAllies.Entities
{
  public abstract class Unit
  {
    public string name { get; set; }
    public Country orginalCountry { get; set; }
    public UnitType type { get; set; }
    public ITerritory territory { get; set; }
    public int cost { get; set; }
    public int movement { get; set; }
    public int attackCapability { get; set; }
    public int defenseCapability { get; set; }

    public int attack()
    {
      Random rand = new Random();
      if(rand.Next(1,7) <= attackCapability)
      {
        return 1;
      }
      return 0;
    }

    public int defend()
    {
      Random rand = new Random();
      if(rand.Next(1,7) <= defenseCapability)
      {
        return 1;
      }
      return 0;
    }
  }
}
