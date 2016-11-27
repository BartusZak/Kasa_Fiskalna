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
                        if (zakupy.Any())
                        {
                            zakupy.Add((Produkt)zakupy.Last().Clone());
                            Console.WriteLine("Skopiowano {0}", zakupy.Last().nazwa);
                        }
                        else
                        {
                            Console.WriteLine("Nie ma czego kopiowac...");
                        }
                        Thread.Sleep(2000);
                            break;
                        }
                    case ConsoleKey.Z:
                        {
                        int lp=0;
                        Console.WriteLine("|{0,-6}|{1,-10}|{2,-10}|{3,-10}|{4,-10}|", "Lp.","Nazwa", "Cena jedn.", "Ilosc", "Lacznie");
                        foreach (var e in zakupy)
                            {                                             
                            Console.WriteLine("|{0,-6}|{1,-10}|{2,-10}|{3,-10}|{4,-10}|", lp++,e.nazwa, e.cenaJednostkowa, e.ilosc, e.ilosc * e.cenaJednostkowa);                        
                            }
                        Pauza();
                        break;
                        }
                case ConsoleKey.S:
                    double suma = 0.0;
                    foreach (var e in zakupy)
                    {
                        suma += e.ilosc * e.cenaJednostkowa; 
                    }
                    Console.WriteLine("Do zapłaty: {0} zł", suma);
                    Pauza();
                    break;
                case ConsoleKey.X:
                    {
                        Console.WriteLine("Podaj Lp. przedmiotu do usunięcia:");
                        int usun = int.Parse(Console.ReadLine());

                        Console.WriteLine("Usuwam.");
                        zakupy.RemoveAt(usun);
                        Thread.Sleep(2000);
                        break;
                    }
                case ConsoleKey.W:
                    { 
                    string Do_pliku = String.Format("|{0,-6}|{1,-10}|{2,-10}|{3,-10}|{4,-10}|", "Lp.","Nazwa", "Cena jedn.", "Ilosc", "Lacznie");
                    string Do_pliku2 = "";
                    string Do_pliku3 = "";
                    int lp_plik=0;
                    double suma_plik = 0.0;

                    foreach(var e in zakupy)
                    {
                        suma_plik += e.ilosc * e.cenaJednostkowa;
                        Do_pliku2 += String.Format("|{0,-6}|{1,-10}|{2,-10}|{3,-10}|{4,-10}|", lp_plik++,e.nazwa, e.cenaJednostkowa, e.ilosc, e.ilosc* e.cenaJednostkowa);
                        Do_pliku2 += System.Environment.NewLine;
                    }

                    Do_pliku3 += String.Format("Do zapłaty: {0} zł", suma_plik);
     
                    File.CreateText(DateTime.Now.ToString("dd MM yyyy HH mm ss") + (".txt")).Close();                   
                    File.WriteAllText(DateTime.Now.ToString("dd MM yyyy HH mm ss")+(".txt"), Do_pliku + System.Environment.NewLine + Do_pliku2 + System.Environment.NewLine + Do_pliku3);

                    Console.WriteLine("Zapisano koszyk w pliku tekstowym!");
                    Thread.Sleep(2000);
                        Console.WriteLine("Czyszczę koszyk..");
                        zakupy.Clear();
                        Thread.Sleep(2000);
                        break;
                    }
                case ConsoleKey.N:
                    {
                        Console.WriteLine("Czyszcze koszyk..");
                        zakupy.Clear();
                        Thread.Sleep(2000);
                        break;
                    }

            }
        }
    }
}
