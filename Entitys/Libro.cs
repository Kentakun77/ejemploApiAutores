using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiAutores2.Entitys
{
	public class Libro
	{
        public int id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}

