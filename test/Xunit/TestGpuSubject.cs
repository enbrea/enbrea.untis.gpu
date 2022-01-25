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
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Untis.Gpu.Tests
{
    /// <summary>
    /// Unit tests for <see cref="GpuSubject"/>.
    /// </summary>
    public class TestGpuSubject
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "\"BIUK\",\"BIOLOGIE UND UMWELTKUNDE\",,\"BIU - S1\",,,2,3,,,,,\"BIU\",\"L3\",1.05000,,,65535,8388608,,,,";

            using var csvReader = new CsvReader(textLine);
            csvReader.Configuration.Separator = ',';

            var gpuReader = new GpuReader<GpuSubject>(csvReader);

            IAsyncEnumerator<GpuSubject> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("BIUK", enumerator.Current.ShortName);
            Assert.Equal("BIOLOGIE UND UMWELTKUNDE", enumerator.Current.LongName);
            Assert.Equal("BIU - S1", enumerator.Current.Room);
            Assert.Equal("BIU", enumerator.Current.Group);
            Assert.Equal(255, enumerator.Current.ForegroundColor.Value.R);
            Assert.Equal(255, enumerator.Current.ForegroundColor.Value.G);
            Assert.Equal(0, enumerator.Current.ForegroundColor.Value.B);
            Assert.Equal(0, enumerator.Current.BackgroundColor.Value.R);
            Assert.Equal(0, enumerator.Current.BackgroundColor.Value.G);
            Assert.Equal(128, enumerator.Current.BackgroundColor.Value.B);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
