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
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Untis.Gpu.Tests
{
    /// <summary>
    /// Unit tests for <see cref="GpuDepartment"/>.
    /// </summary>
    public class TestGpuDepartment
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "\"Fachgruppe für Bodenleger\",,";

            using var strReader = new StringReader(textLine);

            var csvReader = new CsvReader(strReader, new CsvConfiguration { Separator = ',' });

            var gpuReader = new GpuReader<GpuDepartment>(csvReader);

            IAsyncEnumerator<GpuDepartment> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();
            
            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("Fachgruppe für Bodenleger", enumerator.Current.ShortName);
            Assert.Empty(enumerator.Current.LongName);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
