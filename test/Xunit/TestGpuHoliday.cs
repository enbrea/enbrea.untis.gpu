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
    /// Unit tests for <see cref="GpuHoliday"/>.
    /// </summary>
    public class TestGpuHoliday
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLines =
                "\"Weihnachten\",\"Weihnachtsferien\",20091224,20100106," + Environment.NewLine +
                "\"Allerheiligen\",\"Allerheiligen\",20091101,20091101,\"F\"";

            using var csvReader = new CsvReader(textLines);
            csvReader.Configuration.Separator = ',';

            var gpuReader = new GpuReader<GpuHoliday>(csvReader);

            IAsyncEnumerator<GpuHoliday> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("Weihnachten", enumerator.Current.ShortName);
            Assert.Equal("Weihnachtsferien", enumerator.Current.LongName);
            Assert.Equal(new DateTime(2009, 12, 24), enumerator.Current.From);
            Assert.Equal(new DateTime(2010, 1, 6), enumerator.Current.To);
            Assert.False(enumerator.Current.PublicHoliday);

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("Allerheiligen", enumerator.Current.ShortName);
            Assert.Equal("Allerheiligen", enumerator.Current.LongName);
            Assert.Equal(new DateTime(2009, 11, 1), enumerator.Current.From);
            Assert.Equal(new DateTime(2009, 11, 1), enumerator.Current.To);
            Assert.True(enumerator.Current.PublicHoliday);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
