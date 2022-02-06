using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AMedia.Data
{
    public partial class tGeneroPelicula
    {
        [Key]
        public int cod_pelicula { get; set; }
        [Key]
        public int cod_genero { get; set; }

        [ForeignKey(nameof(cod_genero))]
        [InverseProperty(nameof(tGenero.tGeneroPelicula))]
        public virtual tGenero cod_generoNavigation { get; set; }
        [ForeignKey(nameof(cod_pelicula))]
        [InverseProperty(nameof(tPelicula.tGeneroPelicula))]
        public virtual tPelicula cod_peliculaNavigation { get; set; }
    }
}
