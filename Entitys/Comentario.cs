using System;
namespace WebApiAutores2.Entitys
{
	public class Comentario
	{
		public int Id { get; set; }
		public string Contenido { get; set; }
		public int LibroId { get; set; }
		public Libro Libro { get; set; }
	}
}

