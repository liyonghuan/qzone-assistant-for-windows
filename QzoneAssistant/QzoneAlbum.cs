using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QzoneSpider
{
    public class QzoneAlbum
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public AlbumListModeSort[] albumList { get; set; }
    }

    public class AlbumListModeSort
    {
        public string id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string pre { get; set; }
    }
}
