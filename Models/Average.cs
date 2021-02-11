using Notentool.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notentool.Models
{
    /// <summary>
    /// Klasse um den Durchschnitt eines Semesters oder eines Moduls zu berechnen
    /// Autoren: Gion Rubitschung und Noah Siroh Schönthal
    /// </summary>
    public static class Average
    {
        /// <summary>
        /// Berechnet den Durchschnitt für ein Semester
        /// </summary>
        /// <param name="semester">Das Semester für welches den Durchschnitt berechnet werden soll</param>
        /// <returns>Durchschnitt als <c>double</c></returns>
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
        /// <returns>Durchschnitt als <c>double</c></returns>
        public static double CalculateForModul(Modul modul)
        {
            IEnumerable<Grade> grades = new List<Grade>();
            if (modul.Grades != null) grades = grades.Concat(modul.Grades);
            if (grades.ToList().Count > 0) return grades.WeightedAverage(g => g.Note, g => g.Gewichtung);
            return 0;
        }

        /// <summary>
        /// Berechnet einen Durchschnitt in einer Liste mit einberechnung der Gewichtung
        /// </summary>
        /// <typeparam name="T">Der Typ der Liste</typeparam>
        /// <param name="records">Die Liste an Werten bei welchen der Durchschnitt berechnet werden soll</param>
        /// <param name="value">Ein Predicate für den Wert</param>
        /// <param name="weight">Ein Predicate für die Gewichtung</param>
        /// <returns>Durchschnitt als <c>double</c></returns>
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
