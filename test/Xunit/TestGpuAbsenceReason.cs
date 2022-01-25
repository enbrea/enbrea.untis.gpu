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
    /// Unit tests for <see cref="GpuAbsenceReason"/>.
    /// </summary>
    public class TestGpuAbsenceReason
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "\"001\",\"Krankheit(400)\",\"Z\",\"K\"";

            using var csvReader = new CsvReader(textLine);
            csvReader.Configuration.Separator = ',';

            var gpuReader = new GpuReader<GpuAbsenceReason>(csvReader);

            IAsyncEnumerator<GpuAbsenceReason> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("001", enumerator.Current.ShortName);
            Assert.Equal("Krankheit(400)", enumerator.Current.LongName);
            Assert.Equal("Z", enumerator.Current.Code);
            Assert.Equal("K", enumerator.Current.StatisticalCode);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
