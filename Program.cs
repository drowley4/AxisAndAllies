using System;
using System.Collections.Generic;
using AxisAndAllies.Entities;
using AxisAndAllies.Entities.Enums;
using AxisAndAllies.Phases;

namespace AxisAndAllies
{
    class Program
    {
        static List<Country> countries;
        static List<ITerritory> territories;
        static void Main(string[] args)
        {
            countries = new List<Country>();
            territories = new List<ITerritory>();
            setupTerritories();
            setupCountries();
            setupUnits();
            Phase cPhase;
            cPhase = new PurchaseUnits(countries[0],territories);
            cPhase.run();
        }


        static void setupUnits()
        {
            Dictionary<string,List<(Unit,int)>> ussrUnits = new Dictionary<string, List<(Unit, int)>>() {{"CAUCASUS",new List<(Unit, int)>(){(new Infantry(countries[0],findTerritory("CAUCASUS")),5)}},{"KARELIA S.S.R.",new List<(Unit, int)>(){(new Infantry(countries[0],findTerritory("KARELIA S.S.R.")),3),(new Armor(countries[0],findTerritory("KARELIA S.S.R.")),1),(new Fighter(countries[0],findTerritory("KARELIA S.S.R.")),1),(new AnitAircraft(countries[0],findTerritory("KARELIA S.S.R.")),1),(new IndustrialComplex(countries[0],findTerritory("KARELIA S.S.R.")),1)}},{"EVENKINATLOKRUG",new List<(Unit, int)>(){(new Infantry(countries[0],findTerritory("EVENKINATLOKRUG")),2)}},{"RUSSIA",new List<(Unit, int)>(){(new Infantry(countries[0],findTerritory("RUSSIA")),4),(new Armor(countries[0],findTerritory("RUSSIA")),2),(new Fighter(countries[0],findTerritory("RUSSIA")),1),(new AnitAircraft(countries[0],findTerritory("RUSSIA")),1),(new IndustrialComplex(countries[0],findTerritory("RUSSIA")),1)}},{"YAKUT S.S.R.",new List<(Unit, int)>(){(new Infantry(countries[0],findTerritory("YAKUT S.S.R.")),3)}},{"KARELIA COAST",new List<(Unit, int)>(){(new Transport(countries[0],findTerritory("KARELIA COAST")),1),(new Submarine(countries[0],findTerritory("KARELIA COAST")),1)}},{"SOVIET FAR EAST",new List<(Unit, int)>(){(new Infantry(countries[0],findTerritory("SOVIET FAR EAST")),2),(new Armor(countries[0],findTerritory("SOVIET FAR EAST")),1)}}};
            foreach (var item in ussrUnits)
            {
                foreach (var tup in item.Value)
                {
                    ITerritory t = findTerritory(item.Key);

                    t.addArmy(tup.Item1,tup.Item2);
                    countries[0].addOccupiedTerritory(findTerritory(item.Key));
                }
            }
            Dictionary<string,List<(Unit,int)>> germanyUnits = new Dictionary<string, List<(Unit, int)>>() {{"ALGERIA",new List<(Unit, int)>(){(new Infantry(countries[1],findTerritory("ALGERIA")),1)}},{"LIBYA",new List<(Unit, int)>(){(new Infantry(countries[1],findTerritory("LIBYA")),1),(new Armor(countries[1],findTerritory("LIBYA")),1)}},{"WESTERN EUROPE",new List<(Unit, int)>(){(new Infantry(countries[1],findTerritory("WESTERN EUROPE")),2),(new Armor(countries[1],findTerritory("WESTERN EUROPE")),2),(new Fighter(countries[1],findTerritory("WESTERN EUROPE")),1),(new AnitAircraft(countries[1],findTerritory("WESTERN EUROPE")),1),(new IndustrialComplex(countries[1],findTerritory("WESTERN EUROPE")),1)}},{"GERMANY",new List<(Unit, int)>(){(new Infantry(countries[1],findTerritory("GERMANY")),4),(new Armor(countries[1],findTerritory("GERMANY")),2),(new Fighter(countries[1],findTerritory("GERMANY")),1),(new Bomber(countries[1],findTerritory("GERMANY")),1),(new AnitAircraft(countries[1],findTerritory("GERMANY")),1),(new IndustrialComplex(countries[1],findTerritory("GERMANY")),1)}},{"SOUTHERN EUROPE",new List<(Unit, int)>(){(new Infantry(countries[1],findTerritory("SOUTHERN EUROPE")),2),(new Armor(countries[1],findTerritory("SOUTHERN EUROPE")),1),(new AnitAircraft(countries[1],findTerritory("SOUTHERN EUROPE")),1),(new IndustrialComplex(countries[1],findTerritory("SOUTHERN EUROPE")),1)}},{"EASTERN EUROPE",new List<(Unit, int)>(){(new Infantry(countries[1],findTerritory("EASTERN EUROPE")),3),(new Armor(countries[1],findTerritory("EASTERN EUROPE")),1),(new Fighter(countries[1],findTerritory("EASTERN EUROPE")),1)}},{"UKRAINE",new List<(Unit, int)>(){(new Infantry(countries[1],findTerritory("UKRAINE")),3),(new Armor(countries[1],findTerritory("UKRAINE")),2),(new Fighter(countries[1],findTerritory("UKRAINE")),1)}},{"FINLAND NORWAY",new List<(Unit, int)>(){(new Infantry(countries[1],findTerritory("FINLAND NORWAY")),3),(new Armor(countries[1],findTerritory("FINLAND NORWAY")),1),(new Fighter(countries[1],findTerritory("FINLAND NORWAY")),1)}},{"SWEDEN COAST",new List<(Unit, int)>(){(new Transport(countries[1],findTerritory("SWEDEN COAST")),1),(new Submarine(countries[1],findTerritory("SWEDEN COAST")),1)}},{"NORTHEAST ALANTIC",new List<(Unit, int)>(){(new Submarine(countries[1],findTerritory("NORTHEAST ALANTIC")),1)}},{"ROME COAST",new List<(Unit, int)>(){(new Transport(countries[1],findTerritory("ROME COAST")),1),(new Battleship(countries[1],findTerritory("ROME COAST")),1)}}};
            foreach (var item in germanyUnits)
            {
                foreach (var tup in item.Value)
                {
                    ITerritory t = findTerritory(item.Key);

                    t.addArmy(tup.Item1,tup.Item2);
                    countries[1].addOccupiedTerritory(findTerritory(item.Key));
                }
            }
            Dictionary<string,List<(Unit,int)>> ukUnits = new Dictionary<string, List<(Unit, int)>>() {{"AUSTRALIA",new List<(Unit, int)>(){(new Infantry(countries[2],findTerritory("AUSTRALIA")),2)}},{"SYRIA-IRAQ",new List<(Unit, int)>(){(new Infantry(countries[2],findTerritory("SYRIA-IRAQ")),1)}},{"UNION OF SOUTH AFRICA",new List<(Unit, int)>(){(new Infantry(countries[2],findTerritory("UNION OF SOUTH AFRICA")),1)}},{"ANGLO-EGYPT SUDAN",new List<(Unit, int)>(){(new Infantry(countries[2],findTerritory("ANGLO-EGYPT SUDAN")),1),(new Armor(countries[2],findTerritory("ANGLO-EGYPT SUDAN")),1)}},{"WESTERN CANADA",new List<(Unit, int)>(){(new Infantry(countries[2],findTerritory("WESTERN CANADA")),1)}},{"EASTERN CANADA",new List<(Unit, int)>(){(new Armor(countries[2],findTerritory("EASTERN CANADA")),1)}},{"INDIA",new List<(Unit, int)>(){(new Infantry(countries[2],findTerritory("INDIA")),2),(new Fighter(countries[2],findTerritory("INDIA")),1)}},{"UNITED KINGDOM",new List<(Unit, int)>(){(new Infantry(countries[2],findTerritory("UNITED KINGDOM")),2),(new Armor(countries[2],findTerritory("UNITED KINGDOM")),1),(new Fighter(countries[2],findTerritory("UNITED KINGDOM")),2),(new Bomber(countries[2],findTerritory("UNITED KINGDOM")),1),(new AnitAircraft(countries[2],findTerritory("UNITED KINGDOM")),1),(new IndustrialComplex(countries[2],findTerritory("UNITED KINGDOM")),1)}},{"UNITED KINGDOM COAST",new List<(Unit, int)>(){(new Transport(countries[2],findTerritory("UNITED KINGDOM COAST")),1),(new Battleship(countries[2],findTerritory("UNITED KINGDOM COAST")),1)}},{"EASTERN CANADA COAST",new List<(Unit, int)>(){(new Transport(countries[2],findTerritory("EASTERN CANADA COAST")),1)}},{"INDIAN OCEAN",new List<(Unit, int)>(){(new Transport(countries[2],findTerritory("INDIAN OCEAN")),1)}},{"GIBRALTAR COAST",new List<(Unit, int)>(){(new Battleship(countries[2],findTerritory("GIBRALTAR COAST")),1)}},{"SUEZ CANAL NORTH",new List<(Unit, int)>(){(new Submarine(countries[2],findTerritory("SUEZ CANAL NORTH")),1)}}};
            foreach (var item in ukUnits)
            {
                foreach (var tup in item.Value)
                {
                    ITerritory t = findTerritory(item.Key);

                    t.addArmy(tup.Item1,tup.Item2);
                    countries[2].addOccupiedTerritory(findTerritory(item.Key));
                }
            }
            Dictionary<string,List<(Unit,int)>> japanUnits = new Dictionary<string, List<(Unit, int)>>() {{"KWANGTUNG",new List<(Unit, int)>(){(new Infantry(countries[3],findTerritory("KWANGTUNG")),2)}},{"PHILIPPINE ISLANDS",new List<(Unit, int)>(){(new Infantry(countries[3],findTerritory("PHILIPPINE ISLANDS")),2),(new Fighter(countries[3],findTerritory("PHILIPPINE ISLANDS")),1)}},{"OKINAWA",new List<(Unit, int)>(){(new Infantry(countries[3],findTerritory("OKINAWA")),1)}},{"WAKE ISLAND",new List<(Unit, int)>(){(new Infantry(countries[3],findTerritory("WAKE ISLAND")),1)}},{"CAROLINE ISLANDS",new List<(Unit, int)>(){(new Infantry(countries[3],findTerritory("CAROLINE ISLANDS")),1)}},{"SOLOMON ISLANDS",new List<(Unit, int)>(){(new Infantry(countries[3],findTerritory("SOLOMON ISLANDS")),1)}},{"NEW GUINEA",new List<(Unit, int)>(){(new Infantry(countries[3],findTerritory("NEW GUINEA")),1)}},{"BORNEO CELEBES",new List<(Unit, int)>(){(new Infantry(countries[3],findTerritory("BORNEO CELEBES")),1)}},{"EAST INDIES",new List<(Unit, int)>(){(new Infantry(countries[3],findTerritory("EAST INDIES")),1)}},{"FRENCH INDO-CHINA BURMA",new List<(Unit, int)>(){(new Infantry(countries[3],findTerritory("FRENCH INDO-CHINA BURMA")),2),(new Fighter(countries[3],findTerritory("FRENCH INDO-CHINA BURMA")),1)}},{"MANCHURIA",new List<(Unit, int)>(){(new Infantry(countries[3],findTerritory("MANCHURIA")),3),(new Fighter(countries[3],findTerritory("MANCHURIA")),1)}},{"JAPAN",new List<(Unit, int)>(){(new Infantry(countries[3],findTerritory("JAPAN")),3),(new Armor(countries[3],findTerritory("JAPAN")),1),(new Fighter(countries[3],findTerritory("JAPAN")),1),(new Bomber(countries[3],findTerritory("JAPAN")),1),(new AnitAircraft(countries[3],findTerritory("JAPAN")),1),(new IndustrialComplex(countries[3],findTerritory("JAPAN")),1)}},{"JAPAN COAST",new List<(Unit, int)>(){(new Transport(countries[3],findTerritory("JAPAN COAST")),1),(new Battleship(countries[3],findTerritory("JAPAN COAST")),1)}},{"PHILIPPINE ISLANDS COAST",new List<(Unit, int)>(){(new Transport(countries[3],findTerritory("PHILIPPINE ISLANDS COAST")),1)}},{"SOLOMON ISLANDS COAST",new List<(Unit, int)>(){(new Submarine(countries[3],findTerritory("SOLOMON ISLANDS COAST")),1)}},{"CAROLINE ISLANDS COAST",new List<(Unit, int)>(){(new Battleship(countries[3],findTerritory("CAROLINE ISLANDS COAST")),1),(new AircraftCarrier(countries[3],findTerritory("CAROLINE ISLANDS COAST")),1),(new Fighter(countries[3],findTerritory("CAROLINE ISLANDS COAST")),1)}}};
            foreach (var item in japanUnits) 
            {
                foreach (var tup in item.Value)
                {
                    ITerritory t = findTerritory(item.Key);

                    t.addArmy(tup.Item1,tup.Item2);
                    countries[3].addOccupiedTerritory(findTerritory(item.Key));
                }
            }
            Dictionary<string,List<(Unit,int)>> usUnits = new Dictionary<string, List<(Unit, int)>>() {{"ALASKA",new List<(Unit, int)>(){(new Infantry(countries[4],findTerritory("ALASKA")),1)}},{"MIDWAY ISLAND",new List<(Unit, int)>(){(new Infantry(countries[4],findTerritory("MIDWAY ISLAND")),1)}},{"HAWAIIAN ISLANDS",new List<(Unit, int)>(){(new Infantry(countries[4],findTerritory("HAWAIIAN ISLANDS")),1)}},{"SINKIANG",new List<(Unit, int)>(){(new Infantry(countries[4],findTerritory("SINKIANG")),2)}},{"CHINA",new List<(Unit, int)>(){(new Infantry(countries[4],findTerritory("CHINA")),2),(new Fighter(countries[4],findTerritory("CHINA")),1)}},{"WESTERN U.S.A.",new List<(Unit, int)>(){(new Infantry(countries[4],findTerritory("WESTERN U.S.A.")),2),(new Fighter(countries[4],findTerritory("WESTERN U.S.A.")),1),(new AnitAircraft(countries[4],findTerritory("WESTERN U.S.A.")),1),(new IndustrialComplex(countries[4],findTerritory("WESTERN U.S.A.")),1)}},{"EASTERN U.S.A.",new List<(Unit, int)>(){(new Infantry(countries[4],findTerritory("EASTERN U.S.A.")),2),(new Armor(countries[4],findTerritory("EASTERN U.S.A.")),1),(new Fighter(countries[4],findTerritory("EASTERN U.S.A.")),1),(new Bomber(countries[4],findTerritory("EASTERN U.S.A.")),1),(new AnitAircraft(countries[4],findTerritory("EASTERN U.S.A.")),1),(new IndustrialComplex(countries[4],findTerritory("EASTERN U.S.A.")),1)}},{"EASTERN U.S.A. COAST",new List<(Unit, int)>(){(new Transport(countries[4],findTerritory("EASTERN U.S.A. COAST")),1)}},{"WESTERN U.S.A. COAST",new List<(Unit, int)>(){(new Transport(countries[4],findTerritory("WESTERN U.S.A. COAST")),1),(new Battleship(countries[4],findTerritory("WESTERN U.S.A. COAST")),1)}},{"HAWAIIAN ISLANDS COAST",new List<(Unit, int)>(){(new Battleship(countries[4],findTerritory("HAWAIIAN ISLANDS")),1),(new AircraftCarrier(countries[4],findTerritory("HAWAIIAN ISLANDS")),1),(new Fighter(countries[4],findTerritory("HAWAIIAN ISLANDS")),1)}}};
            foreach (var item in usUnits) 
            {
                foreach (var tup in item.Value)
                {
                    ITerritory t = findTerritory(item.Key);

                    t.addArmy(tup.Item1,tup.Item2);
                    countries[4].addOccupiedTerritory(findTerritory(item.Key));
                }
            }
        }

