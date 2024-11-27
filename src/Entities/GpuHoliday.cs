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
    /// Represents an entity within the Untis DIF file GPU018.TXT (Ferien)
    /// </summary>
    public class GpuHoliday : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuHoliday"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuHoliday(List<string> values)
        {
            ShortName = values[0];
            LongName = values[1];
            From = MapDateValue(values[2]).Value;
            To = MapDateValue(values[3]).Value;
            PublicHoliday = values[4] == "F";
        }

        /// <summary>
        /// From date (Datum von)
        /// </summary>
        public DateOnly From { get; set; }

        /// <summary>
        /// Long name (Langname der Ferien)
        /// </summary>
        public string LongName { get; set; }

        /// <summary>
        /// Public Holiday (Feiertag)
        /// </summary>
        public bool PublicHoliday { get; set; }

        /// <summary>
        /// Name (Name der Ferien)
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// To date (Datum bis)
        /// </summary>
        public DateOnly To { get; set; }
   }
}
