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

using Enbrea.Csv;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Untis.Gpu.Tests
{
    /// <summary>
    /// Unit tests for <see cref="GpuSupervision"/>.
    /// </summary>
    public class TestGpuSupervision
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "\"S1\",\"HauGe\",1,4,20,\"24~25~31~32~39~40\",";

            using var csvReader = new CsvReader(textLine);
            csvReader.Configuration.Separator = ',';

            var gpuReader = new GpuReader<GpuSupervision>(csvReader);

            IAsyncEnumerator<GpuSupervision> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("S1", enumerator.Current.Corridor);
            Assert.Equal("HauGe", enumerator.Current.Teacher);
            Assert.Equal(DayOfWeek.Monday, enumerator.Current.Day);
            Assert.Equal((uint)4, enumerator.Current.TimeSlot);
            Assert.Equal(TimeSpan.FromMinutes(20), enumerator.Current.Duration);
            Assert.Equal(6, enumerator.Current.Weeks.Count);
            Assert.Equal((uint)24, enumerator.Current.Weeks[0]);
            Assert.Equal((uint)25, enumerator.Current.Weeks[1]);
            Assert.Equal((uint)31, enumerator.Current.Weeks[2]);
            Assert.Equal((uint)32, enumerator.Current.Weeks[3]);
            Assert.Equal((uint)39, enumerator.Current.Weeks[4]);
            Assert.Equal((uint)40, enumerator.Current.Weeks[5]);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
