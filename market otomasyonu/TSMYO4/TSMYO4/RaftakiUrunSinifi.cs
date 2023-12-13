using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSMYO4
{
    class RaftakiUrunSinifi
    {
        public int barkod;
        public UrunSinifi urunbilgisi;
        public float fiyat;
        public int stok;

        public RaftakiUrunSinifi(UrunSinifi urunbilgisi, int stok)
        {
            this.barkod = Market.raftakiUrunler.Count + 1;
            this.fiyat = urunbilgisi.maliyet+ (urunbilgisi.maliyet / 10);
            this.urunbilgisi = urunbilgisi;
            Market.raftakiUrunler.Add(this);
            this.stok = stok;
        }
    }
}
