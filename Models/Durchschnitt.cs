using Notentool.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models
{
    public static class Durchschnitt
    {
        public static double CalculateForSemester(Semester semester)
        { 
            IEnumerable<Grade> grades = new List<Grade>();
            if (semester.Moduls != null)
            {
                foreach (var modul in semester?.Moduls)
                {
                    if (modul.Grades != null) grades.ToList().AddRange(modul.Grades);
                }
            }
            if (grades.ToList().Count > 0)
            {
                var noten = grades.Select(g => g.Note).AsQueryable();
                return Queryable.Average(noten);
            }
            return 0;
        }

        public static double CalculateForModul(Modul modul)
        {
            IEnumerable<Grade> grades = new List<Grade>();
            if (modul.Grades != null) grades.ToList().AddRange(modul.Grades);
            if (grades.ToList().Count > 0)
            {
                var noten = grades.Select(g => g.Note).AsQueryable();
                return Queryable.Average(noten);
            }
            return 0;
        }
    }
}
