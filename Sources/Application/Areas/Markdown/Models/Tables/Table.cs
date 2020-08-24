using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.TextBuddy.Areas.Markdown.Models.Tables
{
    public class Table
    {
        private readonly ColumnDefinition _columnDefinition;
        private readonly IReadOnlyCollection<Row> _rows;

        public Table(ColumnDefinition columnDefinition, IReadOnlyCollection<Row> rows)
        {
            Guard.ObjectNotNull(() => columnDefinition);
            Guard.CollectionNotNullOrEmpty(() => rows);

            var columnsCount = columnDefinition.HeaderValues.Count;
            Guard.That(() => rows.All(row => row.Values.Count == columnsCount), "Different amount of column definitions and rows found.");

            _columnDefinition = columnDefinition;
            _rows = rows;
        }

        public string ToMarkdown()
        {
            var sb = new StringBuilder();

            _columnDefinition.AppendMarkdownToString(sb);
            _rows.ForEach(row => row.AppendMarkdownToString(sb));

            return sb.ToString();
        }
    }
}