using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa_Fiskalna
{
    class Produkt :ICloneable
    {
        public string nazwa;
        public double cenaJednostkowa;
        public int ilosc;

        public Produkt()
        {
            nazwa = "brak nazwy";
            cenaJednostkowa = 0.0;
            ilosc = 0;
        }

      public Produkt(string nazwa_k,double cenaJednostkowa_k,int ilosc_k)
        {
            this.nazwa = nazwa_k;
            this.cenaJednostkowa = cenaJednostkowa_k;
            this.ilosc = ilosc_k;
        }

        public Object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
