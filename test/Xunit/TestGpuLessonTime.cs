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

using Enbrea.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Untis.Gpu.Tests
{
    /// <summary>
    /// Unit tests for <see cref="GpuLessonTime"/>.
    /// </summary>
    public class TestGpuLessonTime
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLines =
                "3969,\"2.T1 + L\",\"SteIn\",\"RLK\",\"KL14\",3,4,," + Environment.NewLine +
                "1055,\"5AG\",\"LenPh\",\"F\",\"AWR -DirTr.\",1,1,,";

            using var strReader = new StringReader(textLines);

            var csvReader = new CsvReader(strReader, new CsvConfiguration { Separator = ',' });

            var gpuReader = new GpuReader<GpuLessonTime>(csvReader);

            IAsyncEnumerator<GpuLessonTime> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal((uint)3969, enumerator.Current.LessonId);
            Assert.Equal("2.T1 + L", enumerator.Current.Class);
            Assert.Equal("SteIn", enumerator.Current.Teacher);
            Assert.Equal("RLK", enumerator.Current.Subject);
            Assert.Equal("KL14", enumerator.Current.Room);
            Assert.Equal(DayOfWeek.Wednesday, enumerator.Current.Day);
            Assert.Equal((uint)4, enumerator.Current.TimeSlot);

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal((uint)1055, enumerator.Current.LessonId);
            Assert.Equal("5AG", enumerator.Current.Class);
            Assert.Equal("LenPh", enumerator.Current.Teacher);
            Assert.Equal("F", enumerator.Current.Subject);
            Assert.Equal("AWR -DirTr.", enumerator.Current.Room);
            Assert.Equal(DayOfWeek.Monday, enumerator.Current.Day);
            Assert.Equal((uint)1, enumerator.Current.TimeSlot);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
