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

using System.Collections.Generic;

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// Represents an entity within the Untis DIF file GPU012.TXT (Absenzgründe)
    /// </summary>
    public class GpuAbsenceReason : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuAbsenceReason<T>"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuAbsenceReason(List<string> values)
        {
            ShortName = values[0];
            LongName = values[1];
            Code = values[2];
            StatisticalCode = values[3];
        }

        /// <summary>
        /// Code (Kennzeichen)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Long name (Langname)
        /// </summary>
        public string LongName { get; set; }

        /// <summary>
        /// Short name (Name)
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Statistical code (Statistikkennzeichen)
        /// </summary>
        public string StatisticalCode { get; set; }
    }
}
