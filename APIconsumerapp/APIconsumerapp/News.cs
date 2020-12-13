using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIconsumerapp
{
    class News
    {

      
        public string title { get; set; }

        public string pref { get; set; }

        public string description { get; set; }

        public int? Catalog_id { get; set; }

        public DateTime? date { get; set; }

        public  Catalog TbCatalog { get; set; }
    }
}
