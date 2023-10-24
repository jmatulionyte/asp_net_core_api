using System;
using asp_net_core_rest_api.Models.Dto;

namespace asp_net_core_rest_api.Data
{
	public static class VillaStore
	{
		public static List<VillaDTO> villaList = new List<VillaDTO> {
            new VillaDTO { Id=1,Name="Pool voew", Sqft=150, Occupancy=2},
            new VillaDTO { Id = 2, Name = "bearch voew", Sqft=50, Occupancy=1 }
            };
			
	}
}

