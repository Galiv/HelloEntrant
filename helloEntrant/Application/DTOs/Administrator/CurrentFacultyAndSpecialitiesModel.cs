using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Administrator
{
    public class CurrentFacultyAndSpecialitiesModel
    {
        public string FacultyAdminId { get; set; }
        public Faculty CurrentFaculty { get; set; }
        public List<Speciality> Specialities { get; set; } = new List<Speciality>();
    }
}
