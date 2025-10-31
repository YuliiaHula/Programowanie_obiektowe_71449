using System;

namespace Lab2
{
    class Program
    {
        public static void Main()
        {
            Pies pies1= new Pies ("Cezar");
            Kot kot1 = new Kot("Bonia");
            Waz waz1 = new Waz("Kola");
            Zwierze.powiedz_cos(pies1);
            Zwierze.powiedz_cos(kot1);
            Zwierze.powiedz_cos(waz1);

        }
    }

    //zadanie 1/6
    class Zwierze
    {
        protected string nazwa;
        public Zwierze(string nazwa_zwierzat)
        {
            nazwa = nazwa_zwierzat;
        }
        public virtual void daj_glos()
        {
            Console.WriteLine();
        }
        public static void powiedz_cos(Zwierze z) //wywoływania metodę daj_glos()
        {
            z.daj_glos();
        }
    }

    //zadanie 2/5
    class Pies : Zwierze
    {
        public Pies(string nazwa) : base(nazwa) { } 
        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi woof woof!");
        }

    }

    //zadanie 3/5
    class Kot : Zwierze
    {
        public Kot(string nazwa) : base(nazwa) { }
        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi miau miau! ");
        }
    }

    //zadanie 4/5
    class Waz : Zwierze
    {
        public Waz(string nazwa) : base(nazwa) { }
        public override void daj_glos()
        {
            Console.WriteLine($"{nazwa} robi ssssssss!");
        }
    }
    
}
