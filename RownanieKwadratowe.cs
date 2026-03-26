namespace RownanieKwadratowe
{
    internal class RownanieKwadratowe
    {
        static void Main(string[] args)
        {
            float a = 0.0f, b = 0.0f, c = 0.0f; //Współczynnik równania
            //Wprowadzanie wartości
            Console.WriteLine("Podaj liczbe A");
            string strA = Console.ReadLine();
            Console.WriteLine("Podaj liczbe B");
            string strB = Console.ReadLine();
            Console.WriteLine("Podaj liczbe C");
            string strC = Console.ReadLine();


            try
            {
                //Konwersja
                a = float.Parse(strA);
                b = float.Parse(strB);
                c = float.Parse(strC);

                

                if (a == 0) // funkcja liniowa bx+c
                {
                    Console.WriteLine("Podane rownanie jest funkcja liniowa, wzor:" + b + "x+" + c);
                }
                //Jeszcze dwa że b==0 i
                //c==0 nieskonczenie wiele rozwiazan
                //albo
                //c!=0 nie ma rozwizan
                //na koniec x= -c/b
                else // funckja ax2+bx+c;
                {
                    double delta = b * b - 4 * a * c;
                    Console.WriteLine("delta wynosi: " + delta);
                    if (delta > 0) // dwa pierwiastki 
                    {
                        double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                        double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                        Console.WriteLine("Pierwiastki rzeczywiste rownania kwadratowego to x1 = " + x1.ToString("F2") + " oraz x2 = " + x2.ToString("F2"));
                        //dokładność do dwóch mijesc po przecinku
                    }
                    else if (delta == 0) // jeden podwójny pierwiastek
                    {
                        double x0 = -b / (2 * a);
                        Console.WriteLine("Rownanie ma jedno podwojny pierwiastek rzeczywisty x0 = " + x0.ToString("F2"));
                    }
                    else // delta ujemna
                    {
                        Console.WriteLine("Rownanie nie ma pierwiastkow rzeczywistych poniewaz delta <0");
                    }
                }
            }
            catch // wprowadzone wartosci nie sa liczbami
            {
                Console.WriteLine("Wprowadzono bledne wartosci");
            }

        }
    }
}
