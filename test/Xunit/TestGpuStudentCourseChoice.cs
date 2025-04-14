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
    /// Unit tests for <see cref="GpuStudentCourseChoice"/>.
    /// </summary>
    public class TestGpuStudentCourseChoice
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "\"StuA\",298,\"D G1\",,\"EF\",\"S\",,,,\"298~327~312~324\",\"D G1~D  G2~D  G3~D  G4\",,\"1~1~1~1\",";

            using var strReader = new StringReader(textLine);

            var csvReader = new CsvReader(strReader, new CsvConfiguration { Separator = ',' });

            var gpuReader = new GpuReader<GpuStudentCourseChoice>(csvReader);

            IAsyncEnumerator<GpuStudentCourseChoice> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("StuA", enumerator.Current.StudentShortName);
            Assert.Equal((uint)298, enumerator.Current.LessonId);
            Assert.Equal("D G1", enumerator.Current.Subject);
            Assert.Equal("EF", enumerator.Current.Class);
            Assert.Equal("S", enumerator.Current.StatisticalCode);
            Assert.Equal((uint)298, enumerator.Current.AlternativeCourses[0].LessonId);
            Assert.Equal("D G1", enumerator.Current.AlternativeCourses[0].Subject);
            Assert.Equal((uint)1, enumerator.Current.AlternativeCourses[0].Priority);
            Assert.Equal((uint)327, enumerator.Current.AlternativeCourses[1].LessonId);
            Assert.Equal("D  G2", enumerator.Current.AlternativeCourses[1].Subject);
            Assert.Equal((uint)1, enumerator.Current.AlternativeCourses[1].Priority);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
