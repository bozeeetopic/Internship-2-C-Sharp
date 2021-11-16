using System;
using System.Collections.Generic;

namespace PopisStanovnistva
{
    public class PersonData
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var populace = PopulatePopulace();
            string inputToContinue;
            do
            {
                if (Mainfunction(false, populace))
                {
                    Console.Write("Želite li još nešto napraviti? ");
                    inputToContinue = Console.ReadLine();
                }
                else inputToContinue = "da";
            }
            while (inputToContinue == "da");
        }

        static Dictionary<string, PersonData> PopulatePopulace()
        {
            return new Dictionary<string, PersonData>
    {
        {"K",
            new PersonData() { Name="K", Surname="Potassium", DateOfBirth=DateTime.Now}},
        {"Ca",
            new PersonData() { Name="Ca", Surname="Calcium", DateOfBirth=DateTime.Now}},
        {"Sc",
            new PersonData() { Name="Sc", Surname="Scandium", DateOfBirth=DateTime.Now}},
        {"Ti",
            new PersonData() { Name="Ti", Surname="Titanium", DateOfBirth=DateTime.Now}}
    };
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
        static int? UserIntInput(string textForUser)
        {
            int? userNumberInput;
            do
            {
                Console.Write(textForUser);

                try { userNumberInput = int.Parse(Console.ReadLine()); }
                catch
                {
                    userNumberInput = null;
                    Console.WriteLine("Pogrešan unos!! Traži se isključivo unos broja!");
                }
            }
            while (userNumberInput is null);
            return userNumberInput;
        }

        static bool Mainfunction(bool exitedSubMenu, Dictionary<string, PersonData> populace)
            {
                int? userNumberInput;
                string oib;
                PrintMenu();
                userNumberInput = UserIntInput("Vaš izbor: ");
                switch (userNumberInput)
                {
                    case 1:
                        PrintPopulacePrintChoices();
                        userNumberInput = UserIntInput("Vaš izbor: ");
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
                        oib = UserOibInput();
                        PrintPersonByOIB(oib);
                        break;
                    case 3:
                        var personToPrint = UserNameAndSurnameInput();
                        FindPopulaceByNameAndSurname(person);
                        break;
                    case 4:
                        var person = UserNameAndSurnameInput();
                        oib = UserOibInput();
                        var personWithOib = nesto;
                        if (nepostoji)
                            populace.Add(personWithOib);
                        break;
                    case 5:
                        oib = UserOibInput();
                        ErasePersonByOib(OibToErase);
                        break;
                    case 6:
                        var personToDelete = UserNameAndSurnameInput();
                        DeletePopulaceByNameAndSurname(person);
                        break;
                    case 7:
                        ErasePopulace();
                        break;
                    case 8:
                        PrintPopulaceEditingChoices();
                        userNumberInput = UserIntInput("Vaš izbor: ");
                        oib = UserOibInput();
                        switch (userNumberInput)
                        {
                            case 1:
                                EditOib(oib);
                                break;
                            case 2:
                                EditNameAndSurname(oib);
                                break;
                            case 3:
                                EditDateOfBirth(oib);
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
                        userNumberInput = UserIntInput("Vaš izbor: ");
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
                        userNumberInput = UserIntInput("Vaš izbor: ");
                        switch (userNumberInput)
                        {
                           case 1:
                                SortPopulaceBySurname(populace);
                                break;
                           case 2:
                                SortPopulaceByDateOfBirth(populace);
                                break;
                           case 3:
                                SortPopulaceByDateOfBirthDescending(populace);
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
                return exitedSubMenu;
            }
        }
    }