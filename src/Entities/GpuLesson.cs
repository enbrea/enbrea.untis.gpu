#region ENBREA UNTIS.GPU - Copyright (C) 2020 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA UNTIS.GPU 
 *    
 *    Copyright (C) 2020 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// Represents an entity within the Untis DIF file GPU002.TXT (Unterricht)
    /// </summary>
    public class GpuLesson : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuLesson<T>"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuLesson(List<string> values)
        {
            Id = MapUIntValue(values[0]).Value;
            Class = values[4];
            Teacher = values[5];
            Subject = values[6];
            Room = values[7];
            Group = values[11];
            ValidFrom = MapDateValue(values[14]);
            ValidTo = MapDateValue(values[15]);
            Description = values[20];
            ForegroundColor = MapColorValue(values[21]);
            BackgroundColor = MapColorValue(values[22]);
            Code = values[23];
        }

        /// <summary>
        /// Background color (Hintergrundfarbe)
        /// </summary>
        public Color? BackgroundColor { get; set; }

        /// <summary>
        /// School class (Klasse)
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Code (Kennzeichen)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Description (Beschreibung)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Foreground color (Vordergrundfarbe)
        /// </summary>
        public Color? ForegroundColor { get; set; }

        /// <summary>
        /// Group (Unterrichtsgruppe)
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Id (Unterrichtsnummer)
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Room (Raum)
        /// </summary>
        public string Room { get; set; }
        /// <summary>
        /// Subject (Fach)
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Teacher (Lehrer)
        /// </summary>
        public string Teacher { get; set; }

        /// <summary>
        /// Valid to (Datum von)
        /// </summary>
        public DateTime? ValidFrom { get; set; }

        /// <summary>
        /// Valid from (Datum bis)
        /// </summary>
        public DateTime? ValidTo { get; set; }
   }
}
