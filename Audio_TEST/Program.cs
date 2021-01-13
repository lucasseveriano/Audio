using System;
using System.IO;
using System.Threading;
using NAudio;
using NAudio.Wave;

namespace Audio_TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var path_of_the_file_you_want_to_play = "C:\\Users\\Lucas Severiano\\source\\repos\\Audio_TEST\\Audio_TEST\\test.wav";

            WaveStream mainOutputStream = new WaveFileReader(path_of_the_file_you_want_to_play);
            WaveChannel32 volumeStream = new WaveChannel32(mainOutputStream);
                        
            WaveOutEvent player = new WaveOutEvent();
            player.DeviceNumber = 5;

            for (int n = -1; n < WaveOut.DeviceCount; n++)
            {
                var caps = WaveOut.GetCapabilities(n);
                Console.WriteLine($"{n}: {caps.ProductName}");                
                Console.WriteLine($"{n}: {caps.ProductName}");                
            }            

            player.Init(volumeStream);

            player.Play();

            while (player.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(100);
            }
        }
    }
}
