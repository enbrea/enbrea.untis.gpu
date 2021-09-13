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
using System.Drawing;

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// Represents an entity within the Untis DIF file GPU003.TXT (Klassen)
    /// </summary>
    public class GpuClass : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuClass<T>"/> class.
        /// </summary>
        /// <param name="GpuSchoolClass">List of raw values</param>
        public GpuClass(List<string> values)
        {
            ShortName = values[0];
            LongName = values[1];
            Room = values[3];
            Department = values[14];
            ValidFrom = MapDateValue(values[19]);
            ValidTo = MapDateValue(values[20]);
            Description = values[22];
            ForegroundColor = MapColorValue(values[23]);
            BackgroundColor = MapColorValue(values[24]);
            Alias = values[28];
        }
    
        /// <summary>
        /// Alias (Alias)
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Background color (Hintergrundfarbe)
        /// </summary>
        public Color? BackgroundColor { get; set; }

        /// <summary>
        /// Department (Abteilung)
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Description (Beschreibung)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Foreground color (Vordergrundfarbe)
        /// </summary>
        public Color? ForegroundColor { get; set; }

        /// <summary>
        /// Long name (Langname)
        /// </summary>
        public string LongName { get; set; }

        /// <summary>
        /// Room (Raum)
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// Short name (Name)
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Valid to (Unterrichtsbeginn)
        /// </summary>
        public DateTime? ValidFrom { get; set; }

        /// <summary>
        /// Valid from (Unterrichtsende)
        /// </summary>
        public DateTime? ValidTo { get; set; }
    }
}
