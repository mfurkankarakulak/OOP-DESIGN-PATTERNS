using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeSample
{
    public class Facade
    {
        //constructor da oluşturulabilir
        //singleton olarak tasarlanabilir
        TcKimlikSistem TcSistem = new TcKimlikSistem();
        Sistem1Kontrol Sistem1 = new Sistem1Kontrol();
        Sistem2Operations Sistem2 = new Sistem2Operations();

        public void Sistem2UyeEkle(string Tc)
        {
            if (TcSistem.Kontrol(Tc) && !Sistem1.KaraListeKontrol(Tc))
            {
                Sistem2.UyeEkle(Tc);
            }
        }
    }
}
