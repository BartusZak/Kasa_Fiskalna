using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa_Fiskalna
{
    class Program
    {
        static void Main(string[] args)
        {
            Aplikacja nowy = new Aplikacja();
           
            while (Aplikacja.klawisz != ConsoleKey.E)
            {
                nowy.WczytajKlawisz();
                nowy.WykonajDzialanie();
                Console.Clear();
            }
        }
    }
}
