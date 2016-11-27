using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa_Fiskalna
{
    class Koszyk : Produkt
    { 
        public List<Produkt> zakupy = new List<Produkt>();
             
        protected internal void Pauza()
        {
            Console.WriteLine("\nNacisnij dowolny przycisk, aby wrocic do menu...");
            Console.ReadKey();
        }
     
        
      
    }
}
