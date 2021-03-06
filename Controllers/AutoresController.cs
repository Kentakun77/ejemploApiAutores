using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores2.DTOs;
using WebApiAutores2.Entitys;

namespace WebApiAutores2.Controllers
{
	[ApiController]
	[Route("api/autores")]
	public class AutoresController : ControllerBase
	{
		//injectando deopendencias al constructor
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public AutoresController(ApplicationDbContext context, IMapper mapper)
        {
			this.context = context;
			this.mapper = mapper;
		}

		[HttpGet]
		public async Task<List<AutorDTO>> Get()
        {
			var autores = await context.Autores.ToListAsync();
			return mapper.Map<List<AutorDTO>>(autores);
        }


		[HttpGet("{id:int}")]
		public async Task<ActionResult<AutorDTO>> Get(int id)
        {
			var autor = await context.Autores.FirstOrDefaultAsync(autorDb => autorDb.id == id);
			if (autor == null)
            {
				return NotFound();
            }
			return mapper.Map<AutorDTO>(autor);
        }
		[HttpGet("{nombre}")]
		public async Task<ActionResult<List<AutorDTO>>> Get([FromRoute]string nombre)
        {
			var autores = await context.Autores.Where(autorDb => autorDb.Nombre.Contains(nombre)).ToListAsync();

			return mapper.Map<List<AutorDTO>>(autores);
        }


		[HttpPost]
		public async Task<ActionResult> Post([FromBody]AutorCreacionDTO autorCreacionDTO)
		{
			var existeAutor = await context.Autores.AnyAsync(x => x.Nombre == autorCreacionDTO.Nombre);
			if (existeAutor)
			{
				return BadRequest($"Ya existe un autor con el nombre {autorCreacionDTO.Nombre}");
			}

			var autor = mapper.Map<Autor>(autorCreacionDTO);

			context.Add(autor);
			await context.SaveChangesAsync();
			return Ok();
        }

		[HttpPut("{id:int}")]
		public async Task<ActionResult> ModifyAutor(Autor autor, int id)
        {
			if(autor.id != id)
            {
				return BadRequest("El id del autor no coincide con el id de la url");
            }
			var existe = await context.Autores.AnyAsync(x => x.id == id);
			if (!existe)
			{
				return NotFound();
			}
			context.Update(autor);
			await context.SaveChangesAsync();
			return Ok();
        }
		[HttpDelete("{id:int}")]
		public async Task<ActionResult> DeleteAutor(int id)
        {
			var existe = await context.Autores.AnyAsync(x => x.id == id);
            if (!existe)
            {
				return NotFound();
            }
			context.Remove(new Autor() { id = id });
			await context.SaveChangesAsync();
			return Ok();
        }
	}
}

