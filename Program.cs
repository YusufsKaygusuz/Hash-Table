using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_ClosedAddress_
{
    class Program
    {
        class Dugum
        {
            public int anahtar;
            public Dugum pSonraki;

            public Dugum()
            {
            }

            public Dugum(int anahtar)
            {
                this.anahtar = anahtar;
                pSonraki=null;
            }

            public override string ToString()
            {
                return anahtar.ToString();
            }
        }

        class HashTable
        {
            public const int Max = 10;
            public Dugum[] veri = new Dugum[Max];

            public HashTable()
            {
                for (int i = 0; i < Max; i++)
                {
                    veri[i] = null;
                }
            }

            public void Ekle(int Anahtar)
            {
                Dugum pYeni = new Dugum(Anahtar);

                int mod = Anahtar % Max;

                if(veri[mod] == null)
                {
                    veri[mod] = pYeni;
                    return;
                }
                // Eğer aynı düğümde birden fazla eleman varsa
                Dugum pTemp = veri[mod];

                while (pTemp.pSonraki != null)
                    pTemp = pTemp.pSonraki;

                pTemp.pSonraki = pYeni;

            }

            public Dugum Getir(int Anahtar)
            {
                int mod = Anahtar % Max;
                Dugum pTemp = veri[mod];

                while(pTemp!=null)
                {
                    if (pTemp.anahtar == Anahtar)
                        return pTemp;

                    pTemp = pTemp.pSonraki;
                }
                return null;
            }

            public bool Cikar(int Anahtar)
            {
                int Mod = Anahtar % Max;

                // Eleman yoksa...
                if (veri[Mod] == null)
                    return false;

                // Sadece 1 eleman var ve haliyle bu elemanın sonraki elemanı yoksa...
                if(veri[Mod].pSonraki == null)

                {
                    if(veri[Mod].anahtar == Anahtar)
                    {
                        veri[Mod] = null;
                        return true;
                    }
                    return false;
                }

                // En az 2 elemandan oluşuyorsa ve bizden istenen değere ulaşmak istersek...
                if(veri[Mod].anahtar == Anahtar)
                {
                    veri[Mod] = veri[Mod].pSonraki;
                    return true;
                }

                Dugum pTemp = veri[Mod];
                while(pTemp.pSonraki != null)
                {
                    if (pTemp.pSonraki.anahtar == Anahtar)
                    {
                        pTemp.pSonraki = pTemp.pSonraki.pSonraki;
                        return true;
                    }
                    pTemp = pTemp.pSonraki;
                }
                return false;
            }
        }


        static void Main(string[] args)
        {
            HashTable hashTable = new HashTable();

            hashTable.Ekle(32);
            hashTable.Ekle(22);
            hashTable.Ekle(32);
            hashTable.Ekle(19);
            hashTable.Ekle(43);
            hashTable.Ekle(1);
            hashTable.Ekle(16);

            hashTable.Cikar(32);

            /*
            foreach (object i in hashTable.ToString())
            {
                Console.WriteLine(i);
            }*/
            foreach (object j in hashTable.veri)
            {
                Console.WriteLine(j);
            }
            

            Console.ReadLine();

        }
    }
}
