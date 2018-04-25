using CsvFileProject.Common.Objects.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileProject.Common.Services.Interfaces
{
    /// <summary>
    /// Common base class for CSV reader and writer classes.
    /// </summary>
    public interface ICsvFileReaderService
    {
        StreamReader Reader { get; set; }

        /// <summary>
        /// Reads a row of columns from the current CSV file. Returns false if no
        /// more data could be read because the end of the file was reached.
        /// </summary>
        /// <param name="columns">Collection to hold the columns read</param>
        bool ReadRow(List<string> columns);

        void Dispose();
    }
}
