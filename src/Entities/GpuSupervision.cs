#region ENBREA UNTIS.GPU - Copyright (C) 2022 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA UNTIS.GPU 
 *    
 *    Copyright (C) 2022 STÜBER SYSTEMS GmbH
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
    /// Represents an entity within the Untis DIF file GPU009.TXT (Pausenaufsichten)
    /// </summary>
    public class GpuSupervision : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuSupervision"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuSupervision(List<string> values)
        {
            Corridor = values[0];
            Teacher = values[1];
            Day = MapDayValue(values[2]);
            TimeSlot = MapUIntValue(values[3]).Value;
            Duration = MapDurationValue(values[4]);
            Weeks = MapUIntListValue(values[5], '~');
        }

        /// <summary>
        /// Corridor (Gang)
        /// </summary>
        public string Corridor { get; set; }

        /// <summary>
        /// Day (Tag)
        /// </summary>
        public DayOfWeek Day { get; set; }

        /// <summary>
        /// Duration (Dauer)
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Teacher (Lehrer)
        /// </summary>
        public string Teacher { get; set; }

        /// <summary>
        /// Time slot (Stunde)
        /// </summary>
        public uint TimeSlot { get; set; }

        /// <summary>
        /// List of weeks (Kalenderwochen mit ~ getrennt)
        /// </summary>
        public List<uint> Weeks { get; set; }
    }
}