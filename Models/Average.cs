using Notentool.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models
{
    /// <summary>
    /// Klasse um den Durchschnitt eines Semesters oder eines Moduls zu berechnen
    /// </summary>
    public static class Average
    {
        /// <summary>
        /// Berechnet den Durchschnitt für ein Semester
        /// </summary>
        /// <param name="semester">Das Semester für welches den Durchschnitt berechnet werden soll</param>
        /// <returns><c>double</c></returns>
        public static double CalculateForSemester(Semester semester)
        { 
            IEnumerable<Grade> grades = new List<Grade>();
            if (semester.Moduls != null)
            {
                foreach (var modul in semester.Moduls)
                {
                    if (modul.Grades != null) grades = grades.Concat(modul.Grades);
                }
            }
            if (grades.ToList().Count > 0) return grades.WeightedAverage(g => g.Note, g => g.Gewichtung);
            return 0;
        }

        /// <summary>
        /// Berechnet den Durchschnitt für ein Modul
        /// </summary>
        /// <param name="modul">Das Modul für welches den Durchschnitt berechnet werden soll</param>
        /// <returns></returns>
        public static double CalculateForModul(Modul modul)
        {
            IEnumerable<Grade> grades = new List<Grade>();
            if (modul.Grades != null) grades = grades.Concat(modul.Grades);
            if (grades.ToList().Count > 0) return grades.WeightedAverage(g => g.Note, g => g.Gewichtung);
            return 0;
        }

        private static double WeightedAverage<T>(this IEnumerable<T> records, Func<T, double> value, Func<T, double> weight)
        {
            double weightedValueSum = records.Sum(x => value(x) * weight(x));
            double weightSum = records.Sum(x => weight(x));

            if (weightSum != 0)
                return weightedValueSum / weightSum;
            else
                throw new DivideByZeroException("Can't divide by zero!");
        }
    }
}
