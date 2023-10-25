using System;
using asp_net_core_rest_api.Models;
using asp_net_core_rest_api.Models.Dto;
using AutoMapper;

namespace asp_net_core_rest_api
{
	public class MappingConfig : Profile
	{
		public MappingConfig()
		{//custom basic mapping, important that id is same
			CreateMap<Villa, VillaDTO>();
			CreateMap<VillaDTO, Villa>();

            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();


        }
    }
}

