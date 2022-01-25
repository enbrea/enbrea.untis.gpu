#region ENBREA UNTIS.GPU - Copyright (C) 2021 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA UNTIS.GPU 
 *    
 *    Copyright (C) 2021 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System.Collections.Generic;

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// Represents an entity within the Untis DIF file GPU015.TXT (Kurswahlen der Studenten)
    /// </summary>
    public class GpuStudentCourseChoice : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuStudentCourseChoice"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuStudentCourseChoice(List<string> values)
        {
            StudentShortName = values[0];
            LessonId = MapUIntValue(values[1]).Value;
            Subject = values[2];
            LessonAlias = values[3];
            Class = values[4];
            StatisticalCode = values[5];
            StudentNo = values[6];
            AlternativeCourses = GenerateAlternativeCourses(
                MapUIntListValue(values[9], '~'), 
                MapStringListValue(values[10], '~'), 
                MapUIntListValue(values[12], '~'));
        }

        /// <summary>
        /// School class (Klasse)
        /// </summary>
        public IList<GpuStudentAlternativeCourse> AlternativeCourses { get; set; }

        /// <summary>
        /// School class (Klasse)
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Lesson alias (Unterrichtsalias)
        /// </summary>
        public string LessonAlias { get; set; }

        /// <summary>
        /// Lesson Id (Unterrichtsnummer)
        /// </summary>
        public uint LessonId { get; set; }

        /// <summary>
        /// Statistical code (Statistikkennzeichen)
        /// </summary>
        public string StatisticalCode { get; set; }

        /// <summary>
        /// Student number (Studentennummer)
        /// </summary>
        public string StudentNo { get; set; }

        /// <summary>
        /// Student short name (Kurzname des Studenten)
        /// </summary>
        public string StudentShortName { get; set; }

        /// <summary>
        /// Subject (Fach)
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Generates list of alternatve courses from DIF record
        /// </summary>
        /// <param name="lessonIds">List of lesson ids</param>
        /// <param name="subjects">List of subjects</param>
        /// <param name="priorities">List of priorities</param>
        /// <returns>List of <see cref="GpuStudentAlternativeCourse"/> instances</returns>
        private IList<GpuStudentAlternativeCourse> GenerateAlternativeCourses(List<uint> lessonIds, List<string> subjects, List<uint> priorities)
        {
            var list = new List<GpuStudentAlternativeCourse>();
            for (int i = 0; i < lessonIds.Count; i++)
            {
                list.Add(new GpuStudentAlternativeCourse(lessonIds[i], subjects[i], priorities[i]));
            }
            return list;
        }
    }
}
