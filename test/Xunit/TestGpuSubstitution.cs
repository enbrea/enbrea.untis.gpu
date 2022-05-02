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

using Enbrea.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Untis.Gpu.Tests
{
    /// <summary>
    /// Unit tests for <see cref="GpuSubstitution"/>.
    /// </summary>
    public class TestGpuSubstitution
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLines =
                "12,\"20190807\",2,3,124,\"Stü\",\"Zim\",\"Ma\",,,,\"R233\",\"R232\",,\"8a\",\"Krank\",,2,\"8a\", S,201906191028,\" - \"" + Environment.NewLine +
                "13,\"20190807\",3,3,269,\"Bol\",\"Kal\",\"De\",,,,\"R103\",\"R103\",,\"8b\",\"Krank\",,0,\"8b\",,201908011452,\" + ~-\"" + Environment.NewLine +
                "14,\"20190807\",1,,3922,\"Stü\",\"Kal\",\"En\",,,,\"SH\",\"KL6\",,\"2. M1~2. M1+S~2. M2\",,\"Urlaub\",2,\"2. M1~2. M1+S~2. M2\", S,201908011452,\" -\"";

            using var strReader = new StringReader(textLines);

            var csvReader = new CsvReader(strReader, new CsvConfiguration { Separator = ',' });

            var gpuReader = new GpuReader<GpuSubstitution>(csvReader);

            IAsyncEnumerator<GpuSubstitution> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal((uint)12, enumerator.Current.Id);
            Assert.Equal(new DateOnly(2019, 8, 7), enumerator.Current.Date);
            Assert.Equal((uint)2, enumerator.Current.TimeSlot);
            Assert.Equal((uint)124, enumerator.Current.LessonId);
            Assert.Equal("Ma", enumerator.Current.Subject);
            Assert.Equal("Stü", enumerator.Current.AbsentTeacher);
            Assert.Equal("Zim", enumerator.Current.StandInTeacher);
            Assert.Equal("R233", enumerator.Current.Rooms[0]);
            Assert.Equal("R232", enumerator.Current.StandInRooms[0]);
            Assert.Equal("8a", enumerator.Current.SchoolClasses[0]);
            Assert.Equal("8a", enumerator.Current.StandInSchoolClasses[0]);
            Assert.Equal("Krank", enumerator.Current.AbsenceReason);
            Assert.Equal(GpuSubstitutionFlags.SpecialDuty, enumerator.Current.Flags);
            Assert.Null(enumerator.Current.Type);
            Assert.Equal(new DateTime(2019, 6, 19, 10, 28, 0), enumerator.Current.LastChange.Value);

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal((uint)13, enumerator.Current.Id);
            Assert.Equal(new DateOnly(2019, 8, 7), enumerator.Current.Date);
            Assert.Equal((uint)3, enumerator.Current.TimeSlot);
            Assert.Equal((uint)269, enumerator.Current.LessonId);
            Assert.Equal("De", enumerator.Current.Subject);
            Assert.Equal("Bol", enumerator.Current.AbsentTeacher);
            Assert.Equal("Kal", enumerator.Current.StandInTeacher);
            Assert.Equal("R103", enumerator.Current.Rooms[0]);
            Assert.Equal("R103", enumerator.Current.StandInRooms[0]);
            Assert.Equal("8b", enumerator.Current.SchoolClasses[0]);
            Assert.Equal("8b", enumerator.Current.StandInSchoolClasses[0]);
            Assert.Equal("Krank", enumerator.Current.AbsenceReason);
            Assert.Equal(GpuSubstitutionFlags.Cancellation, enumerator.Current.Flags);
            Assert.Null(enumerator.Current.Type);
            Assert.Equal(new DateTime(2019, 8, 01, 14, 52, 0), enumerator.Current.LastChange.Value);

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal((uint)14, enumerator.Current.Id);
            Assert.Equal(new DateOnly(2019, 8, 7), enumerator.Current.Date);
            Assert.Equal((uint)1, enumerator.Current.TimeSlot);
            Assert.Equal((uint)3922, enumerator.Current.LessonId);
            Assert.Equal("En", enumerator.Current.Subject);
            Assert.Equal("Stü", enumerator.Current.AbsentTeacher);
            Assert.Equal("Kal", enumerator.Current.StandInTeacher);
            Assert.Equal("SH", enumerator.Current.Rooms[0]);
            Assert.Equal("KL6", enumerator.Current.StandInRooms[0]);
            Assert.Equal("2. M1", enumerator.Current.SchoolClasses[0]);
            Assert.Equal("2. M1", enumerator.Current.StandInSchoolClasses[0]);
            Assert.Equal("2. M1+S", enumerator.Current.StandInSchoolClasses[1]);
            Assert.Equal("2. M2", enumerator.Current.StandInSchoolClasses[2]);
            Assert.Equal("Urlaub", enumerator.Current.Remark);
            Assert.Equal(GpuSubstitutionFlags.SpecialDuty, enumerator.Current.Flags);
            Assert.Null(enumerator.Current.Type);
            Assert.Equal(new DateTime(2019, 8, 01, 14, 52, 0), enumerator.Current.LastChange.Value);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
