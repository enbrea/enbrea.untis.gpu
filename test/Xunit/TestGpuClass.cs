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
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Untis.Gpu.Tests
{
    /// <summary>
    /// Unit tests for <see cref="GpuClass"/>.
    /// </summary>
    public class TestGpuClass
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "\"3.G1\",\"3.Gebäudereiniger1\",,\"KL4\",,,,,,,,,,,,,0,0,,\"20080901\",\"20081004\",,,,,,,1.00000,,,,0,";

            using var strReader = new StringReader(textLine);

            var csvReader = new CsvReader(strReader, new CsvConfiguration { Separator = ',' });

            var gpuReader = new GpuReader<GpuClass>(csvReader);

            IAsyncEnumerator<GpuClass> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("3.G1", enumerator.Current.ShortName);
            Assert.Equal("3.Gebäudereiniger1", enumerator.Current.LongName);
            Assert.Equal("KL4", enumerator.Current.Room);
            Assert.Equal(new DateOnly(2008, 9, 1), enumerator.Current.ValidFrom.Value);
            Assert.Equal(new DateOnly(2008, 10, 4), enumerator.Current.ValidTo.Value);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
