using System;

namespace Lab4
{
    class Program
    {
        public static void Main()
        {
        //zadanie 2
            ComplexNumber[] liczby = new ComplexNumber[]
            {
                new ComplexNumber(3, -6),
                new ComplexNumber(9, 5),
                new ComplexNumber(20, 4),
                new ComplexNumber(11, 1),
                new ComplexNumber(15, 29),
            };
            
            Console.WriteLine("Przed sortowaniem ");
            foreach(ComplexNumber liczba in liczby)
            {
                Console.WriteLine($"{liczba.Re} + {liczba.Im}i");
            }
            
            Array.Sort(liczby);

            Console.WriteLine("\nPo sortowaniu (według modułu):");
            foreach (ComplexNumber liczba in liczby)
            {
                Console.WriteLine($"{liczba.Re} + {liczba.Im}i");
            }

            ComplexNumber min = liczby.Min();
            Console.WriteLine($"\nMinimalna liczba: {min}");

            ComplexNumber max = liczby.Max();
            Console.WriteLine($"\nMaksymalna liczba: {max}");


            ComplexNumber[] przefiltrowane = liczby.Where(c => c.Im >= 0).ToArray();

            Console.WriteLine("\nLiczby bez ujemnej części urojonej:");
            foreach (ComplexNumber liczba in przefiltrowane)
            {
                Console.WriteLine(liczba);
            }

         //zadanie 3
            List<ComplexNumber> lista = new List<ComplexNumber>
            {
                new ComplexNumber(5, 7),
                new ComplexNumber(4, -12),
                new ComplexNumber(34, 89),
                new ComplexNumber(22, 2),
                new ComplexNumber(36, 13),
            };

            Console.WriteLine("\nPrzed sortowaniem:");
            foreach (ComplexNumber liczba in lista)
            {
                Console.WriteLine(liczba);
            }

            lista.Sort();

            Console.WriteLine("\nLista po sortowaniu (według modułu):");
            foreach (ComplexNumber liczba in lista)
            {
                Console.WriteLine(liczba);
            }

            ComplexNumber minLista = lista.Min();
            Console.WriteLine($"\nMinimalna liczba z listy: {minLista}");

            ComplexNumber maxLista = lista.Max();
            Console.WriteLine($"\nMaksymalna liczba z listy: {maxLista}");

            List<ComplexNumber> przefiltrowaneLista = lista.Where(c => c.Im >= 0).ToList();

            Console.WriteLine("\nLiczby bez ujemnej części urojonej:");
            foreach (ComplexNumber liczba in przefiltrowaneLista)
            {
                Console.WriteLine(liczba);
            }

            Console.WriteLine("\nUsunięcie drugiego elementu:");
            lista.RemoveAt(1);
            foreach (ComplexNumber liczba in lista)
            {
                Console.WriteLine(liczba);
            }

            Console.WriteLine("\nUsunięcie najmniejszego elementu:");
            ComplexNumber najmniejszy = lista.Min();
            lista.Remove(najmniejszy);
            foreach (ComplexNumber liczba in lista)
            {
                Console.WriteLine(liczba);
            }

            Console.WriteLine("\nWyczyszczenie listy:");
            lista.Clear();
            Console.WriteLine($"Liczba elementów w liście: {lista.Count}");
            foreach (ComplexNumber liczba in lista)
            {
                Console.WriteLine(liczba);
            }

         //zadanie 4
            HashSet<ComplexNumber> zbior = new HashSet<ComplexNumber>();

            ComplexNumber z1 = new ComplexNumber(9, 2);
            ComplexNumber z2 = new ComplexNumber(67, 31);
            ComplexNumber z3 = new ComplexNumber(9, 5);
            ComplexNumber z4 = new ComplexNumber(56, -2);
            ComplexNumber z5 = new ComplexNumber(-5, 89);

            zbior.Add(z1);
            zbior.Add(z2);
            zbior.Add(z3);
            zbior.Add(z4);
            zbior.Add(z5);

            Console.WriteLine("\nZawartość zbioru:");
            foreach (ComplexNumber liczba in zbior)
            {
                Console.WriteLine(liczba);
            }
            Console.WriteLine($"Liczba elementów w zbiorze: {zbior.Count}");

            Console.WriteLine("\nMinimum ze zbioru:");
            ComplexNumber minZbior = zbior.Min();
            Console.WriteLine(minZbior);

            Console.WriteLine("\nMaksimum ze zbioru:");
            ComplexNumber maxZbior = zbior.Max();
            Console.WriteLine(maxZbior);

            Console.WriteLine("\nSortowanie zbioru:");
            var posortowanyZbior = zbior.OrderBy(c => c.Module()).ToList();
            foreach (ComplexNumber liczba in posortowanyZbior)
            {
                Console.WriteLine(liczba);
            }

            Console.WriteLine("\nFiltrowanie zbioru (Im >= 0):");
            var przefiltrwanyZbior = zbior.Where(c => c.Im >= 0).ToList();
            foreach (ComplexNumber liczba in przefiltrwanyZbior)
            {
                Console.WriteLine(liczba);
            }

         //zadanie 5
            Dictionary<string, ComplexNumber> slownik = new Dictionary<string, ComplexNumber>();
            slownik.Add("z1", new ComplexNumber(6, 7));
            slownik.Add("z2", new ComplexNumber(1, 2));
            slownik.Add("z3", new ComplexNumber(6, 7));
            slownik.Add("z4", new ComplexNumber(1, -2));
            slownik.Add("z5", new ComplexNumber(-5, 9));
            
            Console.WriteLine("\nWszystkie elementy słownika:");
            foreach (var para in slownik)
            {
                Console.WriteLine($"({para.Key}, {para.Value})");
            }

            Console.WriteLine("\nWszystkie klucze:");
            foreach (var klucz in slownik.Keys)
            {
                Console.WriteLine(klucz);
            }

            Console.WriteLine("\nWszystkie wartości:");
            foreach (var wartosc in slownik.Values)
            {
                Console.WriteLine(wartosc);
            }

            Console.WriteLine("\nCzy istnieje klucz 'z6'?");
            Console.WriteLine(slownik.ContainsKey("z6"));

            Console.WriteLine("\nMinimum ze słownika:");
            ComplexNumber minSlownik = slownik.Values.Min();
            Console.WriteLine(minSlownik);

            Console.WriteLine("\nMaksimum ze słownika:");
            ComplexNumber maxSlownik = slownik.Values.Max();
            Console.WriteLine(maxSlownik);

            Console.WriteLine("\nFiltrowanie słownika (Im >= 0):");
            var przefiltrwanySlownik = slownik.Where(p => p.Value.Im >= 0).ToList();
            foreach (var para in przefiltrwanySlownik)
            {
                Console.WriteLine($"({para.Key}, {para.Value})");
            }

            Console.WriteLine("\nUsunięcie elementu 'z3':");
            slownik.Remove("z3");
            foreach (var para in slownik)
            {
                Console.WriteLine($"({para.Key}, {para.Value})");
            }

            Console.WriteLine("\nUsunięcie drugiego elementu:");
            var drugiKlucz = slownik.Keys.ElementAt(1);
            slownik.Remove(drugiKlucz);
            foreach (var para in slownik)
            {
                Console.WriteLine($"({para.Key}, {para.Value})");
            }

            Console.WriteLine("\nWyczyszczenie słownika:");
            slownik.Clear();
            Console.WriteLine($"Liczba elementów w słowniku: {slownik.Count}");
            foreach (var para in slownik)
            {
                Console.WriteLine($"({para.Key}, {para.Value})");
            }
        }
    }
    public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModular, IComparable<ComplexNumber>
    {
        private float re;
        private float im;

        public float Re { get { return re; } set { re = value; } }
        public float Im { get { return im; } set { im = value; } }

        public ComplexNumber(float RE, float IM)
        {
            re = RE;
            im = IM;
        }
        public override string ToString()
        {
            if (im >= 0)
            {
                return $"{re} + {im}i";
            }
            else
            {
                return $"{re} - {Math.Abs(im)}i";
            }
        }

        public static ComplexNumber operator + (ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.re + c2.re, c1.im + c2.im);

        }

