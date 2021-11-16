using System;
using System.Collections.Generic;

namespace PopisStanovnistva
{
    public class PersonData
    {
        public string NameAndSurname{ get; set; }
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
            new PersonData() { NameAndSurname="Potassium", DateOfBirth=DateTime.Now}},
        {"Ca",
            new PersonData() { NameAndSurname="Calcium", DateOfBirth=DateTime.Now}},
        {"Sc",
            new PersonData() { NameAndSurname="Scandium", DateOfBirth=DateTime.Now}},
        {"Ti",
            new PersonData() { NameAndSurname="Titanium", DateOfBirth=DateTime.Now}}
    };
        }


        static bool Mainfunction(bool exitedSubMenu, Dictionary<string, PersonData> populace)
        {
            int? userNumberInput;
            string oib;
            PersonData person;
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
                    FindPopulaceByNameAndSurname(personToPrint);
                    break;
                case 4:
                    var oibExists= false;
                    do
                    {
                        if (oibExists) Console.WriteLine("Uneseni oib već postoji, pokušajte opet!");
                        oib = UserOibInput();
                        oibExists = true;
                    }
                    while (populace.ContainsKey(oib));
                    person = UserNameAndSurnameInput();
                    populace.Add(oib,person);
                    break;
                case 5:
                    oib = UserOibInput();
                    ErasePersonByOib(populace, oib);
                    break;
                case 6:
                    person = UserNameAndSurnameInput();
                    DeletePopulaceByNameAndSurname(populace, person);
                    break;
                case 7:
                    ErasePopulace(populace);
                    break;
                case 8:
                    PrintPopulaceEditingChoices();
                    userNumberInput = UserIntInput("Vaš izbor: ");
                    oib = UserOibInput();
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



        static void PrintPopulaceDefault(Dictionary<string, PersonData> populace) { }
        static void PrintPopulaceBySurname(Dictionary<string, PersonData> populace) { }
        static void PrintPopulaceBySurnameDescending(Dictionary<string, PersonData> populace) { }
        static void FindPopulaceByNameAndSurname(PersonData person) { }
        static string UserOibInput()
        {
            return "";
        }
        static void PrintPersonByOIB(string oib)
        {

        }
        static PersonData UserNameAndSurnameInput() { return new PersonData(); }
        static void ErasePersonByOib(Dictionary<string, PersonData> populace, string oib) { }
        static void DeletePopulaceByNameAndSurname(Dictionary<string, PersonData> populace, PersonData person) { }
        static void ErasePopulace(Dictionary<string, PersonData> populace) { }
        static void EditOib(Dictionary<string, PersonData> populace, string oib) { }
        static void EditNameAndSurname(Dictionary<string, PersonData> populace, string oib) { }
        static void EditDateOfBirth(Dictionary<string, PersonData> populace, string oib) { }
        static void StatisticsOfUnemployedAndEmployed(Dictionary<string, PersonData> populace) { }
        static void StatisticsOfNames(Dictionary<string, PersonData> populace) { }
        static void StatisticsOfSurnames(Dictionary<string, PersonData> populace) { }
        static void StatisticsOfDates(Dictionary<string, PersonData> populace) { }
        static void StatisticsOfSeasons(Dictionary<string, PersonData> populace) { }
        static void StatisticsOfYoungestPerson(Dictionary<string, PersonData> populace) { }
        static void StatisticsOfOldestPerson(Dictionary<string, PersonData> populace) { }
        static void StatisticsOfAgeAverage(Dictionary<string, PersonData> populace) { }
        static void StatisticsOfAgeMedian(Dictionary<string, PersonData> populace) { }
        static void SortPopulaceBySurname(Dictionary<string, PersonData> populace) { }
        static void SortPopulaceByDateOfBirth(Dictionary<string, PersonData> populace) { }
        static void SortPopulaceByDateOfBirthDescending(Dictionary<string, PersonData> populace) { }
    }
    }