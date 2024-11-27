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
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Untis.Gpu.Tests
{
    /// <summary>
    /// Unit tests for <see cref="GpuStudent"/>.
    /// </summary>
    public class TestGpuStudent
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "\"AckeT\",\"Ackermann\",,,,,\"W\",\"Theresa\",\"10021\",\"12\",\"1\",,\"19911106\",\"AckeT@beispiel.de\",";

            using var strReader = new StringReader(textLine);

            var csvReader = new CsvReader(strReader, new CsvConfiguration { Separator = ',' });

            var gpuReader = new GpuReader<GpuStudent>(csvReader);

            IAsyncEnumerator<GpuStudent> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("AckeT", enumerator.Current.ShortName);
            Assert.Equal("Ackermann", enumerator.Current.LastName);
            Assert.Equal("W", enumerator.Current.Code);
            Assert.Equal("Theresa", enumerator.Current.FirstName);
            Assert.Equal("10021", enumerator.Current.StudentNo);
            Assert.Equal("12", enumerator.Current.Class);
            Assert.Equal(GpuGender.Female, enumerator.Current.Gender);
            Assert.Equal(new DateOnly(1991, 11, 6), enumerator.Current.Birthdate);
            Assert.Equal("AckeT@beispiel.de", enumerator.Current.Email);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
