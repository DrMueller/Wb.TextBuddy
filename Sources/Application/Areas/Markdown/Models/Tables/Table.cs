using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.TextBuddy.Areas.Markdown.Models.Tables
{
    public class Table
    {
        public Table(IReadOnlyCollection<ColumnDefinition> columnDefinitions, IReadOnlyCollection<Row> rows)
        {
            Guard.ObjectNotNull(() => columnDefinitions);
            Guard.ObjectNotNull(() => rows);
            Guard.That(() => columnDefinitions.Count == rows.Count, "Different amount of column definitions and rows found.");

            ColumnDefinitions = columnDefinitions;
            Rows = rows;
        }

        public IReadOnlyCollection<ColumnDefinition> ColumnDefinitions { get; }
        public IReadOnlyCollection<Row> Rows { get; }
    }
}