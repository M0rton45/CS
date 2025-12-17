namespace WiezaHanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Użytkownik podaje liczbę krążków do przeniesienia
            Console.Write("Podaj liczbę krążków: ");
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n > 0)
                {
                    Console.Write("Wybierz metodę: ");
                    char method = char.Parse(Console.ReadLine());
                    //Console.WriteLine(method);
                    //Obliczanie ilości ruchów wzorem 2 do potęgi n, minus 1
                    long ruchy = (long)Math.Pow(2, n)-1; // Obliczanie ruchów do sposobu iteracyjnego

                    //Wywołanie funkcji Hanoi z parametrami
                    // n-podana liczba krażków
                    // 'A' - wieża początkowa | 'C' - wieża końcowa | 'B' - wieża pomocnicza
                    // Przeniesienie z A na C
                    // Bo Hanoi(n, start, end, help)
                    if (method == 'R' || method == 'r') 
                    {
                        Console.WriteLine("Wybrano metodę rekurencyjna");
                        Hanoi(n, 'A', 'C', 'B'); 
                    }
                    //Hanoi(n, 'A', 'C', 'B');
                    else if (method == 'I' || method == 'i') HanoiI(n,ruchy);
                    else
                    {
                        Console.WriteLine("Nie ma takiej metod wybierz I,i (iteracyjna) lub R,r (rekurencyjna)");
                        return;
                    }

                        // Hanoi(n, 'A', 'B', 'C'); W tym przypadku wieżą docelową jest B czyli przeniesienie z A na B
                        // Czyli 'A' to dalej początkowa ale 'B' to wieża końcowa a 'C' to pomocnicza
                        Console.WriteLine("\nGotowe");
                    Console.WriteLine($"Wykonana liczba ruchów to: {ruchy}, dla {n} krążków");
                    Console.ReadKey();
                } else
                {
                    //Gdy wprowadzono liczbe mniejszą lub równą 0
                    Console.WriteLine("Podaj liczbę dodatnią");
                }
            }
            catch
            {
                //Gdy nie wprowadzono liczby tylko np: literę
                Console.WriteLine("Podaj liczbę naturalną");
            }
        }
        
        static void Hanoi(int n, char start, char end, char help)
        // n-ilosc krążków | start-wieża początkowa | end-wieża końcowa | help-wieża pomocnicza 
        {
            if (n == 1) //Warunek zakończenia rekurencji, jeżeli został jeden krążek to może go przenieść jedną komendą
            {
                Console.WriteLine($"Przenieś krążęk z {start} na {end}");
                return;
            }

            //Przeniesienie (n-1)krążków z startu na help
            //Czyli z początkowej na pomocniczą mniejszy krążek
            Hanoi(n - 1, start, help, end);

            //Przeniesienie największego krążka na end
            //Czyli z początkowej na końcową bo ten krazek jest większy od tego zdjętego
            Console.WriteLine($"Przenieś krążek z {start} na {end}");

            //Przeniesienie (n-1)krążków z help na end
            //Czyli z pomocniczej ten mniejszy jest zakładany na większy dany na końcowej
            Hanoi(n - 1, help, end, start);

        }
        static void HanoiI(int n,long ruchy)
        {
            Console.WriteLine("Wybrano sposób Iteracyjny");
            //Console.WriteLine("Liczba krążków to " + n);
            //Console.WriteLine("Liczba ruchów to "+ruchy);

            //Tworzenie 3 'wież' do których swobodnie będzie można dodawać i odejmować krążki za pomocą funckji push,pop

            //A - startowa
            //B - pomocnicza
            //C - końcowa/docelowa

            Stack<int> A = new Stack<int>();
            Stack<int> B = new Stack<int>();
            Stack<int> C = new Stack<int>();

            //Wypełnianie wieży 'startowej' czyli n liczbą krążków
            for (int i = n; i > 0; i--) A.Push(i);
            //foreach (var i in A)
            //{
            //    Console.WriteLine(i);
            //}

            //Do zmiany kolejności w wykonywaniu pętli gdy parzyste aby utrzymać poprawność kroków

            Stack<int> start = A, help = B, end = C;
            if (n % 2 == 0) (help, end) = (end, help);

            //Ruchy są powtarzalne w cyklu trzech możliwych ruchów
            //i%3 to jest nr kroku do podjęcia aby przenieść (wieże A na C)

            for (long i = 1; i <= ruchy; i++)
            {
                if (i % 3 == 1)
                    Przenies(start, end, "A", "C");
                else if (i % 3 == 2)
                    Przenies(start, help, "A", "B");
                else
                    Przenies(help, end, "B", "C");
            }
        }
        //Funkcja przenoszenia sprawdza do którego stosu może dodać i odjąć (czyli zdjąć i założyć krążek)
        static void Przenies(Stack<int> from, Stack<int> to, string fromName, string toName)
        {
            if (from.Count == 0) // jeśli źródło puste, bierz z celu
            {
                from.Push(to.Pop());
                Console.WriteLine($"Przenieś krążek z {toName} na {fromName}");
            }
            else if (to.Count == 0) // jeśli cel pusty, bierz ze źródła
            {
                to.Push(from.Pop());
                Console.WriteLine($"Przenieś krążek z {fromName} na {toName}");
            }
            else if (from.Peek() < to.Peek()) // mniejszy 'krążek' na większy (ze źródła do celu)
            {
                to.Push(from.Pop());
                Console.WriteLine($"Przenieś krążek z {fromName} na {toName}");
            }
            else // większy 'krążek' na mniejszy → bierz z celu (z celu do źródła)
            {
                from.Push(to.Pop());
                Console.WriteLine($"Przenieś krążek z {toName} na {fromName}");
            }
        }
    }
}
