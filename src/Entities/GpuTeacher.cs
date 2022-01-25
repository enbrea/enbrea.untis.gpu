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

using System.Collections.Generic;
using System.Drawing;

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// Represents an entity within the Untis DIF file GPU004.TXT (Lehrer)
    /// </summary>
    public class GpuTeacher : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuTeacher"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuTeacher(List<string> values)
        {
            ShortName = values[0];
            LastName = values[1];
            Department1 = values[16];
            Department2 = values[18];
            Department3 = values[19];
            Description = values[23];
            FirstName = values[28];
            Gender = MapGenderValue(values[30]);
            ForegroundColor = MapColorValue(values[24]);
            BackgroundColor = MapColorValue(values[25]);
            Email = values[32];
            Alias = values[35];
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
        /// Department 1 (Abteilung 1)
        /// </summary>
        public string Department1 { get; set; }

        /// <summary>
        /// Department 2 (Abteilung 2)
        /// </summary>
        public string Department2 { get; set; }

        /// <summary>
        /// Department 3 (Abteilung 3)
        /// </summary>
        public string Department3 { get; set; }

        /// <summary>
        /// Description (Beschreibung)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Email address (E-Mail-Adresse)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// First name (Vorname)
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Foreground color (Vordergrundfarbe)
        /// </summary>
        public Color? ForegroundColor { get; set; }

        /// <summary>
        /// Gender (Geschlecht)
        /// </summary>
        public GpuGender? Gender { get; set; }

        /// <summary>
        /// Long name (Langname)
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Short name (Name)
        /// </summary>
        public string ShortName { get; set; }
    }
}
