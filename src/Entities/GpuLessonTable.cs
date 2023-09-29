#region ENBREA UNTIS.GPU - Copyright (C) 2023 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA UNTIS.GPU 
 *    
 *    Copyright (C) 2023 STÜBER SYSTEMS GmbH
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
    /// Represents an entity within the Untis DIF file GPU011.TXT (Stundentafeln)
    /// </summary>
    public class GpuLessonTable : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuLessonTable"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuLessonTable(List<string> values)
        {
            Name = values[0];
            LongName = values[1];
            Subject = values[2];
            MinTimeSlots = MapUIntValue(values[3]);
            MaxTimeSlots = MapUIntValue(values[4]);
        }

        /// <summary>
        /// Long name (Langname)
        /// </summary>
        public string LongName { get; set; }

        /// <summary>
        /// Max slots (Stundenzahl maximal)
        /// </summary>
        public uint? MaxTimeSlots { get; set; }

        /// <summary>
        /// Min slots (Stundenzahl minimal)
        /// </summary>
        public uint? MinTimeSlots { get; set; }

        /// <summary>
        /// Short name (Kurzname des absenten Elementes)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Subject (Fach)
        /// </summary>
        public string Subject { get; set; }
    }
}
