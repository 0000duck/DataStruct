namespace EFDemo.CodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JD_Commodity_001")]
    public partial class JDCommodity001
    {
        public int Id { get; set; }

        public long? ProductId { get; set; }

        [Display(Name = "123456", Description = "")]
        [Column("CategoryId")]
        public int? ClassId { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        public decimal? Price { get; set; }

        [StringLength(1000)]
        public string Url { get; set; }

        [StringLength(1000)]
        public string ImageUrl { get; set; }
    }
}
