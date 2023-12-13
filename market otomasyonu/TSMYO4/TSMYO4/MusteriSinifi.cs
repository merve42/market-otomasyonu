using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSMYO4
{
    class MusteriSinifi : KisiSinifi
    {
        
        public float butce=1000;
        public List<RaftakiUrunSinifi> sepet = new List<RaftakiUrunSinifi>();
        public float sepetTutari = 0;
        public List<RaftakiUrunSinifi> satinAlinanlar = new List<RaftakiUrunSinifi>();

        public void SepeteEkle()
        {
            Console.WriteLine("-----------------------------");
            Market.raftakiUrunlerYazdir();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Lütfen sepete eklemek istediğiniz ürünün kodunu giriniz.");
            int urunKonumu = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-----------------------------");

            RaftakiUrunSinifi urun = Market.raftakiUrunler[urunKonumu - 1];

            if (urun.stok > 0)
            {
                sepet.Add(urun);
                sepetTutari += urun.fiyat;
                Console.WriteLine("-----------------------------");
                Console.WriteLine(urun.urunbilgisi.isim + " sepete eklenmiştir");
                Console.WriteLine("-----------------------------");
            }
            else
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine(urun.urunbilgisi.isim + " sepete eklenememiştir. Ürün stoğu yoktur.");
                Console.WriteLine("-----------------------------");
            }
            
        }

        public void SepettenCikar()
        {
            for (int i = 0; i < this.sepet.Count; i++)
            {
                Console.WriteLine(i + 1 + " - " + this.sepet[i].urunbilgisi.isim + " Fiyat:" + this.sepet[i].fiyat);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Lütfen sepetten çıkarmak istediğiniz ürünün kodunu giriniz.");
            int urunKonumu = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-----------------------------");

            RaftakiUrunSinifi urun = sepet[urunKonumu - 1];
            sepetTutari -= urun.fiyat;
            sepet.RemoveAt(urunKonumu-1);
            Console.WriteLine("-----------------------------");
            Console.WriteLine(urun.urunbilgisi.isim + " sepetten çıkarılmıştır.");
            Console.WriteLine("-----------------------------");
        }

        public void SepetiGoruntule()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Sepetinizdeki ürünler:");
            foreach (RaftakiUrunSinifi urun in sepet)
            {
                Console.WriteLine(urun.urunbilgisi.isim);
            }
            Console.WriteLine("-----------------------------");
        }

        public void AlisverisiTamamla()
        {
            if (sepetTutari > butce)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Alışveriş tamamlanamadı: Sepet tutarı bütçenizden fazla");
                Console.WriteLine("-----------------------------");
                return;
            }

            foreach(var urun in sepet)
            {
                urun.stok--;
                satinAlinanlar.Add(urun);
                
            }

            butce -= sepetTutari;
            sepetTutari = 0;
            sepet.Clear();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Alışveriş tamamlandı. Yeni bütçeniz: "+butce);
            Console.WriteLine("-----------------------------");
        }
        public void ButceSorgula()
        {
            Console.WriteLine("Bütçeniz: " + butce);
        }
        public bool UrunIade()
        {
            if (satinAlinanlar.Count == 0)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Satın aldığınız ürün bulunmamaktadır. İade yapamazsınız.");
                Console.WriteLine("-----------------------------");
                return false;
            }
            alisverisGecmisiniYazdir();


            Console.WriteLine("-----------------------------");
            Console.WriteLine("Lütfen iade etmek istediğiniz ürünün kodunu giriniz.");
            int urunKonumu = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-----------------------------");

            RaftakiUrunSinifi urun = satinAlinanlar[urunKonumu - 1];
            butce += urun.fiyat;
            satinAlinanlar.RemoveAt(urunKonumu - 1);
            Console.WriteLine("-----------------------------");
            Console.WriteLine(urun.urunbilgisi.isim + " iade edilmiştir.");
            Console.WriteLine("-----------------------------");
            return true;
        }


        public void UrunDegistirme()
        {
            if (UrunIade())
            {
                SepeteEkle();
                AlisverisiTamamla();
            }
        }

        public void alisverisGecmisiniYazdir()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Satın almış olduğunuz ürünler:");
            for (int i = 0; i < this.satinAlinanlar.Count; i++)
            {
                Console.WriteLine(i + 1 + " - " + this.satinAlinanlar[i].urunbilgisi.isim + " Fiyat:" + this.satinAlinanlar[i].fiyat);
            }
            Console.WriteLine("-----------------------------");
        }

    }
}
