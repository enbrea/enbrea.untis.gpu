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
    /// Unit tests for <see cref="GpuExam"/>.
    /// </summary>
    public class TestGpuExam
    {
        [Fact]
        public async Task TestFilledLine()
        {
            var textLine =
                "\"121\",30,\"L\",20090929,3,4,\"E  L2~E  L4~F  L1~M  L1~B  L2~B  L4\",\"2676~2678~2680~2682~2684~2686\"," +
                "\"ÖnüA~QuiJ~RitT~SchA1~SieC~SzaA~TalC~AltH~BraN~KinC~HeinM~GibK~SchüT~MeyK~BadJ~BodeL~HerJ~JäcJ~ElS~NolF~PöhlC~RamJ~SchäM~SchJ1~SchJ2~SchwK~SpoC~WitF~ApfJ~FeiF~KleL~HelbS~GrüM~KaiN~KeßF~DesD~HermM~BecS~BecT~HagM~GerJ~PhilA~RadS~SchK~SejA~SimL~AltS~BodeF~KläJ~MicM~LeicS~MatK~JekS~MetK~BeckS~DegC~BerC~DecL~KuhnJ~StöN~WerL~HöhN~OldD~RogJ~SchnF~SchuC~WebL~WenM~WeyY~WieJ~AdlD~KorC~FriC~ChaR~MetE~HerL~RotT~BötL~MetM~HerD~PauD~LöfY~HehD~PanJ~PörtJ~SchC~SchrC~ThoT~UweF~WeiL~AydP~KohnA~JanS~LohL~BalM~BirA~StrJ~BroD~HahT~GörN~PavM~RotD~SchC2~SchF1~StoA~VriK~WeiD~WörJ~KutA~BreA~KerO~BagN~MettM~AuhB\"," +
                "\"BölHe - BölHe~Da Le\",\"- R 6f\"";

            using var strReader = new StringReader(textLine);

            var csvReader = new CsvReader(strReader, new CsvConfiguration { Separator = ',' });

            var gpuReader = new GpuReader<GpuExam>(csvReader);

            IAsyncEnumerator<GpuExam> enumerator = gpuReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal("121", enumerator.Current.Name);
            Assert.Equal((uint)30, enumerator.Current.Id);
            Assert.Equal("L", enumerator.Current.Text);
            Assert.Equal(new DateOnly(2009, 9, 29), enumerator.Current.Date.Value);
            Assert.Equal((uint)3, enumerator.Current.StartTimeSlot.Value);
            Assert.Equal((uint)4, enumerator.Current.EndTimeSlot.Value);
            Assert.Equal("E  L2", enumerator.Current.Subjects[0]);
            Assert.Equal("E  L4", enumerator.Current.Subjects[1]);
            Assert.Equal("F  L1", enumerator.Current.Subjects[2]);
            Assert.Equal("M  L1", enumerator.Current.Subjects[3]);
            Assert.Equal("B  L2", enumerator.Current.Subjects[4]);
            Assert.Equal("B  L4", enumerator.Current.Subjects[5]);
            Assert.Equal((uint)2676, enumerator.Current.Lessons[0]);
            Assert.Equal((uint)2678, enumerator.Current.Lessons[1]);
            Assert.Equal((uint)2680, enumerator.Current.Lessons[2]);
            Assert.Equal((uint)2682, enumerator.Current.Lessons[3]);
            Assert.Equal((uint)2684, enumerator.Current.Lessons[4]);
            Assert.Equal((uint)2686, enumerator.Current.Lessons[5]);
            Assert.Equal("ÖnüA", enumerator.Current.Students[0]);
            Assert.Equal("QuiJ", enumerator.Current.Students[1]);
            Assert.Equal("RitT", enumerator.Current.Students[2]);
            Assert.Equal("BölHe", enumerator.Current.Teachers[0][0]);
            Assert.Equal("BölHe", enumerator.Current.Teachers[1][0]);
            Assert.Equal("Da Le", enumerator.Current.Teachers[1][1]);
            Assert.Empty(enumerator.Current.Rooms[0]);
            Assert.Equal("R 6f", enumerator.Current.Rooms[1][0]);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}
