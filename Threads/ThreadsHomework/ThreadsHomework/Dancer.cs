using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsHomework
{
    public class Dancer
    {
        private readonly Dictionary<MusicType, DanceType> danceForMusic = new Dictionary<MusicType, DanceType>() {
            { MusicType.Hardbass, DanceType.Elbow},
            { MusicType.Latino,  DanceType.Hip},
            { MusicType.Rock,  DanceType.Head}
        };

        private Thread Dancing { get; set; }

        private string name { get; set; }

        public Dancer(string name)
        {
            this.name = name;
            Dancing = new Thread(new ThreadStart(Dance));
        }
        public void Start()
        {
            this.Dancing.Start();
        }

        private void Dance()
        {
            while (!DJ.ShouldStopAndGoHome)
            {
                Console.WriteLine($"I am dancer {name}, and I am dancing with {danceForMusic[DJ.CurrentTrack]}");
                Thread.Sleep(1000);
            }
        }
    }

    public enum DanceType
    {
        Elbow,

        Hip,

        Head
    }
}
