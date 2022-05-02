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
    /// Unit tests for <see cref="GpuReader<T>"/>.
    /// </summary>
    public class TestGpuReader
    {
        [Fact]
        public async Task TestEmptyLine()
        {
            var textLine = "";

            using var strReader = new StringReader(textLine);

            var csvReader = new CsvReader(strReader, new CsvConfiguration { Separator = ',' });

            var gpuReader = new GpuReader<GpuStudent>(csvReader);

            IAsyncEnumerator<GpuStudent> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();
            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
