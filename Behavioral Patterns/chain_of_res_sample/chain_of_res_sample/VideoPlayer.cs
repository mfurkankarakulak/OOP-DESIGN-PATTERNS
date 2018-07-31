using System;

namespace chain_of_res_sample
{
    public abstract class PlayerHandler
    {
        protected PlayerHandler _SonrakiHandler;
        public PlayerHandler SonrakiHandler { set { _SonrakiHandler = value; } }

        public abstract void Play(string filePath);
    }

    public class ConcreteHandlerMp4 : PlayerHandler
    {
        public override void Play(string filePath)
        {
            /*.mp4 uzantılı dosya ise bu sınıf cevap verir*/
            if (filePath.EndsWith(".mp4"))
                Console.WriteLine("{0} dosyası oynatılıyor(mp4 player)...", filePath);
            else
            {
                /*.mp4 uzantılı dosya değil ise _SonrakiHandler a isteği gönder*/
                if (_SonrakiHandler != null)
                    _SonrakiHandler.Play(filePath);
            }
        }
    }

    public class ConcreteHandlerMpg : PlayerHandler
    {
        public override void Play(string filePath)
        {
            /*.mpg uzantılı dosya ise bu sınıf cevap verir*/
            if (filePath.EndsWith(".mpg"))
                Console.WriteLine("{0} dosyası oynatılıyor(mpg player)...", filePath);
            else
            {
                /*.mpg uzantılı dosya değil ise _SonrakiHandler a isteği gönder*/
                if (_SonrakiHandler != null)
                    _SonrakiHandler.Play(filePath);
            }
        }
    }

    public class ConcreteHandlerAvi : PlayerHandler
    {
        public override void Play(string filePath)
        {
            /*.avi uzantılı dosya ise bu sınıf cevap verir*/
            if (filePath.EndsWith(".avi"))
                Console.WriteLine("{0} dosyası oynatılıyor(avi player)...", filePath);
            else /*isteğe cevap verebilecek son sınıf bu olduğundan .avi uzantılı değil ise hata ver*/
                Console.WriteLine("{0} Geçersiz Dosya Formatı", filePath);

        }
    }
}