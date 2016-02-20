using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraSharp
{
    public class Seed
    {
        private enum SeedType
        {
            Artist,
            Song
        }

        private SeedType seedType;
        private string songName;
        private string artistName;
        public string SeedID;

        public Seed(string artist, string id)
        {
            seedType = SeedType.Artist;
            artistName = artist;
            SeedID = id;
        }

        public Seed(string song, string artist, string id)
        {
            seedType = SeedType.Song;
            songName = song;
            artistName = artist;
            SeedID = id;
        }

        public override string ToString()
        {
            if (seedType == SeedType.Artist)
                return artistName;
            else
                return songName + " by " + artistName;
        }
    }
}
