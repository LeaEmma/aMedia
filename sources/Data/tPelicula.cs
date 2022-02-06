using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AMedia.Data
{
    public partial class tPelicula
    {
        public tPelicula()
        {
            tGeneroPelicula = new HashSet<tGeneroPelicula>();
        }

        [Key]
        public int cod_pelicula { get; set; }
        [StringLength(500)]
        public string txt_desc { get; set; }
        public int? cant_disponibles_alquiler { get; set; }
        public int? cant_disponibles_venta { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? precio_alquiler { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? precio_venta { get; set; }

        [InverseProperty("cod_peliculaNavigation")]
        public virtual ICollection<tGeneroPelicula> tGeneroPelicula { get; set; }
    }
}
