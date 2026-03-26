using System;
using System.Text;

namespace CiagFibonacciego
{
    internal class CiagFibonacciego
    {
        static void Main(string[] args)
        {
            // suma dwóch podanych danych
            // następne liczbny są obliczane otrzymany wyraz dodać poprzedni wyraz 
            // np: a1+a2=a3 a2+a3=a4
            double a = 0;
            double b = 0;
            // Wprowadzenie dwóch danych z który powstanie ciąg
            Console.Write("Podaj liczbe A: ");
            string strA = Console.ReadLine();
            Console.Write("Podaj liczbe B: ");
            string strB = Console.ReadLine();

            try {
                // Konwersja danych
                a = double.Parse(strA);
                b = double.Parse(strB);

                //Tworzymy pętle która powtórzy się 100 razy aby powstało 100 elementów
                //Wyświetlenie danych przed zaczęciem ciągu
                //Console.WriteLine(a);
                //Console.WriteLine(b);
                //Towrzymy pustą tablice do której będziemy przypisywać zmienne
                //Dodajemy dane przed zastosowaniem petli która będzie dodawać następne wyniki do tablicy ciag
                double[] ciag = new double[100];
                ciag[0] = a;
                ciag[1] = b;
                //liczymy od dwójki bo dwa pierwsze miejsca zajmują dane które też są elementem ciągu
                // czyli ciag[0] i ciag[1] są zajęte przez podane dane z nich powstaną następne które wypełnią tablice
                for (int i = 2; i < 100; i++)
                {
                    ciag[i] = a+b;
                    // zmiana na nastepny wyraz
                    a = b;
                    b = ciag[i];
                    //b = c;
                }
                foreach (double x in ciag)
                   Console.WriteLine(x);
                Console.WriteLine(ciag.Length);


            }
            catch {
                Console.WriteLine("Podano zły typ danych");
            }

        }
    }
}