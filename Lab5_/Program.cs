using System;
using System.Collections.Generic;
using System.IO;


namespace Lab5_
{
    class Program
    {
        //zadanie 1
        public static void Main()
        {
            zadanie2();
            zadanie3();
            zadanie4();
        }

        //zadanie 2
        public static void zadanie2(string nazwaPliku = "dane.txt", int ileRazy = 3)
        {
            try
            {
                Console.WriteLine($"Podaj {ileRazy} informacji:");

                using (StreamWriter writer = new StreamWriter(nazwaPliku))
                {
                    for (int i = 0; i < ileRazy; i++)
                    {
                        Console.Write($"Informacja {i + 1}: ");
                        string tekst = Console.ReadLine();
                        writer.WriteLine(tekst);
                    }
                }

                Console.WriteLine($"\nDane zostały zapisane do pliku: {nazwaPliku}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas zapisu: {ex.Message}");
            }
        }

        //zadanie 3
        public static void zadanie3(string nazwaPliku = "dane.txt")
        {
            try
            {
                StreamReader fIn = new StreamReader(nazwaPliku);
                string s;

                do
                {
                    s = fIn.ReadLine();
                    Console.WriteLine(s);
                }
                while (s != null);

                fIn.Close();

                Console.WriteLine($"\nDane zostały zapisane do pliku: {nazwaPliku}");
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine($"Błąd podczas zapisu: {e.Message}");
            }
            catch (System.IO.IOException e) 
            {
                Console.WriteLine($"Błąd podczas zapisu: {e.Message}");
            }
        }

        //zadanie 4
        public static void zadanie4(string nazwaPliku = "dane.txt", int ileRazy = 3)
        {
            try
            {
                Console.WriteLine($"Podaj {ileRazy} dodatkowych informacji:");

                using (StreamWriter writer = new StreamWriter(nazwaPliku))
                {
                    for (int i = 0; i < ileRazy; i++)
                    {
                        Console.Write($"Dodatkowa informacja {i + 1}: ");
                        string tekst = Console.ReadLine();
                        writer.WriteLine(tekst);
                    }
                }

                Console.WriteLine($"\nDane zostały dopisane do pliku: {nazwaPliku}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas dopisywania: {ex.Message}");

            }
        }
        //zadanie 5
        public class Student
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public List<int> Oceny { get; set; }
        
            
        }
    }
}