        public static ComplexNumber operator -(ComplexNumber с1, ComplexNumber с2)
        {
            return new ComplexNumber(с1.re - с2.re, с1.im - с2.im);
        }

        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.re * c2.re - c1.im * c2.im, c1.re * c2.im + c2.re * c1.im);
        }

        public object Clone()
        {
            return new ComplexNumber(this.re, this.im);
        }

        public bool Equals(ComplexNumber other)
        {
            if (this.re == other.re && this.im == other.im)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator == (ComplexNumber c1, ComplexNumber c2)
        {
            if (ReferenceEquals(c1, c2))
            {
                return true;
            }
            else if (c1 is null || c2 is null)
            {
                return false;
            }
            if (c1.re != c2.re || c1.im != c2.im)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool operator !=(ComplexNumber c1, ComplexNumber c2)
        {
            return !(c1 == c2);
        }
        public static ComplexNumber operator -(ComplexNumber m)
        {
            return new ComplexNumber(-m.re, -m.im);
        }
        public float Module()
        {
            float rezult = (float)Math.Sqrt(re * re + im * im);
            return rezult;
        }

        public int CompareTo (ComplexNumber other)
        {
            if (other == null) return 1;
            else if (this.Module() > other.Module()) return 1;
            else if (this.Module() < other.Module()) return -1;
            else return 0;

        }
        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber)
            {
                return this.Equals((ComplexNumber)obj);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return re.GetHashCode() ^ im.GetHashCode();
        }


    }
    public interface IModular
    {
        float Module();
    }


}
