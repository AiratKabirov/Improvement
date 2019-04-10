using System;
using System.Threading;

namespace ThreadsHomework
{
    public class DJ
    {
        public static bool ShouldStopAndGoHome { get; set; }

        public static MusicType CurrentTrack { get; set; }

        private Thread mixThread { get; set; }

        private readonly int trackLength = 2000;

        private readonly int numberOfTracks = 5;

        public DJ()
        {
            mixThread = new Thread(new ThreadStart(() =>
            {
                Random random = new Random();
                int randomNumber = 0;

                for (int i = 0; i < numberOfTracks; i++)
                {
                    randomNumber = random.Next(0, Enum.GetNames(typeof(MusicType)).Length);
                    CurrentTrack = (MusicType)randomNumber;
                    Console.WriteLine($"Hey from DJ! The music is {CurrentTrack}!");
                    Thread.Sleep(trackLength);
                }

                ShouldStopAndGoHome = true;
            }));
        }

        public void Start()
        {
            this.mixThread.Start();
        }
    }

    public enum MusicType
    {
        Hardbass,

        Latino,

        Rock
    }
}
