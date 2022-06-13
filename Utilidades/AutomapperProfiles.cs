using System;
using AutoMapper;
using WebApiAutores2.DTOs;
using WebApiAutores2.Entitys;

namespace WebApiAutores2.Utilidades
{
	public class AutomapperProfiles : Profile
	{
		public AutomapperProfiles()
        {
			CreateMap<AutorCreacionDTO, Autor>();
			CreateMap<Autor, AutorDTO>();
			CreateMap<LibroCreacionDTO, Libro>();
			CreateMap<Libro, LibroDTO>();
		}
	}
}

