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

using Enbrea.Csv;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Untis.Gpu.Tests
{
    /// <summary>
    /// Unit tests for <see cref="GpuAbsence"/>.
    /// </summary>
    public class TestGpuAbsence
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "9,\"L\",\"SchFr\",\"20080908\",\"20080908\",\"1\",\"13\",\"011\",\"Seminar\",";

            using var csvReader = new CsvReader(textLine);
            csvReader.Configuration.Separator = ',';

            var gpuReader = new GpuReader<GpuAbsence>(csvReader);

            IAsyncEnumerator<GpuAbsence> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal((uint)9, enumerator.Current.Id);
            Assert.Equal(GpuAbsenceType.Teacher, enumerator.Current.Type.Value);
            Assert.Equal("SchFr", enumerator.Current.ShortName);
            Assert.Equal(new DateTime(2008, 9, 8), enumerator.Current.StartDate.Value);
            Assert.Equal(new DateTime(2008, 9, 8), enumerator.Current.EndDate.Value);
            Assert.Equal((uint)1, enumerator.Current.FirstTimeSlot.Value);
            Assert.Equal((uint)13, enumerator.Current.LastTimeSlot.Value);
            Assert.Equal("011", enumerator.Current.Reason);
            Assert.Equal("Seminar", enumerator.Current.Text);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
