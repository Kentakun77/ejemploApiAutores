using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiAutores2.DTOs
{
	public class AutorCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Nombre { get; set; }
    }
}

