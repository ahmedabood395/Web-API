namespace LabDay2API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TbNew
    {
        public int id { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        public string pref { get; set; }

        public string description { get; set; }

        [StringLength(50)]
        public string photo { get; set; }

        [Column("User-id")]
        public int? User_id { get; set; }

        public int? Catalog_id { get; set; }

        public DateTime? date { get; set; }

        public virtual TbCatalog TbCatalog { get; set; }
    }
}
