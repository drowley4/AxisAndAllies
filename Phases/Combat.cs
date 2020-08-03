using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AxisAndAllies.Phases
{
    public class Combat : Phase
    {
        public Dictionary<LandTerritory,Dictionary<Unit,int>> landBattles { get; set; }    
        public Dictionary<NavalTerritory,Dictionary<Unit,int>> navalBattles { get; set; }  

        public Combat(Country cCountry, List<ITerritory> terrs,Dictionary<LandTerritory, Dictionary<Unit, int>> lBattles,Dictionary<NavalTerritory, Dictionary<Unit, int>> nBattles)
        {
            currentCountry = cCountry;
            territories = terrs;
            landBattles = lBattles;
            navalBattles = navalBattles;
        }

        public override void run()
        {

        }

        public void performBattles()
        {
            TerritoryStatus status;
            Dictionary<Unit,int> au;
            Dictionary<Unit,int> du;
            foreach (var item in navalBattles)
            {
                au = new Dictionary<Unit, int>(item.Value);
                du = new Dictionary<Unit, int>(item.Key.armies);
                Console.WriteLine($"NAVAL TERRITORY BATTLE IN {item.Key.name}");
                Console.WriteLine($"{item.Key.status} vs ");
                status = navalBattle(ref au,ref du);
            }
        }

        public TerritoryStatus landBattle(ref Dictionary<Unit,int> attackingUnits,ref Dictionary<Unit,int> defendingUnits)
        {
            Dictionary<Unit,int> casualties = new Dictionary<Unit,int>();
            String attackString = armyToString(attackingUnits);
            String defendString = armyToString(defendingUnits);
            Console.WriteLine($"Attcking Units: \n{attackString}");
            Console.WriteLine($"Defending Units: \n{defendString}");
            int totalHits;
            String input;
            int inputCas;
            while(true)
            {
                casualties = new Dictionary<Unit, int>();
                totalHits = attackFires(attackingUnits);
                if(totalHits > 0)
                {
                    Console.WriteLine($"Defender Pick {totalHits} Casualties");
                    foreach (var item in defendingUnits)
                    {
                        Console.WriteLine($"# of {item.Key.name}: ");
                        input = Console.ReadLine();
                        while(!validateCasualtyInput(input,totalHits))
                        {
                            Console.WriteLine("Invalid Input");
                            Console.WriteLine($"# of {item.Key.name}: ");
                            input = Console.ReadLine();
                        }
                        inputCas = Int32.Parse(input);
                        totalHits = totalHits - inputCas;
                        casualties.Add(item.Key, inputCas);
                    }
                }
                else
                {
                    Console.WriteLine("Attacking Troops All Missed!");
                }
                Console.WriteLine("Defending Troops Now Counterattack");
                totalHits = defenseFires(defendingUnits);
                takeCasualties(ref defendingUnits,casualties);
                casualties = new Dictionary<Unit, int>();
                if(totalHits > 0)
                {
                    Console.WriteLine($"Attacker Pick {totalHits} Casualties");
                    foreach (var item in attackingUnits)
                    {
                        Console.WriteLine($"# of {item.Key.name}: ");
                        input = Console.ReadLine();
                        while(!validateCasualtyInput(input,totalHits))
                        {
                            Console.WriteLine("Invalid Input");
                            Console.WriteLine($"# of {item.Key.name}: ");
                            input = Console.ReadLine();
                        }
                        inputCas = Int32.Parse(input);
                        totalHits = totalHits - inputCas;
                        casualties.Add(item.Key, inputCas);
                    }
                }
                else
                {
                    Console.WriteLine("Defending Troops All Missed!");
                }
                takeCasualties(ref attackingUnits,casualties);
                attackString = armyToString(attackingUnits);
                defendString = armyToString(defendingUnits);
                Console.WriteLine($"Attcking Units: \n{attackString}");
                Console.WriteLine($"Defending Units: \n{defendString}");

                break;
            }
            return TerritoryStatus.UnitedStatesControlled;
        }

        public TerritoryStatus navalBattle(ref Dictionary<Unit,int> attackingUnits,ref Dictionary<Unit,int> defendingUnits)
        {
            return TerritoryStatus.UnitedStatesControlled;
        }


        private int attackFires(Dictionary<Unit,int> attackingUnits)
        {
            int totalHits = 0;
            foreach (var item in attackingUnits)
            {
                for(int i = 0; i < item.Value; i++)
                {
                    totalHits += item.Key.attack();
                }
            }
            return totalHits;
        }

        private int defenseFires(Dictionary<Unit,int> defendingUnits)
        {
            int totalHits = 0;
            foreach (var item in defendingUnits)
            {
                for(int i = 0; i < item.Value; i++)
                {
                    totalHits += item.Key.defend();
                }
            }
            return totalHits;
        }

        private string armyToString(Dictionary<Unit,int> army)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<Unit,int> item in army)
            {
                sb.AppendLine($"# of {item.Key.name}: {item.Value}");
            }
            return sb.ToString();
        }

        private bool validateCasualtyInput(string input, int hits)
        {
            int result;
            if(!Int32.TryParse(input, out result))
            {
                return false;
            }
            if(result > hits)
            {
                return false;
            }
            return true;
        }

        private void takeCasualties(ref Dictionary<Unit,int> army, Dictionary<Unit,int> casualties)
        {
            foreach (var item in casualties)
            {
                army[item.Key] = army[item.Key] - casualties[item.Key];
            }
        }
    }
}