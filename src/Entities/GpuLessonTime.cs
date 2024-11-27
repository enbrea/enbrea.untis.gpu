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

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// Represents an entity within the Untis DIF file GPU001.TXT (Stundenplan)
    /// </summary>
    public class GpuLessonTime : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuLessonTime"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuLessonTime(List<string> values)
        {
            LessonId = MapUIntValue(values[0]).Value;
            Class = values[1];
            Teacher = values[2];
            Subject = values[3];
            Room = values[4];
            Day = MapDayValue(values[5]);
            TimeSlot = MapUIntValue(values[6]).Value;
            Duration = MapDurationValue(values[7]);
        }

        /// <summary>
        /// Day (Tag)
        /// </summary>
        public DayOfWeek Day { get; set; }

        /// <summary>
        /// Duration (Stundenlänge)
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Lesson Id (Unterrichtsnummer)
        /// </summary>
        public uint LessonId { get; set; }

        /// <summary>
        /// Time slot (Stunde)
        /// </summary>
        public uint TimeSlot { get; set; }

        /// <summary>
        /// Room (Raum)
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// School class (Klasse)
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Subject (Fach)
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Teacher (Lehrer)
        /// </summary>
        public string Teacher { get; set; }
   }
}
