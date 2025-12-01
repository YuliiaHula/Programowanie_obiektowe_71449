using System;
using System.IO;

namespace Lab5_
{
    class Program
    {
        public static void Main()
        {
        }

        //zadanie1
        public static void zadanie1(string nazwaPliku = "dane.txt", int ileRazy = 3)
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
    }
}