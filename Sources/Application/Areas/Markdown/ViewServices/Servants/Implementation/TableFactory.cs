using System;
using System.Linq;
using Mmu.Wb.TextBuddy.Areas.Markdown.Models.Tables;

namespace Mmu.Wb.TextBuddy.Areas.Markdown.ViewServices.Servants.Implementation
{
    public class TableFactory : ITableFactory
    {
        public Table Parse(string markdown)
        {
            var rows = markdown.Split(Environment.NewLine).ToList();
            var heading = rows.ElementAt(0);
            rows.RemoveAt(1);
            rows.RemoveAt(0);

            var headings = heading.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

            var columnDefinition = new ColumnDefinition(headings);

            var valueRows = rows.Select(
                row =>
                {
                    var cells = row.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

                    return new Row(cells);
                }).ToList();

            return new Table(columnDefinition, valueRows);
        }
    }
}