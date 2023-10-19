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

using System.Collections.Generic;
using System.Drawing;

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// Represents an entity within the Untis DIF file GPU005.TXT (Räume)
    /// </summary>
    public class GpuRoom : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuRoom"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuRoom(List<string> values)
        {
            ShortName = values[0];
            LongName = values[1];
            AlternativeRoom = values[2];
            Weight = MapUIntValue(values[6]);
            Capacity = MapUIntValue(values[7]);
            Department = values[8];
            Description = values[12];
            ForegroundColor = MapColorValue(values[13]);
            BackgroundColor = MapColorValue(values[14]);
        }

        /// <summary>
        /// Alternative room (Ausweichraum)
        /// </summary>
        public string AlternativeRoom { get; set; }

        /// <summary>
        /// Background color (Hintergrundfarbe)
        /// </summary>
        public Color? BackgroundColor { get; set; }

        /// <summary>
        /// Capacity (Kapazität)
        /// </summary>
        public uint? Capacity { get; set; }

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
        /// Short name (Name)
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Weight (Gewicht)
        /// </summary>
        public uint? Weight { get; set; }
    }
}
