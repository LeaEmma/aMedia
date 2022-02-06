using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AMedia.Data
{
    public partial class tRol
    {
        public tRol()
        {
            tUsers = new HashSet<tUsers>();
        }

        [Key]
        public int cod_rol { get; set; }
        [StringLength(500)]
        public string txt_desc { get; set; }
        public int? sn_activo { get; set; }

        [InverseProperty("cod_rolNavigation")]
        public virtual ICollection<tUsers> tUsers { get; set; }
    }
}
