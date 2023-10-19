#region ENBREA UNTIS.GPU - Copyright (C) 2023 STÜBER SYSTEMS GmbH
/*    Copyright (C) 2023 STÜBER SYSTEMS GmbH
 *    ENBREA UNTIS.GPU 
 *    
 *    Copyright (C) 2023 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using Enbrea.Csv;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// An abstract representation for Untis GPU???.txt file records.
    /// </summary>
    public abstract class GpuRecord
    {
        protected GpuAbsenceType? MapAbsenceTypeValue(string value)
        {
            return value switch
            {
                "L" => GpuAbsenceType.Teacher,
                "K" => GpuAbsenceType.Class,
                "R" => GpuAbsenceType.Room,
                _ => null
            };
        }

        protected Color? MapColorValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            else
            {
                return ColorTranslator.FromWin32(int.Parse(value));
            }
        }

        protected DateTime? MapDateTimeValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            else
            {
                return DateTime.ParseExact(value, "yyyyMMddHHmm", CultureInfo.InvariantCulture);
            }
        }

        protected DateOnly? MapDateValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            else
            {
                return DateOnly.ParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
        }

        protected DayOfWeek MapDayValue(string value)
        {
            return value switch
            {
                "1" => DayOfWeek.Monday,
                "2" => DayOfWeek.Tuesday,
                "3" => DayOfWeek.Wednesday,
                "4" => DayOfWeek.Thursday,
                "5" => DayOfWeek.Friday,
                "6" => DayOfWeek.Saturday,
                _ => DayOfWeek.Sunday
            };
        }

        protected TimeSpan? MapDurationValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            else
            {
                if (TimeSpan.TryParseExact(value, new string[] { "hh:mm", "mm" }, null, out var result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        protected GpuSubstitutionFlags MapGapTypeValue(string value)
        {
            return (GpuSubstitutionFlags)MapIntValue(value);
        }

        protected GpuGender? MapGenderValue(string value)
        {
            return value switch
            {
                "1" => GpuGender.Female,
                "2" => GpuGender.Male,
                "3" => GpuGender.Divers,
                _ => null
            };
        }

        protected int? MapIntValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            else
            {
                return int.Parse(value);
            }
        }

        protected GpuSubstitutionType? MapStandInTypeValue(string value)
        {
            return value switch
            {
                "T" => GpuSubstitutionType.ShiftedTo,
                "F" => GpuSubstitutionType.ShiftedFrom,
                "W" => GpuSubstitutionType.Exchange,
                "S" => GpuSubstitutionType.Supervision,
                "A" => GpuSubstitutionType.SpecialOccurrence,
                "C" => GpuSubstitutionType.Cancellation,
                "L" => GpuSubstitutionType.Exemption,
                "P" => GpuSubstitutionType.PartialExchange,
                "R" => GpuSubstitutionType.RoomExchange,
                "B" => GpuSubstitutionType.BreakSupervisionStandIn,
                "~" => GpuSubstitutionType.TeacherExchange,
                "E" => GpuSubstitutionType.Exam,
                _ => null
            };
        }

        protected List<string> MapStringListValue(string value, char separator)
        {
            var list = new List<string>();
            if (!string.IsNullOrEmpty(value))
            {
                var csvLineReader = new CsvLineParser(separator);
                csvLineReader.Parse(value, list);
            }
            return list;
        }

        protected List<uint> MapUIntListValue(string value, char separator)
        {
            return MapStringListValue(value, separator).Select(uint.Parse).ToList();
        }

        protected uint? MapUIntValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            else
            {
                return uint.Parse(value);
            }
        }
    }
}
