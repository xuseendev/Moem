﻿using MoeSystem.Shared.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Areas
{
    public class AreaDto:BaseAreaDto
    {
        public int Id { get; set; }
        public CityDto City{ get; set; }

    }
}
