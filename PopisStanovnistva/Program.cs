﻿using System;
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
            while (inputToContinue == "da");
        }

        static Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> PopulatePopulace()
        {
            return new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>
            {
                //ivo sanader je poseban on si je rezervira ovi oib
            {"1",(nameAndSurname: "Ivo Sanader", dateOfBirth: DateTime.Now )},
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
            int? userNumberInput;
            string oib;
            (string, DateTime) person;
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



        static void PrintPopulaceDefault(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            foreach(var item in populace)
            {
                Console.WriteLine($"OIB: {item.Key}\t" +
                    $"Ime i prezime: {item.Value.Item1}\t" +
                    $"Datum rođenja: {item.Value.Item2}");
            }
        }
        static void PrintPopulaceBySurname(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var temporaryOib = "";
            var minDate = DateTime.Now;
            var sortedPopulace = new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>();
            foreach (var item in populace)
            {
                sortedPopulace.Add(item.Key, (nameAndSurname: item.Value.nameAndSurname, dateOfBirth: item.Value.dateOfBirth));
            }
                do
            {
                minDate = DateTime.Now;
                foreach (var item in sortedPopulace)
                {
                    if ( DateTime.Compare(minDate,item.Value.dateOfBirth)>=0)
                    {
                        temporaryOib = item.Key;
                        minDate = item.Value.dateOfBirth;
                    }
                }
                Console.WriteLine($"OIB: {temporaryOib}\t" +
                    $"Ime i prezime: {sortedPopulace.GetValueOrDefault(temporaryOib).nameAndSurname}\t" +
                    $" Datum rođenja: {sortedPopulace.GetValueOrDefault(temporaryOib).dateOfBirth}");
                sortedPopulace.Remove(temporaryOib);
            }
            while (sortedPopulace.Count >0);
        }
        static void PrintPopulaceBySurnameDescending(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace)
        {
            var temporaryOib = "";
            var minDate = new DateTime (1,1,1,0,0,0);
            var sortedPopulace = new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>();
            foreach (var item in populace)
            {
                sortedPopulace.Add(item.Key, (nameAndSurname: item.Value.nameAndSurname, dateOfBirth: item.Value.dateOfBirth));
            }
            do
            {
                minDate = new DateTime(1, 1, 1, 0, 0, 0);
                foreach (var item in sortedPopulace)
                {
                    if (DateTime.Compare(minDate, item.Value.dateOfBirth) <= 0)
                    {
                        temporaryOib = item.Key;
                        minDate = item.Value.dateOfBirth;
                    }
                }
                Console.WriteLine($"OIB: {temporaryOib}\t" +
                    $"Ime i prezime: {sortedPopulace.GetValueOrDefault(temporaryOib).nameAndSurname}\t" +
                    $" Datum rođenja: {sortedPopulace.GetValueOrDefault(temporaryOib).dateOfBirth}");
                sortedPopulace.Remove(temporaryOib);
            }
            while (sortedPopulace.Count > 0);
        }
        static string UserOibInput()
        {
            var oib = "";
            var repeatedInput = false;
            do
            {
                if (repeatedInput) Console.WriteLine("Pogrešna duljina oiba, treba bit 11 znakova");
                Console.Write("Stanovnikov OIB: ");
                oib = Console.ReadLine();
                Console.WriteLine();
            }
            while (oib.Length != 11);
            return oib;
        }
        static (string nameAndSurname, DateTime dateOfBirth) UserNameAndSurnameInput() 
        {
            var surname = "";
            var name = "";
            int year, month, day;

            name = NameOrSurnameInput("ime");
            surname = NameOrSurnameInput("prezime");
            year = NumberInput("godinu",2021);
            month = NumberInput("mjesec", 12);
            day = NumberInput("dan", DaysInMonth(month,year));
            return (name+" "+surname, new DateTime(year,month,day,0,0,0));
        }
        static string NameOrSurnameInput(string nameOrSurname)
        {
            var repeatedInput = false;
            var input = "";
            do
            {
                if (repeatedInput) Console.WriteLine("Duljina "+ nameOrSurname + "na mora biti 1!");
                Console.Write("Stanovnikovo "+ nameOrSurname+": ");
                input = Console.ReadLine();
                Console.WriteLine();
                repeatedInput = true;
            }
            while (input.Length < 1);
            return input;
        }
        static int NumberInput(string yearOrMonthOrDay,int maxValue)
        {
            var number = 0;
            var repeatedInput = false;
            do
            {
                if (repeatedInput) Console.WriteLine("Morate unjeti broj između 1 i " + maxValue+".");
                Console.Write("Unesite "+ yearOrMonthOrDay+": ");
                if (!int.TryParse(Console.ReadLine(), out number)) Console.WriteLine("Pogrešan unos, brojeve samo!");
                repeatedInput = true;
            }
            while (number > maxValue || number < 1);
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
        static void FindPopulaceByNameAndSurname((string nameAndSurname, DateTime dateOfBirth) person) { }
        static void PrintPersonByOIB(string oib) { }
        static void ErasePersonByOib(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace, string oib) { }
        static void DeletePopulaceByNameAndSurname(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace, (string nameAndSurname, DateTime dateOfBirth) person) { }
        static void ErasePopulace(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
        static void EditOib(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace, string oib) { }
        static void EditNameAndSurname(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace, string oib) { }
        static void EditDateOfBirth(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace, string oib) { }
        static void StatisticsOfUnemployedAndEmployed(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
        static void StatisticsOfNames(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
        static void StatisticsOfSurnames(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
        static void StatisticsOfDates(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
        static void StatisticsOfSeasons(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
        static void StatisticsOfYoungestPerson(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
        static void StatisticsOfOldestPerson(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
        static void StatisticsOfAgeAverage(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
        static void StatisticsOfAgeMedian(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
        static void SortPopulaceBySurname(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
        static void SortPopulaceByDateOfBirth(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
        static void SortPopulaceByDateOfBirthDescending(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> populace) { }
    }
    }