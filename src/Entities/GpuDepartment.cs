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
    /// Represents an entity within the Untis DIF file GPU007.TXT (Abteilungen)
    /// </summary>
    public class GpuDepartment : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuDepartment<T>"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuDepartment(List<string> values)
        {
            ShortName = values[0];
            LongName = values[1];
        }

        /// <summary>
        /// Long name (Langname)
        /// </summary>
        public string LongName { get; set; }

        /// <summary>
        /// Short name (Name)
        /// </summary>
        public string ShortName { get; set; }
    }
}
