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
    /// Unit tests for <see cref="GpuRoom"/>.
    /// </summary>
    public class TestGpuRoom
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "\"KL1\",\"Klasse 1\",\"KL4\",,,,,,,,,,,0,16777215,,," + Environment.NewLine +
                "\"TS 3\",\"Turnhalle groß neu\",\"TSBorg\",,,,4,100,\"1\",,,,,16777215,65793,,,";

            using var strReader = new StringReader(textLine);

            var csvReader = new CsvReader(strReader, new CsvConfiguration { Separator = ',' });

            var gpuReader = new GpuReader<GpuRoom>(csvReader);

            IAsyncEnumerator<GpuRoom> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("KL1", enumerator.Current.ShortName);

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("TS 3", enumerator.Current.ShortName);
            Assert.Equal("Turnhalle groß neu", enumerator.Current.LongName);
            Assert.Equal("TSBorg", enumerator.Current.AlternativeRoom);
            Assert.Equal((uint)4, enumerator.Current.Weight);
            Assert.Equal((uint)100, enumerator.Current.Capacity);
            Assert.Equal("1", enumerator.Current.Department);
            Assert.Equal(255, enumerator.Current.ForegroundColor.Value.R);
            Assert.Equal(255, enumerator.Current.ForegroundColor.Value.G);
            Assert.Equal(255, enumerator.Current.ForegroundColor.Value.B);
            Assert.Equal(1, enumerator.Current.BackgroundColor.Value.R);
            Assert.Equal(1, enumerator.Current.BackgroundColor.Value.G);
            Assert.Equal(1, enumerator.Current.BackgroundColor.Value.B);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
