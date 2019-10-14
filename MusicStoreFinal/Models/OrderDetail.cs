namespace MusicStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    // after order, we can see what we bought.
    // so If we click order Detail part, we can see the details 
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int AlbumId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }

        public virtual Album Album { get; set; }

        public virtual Order Order { get; set; }
    }
}
