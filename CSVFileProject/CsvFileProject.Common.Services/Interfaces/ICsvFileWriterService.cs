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
    public interface ICsvFileWriterService
    {
        StreamWriter Writer { get; set; }

        /// <summary>
        /// Writes a row of columns to the current CSV file.
        /// </summary>
        /// <param name="columns">The list of columns to write</param>
        void WriteRow(List<string> columns);

        void Dispose();
    }
}
