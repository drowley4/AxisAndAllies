using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AxisAndAllies.Phases
{
    public class PurchaseUnits : Phase
    {
        Dictionary<Unit,int> purchaseUnits { get; set; }

        public PurchaseUnits(Country cCountry, List<ITerritory> terrs)
        {
            currentCountry = cCountry;
            territories = terrs;
        }

        public override void run()
        {
            Console.WriteLine($"{currentCountry.name} Purchase Units With {currentCountry.currentIPC} I.P.C.");
            Console.WriteLine(displayUnits());
            selectUnits();

        }

        private string displayUnits()
        {
            string[] names = new string[10] {"INFANTRY          ","ARMOR             ","FIGHTER           ","BOMBER            ","ANTIAIRCRAFT      ","BATTLESHIP        ","AIRACRAFT CARRIER ","TRANSPORT         ","SUBMARINE         ","INDUSTRIAL COMPLEX"};
            string[] costs = new string[10] {"3 ","5 ","12","15","5 ","24","18","8 ","8 ","15"};
            string[] movement = new string[10] {"1","2","4","6","1","2","2","2","2","0"};
            string[] attack = new string[10] {"1","3","3","4","0","4","1","0","2","0"};
            string[] defense = new string[10] {"2","2","4","1","1","4","3","1","2","0"};
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name                Cost  Movement   Attack  Defense");
            for(int i = 0; i < 10; i++)
            {
                sb.AppendLine($"{names[i]}   {costs[i]}      {movement[i]}         {attack[i]}        {defense[i]}");
            }

            return sb.ToString();
        }

        private void selectUnits()
        {
            Unit[] units = new Unit[10] {new Infantry(currentCountry),new Armor(currentCountry),new Fighter(currentCountry),new Bomber(currentCountry),new AnitAircraft(currentCountry),new Battleship(currentCountry),new AircraftCarrier(currentCountry),new Transport(currentCountry),new Submarine(currentCountry),new IndustrialComplex(currentCountry)};
            do 
            {
                purchaseUnits = new Dictionary<Unit, int>();
                string input;
                foreach (var item in units)
                {
                    Console.Write($"# of {item.name}: ");
                    input = Console.ReadLine();
                    while(!validateInput(input))
                    {
                        Console.WriteLine("Invalid Input");
                        Console.Write($"# of {item.name}: ");
                        input = Console.ReadLine();
                    }
                    purchaseUnits.Add(item, Int32.Parse(input));

                }
            }while(!checkTotal());
        }

        private bool checkTotal()
        {
            int total = 0;
            foreach (var item in purchaseUnits)
            {
                total = total + (item.Key.cost*item.Value);
            }
            if(total > currentCountry.currentIPC)
            {
                Console.WriteLine($"Can only spend {currentCountry.currentIPC}, tried to spend {total}");
                return false;
            }
            return true;
        }

        private bool validateInput(string input)
        {
            int result;
            if(!Int32.TryParse(input, out result))
            {
                return false;
            }
            return true;
        }
    }
}