        static void setupCountries()
        {
            string[] names = new string[5] {"U.S.S.R.","GERMANY","UNITED KINGDOM","JAPAN","UNITED STATES"};
            int[] ipc = new int[] {24,32,30,25,36};
            Country country;
            for(int i = 0; i < 5; i++) 
            {
                country = new Country(names[i], ipc[i], ipc[i]);
                countries.Add(country);
            }
            foreach (var t in territories)
            {
                switch (t.status)
                {
                    case TerritoryStatus.USSRControlled:
                        countries[0].addControlledTerritory(t);
                        break;
                    case TerritoryStatus.GermanyControlled:
                        countries[1].addControlledTerritory(t);
                        break;
                    case TerritoryStatus.UnitedKingdomControlled:
                        countries[2].addControlledTerritory(t);
                        break;
                    case TerritoryStatus.JapanControlled:
                        countries[3].addControlledTerritory(t);
                        break;
                    case TerritoryStatus.UnitedStatesControlled:
                        countries[4].addControlledTerritory(t);
                        break;
                }
            }
        } 

        static void setupTerritories()
        {
            string[] landNames = new string[70] {"AFGHAN","ALASKA","ALGERIA","ANGLO-EGYPT SUDAN","ANGOLA","ARGENTINA CHILI","AUSTRALIA","BELGIAN CONGO","BORNEO CELEBES","BRAZIL","CAROLINE ISLANDS","CAUCASUS","CHINA","EASTERN CANADA","EASTERN EUROPE","EASTERN U.S.A.","EAST INDIES","EIRE","EVENKINATLOKRUG","FINLAND NORWAY","FRENCH EQUATORIAL AFRICA","FRENCH INDO-CHINA BURMA","FRENCH MADAGASCAR","FRENCH WEST AFRICA","GERMANY","GIBRALTAR","HAWAIIAN ISLANDS","INDIA","ITALIAN EAST AFRICA","JAPAN","KARELIA S.S.R.","KAZAKH S.S.R.","KENYA RHODESIA","KWANGTUNG","LIBYA","MANCHURIA","MEXICO","MIDWAY ISLAND","MONGOLIA","MOZAMBIQUE","NEW GUINEA","NEW ZEALAND","NOVOSIBIRSK","OKINAWA","PANAMA","PERSIA","PERU","PHILIPPINE ISLANDS","RIO DE ORO","RUSSIA","SAUDI ARABIA","SINKIANG","SOLOMON ISLANDS","SOUTHERN EUROPE","SOVIET FAR EAST","SPAIN","SWEDEN","SWITZ","SYRIA-IRAQ","TURKEY","UKRAINE","UNION OF SOUTH AFRICA","UNITED KINGDOM","VENEZUELA COLUMBIA","WAKE ISLAND","WESTERN CANADA","WESTERN EUROPE","WESTERN U.S.A.","WEST INDIES","YAKUT S.S.R."};
            int[] landValues = new int[70] {0,2,1,2,0,0,2,1,1,3,0,3,2,3,3,12,2,0,2,2,1,3,1,1,10,0,1,3,1,8,3,2,1,3,1,3,2,0,0,0,1,1,2,1,1,1,0,3,0,8,0,2,0,6,2,0,0,0,1,0,3,2,8,0,0,1,6,10,1,2};
            TerritoryStatus[] landStatus = new TerritoryStatus[70] {TerritoryStatus.Neutral,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.GermanyControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.JapanControlled,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.JapanControlled,TerritoryStatus.USSRControlled,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.GermanyControlled,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.JapanControlled,TerritoryStatus.Neutral,TerritoryStatus.USSRControlled,TerritoryStatus.GermanyControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.JapanControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.GermanyControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.JapanControlled,TerritoryStatus.USSRControlled,TerritoryStatus.USSRControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.JapanControlled,TerritoryStatus.GermanyControlled,TerritoryStatus.JapanControlled,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.JapanControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.USSRControlled,TerritoryStatus.JapanControlled,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.Neutral,TerritoryStatus.JapanControlled,TerritoryStatus.Neutral,TerritoryStatus.USSRControlled,TerritoryStatus.Neutral,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.JapanControlled,TerritoryStatus.GermanyControlled,TerritoryStatus.USSRControlled,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.Neutral,TerritoryStatus.GermanyControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.Neutral,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.GermanyControlled,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.USSRControlled};
            bool[] landCapitals = new bool[70] {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false};
            landCapitals[15] = true;
            landCapitals[24] = true;
            landCapitals[29] = true;
            landCapitals[49] = true;
            landCapitals[62] = true;
            ITerritory terr;
            for(int i = 0; i < 70; i++)
            {
                terr = new LandTerritory(landNames[i],landValues[i],landCapitals[i],landStatus[i]);
                territories.Add(terr);
            }

            string[] navalNames = new string[57] {"ALASKA COAST","ANGOLA COAST","ARGENTINA EAST COAST","ARGENTINA SOUTH COAST","AUSTRALIA EAST COAST","AUSTRALIA SOUTH COAST","AUSTRALIA WEST COAST","CASPIAN SEA","BORNEO CELEBES COAST","BRAZIL NORTH COAST","CAROLINE ISLANDS COAST","EASTERN CANADA COAST","EASTERN U.S.A. COAST","EAST INDIES COAST","GIBRALTAR COAST","HAWAIIAN ISLANDS COAST","INDIAN OCEAN","INDO-CHINA COAST","JAPAN COAST","KARELIA COAST","KWANGTUNG COAST","MADAGASCAR EAST COAST","MADAGASCAR SOUTHEAST COAST","MEXICO COAST","MOZAMBIQUE COAST","NEW GUINEA COAST","NEW ZEALAND COAST","NORTHEAST ALANTIC","NORTHEAST PACIFIC","NORTHWEST PACIFIC","NORTHWEST ALANTIC","OKINAWA COAST","PANAMA EAST COAST","PANAMA WEST COAST","PERU COAST","PHILIPPINE ISLANDS COAST","RIO DE ORO COAST","ROME COAST","SOLOMON ISLANDS COAST","SOUTHEAST AFRICA COAST","SOUTHEAST ALANTIC","SOUTHEAST INDIAN OCEAN","SOUTHEAST PACIFIC","SOUTH PACIFIC","SOUTH SOUTH ALANTIC","SOUTH SOUTH INDIAN OCEAN","SOUTH SOUTH SOUTH ALANTIC","SOUTHWEST ALANTIC","SOVIET FAR EAST COAST","SUEZ CANAL NORTH","SUEZ CANAL SOUTH","SWEDEN COAST","UKRAINE COAST","UNITED KINGDOM COAST","WAKE ISLAND COAST","WESTERN CANADA COAST","WESTERN U.S.A. COAST"};
            TerritoryStatus[] navalStatus = new TerritoryStatus[57] {TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.JapanControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.Neutral,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.UnitedStatesControlled,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.Neutral,TerritoryStatus.JapanControlled,TerritoryStatus.USSRControlled,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.GermanyControlled,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.JapanControlled,TerritoryStatus.Neutral,TerritoryStatus.GermanyControlled,TerritoryStatus.JapanControlled,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.GermanyControlled,TerritoryStatus.Neutral,TerritoryStatus.UnitedKingdomControlled,TerritoryStatus.Neutral,TerritoryStatus.Neutral,TerritoryStatus.UnitedStatesControlled};
            for(int i = 0; i < 57; i++)
            {
                terr = new NavalTerritory(navalNames[i],navalStatus[i]);
                territories.Add(terr);
            }
            addAdjacentTerritories();
        }

