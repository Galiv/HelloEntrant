﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Administrator
{
    public class CurrentUniversityAndFacultiesModel
    {
        public University CurrentUniversity { get; set; }
        public List<Faculty> Faculties { get; set; } = new List<Faculty>();
    }
}
