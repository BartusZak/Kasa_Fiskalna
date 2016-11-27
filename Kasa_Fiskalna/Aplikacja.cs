using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Kasa_Fiskalna
{
    class Aplikacja : Koszyk
    {
        public static ConsoleKey klawisz;

        public void WczytajKlawisz()
        {
            Console.WriteLine(@"Dzień dobry!
Co Chcesz zrobić? Naciśnij odpowiedni klawisz.
Legenda:
P - dodaj produkt do koszyka,
K - skopiuj ostatnio wprowadzony produkt,
Z - pokaz zawartosc koszyka,
S - pokaz sume do zaplaty,
X - skasuj z listy (musisz znac wczesniej numer na liscie),
W - wydrukuj paragon,
N - dodaj nowy koszyk,
E - zakoncz dzialanie programu.");

            klawisz = Console.ReadKey().Key;
            Console.Clear();
        }

        public void WykonajDzialanie()
        {
            
                switch (klawisz)
                {
                    case ConsoleKey.P:
                        {
                            Console.WriteLine("Nazwa:");
                            string nazwa_f = Console.ReadLine();

                            Console.WriteLine("Cena Jednostkowa:");
                            double cenaJednostkowa_f = double.Parse(Console.ReadLine());

                            Console.WriteLine("Ilość:");
                            int ilosc_f = int.Parse(Console.ReadLine());

                            zakupy.Add(new Produkt(nazwa_f, cenaJednostkowa_f, ilosc_f));
                        Console.WriteLine("Dodano " + nazwa_f + " do koszyka!");
                        Thread.Sleep(2000);
                        break;
                        }
                    case ConsoleKey.K:
                        {                   
                        // zakupy.Select(item => (Produkt)item.Clone()).ToList(); <-- kopiuje cala liste

                        zakupy.Add((Produkt)zakupy.Last().Clone());
                        Console.WriteLine("Skopiowano {0}", zakupy.Last().nazwa);
                        Thread.Sleep(2000);
                            break;
                        }
                    case ConsoleKey.Z:
                        {
                        Console.WriteLine("|{0,-10}|{1,-10}|{2,-10}|{3,-10}|", "Nazwa", "Cena jedn.", "Ilosc", "Lacznie");
                        foreach (var e in zakupy)
                            {                                             
                            Console.WriteLine("|{0,-10}|{1,-10}|{2,-10}|{3,-10}|",e.nazwa, e.cenaJednostkowa, e.ilosc, e.ilosc * e.cenaJednostkowa);                        
                            }
                        Console.WriteLine("\nNacisnij dowolny przycisk, aby wrocic do menu...");
                        Console.ReadKey();
                        break;
                        }
                
            }
        }
    }
}
