using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSMYO4
{
    static class Market
    {
        public static List<RaftakiUrunSinifi> raftakiUrunler = new List<RaftakiUrunSinifi>();
        public static List<UrunSinifi> depodakiUrunler = new List<UrunSinifi>();



        public static void raftakiUrunlerYazdir()
        {
            foreach (RaftakiUrunSinifi urun2 in Market.raftakiUrunler)
            {
                if (urun2.stok > 0)
                {
                    Console.WriteLine(urun2.barkod + " - " + urun2.urunbilgisi.isim + " Fiyat:" + urun2.fiyat + " Stok: " + urun2.stok);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(urun2.barkod + " - " + urun2.urunbilgisi.isim + " Fiyat:" + urun2.fiyat + " Stok: " + urun2.stok);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }

        public static void raftakiUrunStokGuncelle()
        {
            raftakiUrunlerYazdir();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Stok güncellemek istediğiniz ürünü seçiniz.");
            int urunKonumu = Convert.ToInt32(Console.ReadLine());


            RaftakiUrunSinifi urun = Market.raftakiUrunler[urunKonumu - 1];


            Console.WriteLine("Eklemek istediğiniz stok miktarını giriniz.");
            int stok = Convert.ToInt32(Console.ReadLine());


            urun.stok += stok;


            Console.WriteLine(urun.urunbilgisi.isim+" ürününe "+stok+" adet stok eklenmiştir.");
           
            Console.WriteLine("-----------------------------");
            raftakiUrunlerYazdir();
            Console.WriteLine("-----------------------------");
        }

        public static void raftakiUrunFiyatGuncelle()
        {
            raftakiUrunlerYazdir();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Fiyat güncellemek istediğiniz ürünü seçiniz.");
            int urunKonumu = Convert.ToInt32(Console.ReadLine());


            RaftakiUrunSinifi urun = Market.raftakiUrunler[urunKonumu - 1];


            Console.WriteLine("Koymak istediğiniz fiyatı giriniz.");
            int fiyat = Convert.ToInt32(Console.ReadLine());


            urun.fiyat = fiyat;


            Console.WriteLine(urun.urunbilgisi.isim + " ürününün fiyatı " + fiyat + " olarak güncellenmiştir.");

            Console.WriteLine("-----------------------------");
            raftakiUrunlerYazdir();
            Console.WriteLine("-----------------------------");
        }

        public static bool PersonelGiris(string kullaniciadi, string sifre)
        {
            return (kullaniciadi == "admin" && sifre == "123") ? true : false;
        }

    }
}