        static void addAdjacentTerritories()
        {
            List<List<string>> adjacentLists = new List<List<string>>() { new List<string>(){"SINKIANG","INDIA","PERSIA","KAZAKH S.S.R."},new List<string>(){"WESTERN CANADA","ALASKA COAST","WESTERN CANADA COAST"},new List<string>(){"LIBYA","FRENCH EQUATORIAL AFRICA","NORTHEAST ALANTIC","GIBRALTAR COAST","FRENCH WEST AFRICA"},new List<string>(){"LIBYA","FRENCH EQUATORIAL AFRICA","BELGIAN CONGO","KENYA RHODESIA","ITALIAN EAST AFRICA","SUEZ CANAL SOUTH","SUEZ CANAL NORTH","SYRIA-IRAQ"},new List<string>(){"ANGOLA COAST","UNION OF SOUTH AFRICA","KENYA RHODESIA","BELGIAN CONGO"},new List<string>(){"BRAZIL","PERU","ARGENTINA SOUTH COAST","ARGENTINA EAST COAST","PERU COAST"},new List<string>(){"AUSTRALIA EAST COAST","AUSTRALIA WEST COAST","AUSTRALIA SOUTH COAST"},new List<string>(){"SOUTHEAST ALANTIC","ANGOLA","KENYA RHODESIA","ANGLO-EGYPT SUDAN","FRENCH EQUATORIAL AFRICA"},new List<string>(){"BORNEO CELEBES COAST"},new List<string>(){"SOUTHWEST ALANTIC","BRAZIL NORTH COAST","PERU","VENEZUELA COLUMBIA","ARGENTINA CHILI"},new List<string>(){"CAROLINE ISLANDS COAST"},new List<string>(){"CASPIAN SEA","UKRAINE COAST","UKRAINE","RUSSIA","KARELIA S.S.R.","TURKEY","PERSIA"},new List<string>(){"SINKIANG","FRENCH INDO-CHINA BURMA","KWANGTUNG","MANCHURIA","MONGOLIA"},new List<string>(){"WESTERN CANADA","EASTERN U.S.A.","EASTERN CANADA COAST"},new List<string>(){"UKRAINE","KARELIA S.S.R.","GERMANY","SOUTHERN EUROPE","SWEDEN COAST","UKRAINE COAST"},new List<string>(){"EASTERN U.S.A. COAST","WESTERN U.S.A.","EASTERN CANADA"},new List<string>(){"EAST INDIES COAST"},new List<string>(){"UNITED KINGDOM COAST"},new List<string>(){"RUSSIA","YAKUT S.S.R.","NOVOSIBIRSK"},new List<string>(){"SWEDEN","SWEDEN COAST","KARELIA S.S.R.","UNITED KINGDOM COAST"},new List<string>(){"FRENCH WEST AFRICA","ALGERIA","LIBYA","ANGLO-EGYPT SUDAN","BELGIAN CONGO","SOUTHEAST ALANTIC"},new List<string>(){"KWANGTUNG","CHINA","SINKIANG","INDIA","INDO-CHINA COAST"},new List<string>(){"MADAGASCAR EAST COAST","MADAGASCAR SOUTHEAST COAST","MOZAMBIQUE COAST","SOUTHEAST AFRICA COAST"},new List<string>(){"ALGERIA","FRENCH EQUATORIAL AFRICA","RIO DE ORO","RIO DE ORO COAST"},new List<string>(){"WESTERN EUROPE","SWITZ","SOUTHERN EUROPE","EASTERN EUROPE","SWEDEN COAST"},new List<string>(){"GIBRALTAR COAST","SPAIN"},new List<string>(){"HAWAIIAN ISLANDS COAST"},new List<string>(){"INDIAN OCEAN","FRENCH INDO-CHINA BURMA","SINKIANG","AFGHAN","PERSIA"},new List<string>(){"SUEZ CANAL SOUTH","ANGLO-EGYPT SUDAN","KENYA RHODESIA"},new List<string>(){"JAPAN COAST"},new List<string>(){"KARELIA COAST","FINLAND NORWAY","SWEDEN COAST","EASTERN EUROPE","UKRAINE","CAUCASUS","RUSSIA"},new List<string>(){"CASPIAN SEA","PERSIA","AFGHAN","SINKIANG","NOVOSIBIRSK","RUSSIA"},new List<string>(){"UNION OF SOUTH AFRICA","MOZAMBIQUE","ANGOLA","BELGIAN CONGO","ANGLO-EGYPT SUDAN","ITALIAN EAST AFRICA","MOZAMBIQUE COAST"},new List<string>(){"FRENCH INDO-CHINA BURMA","CHINA","MANCHURIA","KWANGTUNG COAST"},new List<string>(){"ALGERIA","ROME COAST","FRENCH EQUATORIAL AFRICA","ANGLO-EGYPT SUDAN"},new List<string>(){"JAPAN COAST","SOVIET FAR EAST","YAKUT S.S.R.","MONGOLIA","CHINA","KWANGTUNG"},new List<string>(){"WESTERN U.S.A.","PANAMA","MEXICO COAST","PANAMA EAST COAST","EASTERN U.S.A. COAST"},new List<string>(){"NORTHEAST PACIFIC"},new List<string>(){"CHINA","SINKIANG","NOVOSIBIRSK","YAKUT S.S.R.","MANCHURIA"},new List<string>(){"MOZAMBIQUE COAST","UNION OF SOUTH AFRICA","KENYA RHODESIA"},new List<string>(){"NEW GUINEA COAST"},new List<string>(){"NEW ZEALAND COAST"},new List<string>(){"RUSSIA","EVENKINATLOKRUG","YAKUT S.S.R.","MONGOLIA","SINKIANG","KAZAKH S.S.R."},new List<string>(){"OKINAWA COAST"},new List<string>(){"MEXICO","VENEZUELA COLUMBIA","PANAMA EAST COAST","PANAMA WEST COAST"},new List<string>(){"CASPIAN SEA","SUEZ CANAL SOUTH","TURKEY","SYRIA-IRAQ","SAUDI ARABIA","INDIA","AFGHAN","KAZAKH S.S.R.","CAUCASUS"},new List<string>(){"PERU COAST","BRAZIL","VENEZUELA COLUMBIA","ARGENTINA CHILI"},new List<string>(){"PHILIPPINE ISLANDS COAST"},new List<string>(){"RIO DE ORO COAST","FRENCH WEST AFRICA"},new List<string>(){"KARELIA S.S.R.","CAUCASUS","CASPIAN SEA","KAZAKH S.S.R.","NOVOSIBIRSK","EVENKINATLOKRUG"},new List<string>(){"SUEZ CANAL SOUTH","PERSIA","SYRIA-IRAQ"},new List<string>(){"CHINA","MONGOLIA","NOVOSIBIRSK","KAZAKH S.S.R.","AFGHAN","INDIA","FRENCH INDO-CHINA BURMA"},new List<string>(){"SOLOMON ISLANDS COAST"},new List<string>(){"ROME COAST","SWITZ","WESTERN EUROPE","GERMANY","EASTERN EUROPE"},new List<string>(){"SOVIET FAR EAST COAST","YAKUT S.S.R.","MANCHURIA"},new List<string>(){"GIBRALTAR","GIBRALTAR COAST","NORTHEAST ALANTIC","WESTERN EUROPE"},new List<string>(){"FINLAND NORWAY","SWEDEN COAST"},new List<string>(){"GERMANY","SOUTHERN EUROPE","WESTERN EUROPE"},new List<string>(){"TURKEY","PERSIA","SAUDI ARABIA","SUEZ CANAL SOUTH","SUEZ CANAL NORTH","ANGLO-EGYPT SUDAN"},new List<string>(){"UKRAINE COAST","SUEZ CANAL NORTH","CAUCASUS","PERSIA","SYRIA-IRAQ"},new List<string>(){"UKRAINE COAST","CAUCASUS","EASTERN EUROPE","KARELIA S.S.R."},new List<string>(){"ANGOLA","KENYA RHODESIA","MOZAMBIQUE","ANGOLA COAST","SOUTHEAST AFRICA COAST","MOZAMBIQUE COAST"},new List<string>(){"UNITED KINGDOM COAST"},new List<string>(){"PANAMA","BRAZIL","PERU","PANAMA EAST COAST","MEXICO COAST"},new List<string>(){"WAKE ISLAND COAST"},new List<string>(){"WESTERN CANADA COAST","EASTERN CANADA","ALASKA","WESTERN U.S.A.","WESTERN U.S.A. COAST"},new List<string>(){"NORTHEAST ALANTIC","UNITED KINGDOM COAST","SWITZ","GERMANY","SOUTHERN EUROPE","SPAIN","SWEDEN COAST","GIBRALTAR COAST"},new List<string>(){"WESTERN U.S.A. COAST","WESTERN CANADA","EASTERN U.S.A.","MEXICO","PANAMA EAST COAST","EASTERN U.S.A. COAST"},new List<string>(){"PANAMA EAST COAST"},new List<string>(){"SOVIET FAR EAST","MANCHURIA","MONGOLIA","NOVOSIBIRSK","EVENKINATLOKRUG"},new List<string>()
            {"ALASKA","SOVIET FAR EAST COAST","NORTHEAST PACIFIC","NORTHWEST PACIFIC"},new List<string>(){"ANGOLA","UNION OF SOUTH AFRICA","SOUTHEAST AFRICA COAST","SOUTHEAST ALANTIC","SOUTH SOUTH ALANTIC","SOUTH SOUTH SOUTH ALANTIC"},new List<string>(){"ARGENTINA CHILI","SOUTHWEST ALANTIC","ARGENTINA SOUTH COAST","SOUTH SOUTH ALANTIC"},new List<string>(){"ARGENTINA CHILI","ARGENTINA EAST COAST","PERU COAST","SOUTH SOUTH ALANTIC","SOUTH SOUTH SOUTH ALANTIC"},new List<string>(){"AUSTRALIA","AUSTRALIA SOUTH COAST","AUSTRALIA WEST COAST","NEW ZEALAND COAST","SOLOMON ISLANDS COAST","NEW GUINEA COAST","BORNEO CELEBES COAST","EAST INDIES COAST"},new List<string>(){"AUSTRALIA","AUSTRALIA EAST COAST","AUSTRALIA WEST COAST","NEW ZEALAND COAST","SOUTH SOUTH INDIAN OCEAN"},new List<string>(){"AUSTRALIA","AUSTRALIA SOUTH COAST","AUSTRALIA EAST COAST","EAST INDIES COAST","SOUTHEAST INDIAN OCEAN","SOUTH SOUTH INDIAN OCEAN"},new List<string>(){"RUSSIA","CAUCASUS","KAZAKH S.S.R.","PERSIA"},new List<string>(){"BORNEO CELEBES","AUSTRALIA EAST COAST","NEW GUINEA COAST","CAROLINE ISLANDS COAST","PHILIPPINE ISLANDS COAST","INDO-CHINA COAST","EAST INDIES COAST"},new List<string>(){"BRAZIL","SOUTHWEST ALANTIC","RIO DE ORO COAST","NORTHWEST ALANTIC","PANAMA EAST COAST"},new List<string>(){"CAROLINE ISLANDS","OKINAWA COAST","WAKE ISLAND COAST","SOLOMON ISLANDS COAST","NEW GUINEA COAST","BORNEO CELEBES COAST","PHILIPPINE ISLANDS COAST"},new List<string>(){"EASTERN CANADA","EASTERN U.S.A. COAST","UNITED KINGDOM COAST","NORTHWEST ALANTIC","NORTHEAST ALANTIC"},new List<string>(){"EASTERN U.S.A.","EASTERN CANADA COAST","PANAMA EAST COAST","NORTHWEST ALANTIC"},new List<string>(){"EAST INDIES","INDIAN OCEAN","INDO-CHINA COAST","BORNEO CELEBES COAST","AUSTRALIA EAST COAST","AUSTRALIA WEST COAST","SOUTHEAST INDIAN OCEAN"},new List<string>(){"GIBRALTAR","ROME COAST","NORTHEAST ALANTIC","SPAIN","ALGERIA","WESTERN EUROPE"},new List<string>(){"HAWAIIAN ISLANDS","MEXICO COAST","SOUTH PACIFIC","SOLOMON ISLANDS COAST","WAKE ISLAND COAST","NORTHWEST PACIFIC","NORTHEAST PACIFIC","WESTERN U.S.A. COAST"},new List<string>(){"INDIA","MADAGASCAR EAST COAST","SOUTHEAST INDIAN OCEAN","SUEZ CANAL SOUTH","INDO-CHINA COAST","EAST INDIES COAST"},new List<string>(){"FRENCH INDO-CHINA BURMA","INDIAN OCEAN","EAST INDIES COAST","BORNEO CELEBES COAST","PHILIPPINE ISLANDS COAST","KWANGTUNG COAST"},new List<string>(){"JAPAN","MANCHURIA","KWANGTUNG COAST","PHILIPPINE ISLANDS COAST","OKINAWA COAST","WAKE ISLAND COAST","NORTHWEST PACIFIC","SOVIET FAR EAST COAST"},new List<string>(){"KARELIA S.S.R.","UNITED KINGDOM COAST"},new List<string>(){"KWANGTUNG","JAPAN COAST","PHILIPPINE ISLANDS COAST","INDO-CHINA COAST"},new List<string>(){"FRENCH MADAGASCAR","MADAGASCAR SOUTHEAST COAST","MADAGASCAR EAST COAST","SOUTH SOUTH INDIAN OCEAN","MOZAMBIQUE COAST"},new List<string>(){"FRENCH MADAGASCAR","MADAGASCAR EAST COAST","SOUTH SOUTH INDIAN OCEAN","SOUTHEAST AFRICA COAST"},new List<string>(){"MEXICO","HAWAIIAN ISLANDS COAST","PANAMA EAST COAST","SOUTH PACIFIC","SOUTHEAST PACIFIC"},new List<string>(){"MOZAMBIQUE","KENYA RHODESIA","FRENCH MADAGASCAR","SOUTHEAST AFRICA COAST","MADAGASCAR EAST COAST","SUEZ CANAL SOUTH"},new List<string>(){"NEW GUINEA","AUSTRALIA EAST COAST","SOLOMON ISLANDS COAST","CAROLINE ISLANDS COAST","BORNEO CELEBES COAST"},new List<string>(){"NEW ZEALAND","AUSTRALIA EAST COAST","AUSTRALIA SOUTH COAST","SOLOMON ISLANDS COAST","SOUTH PACIFIC"},new List<string>(){"SPAIN","ALGERIA","GIBRALTAR COAST","RIO DE ORO COAST","NORTHWEST ALANTIC","UNITED KINGDOM COAST","EASTERN CANADA COAST"},new List<string>(){"NORTHWEST PACIFIC","MIDWAY ISLAND","WESTERN U.S.A. COAST","HAWAIIAN ISLANDS COAST","WESTERN CANADA COAST","ALASKA COAST"},new List<string>(){"NORTHEAST ALANTIC","EASTERN U.S.A. COAST","EASTERN CANADA COAST","PANAMA EAST COAST","BRAZIL NORTH COAST","RIO DE ORO COAST"},new List<string>(){"NORTHEAST PACIFIC","JAPAN COAST","SOVIET FAR EAST COAST","ALASKA COAST","WAKE ISLAND COAST","HAWAIIAN ISLANDS COAST"},new List<string>(){"OKINAWA","JAPAN COAST","PHILIPPINE ISLANDS COAST","CAROLINE ISLANDS COAST","WAKE ISLAND COAST"},new List<string>(){"PANAMA","WEST INDIES","MEXICO COAST","VENEZUELA COLUMBIA","EASTERN U.S.A. COAST","WESTERN U.S.A.","NORTHWEST ALANTIC","BRAZIL NORTH COAST"},new List<string>(){"PANAMA","VENEZUELA COLUMBIA", "PANAMA EAST COAST", "MEXICO COAST","PERU COAST"},new List<string>(){"PERU","ARGENTINA CHILI","ARGENTINA SOUTH COAST","MEXICO COAST","SOUTHEAST PACIFIC"},new List<string>(){"PHILIPPINE ISLANDS","JAPAN COAST","OKINAWA COAST","CAROLINE ISLANDS COAST","BORNEO CELEBES COAST","INDO-CHINA COAST","KWANGTUNG COAST"},new List<string>(){"RIO DE ORO","FRENCH WEST AFRICA","SOUTHEAST ALANTIC","SOUTHWEST ALANTIC","BRAZIL NORTH COAST","NORTHWEST ALANTIC","NORTHEAST ALANTIC"},new List<string>(){"SOUTHERN EUROPE","LIBYA","SUEZ CANAL NORTH","GIBRALTAR COAST","UKRAINE COAST"},new List<string>(){"SOLOMON ISLANDS","NEW ZEALAND COAST","AUSTRALIA EAST COAST","SOUTH PACIFIC","HAWAIIAN ISLANDS COAST","CAROLINE ISLANDS COAST","WAKE ISLAND COAST","NEW GUINEA COAST"},new List<string>(){"UNION OF SOUTH AFRICA","MOZAMBIQUE COAST","FRENCH MADAGASCAR","MADAGASCAR SOUTHEAST COAST","ANGOLA COAST"},new List<string>(){"FRENCH EQUATORIAL AFRICA","BELGIAN CONGO","ANGOLA COAST","SOUTHWEST ALANTIC","SOUTH SOUTH ALANTIC","RIO DE ORO COAST"},new List<string>(){"MADAGASCAR EAST COAST","INDIAN OCEAN","EAST INDIES COAST","AUSTRALIA WEST COAST","AUSTRALIA SOUTH COAST","SOUTH SOUTH INDIAN OCEAN"},new List<string>(){"SOUTH PACIFIC","MEXICO COAST","PANAMA WEST COAST"},new List<string>(){"NEW ZEALAND COAST","SOLOMON ISLANDS COAST","HAWAIIAN ISLANDS COAST","MEXICO COAST","SOUTHEAST PACIFIC"},new List<string>(){"SOUTH SOUTH SOUTH ALANTIC","ANGOLA COAST","ARGENTINA SOUTH COAST","ARGENTINA EAST COAST","SOUTHWEST ALANTIC","SOUTHEAST ALANTIC"},new List<string>(){"MADAGASCAR EAST COAST","SOUTHEAST INDIAN OCEAN","AUSTRALIA SOUTH COAST","MADAGASCAR SOUTHEAST COAST"},new List<string>(){"SOUTH SOUTH ALANTIC","ARGENTINA SOUTH COAST","ANGOLA COAST"},new List<string>(){"SOUTHEAST ALANTIC","BRAZIL NORTH COAST","RIO DE ORO COAST","SOUTH SOUTH ALANTIC","ARGENTINA SOUTH COAST","BRAZIL"},new List<string>(){"SOVIET FAR EAST","JAPAN COAST","ALASKA COAST","NORTHWEST PACIFIC"},new List<string>(){"SUEZ CANAL SOUTH","UKRAINE COAST","ROME COAST","SYRIA-IRAQ","ANGLO-EGYPT SUDAN","TURKEY"},new List<string>(){"SUEZ CANAL NORTH","INDIAN OCEAN","MADAGASCAR EAST COAST","MOZAMBIQUE COAST","SAUDI ARABIA","SYRIA-IRAQ","ANGLO-EGYPT SUDAN","ITALIAN EAST AFRICA","PERSIA"},new List<string>(){"SWEDEN","FINLAND NORWAY","KARELIA S.S.R.","EASTERN EUROPE","GERMANY","WESTERN EUROPE","UNITED KINGDOM COAST"},new List<string>(){"SUEZ CANAL NORTH","EASTERN EUROPE","CAUCASUS","TURKEY","UKRAINE","ROME COAST"},new List<string>(){"UNITED KINGDOM","EIRE","WESTERN EUROPE","FINLAND NORWAY","SWEDEN COAST","KARELIA COAST","EASTERN CANADA COAST","NORTHEAST ALANTIC"},new List<string>(){"WAKE ISLAND","JAPAN COAST","OKINAWA COAST","CAROLINE ISLANDS COAST","SOLOMON ISLANDS COAST","HAWAIIAN ISLANDS COAST","NORTHWEST PACIFIC"},new List<string>(){"WESTERN CANADA","ALASKA","ALASKA COAST","NORTHEAST PACIFIC","WESTERN U.S.A. COAST"},new List<string>(){"WESTERN U.S.A.","WESTERN CANADA","WESTERN CANADA COAST","NORTHEAST PACIFIC","HAWAIIAN ISLANDS COAST","MEXICO COAST"}};

            List<ITerritory> tmpT = new List<ITerritory>();
            for(int i = 0; i < 127; i++)
            {
                tmpT = new List<ITerritory>();
                var lt = adjacentLists[i];
                foreach (var n in lt)
                {
                    var t = findTerritory(n);
                    if(t == null)
                    {
                        Console.WriteLine($"{n} not found");
                    }
                    else
                    {
                        tmpT.Add(t);
                    }
                }
                territories[i].addTerritories(tmpT);
            }
        
        }

        static ITerritory findTerritory(string name)
        {
            foreach (var t in territories)
            {
                if(t.name.Equals(name))
                {
                    return t;
                }
            }
            Console.WriteLine($"TERRITORY {name} NOT FOUND");
            return null;
        }
    }
}
