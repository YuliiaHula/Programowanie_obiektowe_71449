using System;

namespace Lab2
{
    //zadanie 7/10/15
    class Program_l2
    {
        public static void Main()
        {
            Pies pies1 = new Pies("Cezar");
            Kot kot1 = new Kot("Bonia");
            Waz waz1 = new Waz("Kola");
            Zwierze.powiedz_cos(pies1);
            Zwierze.powiedz_cos(kot1);
            Zwierze.powiedz_cos(waz1);

            Piekarz piekarz1 = new Piekarz();
            piekarz1.Pracuj();

            A a1 = new A();
            B b1 = new B();
            C c1 = new C();

        }
    }

    //zadanie 1/6/7
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
        public static void powiedz_cos(Zwierze z)
        {
            z.daj_glos();
            Console.WriteLine($"Typ obiektu: {z.GetType().Name}\n");
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

    //zadanie 8
    abstract class Pracownik
    {
        public abstract void Pracuj();
    }

    //zadanie 9
    class Piekarz : Pracownik
    {
        public override void Pracuj()
        {
            Console.WriteLine("Trwa pieczenie… \n");
        }
    }

    //zadanie 12
    class A
    {
        public A()
        {
            Console.WriteLine("To jest konstruktor A ");
        }
    }

    //zadanie 13
    class B : A
    {
        public B()
        {
            Console.WriteLine("To jest konstuktor B ");
        }
    }

    //zadnie 14
    class C : B
    {
        public C()
        {
            Console.WriteLine("To jest konstruktor C ");
        }
    }


}