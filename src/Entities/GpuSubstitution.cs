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

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// Represents an entity within the Untis DIF file GPU014.TXT (Vertretungen)
    /// </summary>
    public class GpuSubstitution : GpuRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpuSubstitution<T>"/> class.
        /// </summary>
        /// <param name="values">List of raw values</param>
        public GpuSubstitution(List<string> values)
        {
            Id = MapUIntValue(values[0]).Value;
            Date = MapDateValue(values[1]).Value;
            TimeSlot = MapUIntValue(values[2]).Value;
            AbsenceId = MapUIntValue(values[3]);
            LessonId = MapUIntValue(values[4]).Value;
            AbsentTeacher = values[5];
            StandInTeacher = values[6];
            Subject = values[7];
            SubjectFlag = values[8];
            StandInSubject = values[9];
            StandInSubjectFlag = values[10];
            Room = values[11];
            StandInRoom = values[12];
            SchoolClasses = MapStringListValue(values[14], '~');
            AbsenceReason = values[15];
            Remark = values[16];
            Flags = MapGapTypeValue(values[17]);
            StandInSchoolClasses = MapStringListValue(values[18], '~');
            Type = MapStandInTypeValue(values[19]);
            LastChange = MapDateTimeValue(values[20]);
        }

        /// <summary>
        /// Absence id (Absenznummer)
        /// </summary>
        public uint? AbsenceId { get; set; }

        /// <summary>
        /// Absence reason (Absenzgrund)
        /// </summary>
        public string AbsenceReason { get; set; }

        /// <summary>
        /// Absent teacher (Abwesender Lehrer)
        /// </summary>
        public string AbsentTeacher { get; set; }

        /// <summary>
        /// Date (Datum)
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Flags (Art)
        /// </summary>
        public GpuSubstitutionFlags Flags { get; set; }

        /// <summary>
        /// Id (Vertretungsnummer)
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Last change (Zeit der letzten Änderung)
        /// </summary>
        public DateTime? LastChange { get; set; }

        /// <summary>
        /// Lesson id (Unterrichtsnummer)
        /// </summary>
        public uint LessonId { get; set; }
        /// <summary>
        /// Remark (Text zur Vertretung)
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Room (Raum)
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// List of school classes (Klasse(n) mit ~ getrennt)
        /// </summary>
        public List<string> SchoolClasses { get; set; }

        /// <summary>
        /// Stand-In room (Vertretungsraum)
        /// </summary>
        public string StandInRoom { get; set; }

        /// <summary>
        /// List of stand-in school classes (Vertretungsklasse(n) mit ~ getrennt)
        /// </summary>
        public List<string> StandInSchoolClasses { get; set; }

        /// <summary>
        /// Stand.in subject (Vertretungsfach)
        /// </summary>
        public string StandInSubject { get; set; }

        /// <summary>
        /// Stand.in subject flag (Statistikkennzeichen des Vertretungsfachs)
        /// </summary>
        public string StandInSubjectFlag { get; set; }

        /// <summary>
        /// Stand-in teacher (Vertretender Lehrer)
        /// </summary>
        public string StandInTeacher { get; set; }

        /// <summary>
        /// Subject (Fach)
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Subject flag (Statistikkennzeichen des Fachs)
        /// </summary>
        public string SubjectFlag { get; set; }

        /// <summary>
        /// Time slot (Unterrichtsstunde)
        /// </summary>
        public uint TimeSlot { get; set; }
        /// <summary>
        /// Substitution type (Vertretungsart)
        /// </summary>
        public GpuSubstitutionType? Type { get; set; }
    }
}
