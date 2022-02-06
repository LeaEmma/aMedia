using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AMedia.Data
{
    public partial class tGenero
    {
        public tGenero()
        {
            tGeneroPelicula = new HashSet<tGeneroPelicula>();
        }

        [Key]
        public int cod_genero { get; set; }
        [StringLength(500)]
        public string txt_desc { get; set; }

        [InverseProperty("cod_generoNavigation")]
        public virtual ICollection<tGeneroPelicula> tGeneroPelicula { get; set; }
    }
}
