#region ENBREA UNTIS.GPU - Copyright (C) 2021 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA UNTIS.GPU
 *    
 *    Copyright (C) 2021 STÜBER SYSTEMS GmbH
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
    /// Unit tests for <see cref="GpuTeacher"/>.
    /// </summary>
    public class TestGpuTeacher
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "\"BraFe\",\"Braun\",\"5\",,,\"mn\",,,10,,3,,,,23.000,6.86570,\"Fachgruppe Maler\",\"1000\",,,\"1p\",,,,,,,\"1.00000\",\"Ferdinand\",,\"2\",,,0,,,,,,,,,,,";

            using var csvReader = new CsvReader(textLine);
            csvReader.Configuration.Separator = ',';

            var gpuReader = new GpuReader<GpuTeacher>(csvReader);

            IAsyncEnumerator<GpuTeacher> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("BraFe", enumerator.Current.ShortName);
            Assert.Equal("Braun", enumerator.Current.LastName);
            Assert.Equal("Fachgruppe Maler", enumerator.Current.Department1);
            Assert.Equal("Ferdinand", enumerator.Current.FirstName);
            Assert.Equal(GpuGender.Male, enumerator.Current.Gender);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
