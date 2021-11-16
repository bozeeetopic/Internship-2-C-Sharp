using System;
using System.Collections.Generic;

namespace PopisStanovnistva
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<string, (string, string, DateTime)>> populace = new List<Dictionary<string, (string, string, DateTime)>>();
            PopulatePopulace(populace);
            string inputToContinue;
            do
            {
                Mainfunction(populace);
                Console.Write("Želite li još nešto napraviti? ");
                inputToContinue = Console.ReadLine();
            }
            while (inputToContinue == "da");
        }

        static void PopulatePopulace(List<Dictionary<string, (string, string, DateTime)>> populace)
        {
            var touple = (name: "", surname: "", dateOfBirth: DateTime.Now);
            populace.Add(new Dictionary<string, (string, string, DateTime)> {"oib",touple});
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
            Console.WriteLine();
        }
        static void PrintPopulaceEditingChoices()
        {
            Console.WriteLine("Odaberi što mijenjamo kod stanovnika: ");
            Console.WriteLine("1 - OIB");
            Console.WriteLine("2 - Ime i prezime");
            Console.WriteLine("3 - Datum rođenja");
            Console.WriteLine();
        }
        static void PrintPopulaceStatisticsChoices()
        {
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Ispis postotka zaposlenih i nezaposlenih");
            Console.WriteLine("2 - Ispis najčešćeg imena i koliko ljudi ga dijeli");
            Console.WriteLine("3 - Ispis najčešćeg prezimena i koliko ga stanovnika dijeli");
            Console.WriteLine("4 - Ispis broja ljudi po godišnjim dobima");
            Console.WriteLine("5 - Ispis najmlađeg stanovnika");
            Console.WriteLine("6 - Ispis najstarijeg stanovnika");
            Console.WriteLine("7 - Prosječan broj godina");
            Console.WriteLine("8 - Medijan godina");
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

        static void Mainfunction(List<Dictionary<string, (string, string, DateTime)>> populace)
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
                            default:
                                Console.WriteLine("Nepostojeći izbor!");
                                break;
                        }
                        break;
                    case 10:
                        populace.sort();
                        break;
                    case 0:
                    default:
                        Console.WriteLine("Nepostojeći izbor!");
                        break;
                }
            }
        }
    }