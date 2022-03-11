using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWork1
{
    class DeserializeJSON
    {
        public class Current
        {
            public int timestart { get; set; }
            public int timestop { get; set; }
            public string title { get; set; }
            public string desc { get; set; }
            public int cdnvideo { get; set; }
            public int rating { get; set; }
        }

        public class ForeignPlayer
        {
            public string url { get; set; }
            public string sdk { get; set; }
            public int valid_from { get; set; }
        }

        public class Channel
        {
            public int id { get; set; }
            public int epg_id { get; set; }
            public string name_ru { get; set; }
            public string name_en { get; set; }
            public string cdn { get; set; }
            public string url { get; set; }
            public string url_sound { get; set; }
            public string image { get; set; }
            public bool hasEpg { get; set; }
            public Current current { get; set; }
            public int region_code { get; set; }
            public int tz { get; set; }
            public bool is_foreign { get; set; }
            public bool foreign_player_key { get; set; }
            public ForeignPlayer foreign_player { get; set; }
        }

        public class Root
        {
            public List<Channel> channels { get; set; }
            public int valid { get; set; }
            public string ckey { get; set; }
        }
    }
}
