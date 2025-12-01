using System;
using System.Reflection;

namespace Lab3
{
    class Program
    {
        //zadanie 4
        public static void Main()
        {
            ComplexNumber c1 = new ComplexNumber (3 , 4);
            ComplexNumber c2 = new ComplexNumber (3 , 4);
            ComplexNumber c3 = new ComplexNumber (5, 7);
           

            Console.WriteLine($"c1 = {c1}"); 
            Console.WriteLine($"c2 = {c1}");
            Console.WriteLine($"c3 = {c3}\n");


            Console.WriteLine($"c1 + c2 = {c1 + c2}"); 
            Console.WriteLine($"c3 - c2 = {c3 - c2}"); 
            Console.WriteLine($"c1 * c2 = {c1 * c2}\n");


            ComplexNumber c4 = (ComplexNumber)c3.Clone();
            Console.WriteLine($"kopia c3 = {c4} \n");


            Console.WriteLine($"c1 jest równe c2? {c1.Equals(c2)}");
            Console.WriteLine($"c2 jest równe c3? {c2.Equals(c3)}\n");


            Console.WriteLine($"c1 == c2 {c1 == c2}"); 
            Console.WriteLine($"c1 != c2 {c1 != c2}"); 
            Console.WriteLine($"c1 == c3 {c1 == c3}"); 
            Console.WriteLine($"c1 != c3 {c1 != c3}\n");
             

            Console.WriteLine($"-c1 = {-c1} \n");

            Console.WriteLine($"|c1| = {c1.Metode()}");

        }
    }

    //zadanie 1/3
    public class ComplexNumber : ICloneable , IEquatable<ComplexNumber>, IModular
    {
        private float re;
        private float im;

        public float Re {  get { return re; } set { re = value; } }
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
            return new ComplexNumber(c1.re + c1.re, c1.im + c1.im);
            
        }

        public static ComplexNumber operator - ( ComplexNumber с1, ComplexNumber с2)
        {
            return new ComplexNumber( с1.re - с2.re, с1.im - с2.im);
        }

        public static ComplexNumber operator * (ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.re * c2.re - c1.im * c2.im, c1.re * c2.im + c1.re * c2.im);
        }

        public object Clone()
        {
            return new ComplexNumber(this.re, this.im);
        }

        public bool Equals( ComplexNumber other) 
        {
            if ( this.re == other.re && this.im == other.im)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(ComplexNumber c1, ComplexNumber c2)
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
        public static bool operator != (ComplexNumber c1, ComplexNumber c2)
        {
            return !(c1 == c2);
        }
        public static ComplexNumber operator - ( ComplexNumber m)
        {
            return new ComplexNumber(-m.re, -m.im);
        }
        public float Metode()
        {
            float rezult = (float) Math.Sqrt(re * re + im * im);
            return  rezult;
        }
    
    }

    //zadanie 2
    public interface IModular
    {
        float Metode();
    }
}