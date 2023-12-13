using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSMYO4
{
    class UrunSinifi
    {
        public string isim;
        public float maliyet;

        public UrunSinifi(string isim, float maliyet)
        {
            this.isim = isim;
            this.maliyet = maliyet;
            Market.depodakiUrunler.Add(this);
        }

    }
}
