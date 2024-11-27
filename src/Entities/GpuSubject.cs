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

using System.Collections.Generic;
using System.Drawing;

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// Represents an entity within the Untis DIF file GPU006.TXT (Fächer)
    /// </summary>
    public class GpuSubject : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuSubject"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuSubject(List<string> values)
        {
            ShortName = values[0];
            LongName = values[1];
            Room = values[3];
            Group = values[12];
            Text = values[15];
            Description = values[16];
            ForegroundColor = MapColorValue(values[17]);
            BackgroundColor = MapColorValue(values[18]);
            Alias = values[20];
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
        /// Description (Beschreibung)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Foreground color (Vordergrundfarbe)
        /// </summary>
        public Color? ForegroundColor { get; set; }

        /// <summary>
        /// Subject group (Fachgruppe)
        /// </summary>
        public string Group { get; set; }

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
        /// Text (Text)
        /// </summary>
        public string Text { get; set; }
    }
}
