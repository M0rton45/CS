namespace Zadanie4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] tablicaW = new int[100,100]; // tablica dwuwymiarowa
            //pierwsza tablica jest jakby główną
            //do tej głównej tablicy przypisuje sie elementy drugie
            //np dla int[2,4]; tablica ma dwa glowne int-y
            //czyli dla 1 ma 4 tablice do przechowywania danych
            //tak samo 2 ma 4 tablice do przechowywania danych
            int p = 2; // liczba parzysta
            // nastepne bedziemy tworzyc przez: p+=2
            //Console.WriteLine(tablicaW.Length);
            //Console.WriteLine(tablicaW.GetLength(0)); pobiera dlugosc tablicy glownej
            //Console.WriteLine(tablicaW.GetLength(1)); pobiera dlugosc tablicy przechowującej
            for (byte i = 0; i < tablicaW.GetLength(0); i++) // wykonanie petli tyle razy co elementow w tablicy "głównej"
            {
                for (byte j = 0; j < tablicaW.GetLength(1); j++) // wypełnianie tablicy która należy do głównej
                {
                    tablicaW[i, j] = p;
                    p += 2;
                }
            }
            // Wyświetlenie elementów tablic
            for (byte i = 0; i < tablicaW.GetLength(0); i++)
            {
                for (byte j = 0; j < tablicaW.GetLength(1); j++)
                {
                    // Tablica G - główna
                    // Tablica P - przechowująca
                    // Zastosowanie if-a dla przejrzystego odczytu
                    if (j % 2 == 0) { Console.Write($"TablicaG nr.{i} TablicaP nr.{j} ma wartosc {tablicaW[i, j]}. "); }
                    else { Console.WriteLine($"TablicaG nr.{i} TablicaP nr.{j} ma wartosc {tablicaW[i, j]}. "); }
                }
            }
        }
        
    }
}
