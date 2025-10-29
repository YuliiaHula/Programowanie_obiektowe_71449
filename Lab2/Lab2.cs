using System;

namespace Lab1
{
    class Program
    {
        public static void Main()
        {
            Zwierze Pies = new Pies("Burek");
            Zwierze Kot = new Kot("Filemon");
            Zwierze Waz = new Waz("Pioter");
            Zwierze.powiedz_cos(Pies
            Zwierze.powiedz_cos(Kot);
            Zwierze.powiedz_cos(Waz);
        }
    }
    class Zwierze
    {
        protected string nazwa;
        public Zwierze(string nazwa)
        {
            this.nazwa = nazwa;
        }
        public virtual void daj_glos()
        {
            Console.WriteLine();
        }
        public static void powiedz_cos(Zwierze z) //wywoływanie metody daj_glos
        {
            z.daj_glos();
        }
    }
    class Pies : Zwierze
    {
        Pies(string nazwa) : base(nazwa) { }
        public override void daj_glos()
        {
            Console.WriteLine($"woof woof! {nazwa}");
        }
    }
    class Kot : Zwierze
    {
        Kot(string nazwa) : base(nazwa) { }
        public override void daj_glos()
        {
            Console.WriteLine($"miau miau! {nazwa}");
        }
    }
    class Waz : Zwierze
    {
        Waz(string nazwa) : base(nazwa) { }
        public override void daj_glos()
        {
            Console.WriteLine($"ssssss! {nazwa}");
        }
    }
}
}