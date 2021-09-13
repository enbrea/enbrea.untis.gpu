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

using System;
using System.Collections.Generic;

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// Represents an entity within the Untis DIF file GPU013.TXT (Absenzen)
    /// </summary>
    public class GpuAbsence : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuAbsence<T>"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuAbsence(List<string> values)
        {
            Id = MapUIntValue(values[0]).Value;
            Type = MapAbsenceTypeValue(values[1]);
            ShortName = values[2];
            StartDate = MapDateValue(values[3]);
            EndDate = MapDateValue(values[4]);
            FirstTimeSlot = MapUIntValue(values[5]);
            LastTimeSlot = MapUIntValue(values[6]);
            Reason = values[7];
            Text = values[8];
        }

        /// <summary>
        /// Valid from (Enddatum)
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Text (Absenztext)
        /// </summary>
        public uint? FirstTimeSlot { get; set; }

        /// <summary>
        /// Id (Absenznummer)
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Text (Absenztext)
        /// </summary>
        public uint? LastTimeSlot { get; set; }

        /// <summary>
        /// Reason (Absenzgrund)
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Short name (Kurzname des absenten Elementes)
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Valid to (Beginndatum)
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Text (Absenztext)
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Code (Kennzeichen)
        /// </summary>
        public GpuAbsenceType? Type { get; set; }
    }
}
