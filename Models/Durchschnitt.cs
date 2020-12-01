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
            foreach (var modul in semester.Moduls)
            {
                grades.ToList().AddRange(modul.Grades);
            }

            var noten = grades.Select(g => g.Note).AsQueryable();
            return Queryable.Average(noten);
        }

        public static double CalculateForModul(Modul modul)
        {
            var noten = modul.Grades.Select(g => g.Note).AsQueryable();
            return Queryable.Average(noten);
        }
    }
}
