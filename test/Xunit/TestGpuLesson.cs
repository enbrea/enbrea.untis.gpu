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
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Untis.Gpu.Tests
{
    /// <summary>
    /// Unit tests for <see cref="GpuLesson"/>.
    /// </summary>
    public class TestGpuLesson
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "362,2,,2,,\"EinAl\",\"SA\",,,0,2.00000,,,,\"20080901\",\"20090704\",0.00800,,,,,,,\"In\",,,,,,,,,,0,0,,,,,200000,2.00000,,,,,0,";

            using var csvReader = new CsvReader(textLine);
            csvReader.Configuration.Separator = ',';

            var gpuReader = new GpuReader<GpuLesson>(csvReader);

            IAsyncEnumerator<GpuLesson> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal((uint)362, enumerator.Current.Id);
            Assert.Equal("EinAl", enumerator.Current.Teacher);
            Assert.Equal("SA", enumerator.Current.Subject);
            Assert.Equal(new DateTime(2008, 9, 1), enumerator.Current.ValidFrom.Value);
            Assert.Equal(new DateTime(2009, 7, 4), enumerator.Current.ValidTo.Value);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
