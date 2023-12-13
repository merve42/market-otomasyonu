using System;

namespace TSMYO4
{
    class Program
    {
        static void Main(string[] args)
        {
            MusteriSinifi musteri = new MusteriSinifi();

            UrunSinifi urun1 = new UrunSinifi("Armut",500);

            UrunSinifi urun2 = new UrunSinifi("Elma",300);

            UrunSinifi urun3 = new UrunSinifi("Portakal",100);

            RaftakiUrunSinifi raftakiUrun1 = new RaftakiUrunSinifi(urun1,2);


            RaftakiUrunSinifi raftakiUrun2 = new RaftakiUrunSinifi(urun2, 2);

            RaftakiUrunSinifi raftakiUrun3 = new RaftakiUrunSinifi(urun3, 2);

            Console.WriteLine("Lütfen giriş tipini seçiniz.\n1.Müşteri\n2.Personel");
            int islem = Convert.ToInt32(Console.ReadLine());

            bool personelmi = false;
            if (islem == 2)
            {
                Console.WriteLine("Lütfen kullanıcı adınızı giriniz.");
                string kullaniciadi = Console.ReadLine();
                Console.WriteLine("Lütfen şifrenizi giriniz.");
                string sifre = Console.ReadLine();
                personelmi = Market.PersonelGiris(kullaniciadi, sifre);
            }


            int programState = 0;
            while (programState!=-1)
            {
                if (personelmi)
                {
                    Console.WriteLine("Lütfen yapmak istediğiniz işlemin kodunu girin.\n1.Sepete Ürün Ekle\n2.Sepetten Ürün Çıkar\n3.Alışverişi Tamamla\n4.Sepeti Görüntüle\n5.İade Talebi\n6.Bütçe Sorgula\n7.Değişim Talebi\n8.Alışveriş Geçmişi Görüntüle\n9.Stok Güncelle\n10.Fiyat Güncelle\n100.Çıkış");
                }
                else
                {
                    Console.WriteLine("Lütfen yapmak istediğiniz işlemin kodunu girin.\n1.Sepete Ürün Ekle\n2.Sepetten Ürün Çıkar\n3.Alışverişi Tamamla\n4.Sepeti Görüntüle\n5.İade Talebi\n6.Bütçe Sorgula\n7.Değişim Talebi\n8.Alışveriş Geçmişi Görüntüle\n100.Çıkış");
                }
                islem = Convert.ToInt32(Console.ReadLine());

                switch (islem)
                {
                    case 1:
                        musteri.SepeteEkle();
                        break;
                    case 2:
                        musteri.SepettenCikar();
                        break;
                    case 3:
                        musteri.AlisverisiTamamla();
                        break;
                    case 4:
                        musteri.SepetiGoruntule();
                        break;
                    case 5:
                        musteri.UrunIade();
                        break;
                    case 6:
                        musteri.ButceSorgula();
                        break;
                    case 7:
                        musteri.UrunDegistirme();
                        break;
                    case 8:
                        musteri.alisverisGecmisiniYazdir();
                        break;
                    case 9:
                        if(personelmi) Market.raftakiUrunStokGuncelle();
                        break;
                    case 10:
                        if(personelmi) Market.raftakiUrunFiyatGuncelle();
                        break;
                    case 100:
                        Console.WriteLine("Güvenli çıkış sağlandı.");
                        programState = -1;
                        break;
                    default:
                        break;

                }
            
            }
        }
    }
}
