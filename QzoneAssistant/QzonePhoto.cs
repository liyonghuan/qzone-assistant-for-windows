using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QzoneSpider
{
    public class QzonePhoto
    {
        public Data data;

        public class Data
        {
            public Photo[] photoList;
        }

        public class Photo
        {
            public string name;
            public string desc;
            public string tag;
            public string origin_uuid;
            public string lloc;
            public string sloc;
            public string url;
            public string raw;
            public string origin_url;
        }
    }
}
