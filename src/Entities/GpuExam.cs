#region ENBREA UNTIS.GPU - Copyright (C) STÜBER SYSTEMS GmbH
/*    
 *    ENBREA UNTIS.GPU 
 *    
 *    Copyright (C) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// Represents an entity within the Untis DIF file GPU017.TXT (Klausuren)
    /// </summary>
    public class GpuExam : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuExam"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuExam(List<string> values)
        {
            Name = values[0];
            Id = MapUIntValue(values[1]).Value;
            Text = values[2];
            Date = MapDateValue(values[3]);
            StartTimeSlot = MapUIntValue(values[4]);
            EndTimeSlot = MapUIntValue(values[5]);
            Subjects = MapStringListValue(values[6], '~');
            Lessons = MapUIntListValue(values[7], '~');
            Students = MapStringListValue(values[8], '~');
            foreach (var subStr in MapStringListValue(values[9], '-').Select(s => s.Trim()))
            {
                Teachers.Add(MapStringListValue(subStr, '~'));
            }
            foreach (var subStr in MapStringListValue(values[10], '-').Select(s => s.Trim()))
            {
                Rooms.Add(MapStringListValue(subStr, '~'));
            }
        }

        /// <summary>
        /// Date (Datum)
        /// </summary>
        public DateOnly? Date { get; set; }

        /// <summary>
        /// End time slot (bis Stunde)
        /// </summary>
        public uint? EndTimeSlot { get; set; }

        /// <summary>
        /// Id (Klausurnummer)
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// List of lessonss (Unterichtsnummern mit ~ getrennt)
        /// </summary>
        public List<uint> Lessons { get; set; }

        /// <summary>
        /// Name (Name der Klausur)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of rooms per time slot (Klausurräume mit ~ getrennt, Stunden mit - getrennt)
        /// </summary>
        public List<List<string>> Rooms { get; set; } = new List<List<string>>();

        /// <summary>
        /// Start time slot (von Stunde)
        /// </summary>
        public uint? StartTimeSlot { get; set; }

        /// <summary>
        /// List of students (Studenten mit ~ getrennt)
        /// </summary>
        public List<string> Students { get; set; }

        /// <summary>
        /// List of subjects (Fächer/Kurse mit ~ getrennt)
        /// </summary>
        public List<string> Subjects { get; set; }

        /// <summary>
        /// List of teachers per time slot (Aufsichtslehrer mit ~ getrennt, Stunden mit - getrennt)
        /// </summary>
        public List<List<string>> Teachers { get; set; } = new List<List<string>>();

        /// <summary>
        /// Text (Text zur Klausur)
        /// </summary>
        public string Text { get; set; }
    }
}
