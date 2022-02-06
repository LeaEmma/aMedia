using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AMedia.Data
{
    public partial class tUsers
    {
        [Key]
        public int cod_usuario { get; set; }
        [StringLength(50)]
        public string txt_user { get; set; }
        [StringLength(50)]
        public string txt_password { get; set; }
        [StringLength(200)]
        public string txt_nombre { get; set; }
        [StringLength(200)]
        public string txt_apellido { get; set; }
        [StringLength(50)]
        public string nro_doc { get; set; }
        public int? cod_rol { get; set; }
        public int? sn_activo { get; set; }

        [ForeignKey(nameof(cod_rol))]
        [InverseProperty(nameof(tRol.tUsers))]
        public virtual tRol cod_rolNavigation { get; set; }
    }
}
