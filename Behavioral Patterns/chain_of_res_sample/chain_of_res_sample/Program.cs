using System;

namespace chain_of_res_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*zinciri oluşturacak halkaları tanımlıyoruz*/
            PlayerHandler mp4Player = new ConcreteHandlerMp4();
            PlayerHandler mpgPlayer = new ConcreteHandlerMpg();
            PlayerHandler aviPlayer = new ConcreteHandlerAvi();

            /*Zincirin halkalarını sıralıyoruz */
            /*İstek hangi sıra ile ConcreteHandler sınıflarına iletileceğini belirliyoruz*/
            mp4Player.SonrakiHandler = mpgPlayer;
            mpgPlayer.SonrakiHandler = aviPlayer;

            /*İstekleri zincirin ilk halkasına ygönderiyoruz*/
            mp4Player.Play("video.mpg");
            mp4Player.Play("video.avi");
            mp4Player.Play("video.mp4");
            mp4Player.Play("video.swf");

            Console.ReadKey();

        }
    }
}
