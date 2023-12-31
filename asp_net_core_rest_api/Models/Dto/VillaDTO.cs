﻿using System;
using System.ComponentModel.DataAnnotations;

namespace asp_net_core_rest_api.Models.Dto
{//in dto, cn skip feild that should be exposed
	public class VillaDTO
	{
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }

    }
}

