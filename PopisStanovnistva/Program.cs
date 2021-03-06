using System;
using System.Collections.Generic;

namespace PopisStanovnistva
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var populace = PopulatePopulace();
            string inputToContinue;
            do
            {
                if (!Mainfunction(populace))
                {
                    Console.Write("Želite li još nešto napraviti? ");
                    inputToContinue = Console.ReadLine();
                    Console.WriteLine();
                }
                else inputToContinue = "da";
            }
            while (inputToContinue.Equals("da"));
        }


        static Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopulatePopulace()
        {
            return new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>
            {
                //ivo sanader je poseban on si je rezervira ovi oib
            {"1\t\t",(nameAndSurname: "Ivo Sanader", dateOfBirth: DateTime.Now )},
            {"13333333333",(nameAndSurname: "XÆ A-X11", dateOfBirth: new DateTime(1992, 1, 1, 0, 0, 0) )},
            {"12345678910",(nameAndSurname: "Bože Topić", dateOfBirth: new DateTime(1996, 4, 9, 0, 0, 0) )},
            {"21345678910",(nameAndSurname: "Michelle Šarić", dateOfBirth: new DateTime(1998, 8, 19, 0, 0, 0))},
            {"23145678901",(nameAndSurname: "Duje Šarić", dateOfBirth: new DateTime(2008, 8, 8, 0, 0, 0))},
            {"32145678910",(nameAndSurname: "Davor Meter", dateOfBirth: new DateTime(1900, 9, 9, 0, 0, 0) )},
            {"12345678901",(nameAndSurname: "Mala Mandarina", dateOfBirth: new DateTime(2000, 6, 1, 0, 0, 0) )},
            {"20193847264",(nameAndSurname: "Mala Naranča", dateOfBirth: new DateTime(2000, 6, 1, 0, 0, 0) )},
            {"11111111111",(nameAndSurname: "Njonjo Njonjić", dateOfBirth: new DateTime(1919, 1, 9, 0, 0, 0) )},
            {"88888888888",(nameAndSurname: "Stipe Mesić", dateOfBirth: new DateTime(1, 1, 1, 0, 0, 0) )}
            };
        }
        static bool Mainfunction(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var exitedSubMenu = false;
            int userNumberInput;
            string oib;
            (string, DateTime) person;
            PrintMenu();
            userNumberInput = NumberInput("vaš izbor", 0, 11);
            switch (userNumberInput)
            {
                case 1:
                    PrintPopulacePrintChoices();
                    userNumberInput = NumberInput("vaš izbor", 0, 4);
                    switch (userNumberInput)
                    {
                        case 1:
                            PrintPopulaceDefault(populace);
                            break;
                        case 2:
                            PrintPopulaceBySurname(populace);
                            break;
                        case 3:
                            PrintPopulaceBySurnameDescending(populace);
                            break;
                        case 0:
                            exitedSubMenu = true;
                            break;
                        default:
                            Console.WriteLine("Nepostojeći izbor!");
                            break;
                    }
                    break;
                case 2:
                    oib = UserOibInput("qwertzuiopšđžćčlkjhgfds ayxcvbnm,.-:;<>!#$%&/()=?*¸¨'"+'"');
                    FindPersonByOIB(populace, oib);
                    break;
                case 3:
                    var personToPrint = UserNameSurnameAndDateInput();
                    FindPopulaceByNameAndSurname(populace, personToPrint);
                    break;
                case 4:
                    var oibExists = false;
                    do
                    {
                        if (oibExists) Console.WriteLine("Uneseni oib već postoji, pokušajte opet!");
                        oib = UserOibInput("qwertzuiopšđžćčlkjhgfds ayxcvbnm,.-:;<>!#$%&/()=?*¸¨'" + '"');
                        oibExists = true;
                    }
                    while (populace.ContainsKey(oib));
                    person = UserNameSurnameAndDateInput();
                    populace.Add(oib, person);
                    break;
                case 5:
                    oib = UserOibInput("qwertzuiopšđžćčlkjhgfds ayxcvbnm,.-:;<>!#$%&/()=?*¸¨'" + '"');
                    ErasePersonByOib(populace, oib);
                    break;
                case 6:
                    person = UserNameSurnameAndDateInput();
                    DeletePopulaceByNameAndSurname(populace, person);
                    break;
                case 7:
                    ErasePopulace(populace);
                    break;
                case 8:
                    PrintPopulaceEditingChoices();
                    userNumberInput = NumberInput("vaš izbor", 0, 4);
                    oib = UserOibInput("qwertzuiopšđžćčlkjhgfds ayxcvbnm,.-:;<>!#$%&/()=?*¸¨'" + '"');
                    switch (userNumberInput)
                    {
                        case 1:
                            EditOib(populace, oib);
                            break;
                        case 2:
                            EditNameAndSurname(populace, oib);
                            break;
                        case 3:
                            EditDateOfBirth(populace, oib);
                            break;
                        case 0:
                            exitedSubMenu = true;
                            break;
                        default:
                            Console.WriteLine("Nepostojeći izbor!");
                            break;
                    }
                    break;
                case 9:
                    PrintPopulaceStatisticsChoices();
                    userNumberInput = NumberInput("vaš izbor", 0, 10);
                    switch (userNumberInput)
                    {
                        case 1:
                            StatisticsOfUnemployedAndEmployed(populace);
                            break;
                        case 2:
                            StatisticsOfNames(populace);
                            break;
                        case 3:
                            StatisticsOfSurnames(populace);
                            break;
                        case 4:
                            StatisticsOfDates(populace);
                            break;
                        case 5:
                            StatisticsOfSeasons(populace);
                            break;
                        case 6:
                            StatisticsOfYoungestPerson(populace);
                            break;
                        case 7:
                            StatisticsOfOldestPerson(populace);
                            break;
                        case 8:
                            StatisticsOfAgeAverage(populace);
                            break;
                        case 9:
                            StatisticsOfAgeMedian(populace);
                            break;
                        case 0:
                            exitedSubMenu = true;
                            break;
                        default:
                            Console.WriteLine("Nepostojeći izbor!");
                            break;
                    }
                    break;
                case 10:
                    PrintStatisticsChoices();
                    userNumberInput = NumberInput("vaš izbor", 0, 4);
                    switch (userNumberInput)
                    {
                        case 1:
                            SortPopulaceBySurname(populace);
                            break;
                        case 2:
                            SortPopulaceByDate(populace,SortDatesUp);
                            Console.WriteLine("OIB:\t\tIme i prezime:\t\t\tDatum rođenja:");
                            foreach (var sortedPerson in populace)
                                Console.WriteLine(sortedPerson.Key + "\t" + sortedPerson.Value.nameAndSurname + "\t" + sortedPerson.Value.dateOfBirth);
                            break;
                        case 3:
                            SortPopulaceByDate(populace, SortDatesUp); //iz nekog razloga mi je izbugano reverzno sortiranje iako je kod identican
                            SortPopulaceByDate(populace, SortDatesDown); //al radi ako je vec sortirano na normalan nacin pa eto ¯\_(ツ)_/¯
                            Console.WriteLine("OIB:\t\tIme i prezime:\t\t\tDatum rođenja:");
                            foreach (var sortedPerson in populace)
                                Console.WriteLine(sortedPerson.Key + "\t" + sortedPerson.Value.nameAndSurname + "\t" + sortedPerson.Value.dateOfBirth);
                            break;
                        case 0:
                            exitedSubMenu = true;
                            break;
                        default:
                            Console.WriteLine("Nepostojeći izbor!");
                            break;
                    }
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Nepostojeći izbor!");
                    break;
            }
            Console.WriteLine();
            return exitedSubMenu;
        }



        static void PrintMenu()
        {
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Ispis stanovnistva");
            Console.WriteLine("2 - Ispis stanovnistva po OIB-u");
            Console.WriteLine("3 - Ispis OIB-a po unosu imena i prezimena");
            Console.WriteLine("4 - Unos novog stanovnika");
            Console.WriteLine("5 - Brisanje stanovnika po OIB-u");
            Console.WriteLine("6 - Brisanje stanovnika po imenu, prezimenu te datumu rodenja");
            Console.WriteLine("7 - Brisanje svih stanovnika");
            Console.WriteLine("8 - Uredivanje stanovnika");
            Console.WriteLine("9 - Statistika");
            Console.WriteLine("10 - Sortiranje stanovnika");
            Console.WriteLine("0 - Izlaz");
            Console.WriteLine();
        }
        static void PrintPopulacePrintChoices()
        {
            Console.WriteLine("Odaberi način ispisa stanovništva: ");
            Console.WriteLine("1 - Defaultni ispis stanovnistva");
            Console.WriteLine("2 - Ispis po datumu rođenja uzlazno");
            Console.WriteLine("3 - Ispis po datumu rođenja silazno");
            Console.WriteLine("0 - Izlaz");
            Console.WriteLine();
        }
        static void PrintPopulaceEditingChoices()
        {
            Console.WriteLine("Odaberi što mijenjamo kod stanovnika: ");
            Console.WriteLine("1 - OIB");
            Console.WriteLine("2 - Ime i prezime");
            Console.WriteLine("3 - Datum rođenja");
            Console.WriteLine("0 - Izlaz");
            Console.WriteLine();
        }
        static void PrintPopulaceStatisticsChoices()
        {
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Ispis postotka zaposlenih i nezaposlenih");
            Console.WriteLine("2 - Ispis najčešćeg imena i koliko ljudi ga dijeli");
            Console.WriteLine("3 - Ispis najčešćeg prezimena i koliko ga stanovnika dijeli");
            Console.WriteLine("4 - Ispis datuma na koji je rođeno najviše ljudi i koji je to broj");
            Console.WriteLine("5 - Ispis broja ljudi po godišnjim dobima");
            Console.WriteLine("6 - Ispis najmlađeg stanovnika");
            Console.WriteLine("7 - Ispis najstarijeg stanovnika");
            Console.WriteLine("8 - Prosječan broj godina");
            Console.WriteLine("9 - Medijan godina");
            Console.WriteLine("0 - Izlaz");
            Console.WriteLine();
        }
        static void PrintStatisticsChoices()
        {
            Console.WriteLine("Odaberi kako sortiramo stanovnike: ");
            Console.WriteLine("1 - Preko prezimena");
            Console.WriteLine("2 - Preko datuma rođenja");
            Console.WriteLine("3 - Preko datuma rođenja obrnuti redosljed");
            Console.WriteLine("0 - Izlaz");
            Console.WriteLine();
        }



        static void Red(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Black(string input)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Green(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void PrintAgeCheck(string oib,string nameAndSurname,DateTime dateOfBirth)
        {
            if (DateTime.Now.Subtract(dateOfBirth).Days < 24 * 365 || DateTime.Now.Subtract(dateOfBirth).Days > 65 * 365 && DateTime.Now.Subtract(dateOfBirth).Days <100 * 365)
                PrintHelper(oib, nameAndSurname, dateOfBirth, Red);
            else if(DateTime.Now.Subtract(dateOfBirth).Days > 24 * 365 && DateTime.Now.Subtract(dateOfBirth).Days < 65 * 365)
                PrintHelper(oib, nameAndSurname, dateOfBirth, Green);
            else
                PrintHelper(oib, nameAndSurname, dateOfBirth, Black);
        }
        static void PrintHelper(string oib, string nameAndSurname, DateTime dateOfBirth,Action<string>colorPrint)
        {
            Console.Write("OIB: ");
            colorPrint(oib);
            Console.Write("\tIme i prezime: ");
            colorPrint(nameAndSurname);
            Console.Write("\tDatum rođenja: ");
            colorPrint(dateOfBirth.ToString());
            Console.WriteLine();
        }



        static void PrintPopulaceDefault(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            foreach(var person in populace)
            {
                PrintAgeCheck(person.Key,person.Value.nameAndSurname,person.Value.dateOfBirth);
            }
        }
        static void PrintPopulaceBySurname(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var temporaryOib = "";
            var minDate = DateTime.Now;
            var sortedPopulace = new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>();
            foreach (var person in populace)
            {
                sortedPopulace.Add(person.Key, (nameAndSurname: person.Value.nameAndSurname, dateOfBirth: person.Value.dateOfBirth));
            }
            do
            {
                minDate = DateTime.Now;
                foreach (var person in sortedPopulace)
                {
                    if ( DateTime.Compare(minDate,person.Value.dateOfBirth)>=0)
                    {
                        temporaryOib = person.Key;
                        minDate = person.Value.dateOfBirth;
                    }
                }
                PrintAgeCheck(temporaryOib, sortedPopulace[temporaryOib].nameAndSurname, sortedPopulace[temporaryOib].dateOfBirth);
                sortedPopulace.Remove(temporaryOib);
            }
            while (sortedPopulace.Count >0);
        }
        static void PrintPopulaceBySurnameDescending(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var temporaryOib = "";
            var minDate = new DateTime (1,1,1,0,0,0);
            var sortedPopulace = new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>();
            foreach (var person in populace)
            {
                sortedPopulace.Add(person.Key, (nameAndSurname: person.Value.nameAndSurname, dateOfBirth: person.Value.dateOfBirth));
            }
            do
            {
                minDate = new DateTime(1, 1, 1, 0, 0, 0);
                foreach (var person in sortedPopulace)
                {
                    if (DateTime.Compare(minDate, person.Value.dateOfBirth) <= 0)
                    {
                        temporaryOib = person.Key;
                        minDate = person.Value.dateOfBirth;
                    }
                }
                PrintAgeCheck(temporaryOib, sortedPopulace[temporaryOib].nameAndSurname, sortedPopulace[temporaryOib].dateOfBirth);
                sortedPopulace.Remove(temporaryOib);
            }
            while (sortedPopulace.Count > 0);
        }
        
        

        static bool StringContainsString(string  a,string b)
        {
            foreach(var character in b)
            {
                if (a.Contains(character)) return true;
            }
            return false;
        }
        static string UserOibInput(string forbiddenString) //qwertzuiopšđžćčlkjhgfds ayxcvbnm,.-:;<>!#$%&/()=?*¸¨'
        {
            var oib = "";
            var repeatedInput = false;
            do
            {
                if (repeatedInput && (oib.Length != 11)) Console.WriteLine("Pogrešna duljina oiba, treba bit 11 znakova!");
                if (repeatedInput && StringContainsString(oib.ToLower(), forbiddenString)) Console.WriteLine("Oib sadrži znak, moraju biti isključivo brojevi!");
                Console.Write("Stanovnikov OIB: ");
                oib = Console.ReadLine();
                Console.WriteLine();
                repeatedInput = true;
            }
            while ((oib.Length != 11) || StringContainsString(oib.ToLower(), forbiddenString));
            return oib;
        }
        static (string nameAndSurname, DateTime dateOfBirth) UserNameSurnameAndDateInput() 
        {
            int month, day;
            var name = NameOrSurnameInput("ime","");
            var surname = NameOrSurnameInput("prezime","");
            var year = NumberInput("godinu",1,DateTime.Now.Year+1);
            if(year== DateTime.Now.Year)
                month = NumberInput("mjesec", 1, DateTime.Now.Month+1);
            else 
                month = NumberInput("mjesec",1, 13);
            if(year==DateTime.Now.Year&&month==DateTime.Now.Month)
                day = NumberInput("dan", 1, DateTime.Now.Day + 1);
            else
                day = NumberInput("dan", 1,DaysInMonth(month,year)+1);
            return (name+" "+surname, new DateTime(year,month,day,0,0,0));
        }
        static string NameOrSurnameInput(string nameOrSurname,string forbiddenString)
        {
            var repeatedInput = false;
            var input = "";
            do
            {
                if (repeatedInput && (input.Length <1)) Console.WriteLine("Duljina "+ nameOrSurname + "na mora biti 1!");
                if (repeatedInput && StringContainsString(input.ToLower(), forbiddenString)) Console.WriteLine(nameOrSurname+" sadrži znak, moraju biti isključivo brojevi!");
                Console.Write("Stanovnikovo "+ nameOrSurname+": ");
                input = Console.ReadLine();         //nema zahtjeva za imenom jer postoje ljudi sa jako cudnim imenima
                Console.WriteLine();
                repeatedInput = true;
            }
            while ((input.Length < 1)&&(StringContainsString(input.ToLower(), forbiddenString)));
            return input;
        }
        static int NumberInput(string message, int minValue,int maxValue)
        {
            var number = 0;
            var repeatedInput = false;
            do
            {
                if (repeatedInput) Console.WriteLine("Morate unjeti broj između "+minValue+" i " + maxValue+".");
                Console.Write("Unesite "+ message+": ");
                if (!int.TryParse(Console.ReadLine(), out number)) Console.WriteLine("Pogrešan unos, brojeve samo!");
                repeatedInput = true;
            }
            while (number >= maxValue || number < minValue);
            return number;
        }
        static int DaysInMonth(int month, int year)
        {
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) return 31;
            else if (month == 4 || month == 6 || month == 9 || month == 11) return 30;
            else
            {
                if (year % 4 == 0)
                {
                    if(year % 100 == 0)
                    {
                        if (year % 400 == 0) return 29;
                        return 28;
                    }
                    return 29;
                }
                return 28;
            }
        }
        
        

        static void FindPersonByOIB(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace,string oib)
        {
            if (populace.ContainsKey(oib)) Console.WriteLine("Za traženi oib podatci slijede...\nIme i prezime: "+populace.GetValueOrDefault(oib).nameAndSurname+
                "Datum rođenja: "+ populace.GetValueOrDefault(oib).dateOfBirth);
            else
                Console.WriteLine("Ne postoji stanovnik sa traženim oib-om!");
        }
        static void FindPopulaceByNameAndSurname(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace, (string nameAndSurname, DateTime dateOfBirth) person)
        {
            {
                if (populace.ContainsValue(person))
                {
                    Console.WriteLine("Pronađeni su stanovnici: ");
                    foreach (var personInPopulace in populace)
                    {
                        if (personInPopulace.Value.nameAndSurname.Equals(person.nameAndSurname) && (personInPopulace.Value.dateOfBirth.Equals(person.dateOfBirth)))
                            Console.WriteLine($"OIB: {personInPopulace.Key}\t" +
                            $"Ime i prezime: {personInPopulace.Value.nameAndSurname}\t" +
                            $" Datum rođenja: {personInPopulace.Value.dateOfBirth}");
                     }
                }
                else
                    Console.WriteLine("Ne postoji stanovnik sa traženim podatcima!");
            }
        }
        
        

        static void ErasePersonByOib(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace, string oib)
        {
            if (populace.ContainsKey(oib))
            {
                Console.WriteLine("Pronađen stanovnik...\nIme i prezime: " + populace.GetValueOrDefault(oib).nameAndSurname +
               "Datum rođenja: " + populace.GetValueOrDefault(oib).dateOfBirth);
                Console.Write("Potvrdite sa 'da' brisanje stanovnika, u slučaju drugačijeg unosa prekid radnje: ");
                var deleteConfirmation = Console.ReadLine();
                if (deleteConfirmation.Equals("da")) populace.Remove(oib);
                else Console.WriteLine("Kriv unos, povratak u meni...");
            }
            else
                Console.WriteLine("Ne postoji stanovnik sa traženim oib-om!");
        }
        static void DeletePopulaceByNameAndSurname(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace, (string nameAndSurname, DateTime dateOfBirth) person)
        {
            {
                var keysToErase = new List<string>();
                var keyToErase = "";
                if (populace.ContainsValue(person))
                {
                    Console.WriteLine("Pronađeni su stanovnici: ");
                    foreach (var personInPopulace in populace)
                    {
                        if (personInPopulace.Value.nameAndSurname.Equals(person.nameAndSurname) && (personInPopulace.Value.dateOfBirth.Equals(person.dateOfBirth)))
                        {
                            Console.WriteLine($"OIB: {personInPopulace.Key}\t" +
                            $"Ime i prezime: {personInPopulace.Value.nameAndSurname}\t" +
                            $" Datum rođenja: {personInPopulace.Value.dateOfBirth}");
                            keysToErase.Add(personInPopulace.Key);
                            keyToErase = personInPopulace.Key;
                        }
                    }
                    if (keysToErase.Count > 1)
                    {
                        Console.WriteLine("Pronađeno je više osoba, upišite oib osobe koju želite obrisati: ");
                        ErasePersonByOib(populace, UserOibInput("qwertzuiopšđžćčlkjhgfds ayxcvbnm,.-:;<>!#$%&/()=?*¸¨'" + '"'));
                    }
                    else
                        ErasePersonByOib(populace, keyToErase);
                }
                else
                    Console.WriteLine("Ne postoji stanovnik sa traženim podatcima!");
            }
        }
        static void ErasePopulace(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            Console.Write("Potvrdite sa 'da' brisanje svih stanovnika, u slučaju drugačijeg unosa prekid radnje: ");
            var deleteConfirmation = Console.ReadLine();
            if (deleteConfirmation.Equals("da"))
            {
                foreach (var item in populace)
                    populace.Remove(item.Key);
            }
        }




        static void EditOib(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace, string oib)
        {
            if (populace.ContainsKey(oib))
            {
                var newOib = "";
                var oibExists = false;
                do
                {
                    if (oibExists) Console.WriteLine("Uneseni oib već postoji, pokušajte opet!");
                    newOib = UserOibInput("qwertzuiopšđžćčlkjhgfds ayxcvbnm,.-:;<>!#$%&/()=?*¸¨'" + '"');
                    oibExists = true;
                }
                while (populace.ContainsKey(newOib));
                Console.Write("Potvrdite sa 'da' zamjenu oiba stanovnika, "+oib+" sa "+ newOib+".");
                if (Console.ReadLine().Equals("da"))
                {
                populace.Add(newOib, populace[oib]);
                populace.Remove(oib);
                }
                else Console.WriteLine("Kriv unos, povratak u meni...");
                    
            }
            else
                Console.WriteLine("Ne postoji stanovnik sa traženim oib-om!");
        }
        static void EditNameAndSurname(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace, string oib)
        {
            if (populace.ContainsKey(oib))
            {
                Console.WriteLine("Za traženi oib ime i prezime su: " + populace.GetValueOrDefault(oib).nameAndSurname);
                var newName = NameOrSurnameInput("ime","");
                var newSurame = NameOrSurnameInput("prezime","");
                Console.Write("Potvrdite sa 'da' zamjenu imena i prezimena stanovnika: " + populace.GetValueOrDefault(oib).nameAndSurname + " -> " + newName + " " + newSurame + ".");
                if (Console.ReadLine().Equals("da"))
                {
                      populace[oib] = (newName + " " + newSurame, populace[oib].dateOfBirth);
                }
            }
            else
                Console.WriteLine("Ne postoji stanovnik sa traženim oib-om!");
        }
        static void EditDateOfBirth(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace, string oib)
        {
            if (populace.ContainsKey(oib))
            {
                Console.WriteLine("Za traženi oib datum rođenja je: " + populace.GetValueOrDefault(oib).dateOfBirth);
                int year, month, day;
                year = NumberInput("godinu", 1, 2022);
                month = NumberInput("mjesec", 1, 13);
                day = NumberInput("dan", 1, DaysInMonth(month, year)+1);
                Console.Write("Potvrdite sa 'da' zamjenu datuma rođenja stanovnika: " + populace.GetValueOrDefault(oib).dateOfBirth + " -> " + year + "/" + month + "/" + day+"/0/0/0.");
                if (Console.ReadLine().Equals("da"))
                {
                    populace[oib] = (populace[oib].nameAndSurname, new DateTime(year,month,day,0,0,0));
                }
            }
            else
                Console.WriteLine("Ne postoji stanovnik sa traženim oib-om!");
        }



        static void StatisticsOfUnemployedAndEmployed(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var employedCount = 0.00;
            var unemployedCount = 0.00;
            var deadCount = 0.00;
            foreach (var person in populace)
            {
                if (DateTime.Now.Subtract(person.Value.dateOfBirth).Days < 24 * 365 || DateTime.Now.Subtract(person.Value.dateOfBirth).Days > 65 * 365 && DateTime.Now.Subtract(person.Value.dateOfBirth).Days < 100 * 365)
                    unemployedCount++;
                else if (DateTime.Now.Subtract(person.Value.dateOfBirth).Days > 24 * 365 && DateTime.Now.Subtract(person.Value.dateOfBirth).Days < 65 * 365)
                    employedCount++;
                else
                    deadCount++;
            }

            Console.Write("Nezaposleni: ");
            Red((int)(unemployedCount/populace.Count*100)+"");
            Console.Write("%\tZaposleni: ");
            Green((int)(employedCount / populace.Count * 100) +"");
            Console.Write("%\tUmrli(trebali bi bit): ");
            Black((int)(deadCount / populace.Count * 100) + "");
            Console.WriteLine("%");
        }
        static void StatisticsOfNames(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var counters = new Dictionary<string, int>{ };
            var tempCounter = 0;
            foreach(var person in populace)
            {
                var name = person.Value.nameAndSurname.Substring(0, person.Value.nameAndSurname.IndexOf(" "));
                if (counters.ContainsKey(name))
                    counters[name]++;
                else
                {
                    counters.Add(name,1);
                }
            }
            foreach (var counter in counters)
            {
                if (counter.Value > tempCounter)
                    tempCounter = counter.Value;
            }
            Console.Write("Ime sa najviše ponavljanja: ");
            foreach (var counter in counters)
            {
                if (counter.Value == tempCounter)
                {
                    Console.WriteLine(counter.Key + ":\t" + counter.Value);
                    return;
                }
            }
        }
        static void StatisticsOfSurnames(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var counters = new Dictionary<string, int> { };
            var tempCounter = 0;
            foreach (var person in populace)
            {
                var surname = person.Value.nameAndSurname.Substring(person.Value.nameAndSurname.IndexOf(" "));
                if (counters.ContainsKey(surname))
                    counters[surname]++;
                else
                {
                    counters.Add(surname, 1);
                }
            }
            foreach (var counter in counters)
            {
                if (counter.Value > tempCounter)
                    tempCounter = counter.Value;
            }
            Console.Write("Prezime sa najviše ponavljanja: ");
            foreach (var counter in counters)
            {
                if (counter.Value == tempCounter)
                {
                    Console.WriteLine(counter.Key + ":\t" + counter.Value);
                    return;
                }
            }
        }
        static void StatisticsOfDates(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var counters = new Dictionary<DateTime, int> { };
            var tempCounter = 0;
            foreach (var person in populace)
            {
                if (counters.ContainsKey(new DateTime(1, person.Value.dateOfBirth.Month, person.Value.dateOfBirth.Day, 0, 0, 0)))
                    counters[new DateTime(1,person.Value.dateOfBirth.Month, person.Value.dateOfBirth.Day,0,0,0)]++;
                else
                {
                    counters.Add(new DateTime(1, person.Value.dateOfBirth.Month, person.Value.dateOfBirth.Day, 0, 0, 0), 1);
                }
            }
            foreach (var counter in counters)
            {
                if (counter.Value > tempCounter)
                    tempCounter = counter.Value;
            }
            Console.Write("Datum sa najviše rođenih: ");
            foreach (var counter in counters)
            {
                if (counter.Value == tempCounter)
                {
                    Console.WriteLine(counter.Key.Day+" / " + counter.Key.Month + ":\t" + counter.Value);
                    return;
                }
            }
        }
        static void StatisticsOfSeasons(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var counters = new Dictionary<string, int> { };
            counters.Add("Proljeće", 0);
            counters.Add("Ljeto", 0);
            counters.Add("Jesen", 0);
            counters.Add("Zima", 0);


            foreach (var person in populace)
            {
                if (new List<int>() { 4, 5 }.Contains(person.Value.dateOfBirth.Month))
                {
                    counters["Proljeće"]++;
                }
                else if (new List<int>() { 7, 8 }.Contains(person.Value.dateOfBirth.Month))
                {
                    counters["Ljeto"]++;
                }
                else if (new List<int>() { 10, 11 }.Contains(person.Value.dateOfBirth.Month))
                {
                    counters["Jesen"]++;
                }
                else if (new List<int>() { 1, 2 }.Contains(person.Value.dateOfBirth.Month))
                {
                    counters["Zima"]++;
                }
                else if (person.Value.dateOfBirth.Month==12)
                {
                    if(person.Value.dateOfBirth.Day<21)
                        counters["Jesen"]++;
                    else
                        counters["Zima"]++;
                }
                else if (person.Value.dateOfBirth.Month == 3)
                {
                    if (person.Value.dateOfBirth.Day < 21)
                        counters["Zima"]++;
                    else
                        counters["Proljeće"]++;
                }
                else if (person.Value.dateOfBirth.Month == 6)
                {
                    if (person.Value.dateOfBirth.Day < 21)
                        counters["Proljeće"]++;
                    else
                        counters["Ljeto"]++;
                }
                else if (person.Value.dateOfBirth.Month == 9)
                {
                    if (person.Value.dateOfBirth.Day < 23)
                        counters["Ljeto"]++;
                    else
                        counters["Jesen"]++;
                }
            }
            var list = new List<int>();
            foreach(var season in counters)
            {
                if (!list.Contains(season.Value))
                {
                    list.Add(season.Value);
                }
            }
            list.Sort();
            Console.WriteLine("Broj rođenih po sezonama: ");
            foreach (var numberOfPeople in list) 
            {
                foreach (var season in counters)
                {
                    if(numberOfPeople==season.Value)
                        Console.WriteLine(season.Key + ":\t" + season.Value);
                }
            }
        }
        static void StatisticsOfYoungestPerson(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var tempDate = new DateTime(1,1,1,0,0,0);
            var tempOib = "";
            foreach(var person in populace)
            {
                if (person.Value.dateOfBirth.CompareTo(tempDate) >= 1)
                {
                    tempDate = person.Value.dateOfBirth;
                    tempOib = person.Key;
                }
            }
            Console.WriteLine("Najmlađi stanovnik je: ");
            Console.Write("OIB: "+tempOib);
            Console.Write("\tIme i prezime: "+ populace[tempOib].nameAndSurname);
            Console.Write("\tDatum rođenja: "+ populace[tempOib].dateOfBirth);
            Console.WriteLine();
        }
        static void StatisticsOfOldestPerson(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var tempDate = DateTime.Now;
            var tempOib = "";
            foreach (var person in populace)
            {
                if (person.Value.dateOfBirth.CompareTo(tempDate) <= 1)
                {
                    tempDate = person.Value.dateOfBirth;
                    tempOib = person.Key;
                }
            }
            Console.WriteLine("Najstariji stanovnik je: ");
            Console.Write("OIB: " + tempOib);
            Console.Write("\tIme i prezime: " + populace[tempOib].nameAndSurname);
            Console.Write("\tDatum rođenja: " + populace[tempOib].dateOfBirth);
            Console.WriteLine();
        }
        static void StatisticsOfAgeAverage(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var sum = 0.0;
            foreach(var person in populace)
            {
                sum += DateTime.Now.Subtract(person.Value.dateOfBirth).Days;
                Console.WriteLine(sum);
            }
            sum /= 365;
            Console.WriteLine("Prosječna dob je: "+ (int)(sum/populace.Count));
        }
        static void StatisticsOfAgeMedian(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var tempMinDate = new DateTime(1, 1, 1, 0, 0, 0);
            var tempMaxDate = DateTime.Now;
            var discardablePopulace = new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>();
            var tempMinOib = "";
            var tempMaxOib = "";
            foreach (var item in populace)
            {
                discardablePopulace.Add(item.Key, (nameAndSurname: item.Value.nameAndSurname, dateOfBirth: item.Value.dateOfBirth));
            }
            do
            {
                foreach (var person in discardablePopulace)
                {
                    if (person.Value.dateOfBirth.CompareTo(tempMinDate) >= 1)
                    {
                        tempMinDate = person.Value.dateOfBirth;
                        tempMinOib = person.Key;
                    }
                    if (person.Value.dateOfBirth.CompareTo(tempMaxDate) <= 1)
                    {
                        tempMaxDate = person.Value.dateOfBirth;
                        tempMaxOib = person.Key;
                    }
                }
                if(discardablePopulace.Count>2)
                {
                    discardablePopulace.Remove(tempMinOib);
                    discardablePopulace.Remove(tempMaxOib);
                }
            }
            while (discardablePopulace.Count > 2);
            if(discardablePopulace.Count ==1)
            {
                foreach(var person in  discardablePopulace)
                    Console.WriteLine("Dobni medijan je: "+ DateTime.Now.Subtract(person.Value.dateOfBirth).TotalDays/365);
            }
            else
            {
                tempMinDate = new DateTime(1, 1, 1, 0, 0, 0);
                tempMaxDate = DateTime.Now;
                foreach (var person in discardablePopulace)
                {
                    if (person.Value.dateOfBirth.CompareTo(tempMinDate) > 1)
                    {
                        tempMinDate = person.Value.dateOfBirth;
                        tempMinOib = person.Key;
                    }
                    if (person.Value.dateOfBirth.CompareTo(tempMaxDate) < 1)
                    {
                        tempMaxDate = person.Value.dateOfBirth;
                        tempMaxOib = person.Key;
                    }
                }
                var ageDifference = tempMaxDate.Subtract(tempMinDate).TotalDays;
                Console.WriteLine("Dobni medijan je: " + DateTime.Now.Subtract(tempMinDate.AddDays(ageDifference)).TotalDays / 365);
            }
        }



        static void SortPopulaceBySurname(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var newList = new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>();
            var surnames = new List<string>();
            var tempVar = "";
            foreach (var person in populace)
            {
                var surname = person.Value.nameAndSurname.Substring(person.Value.nameAndSurname.IndexOf(" "));
                if(!surnames.Contains(surname))
                {
                    surnames.Add(surname);
                }
            }
            tempVar = surnames[0];
            for(var i = 0; i < surnames.Count-1; i++)
              {
                  for(var j= i+1;j< surnames.Count; j++)
                  {
                      if (surnames[i].CompareTo(surnames[j]) >= 0)
                      {
                          tempVar = surnames[j];
                          surnames[j] = surnames[i];
                          surnames[i] = tempVar;
                      }
                  }
              }
            //surnames.Sort();
            foreach (var surname in surnames)
            {
                foreach (var person in populace)
                {
                    if (person.Value.nameAndSurname.Substring(person.Value.nameAndSurname.IndexOf(" "))== surname)
                    {
                        newList.Add(person.Key, person.Value);
                        populace.Remove(person.Key);
                    }
                }
            }
            populace.Clear();
            Console.WriteLine("OIB:\t\tIme i prezime:\t\t\tDatum rođenja:");
            foreach (var person in newList)
            {
                Console.WriteLine( person.Key +"\t"+person.Value.nameAndSurname+"\t"+person.Value.dateOfBirth);
                populace.Add(person.Key, person.Value);
                newList.Remove(person.Key);
            }
             
        }
        static void SortPopulaceByDate(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace, Action<List<DateTime>> sortingFunction)
        {
            var newList = new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>();
            var dates = new List<DateTime>();
            foreach (var person in populace)
            {
                var date = person.Value.dateOfBirth;
                if (!dates.Contains(date))
                {
                    dates.Add(date);
                }
            }
            sortingFunction(dates);
            foreach (var date in dates)
            {
                foreach (var person in populace)
                {
                    if (person.Value.dateOfBirth == date)
                    {
                        newList.Add(person.Key, person.Value);
                        populace.Remove(person.Key);
                    }
                }
            }
            populace.Clear();
            foreach (var person in newList)
            {
                populace.Add(person.Key, person.Value);
                newList.Remove(person.Key);
            }

        }
        static void SortDatesUp(List<DateTime> list)
        {
            var newList = new List<DateTime>();
            var min = new DateTime(1, 1, 1, 0, 0, 0);
            do
            {
                min = new DateTime(1, 1, 1, 0, 0, 0);
                foreach (var date in list)
                {
                    if (date.CompareTo(min) >= 1)
                        min = date;
                }
                newList.Add(min);
                list.Remove(min);
            } while (list.Count > 0);
            foreach (var i in newList)
                list.Add(i);
        }
        static void SortDatesDown(List<DateTime> list)
        {
            var newList = new List<DateTime>();
            var max = DateTime.Now;
            do
            {
                max = DateTime.Now;
                foreach (var date in list)
                {
                    if (date.CompareTo(max) <= 1)
                        max = date;
                }
                newList.Add(max);
                list.Remove(max);
            } while (list.Count > 0);
            foreach (var i in newList)
                list.Add(i);
        }
    }
 }