#region ENBREA UNTIS.GPU - Copyright (C) 2023 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA UNTIS.GPU
 *    
 *    Copyright (C) 2023 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using Enbrea.Csv;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Untis.Gpu.Tests
{
    /// <summary>
    /// Unit tests for <see cref="GpuLessonTable"/>.
    /// </summary>
    public class TestGpuLessonTable
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "\"1.M\",\"1. Maler\",\"PB\",\"3\",\"3\"";

            using var strReader = new StringReader(textLine);

            var csvReader = new CsvReader(strReader, new CsvConfiguration { Separator = ',' });

            var gpuReader = new GpuReader<GpuLessonTable>(csvReader);

            IAsyncEnumerator<GpuLessonTable> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("1.M", enumerator.Current.Name);
            Assert.Equal("1. Maler", enumerator.Current.LongName);
            Assert.Equal("PB", enumerator.Current.Subject);
            Assert.Equal((uint)3, enumerator.Current.MinTimeSlots.Value);
            Assert.Equal((uint)3, enumerator.Current.MaxTimeSlots.Value);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
