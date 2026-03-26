using System.ComponentModel.Design;

namespace wydawanieReszty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint W; //wartość która bedzie rozmieniana
            ushort licznik=0;
            byte [] nominaly = [200, 100, 50, 20, 10]; // Nasze dzielniki którymi będziemy rozmieniać
            ushort [] ilosc = new ushort[nominaly.Length]; // Gdy chcemy powiekszyć dane do rozmieniania 
            Console.Write("Podaj wartość do rozmienienia ");
            string strW = Console.ReadLine();
            try
            {
                //Dzięki uint wartości ujemne uznawane są za błędne
                W = uint.Parse(strW); //Konwersja
                    Console.WriteLine($"Wartość wynosi {W}");
                // Przy rozszerzaniu bazy dostępnych dzielników nie musimy sie martwić 
                if (W % nominaly.Last() == 0)//Sprawdzanie podzielnosci bez reszty najmniejszego nominału
                {
                    // jesli jest podzielny bez reszty przez najmnijeszy to da sie go rozmienić chociazby najmniejszymi
                    Console.WriteLine("Wartość jest podzielna przez najmniejszy nominał, możliwa jest wymiana");
                    int n = 0; // zmienna do obslugi tablic
                    while (n < nominaly.Length) // przejscie po całej tablicy 
                    {
                        if (W >= nominaly[n]) 
                        {
                            W -= nominaly[n]; // aktualicaja wartości, bo jest wieksza lub rowna danemu nominalowi
                            licznik++;
                            ilosc[n] = licznik; // aktualizacja wartości "ile sie mieści np 200 w podanej wartośći"
                        }
                        else
                        {
                            //Nie mieści się wiecej danego dzielnika i przechodzi o komórke dalej 
                            licznik = 0;
                            n++; 
                        }
                    }
                    //Wyświetlenie ile razy rozmieniono daną liczbe
                    for (byte i = 0; i < nominaly.Length; i++)
                    {
                        Console.WriteLine($"rozmieniono {nominaly[i]} tyle razy: {ilosc[i]}.");
                    }
                }
                else //gdy wartosc wprowadzono nie jest mozliwa do rozmienienia za pomoca aktualnych nominalow
                {
                    Console.WriteLine("Wprowadzonej wartości nie da się rozmienić");
                }
            }
            catch
            {
                Console.WriteLine($"Wprowadz złe dane");
            }
        }
    }
}
