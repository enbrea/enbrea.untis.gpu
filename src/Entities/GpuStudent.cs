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
    /// Represents an entity within the Untis DIF file GPU010.TXT (Studenten)
    /// </summary>
    public class GpuStudent : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuStudent"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuStudent(List<string> values)
        {
            ShortName = values[0];
            LastName = values[1];
            Text = values[2];
            Description = values[3];
            StatisticalCode1 = values[4];
            StatisticalCode2 = values[5];
            Code = values[6];
            FirstName = values[7];
            StudentNo = values[8];
            Class = values[9];
            Gender = MapGenderValue(values[10]);
            Birthdate = MapDateValue(values[12]);
            Email = values[13];
            ForeignKey = values[14];
        }

        /// <summary>
        /// Birthdate (Geburtsdatum)
        /// </summary>
        public DateOnly? Birthdate { get; set; }

        /// <summary>
        /// Short name (Name)
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
        /// Email address (E-Mail-Adresse, ab Version 2012)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// First name (Vorname)
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Foreign key (Fremdschlüssel, ab Version 2012)
        /// </summary>
        public string ForeignKey { get; set; }

        /// <summary>
        /// Gender (Geschlecht)
        /// </summary>
        public GpuGender? Gender { get; set; }

        /// <summary>
        /// Long name (Langname)
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Statistical code (Statistik 1)
        /// </summary>
        public string StatisticalCode1 { get; set; }

        /// <summary>
        /// Statistical code (Statistik 2)
        /// </summary>
        public string StatisticalCode2 { get; set; }

        /// <summary>
        /// Student no (Schülernummer)
        /// </summary>
        public string StudentNo { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; }
    }
}
