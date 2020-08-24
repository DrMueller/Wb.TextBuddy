using System.Collections.Generic;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.TextBuddy.Areas.Markdown.Models.Tables
{
    public class ColumnDefinition
    {
        public ColumnDefinition(IReadOnlyCollection<string> headerValues)
        {
            Guard.CollectionNotNullOrEmpty(() => headerValues);

            HeaderValues = headerValues;
        }

        public IReadOnlyCollection<string> HeaderValues { get; }

        public void AppendMarkdownToString(StringBuilder sb)
        {
            HeaderValues.ForEach(
                str =>
                {
                    sb.Append("|");
                    sb.Append(str.Trim());
                });

            sb.AppendLine("|");

            HeaderValues.ForEach(
                str =>
                {
                    sb.Append("|");
                    sb.Append("--");
                });

            sb.AppendLine("|");
        }
    }
}