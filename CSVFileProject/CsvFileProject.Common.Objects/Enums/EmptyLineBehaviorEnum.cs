﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileProject.Common.Objects.Enums
{
    /// <summary>
    /// Determines how empty lines are interpreted when reading CSV files.
    /// These values do not affect empty lines that occur within quoted fields
    /// or empty lines that appear at the end of the input file.
    /// </summary>
    public enum EmptyLineBehaviorEnum
    {
        /// <summary>
        /// Empty lines are interpreted as a line with zero columns.
        /// </summary>
        NoColumns,

        /// <summary>
        /// Empty lines are interpreted as a line with a single empty column.
        /// </summary>
        EmptyColumn,

        /// <summary>
        /// Empty lines are skipped over as though they did not exist.
        /// </summary>
        Ignore,

        /// <summary>
        /// An empty line is interpreted as the end of the input file.
        /// </summary>
        EndOfFile,
    }
}
