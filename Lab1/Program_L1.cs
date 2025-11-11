using System;

namespace Lab1
{
    //zadanie 18/21
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("To jest cwiczenie 1");

            Zwierze[] z = new Zwierze[3];
            for (int i=0; i<=2; i++)
            {
                Console.WriteLine();

                Console.WriteLine("Podaj nazwę zwierzęcia : ");
                string nazwa_zwierzat = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Podaj gatunok : ");
                string gatunok_zwierzat = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Podaj liczbu nóg : ");
                int liczba_nóg = Convert.ToInt32(Console.ReadLine());

                z[i]= new Zwierze( nazwa_zwierzat, gatunok_zwierzat, liczba_nóg );
            }
           
            Zwierze klon = new Zwierze(z[0]);
            Console.WriteLine("Podaj nową nazwę dla klona: ");
            klon.nazwa_zwierzat = Console.ReadLine();

            for (int i = 0; i < z.Length; i++)
            {
                Console.WriteLine($"Nazwa : {z[i].nazwa_zwierzat}");
                Console.WriteLine($"Gatunok : {z[i].GatunokGet}");
                Console.WriteLine($"Liczba nóg : {z[i].LiczbaGet} ");
                z[i].Daj_glos();
            }
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Nazwa : {klon.nazwa_zwierzat}");
                Console.WriteLine($"Gatunok : {klon.GatunokGet}");
                Console.WriteLine($"Liczba nóg : {klon.LiczbaGet} ");
                klon.Daj_glos();
            }


            int liczba =Zwierze.Liczba();
            Console.WriteLine($"\n Liczba zwierzat :  {liczba}");

        }

        //zadanie 19/22
        class Zwierze
        {
            public string nazwa_zwierzat { get { return this.nazwa_zwierzat; } set { this.nazwa_zwierzat = value; } } //można napisać tak ponieważ program sam stworzy prywatne pole wewnątrz
            private string gatunok_zwierzat;
            private int liczba_nóg;
            private static int liczba_zwierzat = 0;


            public string GatunokGet { get { return this.gatunok_zwierzat; }}
            public int LiczbaGet { get { return this.liczba_nóg; }} 


            public Zwierze()
            {
                nazwa_zwierzat = "Rex";
                gatunok_zwierzat = "Pies";
                liczba_nóg = 4;
                liczba_zwierzat++;
            }

            public Zwierze(string Nazwa, string Gatunok, int Liczba_nóg)
            {
                nazwa_zwierzat = Nazwa;
                gatunok_zwierzat = Gatunok;
                liczba_nóg = Liczba_nóg;
                liczba_zwierzat++;
            }

            public Zwierze (Zwierze zwierze)
            {
                nazwa_zwierzat = zwierze.nazwa_zwierzat;
                gatunok_zwierzat = zwierze.gatunok_zwierzat;
                liczba_nóg = zwierze.liczba_nóg;
                liczba_zwierzat++;
            }

            public void Daj_glos()
            {
                if (gatunok_zwierzat == "kot") { Console.WriteLine($"{gatunok_zwierzat} {nazwa_zwierzat} robi miau miau!\n"); }
                else if (gatunok_zwierzat == "pies") { Console.WriteLine($"{gatunok_zwierzat} {nazwa_zwierzat} robi woof woof!\n"); }
                else if (gatunok_zwierzat == "krow") { Console.WriteLine($"{gatunok_zwierzat} {nazwa_zwierzat} robi muuu muu!\n"); }
                else { Console.WriteLine("Nie wiem jak to zwięrze robi\n"); }
            }

            public static int Liczba()
            {
                return liczba_zwierzat;
            
            }

            
        
        }
    }
}
