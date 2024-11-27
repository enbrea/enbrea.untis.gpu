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

namespace Enbrea.Untis.Gpu
{
    /// <summary>
    /// A reader for Untis GPU???.txt files.
    /// </summary>
    public class GpuReader<TRecord> where TRecord : GpuRecord
    {
        private readonly CsvReader _csvReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="GpuReader<T>"/> class.
        /// </summary>
        /// <param name="csvReader">A CSV Reader</param>
        public GpuReader(CsvReader csvReader)
        {
            _csvReader = csvReader;
        }

        /// <summary>
        /// Iterates over the internal CSV stream.
        /// </summary>
        /// <returns>An enumerator of <see cref="GpuRecord"/> based instances</returns>
        public IEnumerable<TRecord> Read()
        {
            var csvValues = new List<string>();

            while (_csvReader.ReadLine(csvValues) > 0)
            {
                if (csvValues.Count > 1)
                {
                    yield return (TRecord)Activator.CreateInstance(typeof(TRecord), csvValues);
                }
            }
        }

        /// <summary>
        /// Iterates over the internal CSV stream.
        /// </summary>
        /// <returns>An async enumerator of <see cref="GpuRecord"/> based instances</returns>
        public async IAsyncEnumerable<TRecord> ReadAsync()
        {
            var csvValues = new List<string>();

            while (await _csvReader.ReadLineAsync(csvValues) > 0)
            {
                if (csvValues.Count > 1)
                {
                    yield return (TRecord)Activator.CreateInstance(typeof(TRecord), csvValues);
                }
            }
        }
    }
}
