using System;
using System.ComponentModel.DataAnnotations;

namespace asp_net_core_rest_api.Models.Dto
{
	public class VillaDTO
	{
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int Occupancy { get; set; }

        public int Sqft { get; set; }

    }
}

